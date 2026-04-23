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

        private int? idSeleccionado = null;

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarUsuarios();
        }


        private void ConfigurarGrid()
        {
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = bll_usuario.ListaUsuarios();

            dgvUsuarios.Columns["HashPassword"].Visible = false;
            dgvUsuarios.Columns["usuario"].Visible = false;
            dgvUsuarios.ClearSelection();
            dgvUsuarios.CurrentCell = null;
            idSeleccionado = null;
        }

        public void LimpiarCampos()
        {
            txtNombreUsuario.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtPassword.Clear();

        }
        
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0)
            {
                return;
            }

            else if (e.RowIndex>=0)
            {
                idSeleccionado = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value);
                txtNombreUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();  
                txtEmail.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            }
        }

      

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Por favor seleccione el usuario a modificar");
                return;
            }

            else
            {
                var Fila = dgvUsuarios.SelectedRows[0];

                BE_Usuario Usuario = new BE_Usuario();
                Usuario.IdUsuario = Convert.ToInt32(Fila.Cells["IdUsuario"].Value);
                Usuario.Nombre = txtNombreUsuario.Text;
                Usuario.Apellido = txtApellido.Text;
                Usuario.Email = txtEmail.Text;

                bll_usuario.ModificarUsuario(Usuario);

                CargarUsuarios();
                LimpiarCampos();
            }            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario Usuario = new BE_Usuario();

                Usuario.Nombre = txtNombreUsuario.Text;
                Usuario.Apellido = txtApellido.Text;
                Usuario.Email = txtEmail.Text;
                Usuario.HashPassword = txtPassword.Text;

                bll_usuario.AgregarUsuario(Usuario);

                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                if (idSeleccionado == null)
                {
                    MessageBox.Show("Por favor seleccione el usuario a eliminar");
                    return;
                }

                else
                {
                    var fila = dgvUsuarios.SelectedRows[0];
                    int id = Convert.ToInt32(fila.Cells["IdUsuario"].Value);
                    bll_usuario.EliminarUsuario(id);
                    CargarUsuarios();
                    LimpiarCampos();
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Por favor seleccione el usuario a resetear la contrasena");
                return;
            }
            else
            {
                var fila = dgvUsuarios.SelectedRows[0];
                int id = Convert.ToInt32(fila.Cells["IdUsuario"].Value);

                string nuevaPass = txtPassword.Text;

                bll_usuario.ResetearPassword(id, nuevaPass);

                CargarUsuarios();
                LimpiarCampos();
            }
        }
    }
}
