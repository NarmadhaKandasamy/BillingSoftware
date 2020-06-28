using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAppBillingSoftware.Master;

namespace WinAppBillingSoftware.Admin
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.ToLower() == "admin" && txtPassword.Text == "12345")
            {
                this.Hide();
                frmMainPage frmMainPage = new frmMainPage();
                frmMainPage.Show();
            }
            else
            {
                MessageBox.Show("Invalid User", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
