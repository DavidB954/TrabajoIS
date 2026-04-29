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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        public void AbrirFormularios<T>() where T : Form, new()
        {
            foreach (Form F in this.MdiChildren)
            {
                if (F is T)
                {
                    F.BringToFront();
                    F.WindowState = FormWindowState.Maximized;
                    F.Show();
                    return;
                }
            }

            Form frm = new T();
            frm.MdiParent = this;
            frm.BringToFront();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }


        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void modulo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularios <frmModulo1>();
        }
    }
}
