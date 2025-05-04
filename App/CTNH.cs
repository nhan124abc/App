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
    public partial class CTNH : Form
    {

        private NhapHangDTO nhapHangDTO = new NhapHangDTO();
        private CTHDNBUS ctnhBUS = new CTHDNBUS();
        public CTNH(NhapHangDTO nh)
        {
            nhapHangDTO = nh;
            InitializeComponent();
            dgvCTNH.AllowUserToAddRows = false;
        }
        public CTNH()
        {
            InitializeComponent();
        }

        private void CTNH_Load(object sender, EventArgs e)
        {
            dgvCTNH.DataSource = ctnhBUS.LoadCTHDNInput(nhapHangDTO);
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
