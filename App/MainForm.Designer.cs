﻿namespace App
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
            this.btnLogOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnQLNV = new System.Windows.Forms.Button();
            this.btnSP = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(554, 37);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(110, 71);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Đăng Xuất";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 71);
            this.button1.TabIndex = 1;
            this.button1.Text = "Bán Hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(216, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 71);
            this.button2.TabIndex = 2;
            this.button2.Text = "Quản Lí Hóa Đơn";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnQLNV
            // 
            this.btnQLNV.Location = new System.Drawing.Point(367, 37);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(139, 71);
            this.btnQLNV.TabIndex = 3;
            this.btnQLNV.Text = "Quản Lí Nhân Viên";
            this.btnQLNV.UseVisualStyleBackColor = true;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // btnSP
            // 
            this.btnSP.Location = new System.Drawing.Point(129, 226);
            this.btnSP.Name = "btnSP";
            this.btnSP.Size = new System.Drawing.Size(139, 71);
            this.btnSP.TabIndex = 4;
            this.btnSP.Text = "Quản Lí Sản Phẩm";
            this.btnSP.UseVisualStyleBackColor = true;
            this.btnSP.Click += new System.EventHandler(this.btnSP_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(446, 226);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(139, 71);
            this.button5.TabIndex = 5;
            this.button5.Text = "Quản Lí Khách Hàng";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnSP);
            this.Controls.Add(this.btnQLNV);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogOut);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.Button btnSP;
        private System.Windows.Forms.Button button5;
    }
}

