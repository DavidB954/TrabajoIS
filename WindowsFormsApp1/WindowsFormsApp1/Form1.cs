using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Nombre = textBox1.Text;


                Permiso p = new Permiso();

                p.Nombre = Nombre;

                TreeNode nodoSeleccionado = treeView1.SelectedNode;
               
                TreeNode nodoPadre = nodoSeleccionado;

                while (nodoPadre!=null)
                {
                    if (nodoPadre.Text == p.Nombre)
                    {
                        MessageBox.Show("No se puede agregar un permiso con el mismo nombre que el nodo padre");
                        return;
                    }

                    nodoPadre = nodoPadre.Parent;
                }

                foreach (TreeNode hijo in nodoSeleccionado.Nodes)
                {
                    if (hijo.Text == p.Nombre)
                    {
                        MessageBox.Show("Ya existe un permiso con ese nombre");
                        return;
                    }
                }

                treeView1.SelectedNode.Nodes.Add(p.Nombre);
                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode root = treeView1.Nodes.Add("Roles");
        }
    }
}
