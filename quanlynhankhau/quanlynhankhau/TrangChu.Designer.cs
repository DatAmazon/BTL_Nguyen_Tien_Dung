
namespace quanlynhankhau
{
    partial class TrangChu
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnPhuong = new System.Windows.Forms.Button();
            this.btlQuan = new System.Windows.Forms.Button();
            this.btnTo = new System.Windows.Forms.Button();
            this.btnHoGiaDinh = new System.Windows.Forms.Button();
            this.btnThanNhan = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quản Lý Nhân Khẩu";
            // 
            // btnPhuong
            // 
            this.btnPhuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhuong.Location = new System.Drawing.Point(491, 202);
            this.btnPhuong.Name = "btnPhuong";
            this.btnPhuong.Size = new System.Drawing.Size(182, 99);
            this.btnPhuong.TabIndex = 2;
            this.btnPhuong.Text = "Phường ";
            this.btnPhuong.UseVisualStyleBackColor = true;
            this.btnPhuong.Click += new System.EventHandler(this.btnPhuong_Click);
            // 
            // btlQuan
            // 
            this.btlQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlQuan.Location = new System.Drawing.Point(259, 202);
            this.btlQuan.Name = "btlQuan";
            this.btlQuan.Size = new System.Drawing.Size(182, 99);
            this.btlQuan.TabIndex = 3;
            this.btlQuan.Text = "Quận";
            this.btlQuan.UseVisualStyleBackColor = true;
            this.btlQuan.Click += new System.EventHandler(this.btlQuan_Click);
            // 
            // btnTo
            // 
            this.btnTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTo.Location = new System.Drawing.Point(715, 202);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(182, 99);
            this.btnTo.TabIndex = 4;
            this.btnTo.Text = "Tổ";
            this.btnTo.UseVisualStyleBackColor = true;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // btnHoGiaDinh
            // 
            this.btnHoGiaDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoGiaDinh.Location = new System.Drawing.Point(384, 353);
            this.btnHoGiaDinh.Name = "btnHoGiaDinh";
            this.btnHoGiaDinh.Size = new System.Drawing.Size(182, 99);
            this.btnHoGiaDinh.TabIndex = 5;
            this.btnHoGiaDinh.Text = "Hộ gia đình";
            this.btnHoGiaDinh.UseVisualStyleBackColor = true;
            this.btnHoGiaDinh.Click += new System.EventHandler(this.btnHoGiaDinh_Click);
            // 
            // btnThanNhan
            // 
            this.btnThanNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanNhan.Location = new System.Drawing.Point(619, 353);
            this.btnThanNhan.Name = "btnThanNhan";
            this.btnThanNhan.Size = new System.Drawing.Size(182, 99);
            this.btnThanNhan.TabIndex = 6;
            this.btnThanNhan.Text = "Thân nhân";
            this.btnThanNhan.UseVisualStyleBackColor = true;
            this.btnThanNhan.Click += new System.EventHandler(this.btnThanNhan_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(1019, 625);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 32);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 690);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnThanNhan);
            this.Controls.Add(this.btnHoGiaDinh);
            this.Controls.Add(this.btnTo);
            this.Controls.Add(this.btlQuan);
            this.Controls.Add(this.btnPhuong);
            this.Controls.Add(this.label2);
            this.Name = "TrangChu";
            this.Text = "Trang chủ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPhuong;
        private System.Windows.Forms.Button btlQuan;
        private System.Windows.Forms.Button btnTo;
        private System.Windows.Forms.Button btnHoGiaDinh;
        private System.Windows.Forms.Button btnThanNhan;
        private System.Windows.Forms.Button btnExit;
    }
}