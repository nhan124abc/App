using BUS;
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
    public partial class ThongKe : Form
    {
        public HDBanBUS hdBUS = new HDBanBUS();
        public NhapHangBUS nhapBUS = new NhapHangBUS();
        public ThongKe()
        {
            InitializeComponent();
        }

        private void btnTKThang_Click(object sender, EventArgs e)
        {

        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            cbTke.SelectedItem = cbTke.Items[0];
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string loaiLoc = cbTke.SelectedItem.ToString();
            DateTime ngayChon =DateTime.Now;

            double tongTien = hdBUS.GetTotal(loaiLoc, ngayChon);
            rTBan.Text =  tongTien.ToString();
            double tongNhap = nhapBUS.GetTotalNhapHang(loaiLoc, ngayChon);
            rTNhap.Text = tongNhap.ToString();
            double loiNhuan = tongTien - tongNhap;
            rDThu.Text = loiNhuan.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
