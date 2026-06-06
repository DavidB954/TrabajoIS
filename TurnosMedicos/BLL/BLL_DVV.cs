using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_DVV
    {
        DAL_DVV dal_dvv = new DAL_DVV();
        public void ActualizarDVV(string NombreTabla)
        {
            dal_dvv.ActualizarDVV(NombreTabla);
        }
    }
}
