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

            string appPath = Directory.GetParent(Application.StartupPath).Parent.FullName;
            string folderPath = Path.Combine(appPath, "imghoa");
            string fileName = Path.GetFileName(lblpath.Text);
            string destinationFilePath = Path.Combine(folderPath, fileName);
            File.Copy(lblpath.Text, destinationFilePath, true);

            NHang.MaNCC = Convert.ToInt32(cbNCC.SelectedValue);
            NHang.MaNV = manv;
            NHang.NgayNhap = dtpNNH.Value;
            float.TryParse(txtTotal.Text, out float total);
            NHang.TongTien = total;
            if (nhBUS.ValidateAddNhapHang(NHang)){
                int mahdn = nhBUS.ValidateGetMaHDN();
                foreach (DataGridViewRow row in dgvNhapHang.Rows)
                {
                    if (row.Cells["colTenHoa"].Value == null)
                    {
                        break;
                    }
                    
                        if (!hoaBUS.ValidateCheckFlower(txtTenHoa.Text))
                        {
                            //int mahoa = hoaBUS.GetMaHoa(txtTenHoa.Text);
                            HoaDTO hoa = new HoaDTO
                            {
                                TenHoa = row.Cells["colTenHoa"].Value.ToString(),
                                MoTa = row.Cells["colMoTa"].Value.ToString(),
                                HinhAnh = row.Cells["colHA"].Value.ToString(),
                            };
                            hoaBUS.AddDataFlower(hoa);
                            File.Copy(lblpath.Text, destinationFilePath, true);

                        }
                        ctnhDTO.MaHDN = mahdn;

                        string tenhoa = row.Cells["colTenHoa"].Value.ToString();
                    int a = hoaBUS.GetMaHoa(tenhoa);
                    MessageBox.Show(a.ToString());
                        ctnhDTO.MaHoa = hoaBUS.GetMaHoa(tenhoa);
                        ctnhDTO.SoLuong = Convert.ToInt32(row.Cells["colSL"].Value);
                        ctnhDTO.DonGia = Convert.ToInt32(row.Cells["colGiaNhap"].Value);
                        ctnhDTO.NgayNhap = dtpNNH.Value;
                        ctnhBUS.ValidateAddCTHDN(ctnhDTO);
                    
                   
                }
                
            } 
        }

    }
}
