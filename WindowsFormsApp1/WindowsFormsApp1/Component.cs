using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Component
    {
        public string Nombre { get; set; }

        public abstract bool TienePermiso(string nombre);
    }
}
