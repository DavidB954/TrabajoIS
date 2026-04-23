using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Usuario
    {
        DAL_Conexion conex = new DAL_Conexion();

        public BE_Usuario VerificarUsuario(string Email, string Password)
        {
                using (SqlConnection conexion = conex.ObtenerConexion())
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand("Select IdUsuario, Nombre FROM Usuario WHERE Email = @email AND HashPassword=@password", conexion);

                    comando.Parameters.AddWithValue("@email", Email);
                    comando.Parameters.AddWithValue("@password", Password);

                    SqlDataReader lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                       BE_Usuario usuario = new BE_Usuario();
                       usuario.IdUsuario = lector.GetInt32(0);
                       usuario.Nombre = lector.GetString(1);
                        return usuario;       
                    }                                       
                }
                return null;

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


    }
}
