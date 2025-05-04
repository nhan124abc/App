using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class NH : Form
    {
        private HoaBUS hoaBUS = new HoaBUS();
        private NhapHangBUS nhBUS = new NhapHangBUS();
        private NCCBUS nccBUS = new NCCBUS();
        private CTHDNDTO ctnhDTO = new CTHDNDTO();
        private NhapHangDTO NHang = new NhapHangDTO();
        private CTHDNBUS ctnhBUS = new CTHDNBUS();
        private float tongtien = 0;
        private int manv;
        public NH()
        {
            InitializeComponent();
            manv = 1;
            dgvNhapHang.AllowUserToAddRows = false;
        }
        public NH(int manv)
        {
            InitializeComponent();
            this.manv = manv;
        }
        private void NH_Load(object sender, EventArgs e)
        {
            DataTable dt = nccBUS.LoadDataNCC();
            txtMaNV.Text = manv.ToString();
            cbNCC.DataSource = dt;
            cbNCC.DisplayMember = "TenNCC";
            cbNCC.ValueMember = "MaNCC";
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số ");
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtTenHoa.Text) || string.IsNullOrWhiteSpace(txtGiaNhap.Text) || nupSL.Value <= 0||pbHA.Image==null|| string.IsNullOrWhiteSpace(RtxtMota.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hoa.");
                return;
            }
            string appPath = Directory.GetParent(Application.StartupPath).Parent.FullName;
            string folderPath = Path.Combine(appPath, "imghoa");
            string fileName = Path.GetFileName(lblpath.Text);
            string destinationFilePath = Path.Combine(folderPath, fileName);
            File.Copy(lblpath.Text, destinationFilePath, true);
            HoaDTO hoa = new HoaDTO()
            {
                TenHoa = txtTenHoa.Text
            };
            int soluong = (int)nupSL.Value;

            if (soluong <= 0)
            {
                MessageBox.Show("Số lượng hoa phải lớn hơn 0");
                return;
            }

            float dongia = float.Parse(txtGiaNhap.Text);
            float tongTienHoa = soluong * dongia;
            tongtien += tongTienHoa;
            txtTotal.Text = tongtien.ToString();
            int flag = 0;

            if (dgvNhapHang.RowCount > 1)
            {
                foreach (DataGridViewRow row in dgvNhapHang.Rows)
                {
                    if (row.Cells["colTenHoa"].Value != null && txtTenHoa.Text != null &&
                        row.Cells["colTenHoa"].Value.ToString() == txtTenHoa.Text)
                    {
                        int.TryParse(nupSL.Value.ToString(), out int number);
                        int a = Convert.ToInt32(row.Cells["colSL"].Value) + number;
                        row.Cells["colSL"].Value = a;
                        flag = 1;
                    }
                }

                if (flag == 0)
                {
                    dgvNhapHang.Rows.Add(txtTenHoa.Text, nupSL.Value, txtGiaNhap.Text, dtpNNH.Text, Path.GetFileName(lblpath.Text), RtxtMota.Text);
                }
            }
            else
            {
                dgvNhapHang.Rows.Add(txtTenHoa.Text, nupSL.Value, txtGiaNhap.Text, dtpNNH.Text, Path.GetFileName(lblpath.Text), RtxtMota.Text);
            }
            dgvNhapHang.ClearSelection();
            txtTenHoa.Text=string.Empty;
            txtGiaNhap.Text = string.Empty;
            nupSL.Value = 0;
             pbHA.Image = null;
            lblpath.Text = string.Empty;
            RtxtMota.Text = string.Empty;

        }
        private void pbHA_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblpath.Text = openFileDialog.FileName;
                pbHA.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if(dgvNhapHang.RowCount < 1)
            {
                MessageBox.Show("Vui lòng thêm hoa vào danh sách trước khi nhập hàng.");
                return;
            }

            NHang.MaNCC = Convert.ToInt32(cbNCC.SelectedValue);
            NHang.MaNV = manv;
            NHang.NgayNhap = dtpNNH.Value;
            float.TryParse(txtTotal.Text, out float total);
            NHang.TongTien = total;
            
            if (nhBUS.ValidateAddNhapHang(NHang)){
                int mahdn = nhBUS.ValidateGetMaHDN();
                HoaDTO hoa = new HoaDTO();
                foreach (DataGridViewRow row in dgvNhapHang.Rows)
                {
                    if (row.Cells["colTenHoa"].Value == null)
                    {
                        
                        break;
                    }

                        int flag = 0;
                    if (hoaBUS.ValidateCheckFlower(row.Cells["colTenHoa"].Value.ToString())==false)
                    {
                        //int mahoa = hoaBUS.GetMaHoa(txtTenHoa.Text);


                        hoa.TenHoa = row.Cells["colTenHoa"].Value.ToString();
                        hoa.MoTa = row.Cells["colMoTa"].Value.ToString();
                        hoa.HinhAnh = row.Cells["colHA"].Value.ToString();
                        hoa.DonGia = Convert.ToInt32(row.Cells["colGiaNhap"].Value) + 7000;
                        hoa.SoLuong = Convert.ToInt32(row.Cells["colSL"].Value);
                            hoaBUS.AddDataFlower(hoa);
                        flag = 1;
                    }
                        ctnhDTO.MaHDN = mahdn;
                   
                        string tenhoa = row.Cells["colTenHoa"].Value.ToString();
                        int a = hoaBUS.GetMaHoa(tenhoa);
                        ctnhDTO.MaHoa = hoaBUS.GetMaHoa(tenhoa);
                        ctnhDTO.SoLuong = Convert.ToInt32(row.Cells["colSL"].Value);
                        ctnhDTO.DonGia = Convert.ToInt32(row.Cells["colGiaNhap"].Value);
                        ctnhDTO.NgayNhap = dtpNNH.Value;
                        ctnhBUS.ValidateAddCTHDN(ctnhDTO);
                        hoa.MaHoa = a;  
                        hoa.SoLuong= Convert.ToInt32(row.Cells["colSL"].Value);
                        hoa.HinhAnh = row.Cells["colHA"].Value.ToString();
                        hoa.DonGia = Convert.ToInt32(row.Cells["colGiaNhap"].Value) + 7000;
                        if (flag == 0)
                        {
                            hoaBUS.ValidateUpdateSLNH(hoa); 
                        }
                }
            }
            MessageBox.Show("Nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRefresh_Click(sender, e);
            dgvNhapHang.Rows.Clear();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTenHoa.Clear();
            txtGiaNhap.Clear();
            nupSL.Value = 0;
            lblpath.Text = string.Empty;
            pbHA.Image = null;
            RtxtMota.Clear();
            
            txtTotal.Clear();
            tongtien = 0;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNhapHang.SelectedRows.Count==0)
            {
                MessageBox.Show("Vui lòng chọn hàng để sửa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            DataGridViewRow selectedRow = dgvNhapHang.CurrentRow;
            if (selectedRow != null)
            {
                selectedRow.Cells["colTenHoa"].Value = txtTenHoa.Text;
                selectedRow.Cells["colSL"].Value = nupSL.Value;
                selectedRow.Cells["colGiaNhap"].Value = txtGiaNhap.Text;
                selectedRow.Cells["NgayNhap"].Value = dtpNNH.Value.ToString("dd/MM/yyyy");
                selectedRow.Cells["colHA"].Value = Path.GetFileName(lblpath.Text);
                selectedRow.Cells["colMoTa"].Value = RtxtMota.Text;
            }
            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvNhapHang.ClearSelection();
            txtTenHoa.Text = string.Empty;
            txtGiaNhap.Text = string.Empty;
            nupSL.Value = 0;
            pbHA.Image = null;
            lblpath.Text = string.Empty;
            RtxtMota.Text = string.Empty;
        }

        private void dgvNhapHang_SelectionChanged(object sender, EventArgs e)
        {
           
                if (dgvNhapHang.CurrentRow == null) return; 

                txtTenHoa.Text= dgvNhapHang.CurrentRow.Cells["colTenHoa"].Value.ToString();
                nupSL.Value= Convert.ToDecimal(dgvNhapHang.CurrentRow.Cells["colSL"].Value);
                txtGiaNhap.Text= dgvNhapHang.CurrentRow.Cells["colGiaNhap"].Value.ToString() ;
               
                lblpath.Text = dgvNhapHang.CurrentRow.Cells["colHA"].Value.ToString();
                dtpNNH.Value = DateTime.Now;
                //Convert.ToDateTime(dgvNhapHang.CurrentRow.Cells["NgayNhap"].Value);
                RtxtMota.Text = dgvNhapHang.CurrentRow.Cells["colMoTa"].Value.ToString();
                string imagePath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.FullName, "imghoa", dgvNhapHang.CurrentRow.Cells["colHA"].Value.ToString());
                if (File.Exists(imagePath))
                {
                    pbHA.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pbHA.Image = null;
                }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                tongtien= tongtien-Convert.ToInt32(dgvNhapHang.CurrentRow.Cells["colGiaNhap"].Value) * Convert.ToInt32(dgvNhapHang.CurrentRow.Cells["colSL"].Value);
                
                foreach (DataGridViewRow row in dgvNhapHang.SelectedRows)
                {
                    
                        dgvNhapHang.Rows.Remove(row);
                    
                }
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNhapHang.ClearSelection();
                txtTotal.Text = tongtien.ToString();
                txtTenHoa.Text = string.Empty;
                txtGiaNhap.Text = string.Empty;
                nupSL.Value = 0;
                pbHA.Image = null;
                lblpath.Text = string.Empty;
                RtxtMota.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa.");
            }
           
        }

     
    }
}
