using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace BLL
{
    public class BLL_Usuario
    {
        DAL_Usuario dal_usuario = new DAL_Usuario();
        BLL_Bitacora bll_bitacora = new BLL_Bitacora();
        BLL_DVV bll_dvv = new BLL_DVV();
        DAL_DVV dal_dvv = new DAL_DVV();
        //Obtenemos el objeto usuario con el mail 
        public BE_LoginResultado ObtenerUsuarioPorEmail(string Email, string Password)
        {
           Password = HashHelper.GenerarHash(Password);

            //Obtenemos el objeto Usuario con el mail
            BE_Usuario Usuario = dal_usuario.ObtenerUsuarioPorEmail(Email);

            //Validamos si el usuario existe
            if (Usuario == null)
            {
                //No existe el usuario. Entonces mandamos a bitacora el intento de login con ese email.
                bll_bitacora.RegistrarEvento(null, AccionBitacora.LOGIN_INTENTO, "LOGIN", $"Intento de Login usando el email: {Email}");

                return new BE_LoginResultado { ExitoLogin = false,  Mensaje = "Usuario o Contraseña Incorrecto" };
            }

            //Si no esta activo
            if (!Usuario.Activo)
            {
                //Existe el usuario pero no esta activo. Entonces mandamos a Bitacora el intento de login. 
                bll_bitacora.RegistrarEvento(Usuario.IdUsuario, AccionBitacora.LOGIN_INTENTO, "LOGIN", $"Intento de sesion del usuario bloqueado: {Usuario.Nombre}, con IdUsuario = {Usuario.IdUsuario}");

                return new BE_LoginResultado {ExitoLogin = false, Mensaje = "Usuario bloqueado. Contactese con el Administrador" };
            }

            //Si la contraseña es incorrecta, incrementamos el contador de IntentosFallidos y bloqueamos el usuario si supera los 3 intentos. 
            if (Usuario.HashPassword != Password)
            {
                Usuario.IntentosFallidos++;

                if (Usuario.IntentosFallidos > 3)
                {
                    CalcularDVH(Usuario);

                    dal_usuario.BloquearUsuario(Usuario.IdUsuario, Usuario.DVH);
                    
                    //Recalculamos el DVV
                    bll_dvv.ActualizarDVV("Usuario");


                    //Mandamos a bitacora que se bloquea el usuario por superar intentos fallidos.

                    bll_bitacora.RegistrarEvento(Usuario.IdUsuario, AccionBitacora.LOGIN_BLOQUEADO, "LOGIN", $"Se bloquea al usuario: {Usuario.Nombre}, ID: {Usuario.IdUsuario}, por superar la cantidad de intentos permitidos");

                    return new BE_LoginResultado {ExitoLogin = false, Mensaje = "Usuario Bloqueado. Contacte Administrador" };
                }
                else
                {
                    CalcularDVH(Usuario);

                    dal_usuario.ActualizarIntentosFallidos(Usuario.IntentosFallidos, Usuario.IdUsuario, Usuario.DVH);

                    //Recalculamos el DVV
                    bll_dvv.ActualizarDVV("Usuario");

                    //Mandamos a bitacora el intento de login por contraseña incorrecta

                    bll_bitacora.RegistrarEvento(Usuario.IdUsuario, AccionBitacora.LOGIN_INCORRECTO, "LOGIN", $"Intento de inicio de sesion con el usuario: {Usuario.Nombre}, ID: {Usuario.IdUsuario} con contraseña incorrecta");

                    

                    return new BE_LoginResultado {ExitoLogin = false, Mensaje = $"Contraseña Incorrecta. Intentos fallidos: {Usuario.IntentosFallidos}" };
                }

            }
            //Si el login es exitoso, reseteamos los intentos fallidos a 0
             else
             {
                CalcularDVH(Usuario);

                dal_usuario.ActualizarIntentosFallidos(0, Usuario.IdUsuario, Usuario.DVH);

                //Recalculamos el DVV
                bll_dvv.ActualizarDVV("Usuario");

                //Mandamos a bitacora el login exitoso

                bll_bitacora.RegistrarEvento(Usuario.IdUsuario, AccionBitacora.LOGIN_OK, "LOGIN", $"Login correcto del usuario: {Usuario.Nombre}, ID: {Usuario.IdUsuario}");

                return new BE_LoginResultado { ExitoLogin = true, Usuario = Usuario, Mensaje = "Login exitoso" };
             }
        }

        public List<BE_Usuario> ListaUsuarios()
        {
            return dal_usuario.ListaUsuario();
        }

        public void AgregarUsuario(BE_Usuario usuario)
        {
            
            usuario.HashPassword = HashHelper.GenerarHash(usuario.HashPassword);

            //Generamos el DVH
            CalcularDVH(usuario);

            dal_usuario.AgregarUsuario(usuario);

            //Recalculamos el DVV
            bll_dvv.ActualizarDVV("Usuario");

            //Mandamos a bitacora la creacion del nuevo usuario

            bll_bitacora.RegistrarEvento(Sesion.Instancia().UsuarioActual.IdUsuario, AccionBitacora.USUARIO_ALTA, "USUARIO", $"Se crea un nuevo usuario: {usuario.Nombre}, {usuario.Apellido}, creado por {Sesion.Instancia().UsuarioActual.Nombre}");

        }

        public void ModificarUsuario(BE_Usuario usuario)
        {
            usuario.HashPassword = HashHelper.GenerarHash(usuario.HashPassword);

            CalcularDVH(usuario);

            dal_usuario.ModificarUsuario(usuario);

            //Recalculamos el DVV
            bll_dvv.ActualizarDVV("Usuario");

            //Mandamos a bitacora la modificacion del usuario

            bll_bitacora.RegistrarEvento(Sesion.Instancia().UsuarioActual.IdUsuario, AccionBitacora.USUARIO_MODIFICACION, "USUARIO", $"Se modifica al usuario: {usuario.Nombre}, ID: {usuario.IdUsuario}. Modificado por: {Sesion.Instancia().UsuarioActual.Nombre}");
        }

        public void EliminarUsuario(int id)
        {
            dal_usuario.EliminarUsuario(id);

            //Recalculamos el DVV
            bll_dvv.ActualizarDVV("Usuario");

            //Mandamos a bitacora la eliminacion del usuario
            bll_bitacora.RegistrarEvento(Sesion.Instancia().UsuarioActual.IdUsuario, AccionBitacora.USUARIO_BAJA, "USUARIO", $"El Usuario {Sesion.Instancia().UsuarioActual.Nombre}, da de baja al Usuario con ID: {id}");
        }

      
        public void CalcularDVH(BE_Usuario usuario)
        {
            string activo = usuario.Activo ? "1" : "0";

            string DVH = $"{usuario.Nombre}|{usuario.Apellido}|{usuario.Email}|{usuario.HashPassword}|{usuario.IntentosFallidos}|{activo}";

            usuario.DVH = HashHelper.GenerarHash(DVH);
        }

        public List<BE_RegistrosCorruptos> VerificarUsuarios()
        {
            List<BE_RegistrosCorruptos> ListaCorruptos = new List<BE_RegistrosCorruptos>();

            //Traemos toda la lista de Usuarios
            List<BE_Usuario> ListaUsuarios = dal_usuario.ListaUsuario();

            //Recalculamos el DVH uno por uno

            foreach (var usuario in ListaUsuarios)
            {
                string dvhRecalculado = HashHelper.GenerarHash($"{usuario.Nombre}|{usuario.Apellido}|{usuario.Email}|{usuario.HashPassword}|{usuario.IntentosFallidos}|{usuario.Activo}");

                if (usuario.DVH != dvhRecalculado)
                {
                    ListaCorruptos.Add(new BE_RegistrosCorruptos
                    {
                        IdUsuario = usuario.IdUsuario,
                        DVH_Almacenado = usuario.DVH,
                        DVH_Recalculado = dvhRecalculado
                    });
                }
            }
            return ListaCorruptos;
        }
    }
}

