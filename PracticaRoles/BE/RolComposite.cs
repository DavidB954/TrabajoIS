using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class RolComposite : Component
    {
        public int IdRolC { get; set;}
        public string Nombre { get; set;}

        public List<Component> ListaHijos = new List<Component>();

        public void Agregar(Component c)
        {
            ListaHijos.Add(c);
        }

        public void Eliminar(Component c)
        {
            ListaHijos.Remove(c);
        }
        public override bool TienePermiso(string Permiso)
        {
            foreach (var item in ListaHijos)
            {
                if (item.TienePermiso(Permiso))
                {
                    return true;
                }
            }
            return false;   
        }
    }
}
