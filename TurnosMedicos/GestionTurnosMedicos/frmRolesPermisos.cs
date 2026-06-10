using BE.Composite;
using BLL;
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
        BLL_Roles bll_roles = new BLL_Roles();
        public frmRolesPermisos()
        {
            InitializeComponent();
            Raiz();
        }

        private void Raiz()
        {
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
            CargarTreeView();
            CargarComboRolesExistentes();
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

            try
            {
                // El nodo raíz del TreeView tiene como Tag el RolComposite raíz
                RolComposite raiz = treeViewRoles.Nodes[0].Tag as RolComposite;

                if (raiz == null || !raiz.Hijos().Any())
                {
                    MessageBox.Show("No hay nada para guardar.");
                    return;
                }
                bll_roles.GuardarArbol(raiz, txtDescripcion.Text);

                MessageBox.Show("Guardado correctamente.");

                CargarTreeView();

                CargarComboRolesExistentes();

                Raiz();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }

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
                    TreeNode raizBD = treeViewRolesC.Nodes.Count > 0 ? treeViewRolesC.Nodes[0] : null;
                    if (raizBD != null && ExisteRolEnArbol(raizBD, nombre))
                    {
                        MessageBox.Show("Ya existe un Rol con ese nombre en la base de datos.");
                        return;
                    }

                    nuevoC = new RolComposite
                    {
                        Nombre = nombre

                    };
                }

                else if (cboTipo.Text == "Permiso")
                {
                    TreeNode raizBD = treeViewRolesC.Nodes.Count > 0 ? treeViewRolesC.Nodes[0] : null;

                    if (raizBD != null && ExistePermisoEnArbol(raizBD, nombre))
                    {
                        MessageBox.Show("Ya existe un Permiso con ese nombre en la base de datos.");
                        return;
                    }


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



        private bool ExistePermisoEnArbol(TreeNode nodo, string nombre)
        {
            foreach (TreeNode hijo in nodo.Nodes)
            {
                if (hijo.Tag is Permiso &&
                    hijo.Text.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    return true;

                if (ExistePermisoEnArbol(hijo, nombre))
                    return true;
            }
            return false;
        }




        private bool ExisteRolEnArbol(TreeNode nodo, string nombre)
        {
            foreach (TreeNode hijo in nodo.Nodes)
            {
                if (hijo.Tag is RolComposite &&
                    hijo.Text.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    return true;

                if (ExisteRolEnArbol(hijo, nombre))
                    return true;
            }
            return false;
        }



        private void CargarTreeView()
        {
            treeViewRolesC.Nodes.Clear();

            RolComposite raiz = bll_roles.CargarArbol();

            TreeNode nodoRaiz = new TreeNode(raiz.Nombre);
            nodoRaiz.Tag = raiz;

            AgregarNodosRecursivo(raiz, nodoRaiz);

            treeViewRolesC.Nodes.Add(nodoRaiz);
            treeViewRolesC.ExpandAll();
        }

        private void AgregarNodosRecursivo(RolComposite rolPadre, TreeNode nodoPadre)
        {
            foreach (var hijo in rolPadre.Hijos())
            {
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoHijo.Tag = hijo;

                nodoPadre.Nodes.Add(nodoHijo);

                // Si es un rol, seguir bajando
                if (hijo is RolComposite subRol)
                    AgregarNodosRecursivo(subRol, nodoHijo);
            }
        }


        private void CargarComboRolesExistentes()
        {
            if (treeViewRolesC.Nodes.Count == 0)
                return;

            RolComposite raiz = treeViewRolesC.Nodes[0].Tag as RolComposite;
            if (raiz == null)
                return;

            // Recorre todos los RolComposite del árbol y los agrega al combo
            AgregarRolesAlCombo(raiz);
        }

        private void AgregarRolesAlCombo(RolComposite rol)
        {
            cboRolesExistentes.Items.Clear();

            foreach (var hijo in rol.Hijos())
            {
                if (hijo is RolComposite subRol)
                {
                    cboRolesExistentes.Items.Add(subRol); // Muestra el Nombre via ToString()                   
                }
            }
        }

        private void btnAgregarRolExistente_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeViewRoles.SelectedNode == null)
                {
                    MessageBox.Show("Seleccione un nodo destino.");
                    return;
                }

                if (cboRolesExistentes.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un rol existente.");
                    return;
                }

                Componente compDestino = treeViewRoles.SelectedNode.Tag as Componente;
                if (!(compDestino is RolComposite padreDestino))
                {
                    MessageBox.Show("Solo se puede agregar dentro de un rol.");
                    return;
                }

                RolComposite rolOrigen = cboRolesExistentes.SelectedItem as RolComposite;

                // Validar que no sea el mismo nodo ni un ancestro
                if (EsAncestro(treeViewRoles.SelectedNode, rolOrigen.Nombre))
                {
                    MessageBox.Show("No puede agregar un rol que sea padre del nodo seleccionado.");
                    return;
                }

                // Validar que no exista ya ese nombre en el subárbol destino
                if (ExisteHijo(treeViewRoles.SelectedNode, rolOrigen.Nombre))
                {
                    MessageBox.Show("Ya existe ese rol en este nivel.");
                    return;
                }

                // Clonar el rol con todos sus hijos (permisos incluidos)
                RolComposite clon = ClonarRol(rolOrigen);

                padreDestino.Agregar(clon);

                // Agregar al TreeView
                TreeNode nodoNuevo = new TreeNode(clon.Nombre) { Tag = clon };
                AgregarNodosRecursivo(clon, nodoNuevo);
                treeViewRoles.SelectedNode.Nodes.Add(nodoNuevo);
                treeViewRoles.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private RolComposite ClonarRol(RolComposite original)
        {
            var clon = new RolComposite { Nombre = original.Nombre, Id = original.Id };

            foreach (var hijo in original.Hijos())
            {
                if (hijo is RolComposite subRol)
                    clon.Agregar(ClonarRol(subRol));
                else if (hijo is Permiso p)
                    clon.Agregar(new Permiso { Nombre = p.Nombre,
                        Id = p.Id,         
                        IdPermiso = p.IdPermiso
                    });
            }

            return clon;
        }
        // Verifica que el nodo seleccionado no sea descendiente del rol que queremos agregar
        private bool EsAncestro(TreeNode nodo, string nombre)
        {
            TreeNode actual = nodo;
            while (actual != null)
            {
                if (actual.Text.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    return true;
                actual = actual.Parent;
            }
            return false;
        }


    }
}
