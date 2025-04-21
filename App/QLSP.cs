using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class QLSP : Form
    {
        private HoaBUS hoaBUS = new HoaBUS();
        public QLSP()
        {
            InitializeComponent();
        }
        private void QLSP_Load(object sender, EventArgs e)
        {
            DataTable dt = hoaBUS.LoadDataFlower();
            dgvFlowers.DataSource = dt; 
            btnRefresh_Click(sender, e);

        }
        private void dgvFlowers_SelectionChanged(object sender, EventArgs e)
        {

            string appPath = Directory.GetParent(Application.StartupPath).Parent.FullName;
            
            string folderPath = Path.Combine(appPath, "imghoa");
            DataGridViewRow Row=dgvFlowers.CurrentRow;
            pbHinhAnhHoa.Image = Image.FromFile(Path.Combine(folderPath, dgvFlowers.CurrentRow.Cells["HinhAnh"].Value.ToString()));
            txtIdFl.Text = dgvFlowers.CurrentRow.Cells["MaHoa"].Value.ToString();
            txtNameFl.Text = dgvFlowers.CurrentRow.Cells["TenHoa"].Value.ToString();
            txtQuantity.Text = dgvFlowers.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtSP.Text = Convert.ToInt32( dgvFlowers.CurrentRow.Cells["GiaBan"].Value).ToString();
            txtPP.Text = (Convert.ToInt32(dgvFlowers.CurrentRow.Cells["GiaBan"].Value)-7000).ToString();
            //int gia=Convert.ToDecimal(txtSP.Text)-7000;
            //txtPP.Text = gia.ToString();
            txtDescribe.Text = dgvFlowers.CurrentRow.Cells["MoTa"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HoaDTO flowers = new HoaDTO()
            {
                TenHoa = txtNameFl.Text,
                MoTa = txtDescribe.Text
            };

            if (hoaBUS.AddDataFlower(flowers))
            {
                MessageBox.Show("Thêm hoa thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Thêm hoa không thành công", "Thông báo", MessageBoxButtons.OK);
            }

            txtNameFl.Text = string.Empty;
            txtDescribe.Text = string.Empty;

            DataTable dt = hoaBUS.LoadDataFlower();
            dgvFlowers.DataSource = dt;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvFlowers.ClearSelection();

            if(dgvFlowers.CurrentRow.Selected == false)
            {
                txtIdFl.Text = string.Empty;
                txtNameFl.Text = string.Empty;
                txtSP.Text = string.Empty;
                txtPP.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtDescribe.Text = string.Empty;

                pbHinhAnhHoa.Image = null;


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HoaDTO flowers = new HoaDTO()
            {
                MaHoa = Convert.ToInt32(txtIdFl.Text)
            };

            if(hoaBUS.DeleteDataFlower(flowers))
            {
                MessageBox.Show("Hủy hoa thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Hủy hoa không thành công", "Thông báo", MessageBoxButtons.OK);
            }

            txtIdFl.Text = string.Empty;
            txtNameFl.Text = string.Empty;
            txtSP.Text = string.Empty;
            txtPP.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDescribe.Text = string.Empty;

            DataTable dt = hoaBUS.LoadDataFlower();
            dgvFlowers.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            HoaDTO flowers = new HoaDTO()
            {
                MaHoa= Convert.ToInt32(txtIdFl.Text),
                TenHoa = txtNameFl.Text,
                MoTa = txtDescribe.Text
            };

            if(hoaBUS.InsertDataFlower(flowers))
            {
                MessageBox.Show("Sửa thông tin hoa thành công", "Thông báo", MessageBoxButtons.OK);
                DataTable dt = hoaBUS.LoadDataFlower();
                dgvFlowers.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Sửa thông tin hoa không thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            HoaDTO flower = new HoaDTO { TenHoa = txtSearch.Text };
            DataTable dt = hoaBUS.ValidateSearch(flower);
           

            if(dt.Rows.Count==0)
            {
                MessageBox.Show("Không có hoa bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                dgvFlowers.DataSource = dt;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == string.Empty)
            {
                dgvFlowers.DataSource = hoaBUS.LoadDataFlower();

                btnRefresh_Click(sender, e);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
