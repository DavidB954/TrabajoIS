using BE.Composite;
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
    public partial class frmRolesPermisos : Form
    {
        public frmRolesPermisos()
        {
            InitializeComponent();
        }

        private void frmRolesPermisos_Load(object sender, EventArgs e)
        {
            groupBoxDetalles.Visible = false;
            groupBoxOpciones.Visible = false;
            CargarCombo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            groupBoxDetalles.Visible = true;
            groupBoxOpciones.Visible = true;
        }

        public class TipoItem
        {
            public int ID
            {
                get; set;
            }
            public string Nombre
            {
                get; set;
            }
        }

        public void CargarCombo()
        {
            var tipos = new List<TipoItem>
    {
        new TipoItem { ID = 1, Nombre = "Permiso" },
        new TipoItem { ID = 2, Nombre = "Rol" }
    };

            cboTipo.DataSource = tipos;
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember = "ID";
        }

        private void btnGuardarRP_Click(object sender, EventArgs e)
        {

            var tipoSeleccionado = (TipoItem)cboTipo.SelectedItem;

            if (tipoSeleccionado.Nombre == "Permiso")
            {
                var nuevoPermiso = new BE.Composite.Permiso
                {
                    Nombre = txtNombre.Text
                };

                TreeNode nodoPermiso = new TreeNode(nuevoPermiso.Nombre);
                nodoPermiso.Tag = nuevoPermiso;
                TreeNode parentNode = treeViewRoles.SelectedNode ?? treeViewRoles.Nodes[0];

                parentNode.Nodes.Add(nodoPermiso);
                treeViewRoles.BeginUpdate();
                treeViewRoles.SelectedNode.Nodes.Add(nodoPermiso);
                treeViewRoles.EndUpdate();
                treeViewRoles.Refresh();
            }
            else if (tipoSeleccionado.Nombre == "Rol")
            {
            
                var nuevoRol = new BE.Composite.RolComposite
                {
                    Nombre = txtNombre.Text
                };


                TreeNode nodoRol = new TreeNode(nuevoRol.Nombre);
                nodoRol.Tag = nuevoRol;
                TreeNode parentNode = treeViewRoles.SelectedNode ?? treeViewRoles.Nodes[0];

                parentNode.Nodes.Add(nodoRol);
                treeViewRoles.BeginUpdate();
                treeViewRoles.SelectedNode.Nodes.Add(nodoRol);
                treeViewRoles.EndUpdate();
                treeViewRoles.Refresh();
            }
        }

        private void treeViewRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Permiso permiso)
            {
                txtNombre.Text = permiso.Nombre;
                cboTipo.SelectedItem = "Permiso";
            }
            else if (e.Node.Tag is RolComposite rol)
            {
                txtNombre.Text = rol.Nombre;
                cboTipo.SelectedItem = "Rol";
            }
        }
    }
}
