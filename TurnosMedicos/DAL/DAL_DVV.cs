using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DVV
    {
        DAL_Conexion conex = new DAL_Conexion();

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
    }
}
