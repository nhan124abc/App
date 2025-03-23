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
    public partial class Sale : Form
    {
       
        private HoaBUS hoaBUS = new HoaBUS();
        public Sale()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
           // UserDTO user = new UserDTO { Username = txtUsername.Text, Password = txtPassword.Text };
            DataTable dt = hoaBUS.LoadDataFlower();
            cbTen.DataSource = dt;
            cbTen.DisplayMember = "TenHoa"; 
            cbTen.ValueMember = "MaHoa";
            cbMa.DataSource = dt;
            cbMa.DisplayMember = "MaHoa";
            cbMa.ValueMember = "TenHoa";
            
        }

        private void cbMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rowview = cbMa.SelectedItem as DataRowView;
            if(cbMa.SelectedValue != null)
            {
                int ma = Convert.ToInt32( rowview["MaHoa"]);
                DataTable dt = (DataTable)cbMa.DataSource;
                DataRow[] rows = dt.Select($"MaHoa = {ma}");
                if (rows.Length > 0)
                {
                    cbTen.SelectedValue = ma;
                }
            }


        }

        private void cbTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rowview = cbTen.SelectedItem as DataRowView;
            if(cbTen.SelectedValue != null)
            {
                string ten = rowview["TenHoa"].ToString();
                DataTable dt=(DataTable)cbTen.DataSource;
                DataRow[] rows = dt.Select($"TenHoa = '{ten}'");
                if (rows.Length > 0)
                {
                    cbMa.SelectedValue = ten;
                }
                DataTable data = hoaBUS.LoadDataFlower();
              
                string tenhoa = rowview["TenHoa"].ToString();
                DataRow[] row = data.Select($"TenHoa = '{ten}'");
                
                decimal donGiaDecimal = Convert.ToDecimal(row[0]["Gia"]);
                float dongia = (float)donGiaDecimal;
                txtDonGia.Text = dongia.ToString();
            }
        }

        

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int soluong = Convert.ToInt32(txtSoLuong.Text);
            float dongia = float.Parse(txtDonGia.Text);
          
            txtTongTien.Text = (soluong * dongia).ToString();
        }
    }
}
