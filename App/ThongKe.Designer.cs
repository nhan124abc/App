namespace App
{
    partial class ThongKe
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
            this.cbTke = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.rDThu = new System.Windows.Forms.RichTextBox();
            this.rTNhap = new System.Windows.Forms.RichTextBox();
            this.rTBan = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbTke
            // 
            this.cbTke.FormattingEnabled = true;
            this.cbTke.Items.AddRange(new object[] {
            "Ngày",
            "Tháng",
            "Năm"});
            this.cbTke.Location = new System.Drawing.Point(245, 69);
            this.cbTke.Name = "cbTke";
            this.cbTke.Size = new System.Drawing.Size(277, 24);
            this.cbTke.TabIndex = 0;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.Wheat;
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Location = new System.Drawing.Point(549, 64);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 31);
            this.btnLoc.TabIndex = 1;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // rDThu
            // 
            this.rDThu.Location = new System.Drawing.Point(245, 424);
            this.rDThu.Name = "rDThu";
            this.rDThu.Size = new System.Drawing.Size(277, 96);
            this.rDThu.TabIndex = 2;
            this.rDThu.Text = "";
            // 
            // rTNhap
            // 
            this.rTNhap.Location = new System.Drawing.Point(245, 278);
            this.rTNhap.Name = "rTNhap";
            this.rTNhap.Size = new System.Drawing.Size(277, 96);
            this.rTNhap.TabIndex = 3;
            this.rTNhap.Text = "";
            // 
            // rTBan
            // 
            this.rTBan.Location = new System.Drawing.Point(245, 134);
            this.rTBan.Name = "rTBan";
            this.rTBan.Size = new System.Drawing.Size(277, 96);
            this.rTBan.TabIndex = 4;
            this.rTBan.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tổng Tiền Nhập :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tổng Tiền Bán :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Doanh Thu :";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Wheat;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(657, 30);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(70, 28);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rTBan);
            this.Controls.Add(this.rTNhap);
            this.Controls.Add(this.rDThu);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cbTke);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTke;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.RichTextBox rDThu;
        private System.Windows.Forms.RichTextBox rTNhap;
        private System.Windows.Forms.RichTextBox rTBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
    }
}