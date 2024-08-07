using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the patient name");
                txtName.Focus();
                return;
            }

            if (txtIdNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Id name");
                txtIdNo.Focus();
                return;
            }

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-D1LT6IQ\SQLEXPRESS; Initial Catalog=CovidPatients; User ID=sa; Password=omollo13829";
            //conn.ConnectionString = @" Server = DESKTOP - D1LT6IQ\SQLEXPRESS; Database = CovidPatients; Integrated Security = True";
           
            conn.Open();

            int checkedValue = 0;
            if (chkIsActive.Checked) checkedValue = 1;

            string sql = "";
            sql = "INSERT INTO tblPatients(Name, IdNo, DOB, Gender, Country, IsActive) VALUES ('" + txtName.Text + "', " + txtIdNo.Text + ", '" + dtpDOB.Value.ToString("yyyyMMdd") + "', '" + cmbGender.Text + "', '" + txtCountry.Text + "', " + checkedValue + "   )   ";
                        
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Process Completed Sucessfully");

        }
    }
}
