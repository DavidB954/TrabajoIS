using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_HistorialCambios
    {
        DAL_HistorialCambios dal_historialCambios = new DAL_HistorialCambios();
        DAL_Usuario dal_usuario = new DAL_Usuario();

        public void RegistrarCambio(BE_Usuario anterior, BE_Usuario nuevo, int idUsuarioEditor)
        {
            CompararYRegistrar("Usuario", anterior.IdUsuario, "Nombre", anterior.Nombre, nuevo.Nombre, idUsuarioEditor);

            CompararYRegistrar("Usuario", anterior.IdUsuario, "Apellido", anterior.Apellido, nuevo.Apellido, idUsuarioEditor);

            CompararYRegistrar("Usuario", anterior.IdUsuario, "Email", anterior.Email, nuevo.Email, idUsuarioEditor);

            CompararYRegistrar("Usuario", anterior.IdUsuario, "Activo", anterior.Activo.ToString(), nuevo.Activo.ToString(), idUsuarioEditor);
        }

        private void CompararYRegistrar(string tabla, int idRegistro, string campo, string anterior, string nuevo, int idUsuario)
        {
            if (anterior != nuevo)
            {
                dal_historialCambios.RegistrarCambio(tabla, idRegistro, campo,
                    anterior, nuevo, idUsuario, "MODIFICACION");
            }
        }

        public void RegistrarAlta(string tabla, int idRegistro, int idUsuarioEditor)
        {
            dal_historialCambios.RegistrarCambio(tabla, idRegistro, "-", null, "Registro Creado", idUsuarioEditor, "ALTA");
        }

        public void RegistrarBaja(string tabla, int idRegistro, int idUsuarioEditor)
        {
            dal_historialCambios.RegistrarCambio(tabla, idRegistro, "-", null, "Registro Existente", idUsuarioEditor, "BAJA");
        }

        public DataTable ObtenerHistorial(string tabla, int idRegistro)
        {
            return dal_historialCambios.ObtenerHistorial(tabla, idRegistro);
        }

        public BE_Usuario RecomponerEstado(int idUsuario, DateTime fechaHasta)
        {
            DataTable historial = dal_historialCambios.ObtenerHistorialHastaFecha("Usuario", idUsuario, fechaHasta);

            //Estado Actual

            BE_Usuario usuario = dal_usuario.ObtenerUsuarioPorId(idUsuario);

            foreach (DataRow row in historial.Rows)
            {
                string campo = row["Campo"].ToString();

                string valorAnterior = row["ValorAnterior"].ToString();

                switch (campo)
                {
                    case "Nombre": usuario.Nombre = valorAnterior; break;
                    case "Apellido": usuario.Apellido = valorAnterior; break;
                    case "Email": usuario.Email = valorAnterior; break;
                    case "Activo": usuario.Activo = valorAnterior == "True"; break;
                }
            }

            return usuario;

        }
    }
}
