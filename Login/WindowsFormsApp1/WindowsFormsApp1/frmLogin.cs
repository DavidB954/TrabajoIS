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

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        BLL_Usuario bll_usuario = new BLL_Usuario();
        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            BE_LoginResultado resultado  = bll_usuario.LoginUsuario(email, password);

            MessageBox.Show(resultado.Mensaje);

            if (resultado.ExitoLogin == true)
            {
                frmMenu frm = new frmMenu();
                frm.Show();
                this.Hide();
            }


        }
    }
}
