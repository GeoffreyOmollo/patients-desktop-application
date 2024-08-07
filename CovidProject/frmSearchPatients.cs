﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CovidProject
{
    public partial class frmSearchPatients : Form
    {
        public frmSearchPatients()
        {
            InitializeComponent();
        }

        private void frmSearchPatients_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-D1LT6IQ\SQLEXPRESS; Initial Catalog=CovidPatients; User ID=sa; Password=omollo13829";
            //conn.ConnectionString = @" Server = DESKTOP - D1LT6IQ\SQLEXPRESS; Database = CovidPatients; Integrated Security = True";

            conn.Open();

            string sql = "";
            sql = "SELECT * FROM tblPatients";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read()) 
            {
                ListViewItem item = new ListViewItem(sqlDataReader[0].ToString());
                item.SubItems.Add(sqlDataReader[1].ToString());
                item.SubItems.Add(sqlDataReader[2].ToString());
                item.SubItems.Add(sqlDataReader[3].ToString());
                item.SubItems.Add(sqlDataReader[4].ToString());
                item.SubItems.Add(sqlDataReader[5].ToString());
                item.SubItems.Add(sqlDataReader[6].ToString());

                lvwList.Items.Add(item);
            }



            conn.Close();
        }
    }
}
