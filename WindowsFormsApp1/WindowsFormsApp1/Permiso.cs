using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Permiso : Component
    {

        public override bool TienePermiso(string nombre)
        {
            return Nombre == nombre;
        }
    }
}
