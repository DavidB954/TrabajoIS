using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Conexion
    {
        private string connectionString = "Data Source=.; Initial Catalog = LOGINDB ; Integrated Security = true";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection (connectionString);

        }

    }
}
