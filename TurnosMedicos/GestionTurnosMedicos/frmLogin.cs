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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        BLL_Usuario bll_Usu = new BLL_Usuario();
        BE_LoginResultado Obj_Usuario = new BE_LoginResultado();

        public void LimpiarTextBox()
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Obj_Usuario = bll_Usu.ObtenerUsuarioPorEmail(txtEmail.Text, txtPassword.Text);

                if (Obj_Usuario.Usuario != null)
                {
                    //Para agarrar la sesion del singleton y guardar el usuario logueado
                    Sesion.Instancia().UsuarioActual = Obj_Usuario.Usuario;

                    frmPrincipal formP = new frmPrincipal();
                    formP.Show();
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
    }
}
