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
        private KHBUS khBUS = new KHBUS();
        private HDBanBUS hdBUS = new HDBanBUS();
        private CTHDBUS cthdBUS = new CTHDBUS();
        private double tongtien = 0;

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
           
            if (txtTenkh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng");
                return;
            }
            int.TryParse(cbMa.SelectedValue.ToString(), out int maHoa);
            DataTable dt = hoaBUS.LoadDataFlower();
            int data = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["SoLuongTon"]) : 0;
            int soluong = (int)txtSoluong.Value;
            if (soluong > data)
            {
                MessageBox.Show("Số lượng hoa chỉ còn " + data);
                return;
            }
            else
            {
                if (soluong <= 0)
                {
                    MessageBox.Show("Số lượng hoa phải lớn hơn 0");
                    return;
                }
                else
                {
                    float dongia = float.Parse(txtDonGia.Text);

                    txtTongTien.Text = (soluong * dongia).ToString();

                }

            }
            int flag = 0;
            if(txtTongTien.Text != "")
            {
                tongtien += Convert.ToDouble(txtTongTien.Text);
            }
           
            txtTongHD.Text = tongtien.ToString();
            if (dgvDH.RowCount>1)
            {
              
                foreach (DataGridViewRow row in dgvDH.Rows)
                {
                    if (row.Cells["colMaSP"].Value != null && cbTen.SelectedValue != null &&
                        row.Cells["colMaSP"].Value.ToString() == cbTen.SelectedValue.ToString())
                    {
                        int.TryParse(txtSoluong.Value.ToString(), out int number);

                        int a = Convert.ToInt32(row.Cells["colSoLuong"].Value) + number;
                        float b =a * float.Parse(txtDonGia.Text);
                        row.Cells["colSoLuong"].Value = a;
                        row.Cells["colTongTien"].Value = b;
                        flag = 1;
                    }
                    tongtien += Convert.ToDouble(row.Cells["colTongTien"].Value);
                }

                if (flag == 0)
                {
                    dgvDH.Rows.Add(cbTen.SelectedValue.ToString(), cbMa.SelectedValue.ToString(), txtSoluong.Value, txtDonGia.Text, txtTongTien.Text);
                }

            }
            else
            {
                dgvDH.Rows.Add(cbTen.SelectedValue.ToString(), cbMa.SelectedValue.ToString(), txtSoluong.Value, txtDonGia.Text, txtTongTien.Text);
            }
            
        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {
            KHDTO kh = new KHDTO { SDT = txtsdt.Text, TenKH = txtTenkh.Text };
            DataTable dt = khBUS.LoadDataKHInput(kh);
            if (dt.Rows.Count > 0)
            {
                txtTenkh.Text = dt.Rows[0]["TenKH"].ToString();
                txtMKH.Text = dt.Rows[0]["MaKH"].ToString();
            }
            else
            {
                //Them khach hang vao

            }

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            HDBanDTO hd = new HDBanDTO { MaKH = Convert.ToInt32(txtMKH.Text), NgayBan = DateTime.Now, TongTien = Convert.ToInt32(txtTongTien.Text), TrangThai = "Đã Thanh Toán" };
            CTHDDTO cthd = new CTHDDTO();
            
            if (hdBUS.ValidateAddHDBan(hd)!=0)
            {
                int a=hdBUS.ValidateAddHDBan(hd);
                foreach (DataGridViewRow row in dgvDH.Rows)
                {
                    cthd.MaHD = a;
                    cthd.MaHoa = Convert.ToInt32(row.Cells["colMaSP"].Value);
                    cthd.SoLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    cthd.DonGia = Convert.ToInt32(row.Cells["colDonGia"].Value);
                    cthdBUS.ValidateAddCTHD(cthd);
                }
                MessageBox.Show("Thanh toán thành công");
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại");
                MessageBox.Show("Thanh toán thất bại"+ hdBUS.ValidateAddHDBan(hd));
            }
        }

    }
}
