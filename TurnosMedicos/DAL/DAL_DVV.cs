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

        public void ActualizarDVV(string DVV, string NombreTabla)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdDVV = new SqlCommand("UPDATE DVV SET DVV=@DVV, FechaDeActualizacion=GETDATE() WHERE NombreTabla=@tabla", conexion);
                
                cmdDVV.Parameters.Add("@DVV", SqlDbType.VarChar, 64).Value = DVV;
                cmdDVV.Parameters.Add("@tabla", SqlDbType.VarChar, 50).Value = NombreTabla;     
                cmdDVV.ExecuteNonQuery();

            }
        }
    }
}
