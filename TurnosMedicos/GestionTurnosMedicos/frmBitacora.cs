using BLL;
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
    public partial class frmBitacora : Form
    {
        public frmBitacora()
        {
            InitializeComponent();
            LimpiarActualizar();
        }
        BLL_Bitacora bll_bitacora = new BLL_Bitacora();
        private void frmMenu_Load(object sender, EventArgs e)
        {
            LimpiarActualizar();
            dgvBitacora.Columns["IdBitacora"].Visible = false;
            dgvBitacora.MultiSelect = false;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;          

        }


        public void LimpiarActualizar()
        {
            dgvBitacora.DataSource = null;
            dgvBitacora.DataSource = bll_bitacora.ObtenerBitacora();
        }

        private void btnActualizarBitacora_Click(object sender, EventArgs e)
        {
            LimpiarActualizar();
        }
    }
}
