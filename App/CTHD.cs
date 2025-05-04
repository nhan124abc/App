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
    public partial class CTHD : Form
    {
        private CTHDDTO chitiet=new CTHDDTO();
        private CTHDBUS chitietBUS=new CTHDBUS();
        public CTHD()
        {
            InitializeComponent();
            dgvID.AllowUserToAddRows = false;
        }
        public CTHD(CTHDDTO cTHDDTO)
        {
            InitializeComponent();
            chitiet=cTHDDTO;
        }

        private void CTHD_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt=chitietBUS.LoadCTHDInput(chitiet);
            dgvID.DataSource = dt;
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
