using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPermisos : Form
    {
        public frmPermisos()
        {
            InitializeComponent();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            CargarCombo();
        }

        public void CargarCombo()
        {
            comboTipoPermiso.DataSource = Enum.GetValues(typeof(BE.TipoPermiso));
         
        }
    }
}
