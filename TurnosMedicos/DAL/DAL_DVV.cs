using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DVV
    {
        DAL_Conexion conex = new DAL_Conexion();

        public string ObtenerDVV(string NombreTabla)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdObtenerDVV = new SqlCommand("Select DVV from DVV Where NombreTabla=@tabla", conexion);

                cmdObtenerDVV.Parameters.Add("@tabla", SqlDbType.VarChar, 50).Value = NombreTabla;

                object result = cmdObtenerDVV.ExecuteScalar();

                return result?.ToString();
            }
        }


        public void ActualizarDVV(string NombreTabla)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdDVV = new SqlCommand("dbo.ActualizarDVV", conexion);

                cmdDVV.CommandType = CommandType.StoredProcedure;

                cmdDVV.Parameters.Add("@NombreTabla", SqlDbType.VarChar, 50).Value = NombreTabla;

                cmdDVV.ExecuteNonQuery();
            }
        }

        //Calcular sin actualizar
        public string CalcularDVV(string NombreTabla)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdCalcularDVV = new SqlCommand($"SELECT STRING_AGG(DVH, '''') FROM {NombreTabla}", conexion);

                string concatenacion = cmdCalcularDVV.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(concatenacion))
                {
                    return null;
                }

                //Calculamos el hash
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(concatenacion));

                    StringBuilder constructor = new StringBuilder();

                    //Por cada byte del array, convierte a string en formato hexadecimal (x) y con dos digitos (2). Y lo agrega al constructor.
                    foreach (byte b in bytes)
                    {
                        constructor.Append(b.ToString("X2"));
                    }


                    //Devuelve el hash como string.
                    return constructor.ToString();

                }
            }
        }
    }
}
