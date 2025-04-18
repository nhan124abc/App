using BUS;
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
    public partial class QLKH : Form
    {
        private KHBUS KHBUS = new KHBUS();
        public QLKH()
        {
            InitializeComponent();
        }

        private void QLKH_Load(object sender, EventArgs e)
        {
            DataTable dt = KHBUS.LoadDataKH();
            dgvInvoice.DataSource = dt;
            btnRefresh_Click(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInvoice_SelectionChanged(object sender, EventArgs e)
        {
            txtCC.Text = dgvInvoice.CurrentRow.Cells["MaKH"].Value.ToString();
            txtCN.Text = dgvInvoice.CurrentRow.Cells["TenKH"].Value.ToString();
            txtNP.Text = dgvInvoice.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvInvoice.ClearSelection();
            if(dgvInvoice.CurrentRow.Selected ==  false)
            {
                txtCC.Text = "";
                txtCN.Text = "";
                txtNP.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KHDTO khDTO = new KHDTO
            {
                TenKH = txtCN.Text,
                SDT = txtNP.Text
            };

            if(KHBUS.ValidateAddKH(khDTO))
            {
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Xóa khách hàng không thành công", "Thông báo", MessageBoxButtons.OK);
            }

            txtCN.Text = string.Empty;
            txtNP.Text = string.Empty;

            DataTable dt = KHBUS.LoadDataKH();
            dgvInvoice.DataSource = dt;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            KHDTO khDTO = new KHDTO
            {
                MaKH = Convert.ToInt32(txtCC.Text),
                TenKH = txtCN.Text,
                SDT = txtNP.Text
            };

            if (KHBUS.ValidateEditKH(khDTO))
            {
                MessageBox.Show("Sừa khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
                DataTable dt = KHBUS.LoadDataKH();
                dgvInvoice.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Sửa khách hàng không thành công", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            KHDTO khDTO = new KHDTO
            {
                TenKH = txtSearch.Text
            };

            DataTable dt = KHBUS.ValadateSearchKH(khDTO);

            if(dt.Rows.Count == 0) 
            {
                MessageBox.Show("Không có khách hàng bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                dgvInvoice.DataSource = dt;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (txtSearch.Text == string.Empty)
            {
                dgvInvoice.DataSource = KHBUS.LoadDataKH();
                btnRefresh_Click(sender, e);
            }
        }
    }
}
