using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_DVV
    {
        DAL_DVV dal_dvv = new DAL_DVV();
        DAL_Usuario dal_usuario = new DAL_Usuario();
        public void ActualizarDVV(string NombreTabla)
        {
            string concatenacion = CalcularDVV();

            dal_dvv.ActualizarDVV(concatenacion, NombreTabla);
        }

        public bool VerificarIntegridad(string nombreTabla)
        {
            string dvvAlmacenado = dal_dvv.ObtenerDVV(nombreTabla);

            string dvvRecalculado = CalcularDVV();

            return dvvAlmacenado == dvvRecalculado;

        }

        public string CalcularDVV()
        {
            List<BE_Usuario> ListaUsuario = dal_usuario.ListaUsuario();

            StringBuilder concatenacion = new StringBuilder();

            foreach (var usuario in ListaUsuario)
            {
                string activo = usuario.Activo ? "1" : "0";

                string dvhRecalculado = HashHelper.GenerarHash(
                    $"{usuario.Nombre}|{usuario.Apellido}|{usuario.Email}|{usuario.HashPassword}|{usuario.IntentosFallidos}|{activo}"
                );
                concatenacion.Append(dvhRecalculado);
            }

            return HashHelper.GenerarHash(concatenacion.ToString());
        }

        public void GenerarBackUp(string rutaBackup)
        {
            dal_dvv.GenerarBackUp(rutaBackup);
        }

        public void RestaurarBackup(string rutaBackup)
        {
            dal_dvv.RestaurarBackup(rutaBackup);
        }
    }
}
