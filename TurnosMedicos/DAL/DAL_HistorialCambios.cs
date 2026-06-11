using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HistorialCambios
    {
        DAL_Conexion conex = new DAL_Conexion();

        public void RegistrarCambio(string tabla, int idRegistro, string campo, string valorAnterior, string valorNuevo, int idUsuario, string accion)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdRegistrarCambio = new SqlCommand(@"Insert into HistorialCambios 
                    (Tabla, IdRegistro, Campo, ValorAnterior, ValorNuevo, IdUsuario, Accion)
                    VALUES (@tabla, @idRegistro, @campo, @valorAnt, @valorNuevo, @idUsu, @accion)", conexion);

                cmdRegistrarCambio.Parameters.Add("@tabla", SqlDbType.VarChar, 50).Value = tabla;
                cmdRegistrarCambio.Parameters.Add("@idRegistro", SqlDbType.Int).Value = idRegistro;
                cmdRegistrarCambio.Parameters.Add("@campo", SqlDbType.VarChar, 50).Value = campo;
                cmdRegistrarCambio.Parameters.Add("@valorAnt", SqlDbType.VarChar, 500).Value = valorAnterior;
                cmdRegistrarCambio.Parameters.Add("@valorNuevo", SqlDbType.VarChar, 500).Value = valorNuevo;
                cmdRegistrarCambio.Parameters.Add("@idUsu", SqlDbType.Int).Value = idUsuario;
                cmdRegistrarCambio.Parameters.Add("@accion", SqlDbType.VarChar, 20).Value = accion;


                cmdRegistrarCambio.ExecuteNonQuery();
            }

        }

        public DataTable ObtenerHistorial(string tabla, int idRegistro)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                conexion.Open();

                SqlCommand cmdObtHistorial = new SqlCommand(@"
                SELECT h.FechaCambio, u.Nombre + ' ' + u.Apellido AS Usuario,
                       h.Accion, h.Campo, h.ValorAnterior, h.ValorNuevo
                FROM HistorialCambios h
                LEFT JOIN Usuario u ON h.IdUsuario = u.IdUsuario
                WHERE h.Tabla = @tabla AND h.IdRegistro = @id
                ORDER BY h.FechaCambio DESC", conexion);

                cmdObtHistorial.Parameters.Add("@tabla", SqlDbType.VarChar, 50).Value = tabla;
                cmdObtHistorial.Parameters.Add("@id", SqlDbType.Int).Value = idRegistro;

                SqlDataAdapter da = new SqlDataAdapter(cmdObtHistorial);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ObtenerHistorialHastaFecha(string tabla, int idRegistro, DateTime fechaHasta)
        {
            using (SqlConnection conexion = conex.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT Campo, ValorAnterior, ValorNuevo, FechaCambio
            FROM HistorialCambios
            WHERE Tabla = @tabla 
              AND IdRegistro = @id 
              AND FechaCambio >= @fecha
              AND Accion = 'MODIFICACION'
            ORDER BY FechaCambio DESC", conexion);

                cmd.Parameters.Add("@tabla", SqlDbType.VarChar, 50).Value = tabla;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idRegistro;
                cmd.Parameters.AddWithValue("@fecha", fechaHasta);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
