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
            cboModulo.SelectedIndex = -1;
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
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
            try
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
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        public void CboModulos()
        {
            cboModulo.Items.Add("LOGIN");
            cboModulo.Items.Add("USUARIO");
            cboModulo.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            DateTime ? desde = dtpDesde.Checked ? dtpDesde.Value.Date : (DateTime?)null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date : (DateTime?)null;
            int? idUsuario = ucCboUsuario1.IdSeleccionado;
            string modulo = string.IsNullOrEmpty(cboModulo.Text) ? null : cboModulo.Text;
            string ip = string.IsNullOrEmpty(txtBuscarPorIP.Text) ? null : txtBuscarPorIP.Text;
           
            dgvBitacora.DataSource = null;
            
            DataTable rdo = bll_bitacora.FiltrarBitacora(desde, hasta, idUsuario, modulo, ip);

            dgvBitacora.DataSource = rdo;            

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpDesde.Checked = false;
            dtpHasta.Value = DateTime.Now;
            dtpHasta.Checked = false;
            ucCboUsuario1.CargarCombo();
            cboModulo.SelectedIndex = -1;
            txtBuscarPorIP.Clear();

            LimpiarActualizar();
        }
    }
}
