﻿using System;
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

            validateLoginUser();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validateLoginUser();
            }
        }

        private void validateLoginUser()
        {
            if (string.IsNullOrEmpty(txtUserName.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("User & Pass Word can't be blank", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("User Can't be blank", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password Can't be blank", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (txtUserName.Text.Trim().ToLower() == "admin" && txtPassword.Text.Trim() == "12345")
            {
                this.Hide();
                mdiMainPage mdiMainPage = new mdiMainPage();
                mdiMainPage.Show();               
            }
            else
            {
                MessageBox.Show("Invalid User", "Validation Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
