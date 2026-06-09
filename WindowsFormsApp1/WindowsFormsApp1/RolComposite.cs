using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class RolComposite : Component
    {
        List<Component> hijos = new List<Component>();

        public void Agregar(Component comp) => hijos.Add(comp);

        public void Eliminar(Component comp) => hijos.Remove(comp);

        public override bool TienePermiso(string nombre)
        {
            foreach (var hijo in hijos)
            {
                if (hijo.TienePermiso(nombre))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
