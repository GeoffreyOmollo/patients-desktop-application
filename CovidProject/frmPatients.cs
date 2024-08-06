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
    public partial class frmPatients : Form
    {
        public frmPatients()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtIdNo.Text = "";
            dtpDOB.Value = DateTime.Today;
            cmbGender.SelectedIndex = -1;
            txtCountry.Text = "";
            chkIsActive.Checked = true;
            txtName.Focus();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
