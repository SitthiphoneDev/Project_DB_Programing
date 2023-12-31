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
    public partial class UnitModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        Unit brand;
        public UnitModule(Unit br)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            brand = br;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // To insert unit name to unit table 
            try
            {
                if (MessageBox.Show("ທ່ານແນ່ໃຈບໍ່ວ່າຕ້ອງການບັນທຶກ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tbBrand(brand)VALUES(@brand)", cn);
                    cm.Parameters.AddWithValue("@brand", txtBrand.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("ບັນທຶກສຳເລັດແລ້ວ.", "POS");
                    Clear();
                    brand.LoadBrand();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        public void Clear()
        {
            txtBrand.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtBrand.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update brand name
            if (MessageBox.Show("ທ່ານແນ່ໃຈບໍ່ວ່າຕ້ອງການອັບເດດ?", "Update Record!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new SqlCommand("UPDATE tbBrand SET brand = @brand WHERE id LIKE'" + lblId.Text + "'", cn);
                cm.Parameters.AddWithValue("@brand", txtBrand.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("ອັບເດດສຳເລັດແລ້ວ.", "POS");
                Clear();
                this.Dispose();// To close this form after update data
            }
        }

        private void UnitModule_Load(object sender, EventArgs e)
        {

        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
