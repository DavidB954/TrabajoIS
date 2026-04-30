using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
            CboModulos();
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

            int contador = 0;
            foreach (DataGridViewRow fila in dgvBitacora.Rows)
            {
                contador++;
            }

            lblTotalRegistros.Text = contador.ToString();
        }

        private void btnActualizarBitacora_Click(object sender, EventArgs e)
        {
            LimpiarActualizar();
        }

        private void dgvBitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Fila = dgvBitacora.Rows[e.RowIndex];

            if (Fila == null)
            {
                return;
            }
            else
            {
                txtFecha.Text = Fila.Cells["FechaHora"].Value.ToString();
                if (Fila.Cells["IdUsuario"].Value != null)
                {
                    txtUsuario.Text = Convert.ToString(Fila.Cells["IdUsuario"].Value.ToString()) ?? "";
                }
                else
                {
                    txtUsuario.Text = "";
                }
                txtAccion.Text = Fila.Cells["Accion"].Value.ToString();
                txtModulo.Text = Fila.Cells["Modulo"].Value.ToString();
                txtIP.Text = Fila.Cells["IP"].Value.ToString();
                txtNombreHost.Text = Fila.Cells["NombreMaquina"].Value.ToString();
                txtDescripcion.Text = Fila.Cells["Descripcion"].Value.ToString();

            }
        }

        public void CboModulos()
        {
            cboModulo.Items.Add("LOGIN");
            cboModulo.Items.Add("USUARIOS");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {



            if (!IPAddress.TryParse(txtBuscarPorIP.Text, out _))
            {
                MessageBox.Show("IP Invalida");
            }




        }
    }
}
