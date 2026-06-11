using Servicios;
using System;
using System.Linq;
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
            Sesion Sesion = Sesion.Instancia();
            lblUsuario.Text = Sesion.UsuarioActual.Nombre;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmLogin>();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmBitacora>();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesion.Instancia().CerrarSesion();
            foreach (Form form in this.MdiChildren)
                form.Close();

            // Ocultar el MDI parent
            frmLogin login = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
            if (login != null)
            {
                login.Show();
            }
            else
            {
                new frmLogin().Show();
            }

            this.Close(); // ← cerrar el principal 
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmUsuario>();
        }

        private void rolesYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmRolesPermisos>();
        }

        private void gestionSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios<frmSeguridad>();
        }
    }
}
