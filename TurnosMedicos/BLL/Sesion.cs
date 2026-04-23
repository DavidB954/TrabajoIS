using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Sesion
    {
        private static Sesion instancia;

        private static readonly object _lock = new object();
        public BE_Usuario UsuarioActual
        {
            get; set;
        }

        private Sesion()
        {
        }

        public static Sesion Instancia()
        {
            if (instancia == null)
            {
                lock (_lock)
                {
                    if (instancia == null)
                    {
                        instancia = new Sesion();
                    }
                        
                }
            }
            return instancia;
        }
        public void CerrarSesion()
        {
            UsuarioActual = null;
            instancia = null;
        }
    }

}
