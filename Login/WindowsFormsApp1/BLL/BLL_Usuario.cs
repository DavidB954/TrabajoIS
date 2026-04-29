using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Usuario
    {
        DAL_Usuario dal_usu = new DAL_Usuario();
        public void AgregarUsuario(BE_Usuario usuario)
        {
            //Encriptamos la contrasena

            usuario.HashPassword = HashHelper.GenerarHash(usuario.HashPassword);

            dal_usu.AgregarUsuario(usuario);
        }

        public BE_LoginResultado LoginUsuario(string email, string password)
        {
            password = HashHelper.GenerarHash(password);

            BE_Usuario Usuario = dal_usu.ObtenerUsuarioPorEmail(email);

            if (Usuario == null)
            {
                return new BE_LoginResultado { ExitoLogin = false, Mensaje = "Usuario o Contrasena Incorrecto " };
            }

            if (!Usuario.Activo)
            {
                return new BE_LoginResultado {ExitoLogin = false,  Mensaje = "Usuario Bloqueado. Contacte Administrador" };
            }
            if (Usuario.HashPassword != password)
            {
                Usuario.IntentosFallidos++;
                dal_usu.ActualizarIntentos(Usuario.IdUsuario, Usuario.IntentosFallidos);

                if (Usuario.IntentosFallidos >= 3)
                {
                    dal_usu.BloquearUsuario(Usuario.IdUsuario);
                    return new BE_LoginResultado {ExitoLogin=false, Mensaje = "Usuario Bloqueado. Contacte Administrador" };
                }
                else
                {
                    return new BE_LoginResultado { Mensaje = $"Contrasena Incorrecta. Intento {Usuario.IntentosFallidos} de 3" };
                }
            }
            else
            {
                dal_usu.ResetearIntentos(Usuario.IdUsuario);

                return new BE_LoginResultado { ExitoLogin = true, Usuario = Usuario, Mensaje = "Bienvenido" };
            }
        }
    }
}
