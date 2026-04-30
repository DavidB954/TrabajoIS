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
    public partial class frmModulo1 : Form
    {
        public frmModulo1()
        {
            InitializeComponent();
        }
        BE_Usuario usuario = new BE_Usuario();
        BLL_Usuario bll_usuario = new BLL_Usuario();

        public void LimpiarTxt()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Email = txtEmail.Text;
            usuario.HashPassword = txtPassword.Text;

            bll_usuario.AgregarUsuario(usuario);

            LimpiarTxt();
        }
    }
}
