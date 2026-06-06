using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class RolComposite : Componente
    {
        public string Nombre{ get; set;}

        public List<Componente> hijos = new List<Componente>();

        public void Agregar(Componente componente) => hijos.Add(componente);

        public override bool TienePermiso(string Permiso)
        {
            foreach (var hijo in hijos)
            {
                if (hijo.TienePermiso(Permiso))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
