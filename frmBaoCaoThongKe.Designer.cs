namespace GUI_QuanLyCuaHang279
{
    partial class frmBaoCaoThongKe
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpToDateBC = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDateBC = new System.Windows.Forms.DateTimePicker();
            this.btnCapNhatBC = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grb1 = new System.Windows.Forms.GroupBox();
            this.dgvSachBanChayNhat = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSachBanItNhat = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTongDoanhThuBC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDoanhThuChiTietBC = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachBanChayNhat)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachBanItNhat)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThuChiTietBC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.dtpToDateBC);
            this.groupBox1.Controls.Add(this.dtpFromDateBC);
            this.groupBox1.Controls.Add(this.btnCapNhatBC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tác vụ";
            // 
            // dtpToDateBC
            // 
            this.dtpToDateBC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDateBC.Location = new System.Drawing.Point(232, 47);
            this.dtpToDateBC.Name = "dtpToDateBC";
            this.dtpToDateBC.Size = new System.Drawing.Size(130, 27);
            this.dtpToDateBC.TabIndex = 4;
            // 
            // dtpFromDateBC
            // 
            this.dtpFromDateBC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDateBC.Location = new System.Drawing.Point(77, 47);
            this.dtpFromDateBC.Name = "dtpFromDateBC";
            this.dtpFromDateBC.Size = new System.Drawing.Size(111, 27);
            this.dtpFromDateBC.TabIndex = 3;
            // 
            // btnCapNhatBC
            // 
            this.btnCapNhatBC.Location = new System.Drawing.Point(415, 26);
            this.btnCapNhatBC.Name = "btnCapNhatBC";
            this.btnCapNhatBC.Size = new System.Drawing.Size(99, 30);
            this.btnCapNhatBC.TabIndex = 2;
            this.btnCapNhatBC.Text = "Truy Vấn";
            this.btnCapNhatBC.UseVisualStyleBackColor = true;
            this.btnCapNhatBC.Click += new System.EventHandler(this.btnCapNhatBC_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến ngày :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            // 
            // grb1
            // 
            this.grb1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.grb1.Controls.Add(this.dgvSachBanChayNhat);
            this.grb1.Location = new System.Drawing.Point(12, 191);
            this.grb1.Name = "grb1";
            this.grb1.Size = new System.Drawing.Size(541, 298);
            this.grb1.TabIndex = 1;
            this.grb1.TabStop = false;
            this.grb1.Text = "Sách bán chạy";
            // 
            // dgvSachBanChayNhat
            // 
            this.dgvSachBanChayNhat.AllowUserToAddRows = false;
            this.dgvSachBanChayNhat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachBanChayNhat.BackgroundColor = System.Drawing.Color.White;
            this.dgvSachBanChayNhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachBanChayNhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSachBanChayNhat.Location = new System.Drawing.Point(3, 18);
            this.dgvSachBanChayNhat.Name = "dgvSachBanChayNhat";
            this.dgvSachBanChayNhat.ReadOnly = true;
            this.dgvSachBanChayNhat.RowHeadersWidth = 51;
            this.dgvSachBanChayNhat.RowTemplate.Height = 24;
            this.dgvSachBanChayNhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachBanChayNhat.Size = new System.Drawing.Size(535, 277);
            this.dgvSachBanChayNhat.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox3.Controls.Add(this.dgvSachBanItNhat);
            this.groupBox3.Location = new System.Drawing.Point(573, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(567, 295);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sách bán Ế";
            // 
            // dgvSachBanItNhat
            // 
            this.dgvSachBanItNhat.AllowUserToAddRows = false;
            this.dgvSachBanItNhat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachBanItNhat.BackgroundColor = System.Drawing.Color.White;
            this.dgvSachBanItNhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachBanItNhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSachBanItNhat.Location = new System.Drawing.Point(3, 18);
            this.dgvSachBanItNhat.Name = "dgvSachBanItNhat";
            this.dgvSachBanItNhat.ReadOnly = true;
            this.dgvSachBanItNhat.RowHeadersWidth = 51;
            this.dgvSachBanItNhat.RowTemplate.Height = 24;
            this.dgvSachBanItNhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachBanItNhat.Size = new System.Drawing.Size(561, 274);
            this.dgvSachBanItNhat.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox4.Controls.Add(this.txtTongDoanhThuBC);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.dgvDoanhThuChiTietBC);
            this.groupBox4.Location = new System.Drawing.Point(9, 505);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1137, 267);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Doanh thu cửa hàng";
            // 
            // txtTongDoanhThuBC
            // 
            this.txtTongDoanhThuBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThuBC.Location = new System.Drawing.Point(153, 234);
            this.txtTongDoanhThuBC.Name = "txtTongDoanhThuBC";
            this.txtTongDoanhThuBC.ReadOnly = true;
            this.txtTongDoanhThuBC.Size = new System.Drawing.Size(184, 27);
            this.txtTongDoanhThuBC.TabIndex = 2;
            this.txtTongDoanhThuBC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tổng doanh thu :";
            // 
            // dgvDoanhThuChiTietBC
            // 
            this.dgvDoanhThuChiTietBC.AllowUserToAddRows = false;
            this.dgvDoanhThuChiTietBC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThuChiTietBC.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThuChiTietBC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThuChiTietBC.Location = new System.Drawing.Point(6, 21);
            this.dgvDoanhThuChiTietBC.Name = "dgvDoanhThuChiTietBC";
            this.dgvDoanhThuChiTietBC.ReadOnly = true;
            this.dgvDoanhThuChiTietBC.RowHeadersWidth = 51;
            this.dgvDoanhThuChiTietBC.RowTemplate.Height = 24;
            this.dgvDoanhThuChiTietBC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThuChiTietBC.Size = new System.Drawing.Size(1125, 190);
            this.dgvDoanhThuChiTietBC.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(444, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 52);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thống Kê";
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1180, 797);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grb1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaoCaoThongKe";
            this.Text = "frmBaoCaoThongKe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grb1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachBanChayNhat)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachBanItNhat)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThuChiTietBC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grb1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCapNhatBC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSachBanChayNhat;
        private System.Windows.Forms.DataGridView dgvSachBanItNhat;
        private System.Windows.Forms.DataGridView dgvDoanhThuChiTietBC;
        private System.Windows.Forms.DateTimePicker dtpToDateBC;
        private System.Windows.Forms.DateTimePicker dtpFromDateBC;
        private System.Windows.Forms.TextBox txtTongDoanhThuBC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}