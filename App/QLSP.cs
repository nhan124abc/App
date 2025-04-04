﻿using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class QLSP : Form
    {
        private HoaBUS hoaBUS = new HoaBUS();
        public QLSP()
        {
            InitializeComponent();
        }
        private void QLSP_Load(object sender, EventArgs e)
        {
            DataTable dt = hoaBUS.LoadDataFlower();
            dgvFlowers.DataSource = dt; 
            btnRefresh_Click(sender, e);

        }
        private void dgvFlowers_SelectionChanged(object sender, EventArgs e)
        {
            txtIdFl.Text = dgvFlowers.CurrentRow.Cells["MaHoa"].Value.ToString();
            txtNameFl.Text = dgvFlowers.CurrentRow.Cells["TenHoa"].Value.ToString();
            txtQuantity.Text = dgvFlowers.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtSP.Text = dgvFlowers.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtDescribe.Text = dgvFlowers.CurrentRow.Cells["MoTa"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HoaDTO flowers = new HoaDTO()
            {
                TenHoa = txtNameFl.Text,
                MoTa = txtDescribe.Text
            };

            if (hoaBUS.AddDataFlower(flowers))
            {
                MessageBox.Show("Thêm hoa thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Thêm hoa không thành công", "Thông báo", MessageBoxButtons.OK);
            }

            txtNameFl.Text = string.Empty;
            txtDescribe.Text = string.Empty;

            DataTable dt = hoaBUS.LoadDataFlower();
            dgvFlowers.DataSource = dt;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvFlowers.ClearSelection();

            if(dgvFlowers.CurrentRow.Selected == false)
            {
                txtIdFl.Text = string.Empty;
                txtNameFl.Text = string.Empty;
                txtSP.Text = string.Empty;
                txtPP.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtDescribe.Text = string.Empty;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HoaDTO flowers = new HoaDTO()
            {
                MaHoa = Convert.ToInt32(txtIdFl.Text)
            };

            if(hoaBUS.DeleteDataFlower(flowers))
            {
                MessageBox.Show("Hủy hoa thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Hủy hoa không thành công", "Thông báo", MessageBoxButtons.OK);
            }

            txtIdFl.Text = string.Empty;
            txtNameFl.Text = string.Empty;
            txtSP.Text = string.Empty;
            txtPP.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDescribe.Text = string.Empty;

            DataTable dt = hoaBUS.LoadDataFlower();
            dgvFlowers.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            HoaDTO flowers = new HoaDTO()
            {
                MaHoa= Convert.ToInt32(txtIdFl.Text),
                TenHoa = txtNameFl.Text,
                MoTa = txtDescribe.Text
            };

            if(hoaBUS.InsertDataFlower(flowers))
            {
                MessageBox.Show("Sửa thông tin hoa thành công", "Thông báo", MessageBoxButtons.OK);
                DataTable dt = hoaBUS.LoadDataFlower();
                dgvFlowers.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Sửa thông tin hoa không thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
