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

namespace POSales
{
    public partial class Dashboard : Form
    {
        SqlConnection cn = new SqlConnection();        
        DBConnect dbcon = new DBConnect();

        public Dashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string sdate = DateTime.Now.ToString("yyyy-MM-dd"); // ใช้ yyyy-MM-dd สำหรับแปลงข้อมูล date ให้ถูกต้อง
            lblDalySale.Text = dbcon.ExtractData("SELECT ISNULL(SUM(total),0) AS total FROM tbCart WHERE status LIKE 'Sold' AND sdate BETWEEN '" + sdate + " 00:00:00' AND '" + sdate + " 23:59:59'").ToString("#,##0.00");
            lblTotalProduct.Text = dbcon.ExtractData("SELECT COUNT(*) FROM tbProduct").ToString("#,##0");
            lblStockOnHand.Text = dbcon.ExtractData("SELECT ISNULL(SUM(qty), 0) AS qty FROM tbProduct").ToString("#,##0");
            lblCriticalItems.Text = dbcon.ExtractData("SELECT COUNT(*) FROM vwCriticalItems").ToString("#,##0"); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
