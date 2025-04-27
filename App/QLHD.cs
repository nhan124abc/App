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
            dgvBill.AllowUserToAddRows = false;
        }

        private void btnVID_Click(object sender, EventArgs e)
        {
           
            int MaDH=Convert.ToInt32( dgvBill.CurrentRow.Cells["MaHD"].Value);
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
        

        private void dgvBill_SelectionChanged(object sender, EventArgs e)
        {
            
           if(dgvBill.CurrentRow != null && dgvBill.CurrentRow.Selected == false)
            {
                return;
            }
            txtIC.Text = dgvBill.CurrentRow.Cells["MaHD"].Value.ToString();
            txtCC.Text = dgvBill.CurrentRow.Cells["MaKH"].Value.ToString(); 
            dateTimePicker1.Value = Convert.ToDateTime(dgvBill.CurrentRow.Cells["NgayLap"].Value);
            txtToTal.Text = dgvBill.CurrentRow.Cells["TongTien"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvBill.ClearSelection();

            if(dgvBill.CurrentCell.Selected == false)
            {
                txtIC.Text = "";
                txtCC.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                txtToTal.Text = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            this.Hide();
            sale.ShowDialog();
            this.Show();
        }
    }
}
