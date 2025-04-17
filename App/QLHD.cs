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
    public partial class QLHD : Form
    {
        private CTHDBUS cthbus=new CTHDBUS();
        private HDBanBUS HDBUS = new HDBanBUS();
        public QLHD()
        {
            InitializeComponent();
        }

        private void btnVID_Click(object sender, EventArgs e)
        {
           
            int MaDH=Convert.ToInt32( dgvBill.CurrentRow.Cells["MaHoaDon"].Value);
            CTHDDTO cTHDDTO = new CTHDDTO {MaHD=MaDH };
            CTHD cTHD = new CTHD(cTHDDTO);
            this.Hide();
            cTHD.ShowDialog();
            this.Show();

        }

        private void QLHD_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = HDBUS.LoadDataHDBan();
            dgvBill.DataSource = dt;
        }
    }
}
