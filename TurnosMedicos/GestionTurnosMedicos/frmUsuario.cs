using BE;
using BE.Composite;
using BLL;
using Servicios;
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
        BLL_Roles bll_Roles = new BLL_Roles();

        private int? idSeleccionado = null;

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarUsuarios();
            CargarUsuarioCbo();
            CargarRoles();
            CargarTreeViewUsuarios();
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
            dgvUsuarios.Columns["NombreApellido"].Visible = false;
            dgvUsuarios.Columns["DVH"].Visible = false;
            dgvUsuarios.ClearSelection();
            dgvUsuarios.CurrentCell = null;
            idSeleccionado = null;
        }

        private void CargarUsuarioCbo()
        {
            cboUsuario.DataSource = bll_usuario.ListaUsuarios();

            cboUsuario.DisplayMember = "NombreApellido";
            cboUsuario.ValueMember = "IdUsuario";

        }

        private void CargarRoles()
        {
            cboRoles.DataSource = bll_Roles.ObtenerRoles();
            cboRoles.DisplayMember = "Nombre";
            cboRoles.ValueMember = "Id";

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
            if (idSeleccionado == null || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Por favor seleccione el usuario a modificar y asegúrese de ingresar una contraseña");
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
                Usuario.HashPassword = txtPassword.Text;
                Usuario.Activo = Convert.ToBoolean(Fila.Cells["Activo"].Value);

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

        private void btnAsignarRol_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                int idRol = Convert.ToInt32(cboRoles.SelectedValue);

                bll_Roles.AgregarRolUsuario(idUsuario, idRol);

                MessageBox.Show("Rol Asignado correctamente");

                CargarTreeViewUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void CargarTreeViewUsuarios()
        {
            treeViewUsuarios.Nodes.Clear();

            TreeNode raiz = new TreeNode("Usuarios");

            List<BE_Usuario> usuarios = bll_usuario.ListaUsuarios();


            foreach (var usuario in usuarios)
            {
                TreeNode nodoUsuario = new TreeNode($"{usuario.Nombre} {usuario.Apellido}");
                nodoUsuario.Tag = usuario;

                // Reutiliza ObtenerRolesDeUsuario de BLL_Roles
                List<RolComposite> roles = bll_Roles.ObtenerRolesDeUsuario(usuario.IdUsuario);

                foreach (var rol in roles)
                {
                    TreeNode nodoRol = new TreeNode(rol.Nombre) { Tag = rol };
                    TreeViewHelper.AgregarNodosRecursivo(rol, nodoRol);
                    nodoUsuario.Nodes.Add(nodoRol);
                }

                raiz.Nodes.Add(nodoUsuario);
            }

            treeViewUsuarios.Nodes.Add(raiz);
            treeViewUsuarios.ExpandAll();
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeViewUsuarios.SelectedNode == null)
                {
                    MessageBox.Show("Seleccione un rol para quitar.");
                    return;
                }

                TreeNode nodoSeleccionado = treeViewUsuarios.SelectedNode;

                // Tiene que ser un Rol (hijo directo de un usuario)
                // El padre tiene que tener Tag de BE_Usuario
                if (nodoSeleccionado.Parent == null ||
                    nodoSeleccionado.Parent.Tag == null ||
                    !(nodoSeleccionado.Parent.Tag is BE_Usuario))
                {
                    MessageBox.Show("Seleccione un rol directamente asignado a un usuario.");
                    return;
                }

                // El nodo tiene que ser un RolComposite
                if (!(nodoSeleccionado.Tag is RolComposite rol))
                {
                    MessageBox.Show("Seleccione un rol para quitar.");
                    return;
                }

                BE_Usuario usuario = nodoSeleccionado.Parent.Tag as BE_Usuario;

                var confirmacion = MessageBox.Show(
                    $"¿Quitar el rol '{rol.Nombre}' del usuario '{usuario.Nombre} {usuario.Apellido}'?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion != DialogResult.Yes)
                    return; 
                bll_Roles.QuitarRolUsuario(usuario.IdUsuario, rol.Id);
                
                // Quitar el nodo del TreeView
                nodoSeleccionado.Remove();
                MessageBox.Show("Rol quitado correctamente.");

                CargarTreeViewUsuarios();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar rol: " + ex.Message);
            }
        }
    }
}
