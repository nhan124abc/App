namespace App
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnQLNV = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.btnQLKH = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnQLHDNhap = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHang.ImageKey = "importgoods.png";
            this.btnNhapHang.ImageList = this.imageList1;
            this.btnNhapHang.Location = new System.Drawing.Point(559, 121);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(205, 152);
            this.btnNhapHang.TabIndex = 0;
            this.btnNhapHang.Text = "Nhập Hàng";
            this.btnNhapHang.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNhapHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNhapHang.UseVisualStyleBackColor = true;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bill.png");
            this.imageList1.Images.SetKeyName(1, "employee.png");
            this.imageList1.Images.SetKeyName(2, "product.png");
            this.imageList1.Images.SetKeyName(3, "sale.png");
            this.imageList1.Images.SetKeyName(4, "customer.png");
            this.imageList1.Images.SetKeyName(5, "importgoods.png");
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageIndex = 3;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(34, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 152);
            this.button1.TabIndex = 1;
            this.button1.Text = "Bán Hàng";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageKey = "bill.png";
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(295, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 152);
            this.button2.TabIndex = 2;
            this.button2.Text = "Quản Lí Hóa Đơn";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnQLNV
            // 
            this.btnQLNV.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLNV.ImageKey = "employee.png";
            this.btnQLNV.ImageList = this.imageList1;
            this.btnQLNV.Location = new System.Drawing.Point(559, 323);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(205, 168);
            this.btnQLNV.TabIndex = 3;
            this.btnQLNV.Text = "Quản Lí Nhân Viên";
            this.btnQLNV.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQLNV.UseVisualStyleBackColor = true;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // btnSP
            // 
            this.btnSP.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSP.ImageKey = "product.png";
            this.btnSP.ImageList = this.imageList1;
            this.btnSP.Location = new System.Drawing.Point(34, 323);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(217, 168);
            this.btnSP.TabIndex = 4;
            this.btnSP.Text = "Quản Lí Sản Phẩm";
            this.btnSP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // btnQLKH
            // 
            this.btnQLKH.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLKH.ImageKey = "customer.png";
            this.btnQLKH.ImageList = this.imageList1;
            this.btnQLKH.Location = new System.Drawing.Point(295, 323);
            this.btnQLKH.Name = "btnQLKH";
            this.btnQLKH.Size = new System.Drawing.Size(209, 168);
            this.btnQLKH.TabIndex = 5;
            this.btnQLKH.Text = "Quản Lí Khách Hàng";
            this.btnQLKH.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQLKH.UseVisualStyleBackColor = true;
            this.btnQLKH.Click += new System.EventHandler(this.btnQLKH_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ImageKey = "logout.png";
            this.btnLogout.ImageList = this.imageList2;
            this.btnLogout.Location = new System.Drawing.Point(675, 34);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(89, 60);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "logout.png");
            // 
            // btnQLHDNhap
            // 
            this.btnQLHDNhap.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLHDNhap.ImageKey = "logout.png";
            this.btnQLHDNhap.ImageList = this.imageList2;
            this.btnQLHDNhap.Location = new System.Drawing.Point(106, 34);
            this.btnQLHDNhap.Name = "btnQLHDNhap";
            this.btnQLHDNhap.Size = new System.Drawing.Size(89, 60);
            this.btnQLHDNhap.TabIndex = 7;
            this.btnQLHDNhap.Text = "Đăng Xuất";
            this.btnQLHDNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQLHDNhap.UseVisualStyleBackColor = true;
            this.btnQLHDNhap.Click += new System.EventHandler(this.btnQLHDNhap_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ImageKey = "logout.png";
            this.btnThongKe.ImageList = this.imageList2;
            this.btnThongKe.Location = new System.Drawing.Point(376, 34);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(89, 60);
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Text = "Đăng Xuất";
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnQLHDNhap);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnQLKH);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.btnQLNV);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNhapHang);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Button btnQLKH;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnQLHDNhap;
        private System.Windows.Forms.Button btnThongKe;
    }
}

