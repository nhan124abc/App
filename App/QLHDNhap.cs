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
    public partial class QLHDNhap : Form
    {
        private NhapHangBUS nhapHangBUS = new NhapHangBUS();
        public QLHDNhap()
        {
            InitializeComponent();
            dgvNH.AllowUserToAddRows = false;
        }

        private void QLHDNhap_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt= nhapHangBUS.LoadDataNhapHang();
            dgvNH.DataSource = dt;
            
        }


        private void dgvNH_SelectionChanged(object sender, EventArgs e)
        {
           
            if (dgvNH.CurrentRow != null)
            {
                txtMaNH.Text = dgvNH.CurrentRow.Cells["MaNH"].Value.ToString();
                txtNCC.Text = dgvNH.CurrentRow.Cells["MaNCC"].Value.ToString();
                txtMaNV.Text = dgvNH.CurrentRow.Cells["MaNV"].Value.ToString();
                dtpNgayNhap.Text = dgvNH.CurrentRow.Cells["NgayNhap"].Value.ToString();
                txtToTal.Text = dgvNH.CurrentRow.Cells["TongTien"].Value.ToString();
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtToTal.Text = "";
            txtMaNH.Text = "";
            txtNCC.Text = "";
            txtMaNV.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            txtSearch.Text = "";
            dgvNH.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NH nH = new NH();
            this.Hide();
            nH.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NhapHangDTO nh = new NhapHangDTO { MaHDN=Convert.ToInt32( txtMaNH.Text)};
            nhapHangBUS.CancelNhapHang(nh);
            QLHDNhap_Load(sender, e);
        }

        private void btnCTNH_Click(object sender, EventArgs e)
        {
            CTNH cTNH = new CTNH(new NhapHangDTO { MaHDN = Convert.ToInt32(txtMaNH.Text) });
            this.Hide();
            cTNH.ShowDialog();
            this.Show();
        }

    }
}
