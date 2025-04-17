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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
           

        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            Sale mainForm = new Sale();
            this.Hide();
            mainForm.ShowDialog();
           this.Show();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            QLNV mainForm = new QLNV();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            QLSP mainForm = new QLSP();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLHD mainForm = new QLHD();
            this.Hide();
            mainForm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
