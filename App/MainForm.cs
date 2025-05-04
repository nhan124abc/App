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
    public partial class MainForm : Form
    {
        private int MaNV;   
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(int MaNV)
        {
            InitializeComponent();
            this.MaNV = MaNV;
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            Sale mainForm = new Sale();
            this.Hide();
            mainForm.ShowDialog();
           this.Show();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            QLNV mainForm = new QLNV();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            QLSP mainForm = new QLSP();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLHD mainForm = new QLHD();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            NH mainForm = new NH(MaNV);
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            QLKH mainForm = new QLKH();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void btnQLHDNhap_Click(object sender, EventArgs e)
        {
            QLHDNhap mainForm = new QLHDNhap();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe thongKe = new ThongKe();
            this.Hide();
            thongKe.ShowDialog();
            this.Show();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            NCC mainForm = new NCC();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }
    }
}
