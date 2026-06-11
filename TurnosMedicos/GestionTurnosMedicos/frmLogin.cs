using BE;
using BLL;
using System;
using Servicios;
using System.Windows.Forms;
using System.Windows.Documents.DocumentStructures;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using BE.Composite;
using System.Linq;

namespace GestionTurnosMedicos
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        BLL_Usuario bll_Usu = new BLL_Usuario();
        BE_LoginResultado Obj_Usuario = new BE_LoginResultado();
        BLL_DVV bll_dvv = new BLL_DVV();
        BLL_Roles bll_roles = new BLL_Roles();

        public void LimpiarTextBox()
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                bool integra = bll_dvv.VerificarIntegridad("Usuario");

                if (!integra)
                {
                    if (EsUsuarioEmergencia(txtEmail.Text, txtPassword.Text))
                    {
                        // Si DVV no coincide → verificar fila por fila
                        var corruptos = bll_Usu.VerificarUsuarios();

                        MessageBox.Show("Tabla Usuario corrupta. Se abrirá el detalle en Seguridad.");

                        frmSeguridad frm = new frmSeguridad();

                        frm.WindowState = FormWindowState.Maximized;

                        frm.MostrarCorruptos(corruptos);

                        frm.Show();
                    }



                    BE_LoginResultado resultado = bll_Usu.ObtenerUsuarioPorEmail(txtEmail.Text, txtPassword.Text);

                    if (resultado.Usuario != null && EsAdministrador(resultado.Usuario))
                    {
                        // Si DVV no coincide → verificar fila por fila
                        var corruptos = bll_Usu.VerificarUsuarios();

                        MessageBox.Show("Tabla Usuario corrupta. Se abrirá el detalle en Seguridad.");

                        frmSeguridad frm = new frmSeguridad();

                        frm.WindowState = FormWindowState.Maximized;

                        frm.MostrarCorruptos(corruptos);

                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("El sistema detecto un problema de integridad. \nContacte al Administrador", "Error de integridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    return;
                }

               

                Obj_Usuario = bll_Usu.ObtenerUsuarioPorEmail(txtEmail.Text, txtPassword.Text);

                if (Obj_Usuario.Usuario != null)
                {
                    //Para agarrar la sesion del singleton y guardar el usuario logueado
                    Sesion Sesion = Sesion.Instancia();
                    
                    Sesion.UsuarioActual = Obj_Usuario.Usuario;

                    frmPrincipal formP = new frmPrincipal();
                    formP.Show();

                    this.Hide();

                    LimpiarTextBox();
                }
                else
                {
                    MessageBox.Show(Obj_Usuario.Mensaje);
                    LimpiarTextBox();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                
            }
            
        }

        private bool EsUsuarioEmergencia(string email, string password)
        {
            const string Email_Emergencia = "admin@sistema.com";
            const string Password_Emergencia = "B48728584C9A1E68291C83CA26696090A51EEB435BB207009969D1743F4BA397";

            return email == Email_Emergencia && HashHelper.GenerarHash(password) == Password_Emergencia;
        }

        private bool EsAdministrador(BE_Usuario usuario)
        {
            List<RolComposite> roles = bll_roles.ObtenerRolesDeUsuario(usuario.IdUsuario);

            return roles.Any(r => r.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase));

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
