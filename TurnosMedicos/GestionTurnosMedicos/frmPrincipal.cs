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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public void AbrirFormularios<T>() where T : Form, new ()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is T)
                {
                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized;
                    f.Show();
                    return;
                }
            }

            Form frm = new T();
            frm.BringToFront();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;

        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Sesion.Instancia().UsuarioActual.Nombre;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmLogin>();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmMenu>();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmUsuario>();
        }

        private void rolesYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmRolesPermisos>();
        }

    }
}
