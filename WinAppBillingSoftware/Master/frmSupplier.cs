using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppBillingSoftware.Master
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
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
                this.Width = (this.Parent.Width - 5);
                this.Height = (this.Parent.Height - 15);
                this.PointToScreen(new Point(0, 0));
            }
        }
    }
}
