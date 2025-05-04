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
            dgvInvoice.AllowUserToAddRows = false;

        }

        private void QLKH_Load(object sender, EventArgs e)
        {
            DataTable dt = KHBUS.LoadDataKH();
            dgvInvoice.DataSource = dt;
            btnRefresh_Click(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dgvInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoice.CurrentRow == null)
                return;
            txtCC.Text = dgvInvoice.CurrentRow.Cells["MaKH"].Value.ToString();
            txtCN.Text = dgvInvoice.CurrentRow.Cells["TenKH"].Value.ToString();
            txtNP.Text = dgvInvoice.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvInvoice.ClearSelection();
            txtCC.Text = "";
            txtCN.Text = "";
            txtNP.Text = "";
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để hủy", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            int MaKH = Convert.ToInt32(dgvInvoice.CurrentRow.Cells["MaKH"].Value);
            KHDTO khDTO = new KHDTO { MaKH = MaKH };
            if (KHBUS.ValidateCancelKH(khDTO))
            {
                MessageBox.Show("Hủy khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Hủy khách hàng không thành công", "Thông báo", MessageBoxButtons.OK);
            }
            QLKH_Load(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCN.Text) || string.IsNullOrEmpty(txtNP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                return;
            }
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
            if (dgvInvoice.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
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
