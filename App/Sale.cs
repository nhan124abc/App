﻿using BUS;
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
        private bool KH= false;

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
            txtTongTien.Text = "0";
            txtTongHD.Text = "0";
            txtTienNhan.Text = "0";
            txtTienThua.Text = "0";
           
        }

        private void cbMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDH.SelectedRows.Count > 0)
            {
                cbMa.Enabled = false;
                return;
            }
            var rowview = cbMa.SelectedItem as DataRowView;
            if (cbMa.SelectedValue != null)
            {
                int ma = Convert.ToInt32(rowview["MaHoa"]);
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

                if (dgvDH.SelectedRows.Count > 0)
                {
                cbTen.Enabled = false;
                return;
                }
                var rowview = cbTen.SelectedItem as DataRowView;
                if (cbTen.SelectedValue != null)
                {
                    string ten = rowview["TenHoa"].ToString();
                    DataTable dt = (DataTable)cbTen.DataSource;
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
            if (dgvDH.SelectedRows.Count > 0)
            {
                MessageBox.Show("Vui lòng chọn chức năng sửa. ");
                tongtien+=Convert.ToDouble( dgvDH.CurrentRow.Cells["colTongTien"].Value.ToString());
                txtTongHD.Text = tongtien.ToString();
                dgvDH.ClearSelection();
                return;
            }
            if (txtTenkh.Text == ""||txtsdt.Text=="")
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
            }

            float dongia = float.Parse(txtDonGia.Text);
            float tongTienHoa = soluong * dongia;
            tongtien += tongTienHoa;

            int flag = 0;

            if (dgvDH.RowCount > 1)
            {
                foreach (DataGridViewRow row in dgvDH.Rows)
                {
                    if (row.Cells["colMaSP"].Value != null && cbTen.SelectedValue != null &&
                        row.Cells["colMaSP"].Value.ToString() == cbTen.SelectedValue.ToString())
                    {
                        int.TryParse(txtSoluong.Value.ToString(), out int number);

                        int a = Convert.ToInt32(row.Cells["colSoLuong"].Value) + number;
                        float b = a * float.Parse(txtDonGia.Text);
                        row.Cells["colSoLuong"].Value = a;
                        row.Cells["colTongTien"].Value = b;
                        flag = 1;
                    }
                }

                if (flag == 0)
                {
                    dgvDH.Rows.Add(cbTen.SelectedValue.ToString(), cbMa.SelectedValue.ToString(), txtSoluong.Value, txtDonGia.Text, tongTienHoa.ToString());
                }
            }
            else
            {
                dgvDH.Rows.Add(cbTen.SelectedValue.ToString(), cbMa.SelectedValue.ToString(), txtSoluong.Value, txtDonGia.Text, tongTienHoa.ToString());
            }

            txtTongHD.Text = tongtien.ToString();
            txtSoluong.Value = 0;
            txtTongTien.Text = "0";
            dgvDH.ClearSelection();
        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {
            KHDTO kh = new KHDTO { SDT = txtsdt.Text, TenKH = txtTenkh.Text };
            DataTable dt = khBUS.LoadDataKHInput(kh);
            if (dt.Rows.Count > 0)
            {
                txtTenkh.Text = dt.Rows[0]["TenKH"].ToString();
                txtMKH.Text = dt.Rows[0]["MaKH"].ToString();
                KH = true;
            }
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            KHDTO kh = new KHDTO { SDT = txtsdt.Text, TenKH = txtTenkh.Text };
            if (KH==false)
            {
                khBUS.ValidateAddKH(kh);
            }
            int MAKH=khBUS.ValidateGetMaKH(kh);
            HDBanDTO hd = new HDBanDTO { MaKH = MAKH, NgayBan = DateTime.Now, TongTien = Convert.ToInt32(txtTongHD.Text), TrangThai = "Đã Thanh Toán" };
            CTHDDTO cthd = new CTHDDTO();

            if (hdBUS.ValidateAddHDBan(hd) )
            {
               
                int a = hdBUS.ValidateGetMaHD();
                foreach (DataGridViewRow row in dgvDH.Rows)
                {
                    if (row.Cells["colMaSP"].Value == null)
                    {
                        break;
                    }
                    cthd.MaHD = a;
                   int mahoa = Convert.ToInt32(row.Cells["colMaSP"].Value);
                    cthd.MaHoa = mahoa;
                    MessageBox.Show("MaHoa: " + cthd.MaHoa);
                    int soluong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    cthd.SoLuong =soluong;
                    int dongia = Convert.ToInt32(row.Cells["colDonGia"].Value);
                    cthd.DonGia = dongia;
                    cthdBUS.ValidateAddCTHD(cthd);
                }
                MessageBox.Show("Thanh toán thành công");
                return;
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại");
                return;
            }
        }

        private void txtSoluong_ValueChanged(object sender, EventArgs e)
        {
            float dongia = float.Parse(txtDonGia.Text);
            int soluong = (int)txtSoluong.Value;

            txtTongTien.Text = (soluong * dongia).ToString();
        }

        private void txtTienNhan_Enter(object sender, EventArgs e)
        {
            if(txtTienNhan.Text == "0")
            {
                txtTienNhan.Text = "";
            }
        }

        private void txtTienNhan_Leave(object sender, EventArgs e)
        {
            if(txtTienNhan.Text == "")
            {
                txtTienNhan.Text = "0";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbMa.Text = "1";
            txtSoluong.Value = 0;
            txtMKH.Text = "";
            txtsdt.Text = "";
            txtTenkh.Text = "";
            txtTienNhan.Text = "0";
            txtTongHD.Text = "0";
            txtTongTien.Text = "0";
            txtTienThua.Text = "0";
            dgvDH.Rows.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvDH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa");
                return;
            }
            else
            {
                dgvDH.CurrentRow.Cells["colSoLuong"].Value = txtSoluong.Value;
                dgvDH.CurrentRow.Cells["colTongTien"].Value = txtTongTien.Text;
                tongtien += Convert.ToDouble(txtTongTien.Text);
                txtTongHD.Text = tongtien.ToString();
            }
            txtSoluong.Value = 0;
            txtTongTien.Text = "0";
            cbMa.Text = "1";
            dgvDH.ClearSelection();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dgvDH.SelectedRows)
                {
                    dgvDH.Rows.Remove(row);
                }
                txtSoluong.Value = 0;
                txtTongTien.Text = "0";
                cbMa.Text = "1";
                txtTongHD.Text = tongtien.ToString();
            }
        }

        private void dgvDH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDH.SelectedRows.Count == 0)
            {
                return;
            }
            txtSoluong.Value = Convert.ToDecimal( dgvDH.CurrentRow.Cells["colSoLuong"].Value);
            cbMa.Text=dgvDH.CurrentRow.Cells["colMaSP"].Value.ToString();
            txtTongTien.Text = dgvDH.CurrentRow.Cells["colTongTien"].Value.ToString();
            tongtien -= Convert.ToDouble(dgvDH.CurrentRow.Cells["colTongTien"].Value);
        }
    }
}
