using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //Utilizamos un enum para poder definir las acciones que se van a registrar en la bitacora. Enum es la mejor opcion para esto porque nos permite tener un conjunto de valores predefinidos y evitar errores de tipeo al registrar las acciones.
    public enum AccionBitacora
    {
        LOGIN_INTENTO,
        LOGIN_INCORRECTO,
        LOGIN_BLOQUEADO,
        LOGIN_OK,
        USUARIO_ALTA,
        USUARIO_MODIFICACION,
        USUARIO_BAJA,
        USUARIO_RESTABLECIMIENTO_PASSWORD,
        MODULO_GENERAL
    }
}
