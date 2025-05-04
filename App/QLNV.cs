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
    public partial class QLNV : Form
    {
        private UserBUS userBUS = new UserBUS();
        public QLNV()
        {
            InitializeComponent();
            dgvNV.AllowUserToAddRows = false;
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
           
            DataTable dt = userBUS.LoadNV();
            dgvNV.DataSource = dt;
            btnReset_Click(sender, e);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dgvNV_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvNV.CurrentRow != null && dgvNV.CurrentRow.Selected == false)
            {
                return;
            }
            txtMaNV.Text= dgvNV.CurrentRow.Cells["MaNV"].Value.ToString();
            txtHoten.Text = dgvNV.CurrentRow.Cells["TenNV"].Value.ToString();
            txtQuyenhan.Text = dgvNV.CurrentRow.Cells["QuyenHan"].Value.ToString();
            txtDiachi.Text = dgvNV.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvNV.CurrentRow.Cells["Email"].Value.ToString();
            txtSdt.Text = dgvNV.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            if (dgvNV.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam")
            {
                rNam.Checked = true;
            }
            else
            {
                rNu.Checked = true;
            }
            dtpNgaysinh.Value = Convert.ToDateTime(dgvNV.CurrentRow.Cells["NgaySinh"].Value.ToString());
            txtTK.Text = dgvNV.CurrentRow.Cells["TenTK"].Value.ToString();
            txtMK.Text = dgvNV.CurrentRow.Cells["MK"].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvNV.ClearSelection();
            if(dgvNV.CurrentRow.Selected == false)
            {
                txtSdt.Text = "";
                txtQuyenhan.Text = "";
                txtMaNV.Text = "";
                txtHoten.Text = "";
                txtEmail.Text = "";
                txtDiachi.Text = "";
                rNam.Checked = false;
                rNu.Checked = false;
                txtMK.Text = "";
                txtTK.Text = "";
                dtpNgaysinh.Value = DateTime.Now;
            }

        }

        private void btnEditNV_Click(object sender, EventArgs e)
        {
            if (dgvNV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
                
            UserDTO user = new UserDTO
            {
                TenNV = txtHoten.Text,
                ChucVu = txtQuyenhan.Text,
                DiaChi = txtDiachi.Text,
                Email = txtEmail.Text,
                SDT = txtSdt.Text,
                NgaySinh = dtpNgaysinh.Value,
                Username = txtTK.Text,
                Password = txtMK.Text,
                MaNV = Convert.ToInt32(txtMaNV.Text)

            };
            if (rNam.Checked)
            {
                user.GioiTinh = 1;
            }
            else
            {
                user.GioiTinh = 0;
            }
            if (userBUS.ValidateEditNV(user))
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
                DataTable dt = userBUS.LoadNV();
                dgvNV.DataSource = dt;
                btnReset_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên thất bại", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoten.Text) || string.IsNullOrEmpty(txtQuyenhan.Text) || string.IsNullOrEmpty(txtSdt.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTK.Text) || string.IsNullOrEmpty(txtMK.Text) || string.IsNullOrEmpty(txtDiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                return;
            };
            UserDTO user = new UserDTO
            {
                TenNV = txtHoten.Text,
                ChucVu = txtQuyenhan.Text,
                SDT = txtSdt.Text,
                Email = txtEmail.Text,
                Username = txtTK.Text,
                Password = txtMK.Text,
                DiaChi = txtDiachi.Text,
                GioiTinh = rNam.Checked ? 1 : 0,
                NgaySinh = dtpNgaysinh.Value
            };
            if(userBUS.ValidateAddEmployee(user))
            {
                MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại", "Thông báo", MessageBoxButtons.OK);
            }

            txtHoten.Text = string.Empty;
            txtQuyenhan.Text = string.Empty;
            txtSdt.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTK.Text = string.Empty;
            txtMK.Text = string.Empty;
            txtDiachi.Text = string.Empty;
            rNam.Checked = true;
            dtpNgaysinh.Value = DateTime.Now;
            DataTable dt = userBUS.LoadNV();
            dgvNV.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            UserDTO user = new UserDTO
            {
                MaNV = Convert.ToInt32(txtMaNV.Text)
            };
            if (userBUS.ValidateDeleteEmployee(user))
            {
                MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại", "Thông báo", MessageBoxButtons.OK);
            }
            txtMaNV.Text = string.Empty;
            txtHoten.Text = string.Empty;
            txtQuyenhan.Text = string.Empty;
            txtSdt.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTK.Text = string.Empty;
            txtMK.Text = string.Empty;
            txtDiachi.Text = string.Empty;
            rNam.Checked = true;
            dtpNgaysinh.Value = DateTime.Now;
            DataTable dt = userBUS.LoadNV();
            dgvNV.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == string.Empty)
            {
                dgvNV.DataSource = userBUS.LoadNV();
            }
            btnReset_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO
            {
                TenNV = txtSearch.Text
            };
            DataTable dt = userBUS.ValidateSearchEmployee(user);

            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có nhân viên bạn cần tìm!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                dgvNV.DataSource = dt;
            }
        }

    }
}
