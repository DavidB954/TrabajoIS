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
        BE_Usuario usuario = new BE_Usuario();
        
              
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = bll_Usu.VerificarUsuario(txtUsuario.Text, txtPassword.Text);

                if (usuario != null)
                {
                    Sesion.Instancia().UsuarioActual = usuario; 
                    MessageBox.Show($"Bienvenido {usuario.Nombre}");

                    frmPrincipal formPrincipal = new frmPrincipal();
                    formPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrectos");
                    txtPassword.Clear();
                    txtUsuario.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                
            }
            
        }
    }
}
