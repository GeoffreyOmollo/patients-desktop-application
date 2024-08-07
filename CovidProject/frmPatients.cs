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
        int currentId = 0;
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
            currentId = 0;

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

            if (currentId == 0)
            {
                sql = "INSERT INTO tblPatients(Name, IdNo, DOB, Gender, Country, IsActive) VALUES ('" + txtName.Text + "', " + txtIdNo.Text + ", '" + dtpDOB.Value.ToString("yyyyMMdd") + "', '" + cmbGender.Text + "', '" + txtCountry.Text + "', " + checkedValue + "   )   ";
            }
            else
            {
                sql = "UPDATE tblPatients SET Name = '" + txtName.Text + "', IdNo = " + txtIdNo.Text + ", DOB = '" + dtpDOB.Value.ToString("yyyyMMdd") + "', Gender = '" + cmbGender.Text + "', Country = '" + txtCountry.Text + "', IsActive = " + checkedValue + " WHERE PatientId = " + currentId;
            }

            MessageBox.Show(sql);

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Process Completed Sucessfully");

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            frmSearchPatients frm = new frmSearchPatients();
            frm.ShowDialog();
            displayInfo(frm.selectedInteger);
            currentId = frm.selectedInteger;
        }

        private void displayInfo(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-D1LT6IQ\SQLEXPRESS; Initial Catalog=CovidPatients; User ID=sa; Password=omollo13829";
            //conn.ConnectionString = @" Server = DESKTOP - D1LT6IQ\SQLEXPRESS; Database = CovidPatients; Integrated Security = True";

            conn.Open();

            string sql = "";
            sql = "SELECT * FROM tblPatients WHERE PatientId = " + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.Read())
            {

                txtName.Text = sqlDataReader[1].ToString();
                txtIdNo.Text = sqlDataReader[2].ToString();
                dtpDOB.Value = DateTime.Parse(sqlDataReader[3].ToString());
                cmbGender.Text = sqlDataReader[4].ToString();
                txtCountry.Text = sqlDataReader[5].ToString();
                chkIsActive.Checked = bool.Parse(sqlDataReader[6].ToString());

            }

            conn.Close();
        }

    }
}
