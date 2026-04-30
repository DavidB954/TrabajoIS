using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Usuario
    {
        DAL_Conexion conex = new DAL_Conexion();

        public void AgregarUsuario(BE_Usuario Usuario)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand(@"Insert into Usuario (Nombre, Apellido, Email, HashPassword, IntentosFallidos, Activo) VALUES 
                                                    (@nombre, @apellido, @email, @hash, 0, 1)", conexion);

                comando.Parameters.Add("@nombre", SqlDbType.VarChar, 20).Value = Usuario.Nombre;
                comando.Parameters.Add("@apellido", SqlDbType.VarChar, 20).Value = Usuario.Apellido;
                comando.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Usuario.Email;
                comando.Parameters.Add("@hash", SqlDbType.VarChar, 100).Value = Usuario.HashPassword;

                comando.ExecuteNonQuery();
            }

        }

        /* public void VerificarUsuario(string Email, string HashPassword)
         {
             //Primero conectamos la BD
             using (SqlConnection conexion = conex.ObtenerConexion())
             {
                 conexion.Open();

                 //Segundo verificamos que el email sea valido
                 SqlCommand cmdEmail = new SqlCommand("Select * From Usuario Where Email=@email", conexion);
                 cmdEmail.Parameters.Add("@email", SqlDbType.VarChar, 20).Value =Email;
                 SqlDataReader lector = cmdEmail.ExecuteReader();

                 if (!lector.Read())
                 {
                     //No existe el Usuario con ese email.
                     return;
                 }

                 else 
                 {
                     //Existe entonces trae los datos
                     int IdUsuario = lector.GetInt32(0);
                     string nombre = lector.GetString(1);
                     string apellido = lector.GetString(2);
                     string email = lector.GetString(3);
                     string hashpassword = lector.GetString(4);
                     int intentofallidos = lector.GetInt32(5);
                     bool activo = lector.GetBoolean(6);

                     lector.Close();
                     //Verificar la contrasena

                     //Si no es igual se le suma un intento fallido
                     if (HashPassword != hashpassword)
                     {
                         intentofallidos++;

                         SqlCommand cmdPassword = new SqlCommand("Update Usuario SET IntentosFallidos = @intentos WHERE IdUsuario=@id", conexion);

                         cmdPassword.Parameters.Add("@intentos", SqlDbType.VarChar, 100).Value = intentofallidos;
                         cmdPassword.Parameters.Add("@id", SqlDbType.Int).Value = IdUsuario;

                         cmdPassword.ExecuteNonQuery();
                     }
                     //Si la contrase;a coincide entonces se le pone en 0
                     else if (HashPassword==hashpassword)
                     {
                         SqlCommand cmdReset = new SqlCommand("Update Usuario SET IntentosFallidos = 0 WHERE IdUsuario=@id", conexion);
                         cmdReset.Parameters.Add("@id", SqlDbType.Int).Value = IdUsuario;

                         cmdReset.ExecuteNonQuery();
                     }


                 }

             }

         }*/

        public BE_Usuario ObtenerUsuarioPorEmail(string Email)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdEmail = new SqlCommand("Select * From Usuario WHERE Email=@email", conexion);

                cmdEmail.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;

                SqlDataReader Lector = cmdEmail.ExecuteReader();

                if (!Lector.Read())
                {
                    return null;
                }

                return new BE_Usuario
                {
                    IdUsuario = Lector.GetInt32(0),
                    Nombre = Lector.GetString(1),
                    Apellido = Lector.GetString(2),
                    Email = Lector.GetString(3),
                    HashPassword = Lector.GetString(4),
                    IntentosFallidos = Lector.GetInt32(5),
                    Activo = Lector.GetBoolean(6)
                };
            }
        }

        public void ActualizarIntentos(int IdUsuario, int Intentos )
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdActualizar = new SqlCommand("Update Usuario SET IntentosFallidos = @intentos WHERE IdUsuario=@id", conexion);

                cmdActualizar.Parameters.Add("@intentos", SqlDbType.Int).Value = Intentos;
                cmdActualizar.Parameters.Add("@id", SqlDbType.Int).Value = IdUsuario;

                cmdActualizar.ExecuteNonQuery();
            }
        }

        public void ResetearIntentos(int IdUsuario)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdReseteo = new SqlCommand("Update Usuario SET IntentosFallidos=0 Where IdUsuario=@id", conexion);

                cmdReseteo.Parameters.Add("@id", SqlDbType.Int).Value = IdUsuario;

                cmdReseteo.ExecuteNonQuery();
            }
        }

        public void BloquearUsuario(int IdUsuario)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdBloqueoUsuario = new SqlCommand("Update Usuario SET Activo=0 Where IdUsuario=@id", conexion);

                cmdBloqueoUsuario.Parameters.Add("@id", SqlDbType.Int).Value = IdUsuario;

                cmdBloqueoUsuario.ExecuteNonQuery();
            }
        }
    }
}
