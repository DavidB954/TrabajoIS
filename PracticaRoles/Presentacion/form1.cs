using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void form1_Load(object sender, EventArgs e)
        {

        }

        public void AbrirFormularios<T>() where T:Form, new()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is T)
                {
                    frm.BringToFront();
                    frm.WindowState=FormWindowState.Maximized;
                    frm.Show();
                    return;
                }
            }

            Form f = new T();
            f.BringToFront();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
            f.MdiParent = this;
        }

        private void gestionRolesYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmPermisos>();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmRoles>();
        }

        private void asignacionDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmUsuarios>();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmUsuarios>();
        }
    }
}
