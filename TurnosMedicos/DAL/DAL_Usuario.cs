using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Usuario
    {
        DAL_Conexion conex = new DAL_Conexion();

        /*  public BE_Usuario VerificarUsuario(string Email, string Password, out string mensaje)
          {
               mensaje = "";
              using (SqlConnection conexion = conex.ObtenerConexion())
              {
                  conexion.Open();

                  //Buscamos por mail

                  SqlCommand comando = new SqlCommand("Select IdUsuario, Nombre, HashPassword, Activo, IntentosFallidos FROM Usuario WHERE Email=@email", conexion);

                  comando.Parameters.AddWithValue("@email", Email);

                  SqlDataReader lector = comando.ExecuteReader();

                  if (!lector.Read()) //Usuario no existe
                  {
                      mensaje = "Usuario no encontrado.";
                      return null;
                  }

                  int id = lector.GetInt32(0);
                  string nombre = lector.GetString(1);
                  string hashPassword = lector.GetString(2);
                  bool activo = lector.GetBoolean(3);
                  int intentosFallidos = lector.GetInt32(4);

                  lector.Close();

                  //verifica si esta activo
                  if (!activo)
                  {
                      mensaje = "Usuario bloqueado por demasiados intentos fallidos. Contacte Administrador";
                      return null;
                  }

                  //validamos la contraseña 

                  if (hashPassword == Password)
                  {
                      if (intentosFallidos > 0)
                      {
                          SqlCommand cmdReset = new SqlCommand("Update Usuario SET IntentosFallidos=0 WHERE IdUsuario=@id", conexion);

                          cmdReset.Parameters.Add("@id", SqlDbType.Int).Value = id;

                          cmdReset.ExecuteNonQuery();
                      }

                      mensaje = "Login exitoso.";

                      return new BE_Usuario
                      {
                          IdUsuario = id,
                          Nombre = nombre
                      };
                  }
                  else //login incorrecto
                  {
                      intentosFallidos++;

                      bool act = intentosFallidos < 3;

                      SqlCommand updComando = new SqlCommand("Update Usuario Set IntentosFallidos=@intentos, Activo=@activo WHERE IdUsuario=@id", conexion);

                      updComando.Parameters.Add("@intentos", SqlDbType.Int).Value = intentosFallidos;
                      updComando.Parameters.Add("@activo", SqlDbType.Bit).Value = act;
                      updComando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                      updComando.ExecuteNonQuery();

                      if (!act)
                      {
                          mensaje = "Usuario bloqueado por demasiados intentos fallidos. Contacte Administrador";
                      }
                      else
                      {
                          mensaje = $"Contraseña incorrecta. Intentos restantes: {3 - intentosFallidos}";
                      }

                      return null;

                  }
              }
          }*/

        //Verificamos que existe el mail del Usuario y devolvemos un objeto Usuario con la contraseña hasheada para poder compararla luego.

        public BE_Usuario ObtenerUsuarioPorEmail(string email)
        {

            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdUsuEmail = new SqlCommand("Select * From Usuario Where Email=@email", conexion);

                cmdUsuEmail.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = email;

                SqlDataReader Lector = cmdUsuEmail.ExecuteReader();


                if (!Lector.Read())
                {
                    return null;
                }

                else return new BE_Usuario
                {
                    IdUsuario = Lector.GetInt32(0),
                    Nombre = Lector.GetString(1),
                    Apellido = Lector.GetString(2),
                    Email = Lector.GetString(3),
                    HashPassword = Lector.GetString(4),
                    Activo = Lector.GetBoolean(5),
                    IntentosFallidos = Lector.GetInt32(6)
                };
            }
        }

        //Updateamos los intentos fallidos en caso de que el login sea incorrecto, y bloqueamos el usuario si supera los 3 intentos fallidos.
        public void ActualizarIntentosFallidos(int intentos, int IdUsuario)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdActualizarIntentos = new SqlCommand("Update Usuario Set IntentosFallidos = @intentos Where IdUsuario=@id", conexion);

                cmdActualizarIntentos.Parameters.Add("@intentos", SqlDbType.Int).Value = intentos;
                cmdActualizarIntentos.Parameters.Add("@id", SqlDbType.Int).Value = IdUsuario;

                cmdActualizarIntentos.ExecuteNonQuery();
            }
        }

        public void BloquearUsuario(int IdUsuario)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdBloquearUsuario = new SqlCommand("Update Usuario SET Activo=0 Where IdUsuario = @id", conexion);

                cmdBloquearUsuario.Parameters.Add("@id", SqlDbType.Int).Value = IdUsuario;

                cmdBloquearUsuario.ExecuteNonQuery();
            }
        }
        public List<BE_Usuario> ListaUsuario()
        {
            List<BE_Usuario> ListaUsu = new List<BE_Usuario>();

            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("Select * from Usuario", conexion);

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    BE_Usuario Usu = new BE_Usuario();
                    Usu.IdUsuario = Convert.ToInt32(lector[0]);
                    Usu.Nombre = lector[1].ToString();
                    Usu.Apellido = lector[2].ToString();
                    Usu.Email = lector[3].ToString();
                    Usu.Activo = Convert.ToBoolean(lector[5]);
                    Usu.IntentosFallidos = Convert.ToInt32(lector[6]);
                    ListaUsu.Add(Usu);
                }

                return ListaUsu;
            }

        }

        public void AgregarUsuario(BE_Usuario Usuario)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("Insert into Usuario (Nombre, Apellido, Email, HashPassword) VALUES (@nombre, @apellido, @email, @hash)", conexion);

                comando.Parameters.AddWithValue("@nombre", Usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", Usuario.Apellido);
                comando.Parameters.AddWithValue("@email", Usuario.Email);
                comando.Parameters.AddWithValue("@hash", Usuario.HashPassword);

                comando.ExecuteNonQuery();
            }

        }

        public void ModificarUsuario(BE_Usuario Usuario)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("Update Usuario SET Nombre=@nombre, Apellido=@apellido, Email=@email, Activo = @activo WHERE IdUsuario=@id", conexion);

                comando.Parameters.AddWithValue("@id", Usuario.IdUsuario);
                comando.Parameters.AddWithValue("@nombre", Usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", Usuario.Apellido);
                comando.Parameters.AddWithValue("@email", Usuario.Email);
                comando.Parameters.Add("@activo", SqlDbType.Bit).Value = Usuario.Activo;
                comando.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int id)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();
                //Primero borro todo lo de ese usuario en la bitacora
                SqlCommand cmdBorrarUsuBitacora = new SqlCommand("Delete from Bitacora WHERE IdUsuario=@idUsuBorrado", conexion);

                cmdBorrarUsuBitacora.Parameters.Add("@idUsuBorrado", SqlDbType.Int).Value = id;

                cmdBorrarUsuBitacora.ExecuteNonQuery();

                SqlCommand comando = new SqlCommand("Delete from Usuario WHERE IdUsuario = @id", conexion);

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
        }

        public void ResetearContrasena(int id, string nuevaPass)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("Update Usuario SET HashPassword=@nuevoHash, IntentosFallidos = 0, Activo=1 WHERE IdUsuario=@id", conexion);

                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nuevoHash", nuevaPass);

                comando.ExecuteNonQuery();
            }
        }

    }
}
