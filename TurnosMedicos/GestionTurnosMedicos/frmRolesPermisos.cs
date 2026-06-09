using BE.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;

namespace GestionTurnosMedicos
{
    public partial class frmRolesPermisos : Form
    {
        public frmRolesPermisos()
        {
            InitializeComponent();
            RolComposite raiz = new RolComposite
            {
                Nombre = "Roles"
            };

            TreeNode root = new TreeNode("Roles");
            root.Tag = raiz;
            treeViewRoles.Nodes.Clear();
            treeViewRoles.Nodes.Add(root);
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
            //try
            //{
            //    TreeNode nodoPadre;

            //    ExisteRol(txtNombre.Text);

            //    if (rolPadre.ExisteRol(nuevoRol.Nombre))
            //    {
            //        MessageBox.Show("Ya existe un rol con ese nombre");
            //    }

            //    if (treeViewRoles.SelectedNode!= null)
            //    {
            //        nodoPadre = treeViewRoles.SelectedNode;
            //    }

            //    else if (treeViewRoles.Nodes.Count>0)
            //    {
            //        nodoPadre = treeViewRoles.Nodes[0];
            //    }
            //    else
            //    {
            //        nodoPadre = new TreeNode("Root");
            //        treeViewRoles.Nodes.Add(nodoPadre);
            //    }

            //    var tipoSeleccionado = (TipoItem)cboTipo.SelectedItem;


            //    if (tipoSeleccionado.Nombre == "Permiso")
            //    {
            //        var nuevoPermiso = new BE.Composite.Permiso
            //        {
            //            Nombre = txtNombre.Text
            //        };

            //        TreeNode nodoPermiso = new TreeNode(nuevoPermiso.Nombre);
            //        nodoPermiso.Tag = nuevoPermiso;

            //        //Agregamos al treeview
            //        nodoPadre.Nodes.Add(nodoPermiso);
            //        nodoPadre.Expand();


            //    }
            //    else if (tipoSeleccionado.Nombre == "Rol")
            //    {

            //        var nuevoRol = new BE.Composite.RolComposite
            //        {
            //            Nombre = txtNombre.Text
            //        };


            //        TreeNode nodoRol = new TreeNode(nuevoRol.Nombre);
            //        nodoRol.Tag = nuevoRol;

            //        nodoPadre.Nodes.Add(nodoRol);

            //        nodoPadre.Expand();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }

        private void treeViewRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
        //    if (e.Node.Tag is Permiso permiso)
        //    {
        //        txtNombre.Text = permiso.Nombre;
        //        cboTipo.SelectedItem = "Permiso";
        //    }
        //    else if (e.Node.Tag is RolComposite rol)
        //    {
        //        txtNombre.Text = rol.Nombre;
        //        cboTipo.SelectedItem = "Rol";
        //    }
        }
        public bool ExisteHijo(TreeNode nodoPadre, string nombre)
        {
           
            foreach (TreeNode hijo in nodoPadre.Nodes)
            {
                Componente comp = hijo.Tag as Componente;

                if (comp != null && comp.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (ExisteHijo(hijo, nombre))
                {
                    return true;
                }
            }

            return false;
        }
        private void btnAgregarPR_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeViewRoles.SelectedNode == null)
                {
                    MessageBox.Show("Seleccione un nodo");
                    return;
                }
                
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Ingrese un nombre");
                    return;
                }
                string nombre = txtNombre.Text;

                Componente compSeleccionado = treeViewRoles.SelectedNode.Tag as Componente;   
                
                if (!(compSeleccionado is RolComposite))
                {
                    MessageBox.Show("Solo se pueden agregar componentes dentro de un rol");
                    return;
                }

                TreeNode nodoSeleccionado = treeViewRoles.SelectedNode;
                TreeNode nodoActual = nodoSeleccionado;

                while (nodoActual!=null)
                {
                    Componente comp = nodoActual.Tag as Componente;

                    if (comp != null && comp.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("No puede agregar un componente con el mismo nombre que un padre");
                        return;
                    }
                    if (ExisteHijo(nodoActual, nombre))
                    {
                        MessageBox.Show("Ya existe un Rol o Permiso con ese nombre en este nivel o subniveles");
                        return;
                    }
                    nodoActual = nodoActual.Parent;
                }

                Componente nuevoC = null;

                if (cboTipo.Text == "Rol")
                {
                    nuevoC = new RolComposite
                    {
                        Nombre = nombre

                    };
                }

                else if (cboTipo.Text == "Permiso")
                {
                    nuevoC = new Permiso
                    {
                        Nombre = nombre
                    };
                }
               

                ((RolComposite)compSeleccionado).Agregar(nuevoC);

                TreeNode nodoNuevo = new TreeNode(nombre);
                nodoNuevo.Tag = nuevoC;

                treeViewRoles.SelectedNode.Nodes.Add(nodoNuevo);

                txtNombre.Clear();

                treeViewRoles.ExpandAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
