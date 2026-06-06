using BE;
using BLL;
using System;
using Servicios;
using System.Windows.Forms;

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
                    // Si DVV no coincide → verificar fila por fila
                    var corruptos = bll_Usu.VerificarUsuarios();

                    MessageBox.Show("Tabla Usuario corrupta. Se abrirá el detalle en Seguridad.");

                    frmSeguridad frm = new frmSeguridad();
                    frm.MdiParent = this;
                    frm.WindowState = FormWindowState.Maximized;

                    frm.MostrarCorruptos(corruptos);

                    frm.Show();

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
