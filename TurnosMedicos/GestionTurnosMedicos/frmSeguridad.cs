using BE;
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
    public partial class frmSeguridad : Form
    {
        public frmSeguridad()
        {
            InitializeComponent();
        }
        BLL_Usuario bll_usuario = new BLL_Usuario();
        private void frmSeguridad_Load(object sender, EventArgs e)
        {
           
        }

        public void MostrarCorruptos(List<BE_RegistrosCorruptos> lista)
        {
            dgvSeguridad.DataSource = null;
            dgvSeguridad.DataSource = lista;

            // Opcional: ajustar columnas para que se vean mejor
            dgvSeguridad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSeguridad.Columns["IdUsuario"].HeaderText = "ID Usuario";
            dgvSeguridad.Columns["DVH_Almacenado"].HeaderText = "DVH Guardado";
            dgvSeguridad.Columns["DVH_Recalculado"].HeaderText = "DVH Recalculado";
        }
    }
}
