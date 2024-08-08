using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidProject
{
    public partial class frmLogin : Form
    {
        public bool SuccessfulLogin { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.SuccessfulLogin = false;

            // Ensuring the user has entered data

            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("User name required");
                txtUserName.Focus();
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Password required");
                txtUserName.Focus();
                return;
            }

            // The validation code to check user credentials goes here
            // if the validation is false you return

            this.SuccessfulLogin = true;

            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.SuccessfulLogin = false;


        }
    }
}
