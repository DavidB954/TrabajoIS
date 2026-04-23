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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }
        BLL_Usuario bll_usuario = new BLL_Usuario();
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = bll_usuario.ListaUsuarios();
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Columns["HashPassword"].Visible = false;
            dgvUsuarios.Columns["usuario"].Visible = false;
        }
        public void LimpiarActualizar()
        {
            txtNombreUsuario.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            dgvUsuarios.DataSource = bll_usuario.ListaUsuarios();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                txtNombreUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();  
                txtEmail.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BE_Usuario Usuario = new BE_Usuario();

            Usuario.Nombre = txtNombreUsuario.Text;
            Usuario.Apellido = txtApellido.Text;
            Usuario.Email = txtEmail.Text;
            Usuario.HashPassword = txtPassword.Text;

            bll_usuario.AgregarUsuario(Usuario);
        }
    }
}
