using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BillingSoftware.ClassModels;
using BillingSoftware.ClassServices;

namespace WinAppBillingSoftware.Master
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

            customer.CustCode = cBCode.Text;
            customer.CustName = txtName.Text;
            customer.ContactName = txtContactName.Text;
            customer.Address1 = txtAdd1.Text;
            customer.Address2 = txtAdd2.Text;
            customer.City = txtCity.Text;
            customer.PostalCode = txtPostalcode.Text;
            customer.Mobile = txtMobile.Text;
            customer.Phone = txtPhoneno.Text;

            CustomerManager customerManager = new CustomerManager();
            lbCustId.Text= customerManager.Insert(customer).ToString();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            if (!this.IsMdiChild)
            {
                this.WindowState = FormWindowState.Normal;
                this.Width = (Screen.PrimaryScreen.Bounds.Width - 200);
                this.Height = (Screen.PrimaryScreen.Bounds.Height - 200);
            }
            else
            {
                //this.WindowState = FormWindowState.Maximized;
                this.Width = (this.Parent.Width-5);
                this.Height = (this.Parent.Height-15);
                this.PointToScreen(new Point(0, 0));
            }
        }
    }
}
