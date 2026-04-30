using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTurnosMedicos
{
    public partial class ucCboUsuario : UserControl
    {
        public ucCboUsuario()
        {
            InitializeComponent();
            CargarCombo();
        }

        public void CargarCombo()
        {
            BLL.BLL_Usuario bll_usuario = new BLL.BLL_Usuario();
            cboUsuario.DataSource = bll_usuario.ListaUsuarios();     
            cboUsuario.DisplayMember = "NombreApellido";
            cboUsuario.ValueMember = "IdUsuario";
        }

        public int? IdSeleccionado
        {
            get
            {
                if (cboUsuario.SelectedIndex == -1)
                    return null;
                return (int)cboUsuario.SelectedValue;
            }
        }

    }
}
