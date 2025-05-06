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
    public partial class NCC : Form
    {
        private NCCBUS nccBUS = new NCCBUS();
        public NCC()
        {
            InitializeComponent();
        }

        private void NCC_Load(object sender, EventArgs e)
        {
            DataTable dt = nccBUS.LoadNCCall();
            dgvNCC.DataSource = dt;
            dgvNCC.ClearSelection();
        }

        private void dgvNCC_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvNCC.CurrentRow == null && dgvNCC.CurrentRow.Selected == false)
            {
                return;
            }
            else
            {
                txtMaNCC.Text = dgvNCC.CurrentRow.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dgvNCC.CurrentRow.Cells["TenNCC"].Value.ToString();
                txtSDT.Text = dgvNCC.CurrentRow.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = dgvNCC.CurrentRow.Cells["diachi"].Value.ToString();
                txtEmail.Text = dgvNCC.CurrentRow.Cells["email"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhaCungCapDTO nccDTO = new NhaCungCapDTO
            {
                TenNCC = txtTenNCC.Text,
                SDT = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                Email = txtEmail.Text
            };
            if (nccBUS.ValidateAddNCC(nccDTO))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NCC_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhaCungCapDTO nccDTO = new NhaCungCapDTO
            {
                MaNCC = Convert.ToInt32(txtMaNCC.Text),
            };
            if (nccBUS.ValidateCancelNCC(nccDTO))
            {
                MessageBox.Show("Hủy nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NCC_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Hủy nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhaCungCapDTO nccDTO = new NhaCungCapDTO
            {
                MaNCC = Convert.ToInt32(txtMaNCC.Text),
                TenNCC = txtTenNCC.Text,
                SDT = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                Email = txtEmail.Text
            };
            if (nccBUS.ValidateEditNCC(nccDTO))
            {
                MessageBox.Show("Sửa thông tin nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NCC_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMaNCC.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtTenNCC.Text = string.Empty;
            dgvNCC.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhaCungCapDTO nccDTO = new NhaCungCapDTO
            {
                TenNCC = txtSearch.Text
            };
            DataTable dt = nccBUS.ValidateSearchNCC(nccDTO);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp bạn cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dgvNCC.DataSource = dt;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
