namespace GUI_QuanLyCuaHang279
{
    partial class frmPhieuNhap
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
            this.btn = new System.Windows.Forms.GroupBox();
            this.btnInPN = new System.Windows.Forms.Button();
            this.btnXoaCTPN = new System.Windows.Forms.Button();
            this.btnSuaCTPN = new System.Windows.Forms.Button();
            this.btnThemCTPN = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietPN = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtMaSachCTPN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtThanhTienPN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoLuongPN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtGiaNhapPN = new System.Windows.Forms.TextBox();
            this.btnLamMoiCTPN = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMaNVPN = new System.Windows.Forms.TextBox();
            this.txtMaNCCPN = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimKiemPN = new System.Windows.Forms.TextBox();
            this.btnThemPN = new System.Windows.Forms.Button();
            this.btnSuaPN = new System.Windows.Forms.Button();
            this.btnTimKiemPN = new System.Windows.Forms.Button();
            this.btnXoaPN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbPath = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.Label();
            this.b = new System.Windows.Forms.Label();
            this.txtTongTienPN = new System.Windows.Forms.TextBox();
            this.btnLamMoiPN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPN)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn.Controls.Add(this.btnInPN);
            this.btn.Controls.Add(this.btnXoaCTPN);
            this.btn.Controls.Add(this.btnSuaCTPN);
            this.btn.Controls.Add(this.btnThemCTPN);
            this.btn.Controls.Add(this.groupBox7);
            this.btn.Controls.Add(this.groupBox6);
            this.btn.Location = new System.Drawing.Point(16, 471);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(1409, 327);
            this.btn.TabIndex = 86;
            this.btn.TabStop = false;
            this.btn.Text = "Chi tiết Phiếu Nhập";
            // 
            // btnInPN
            // 
            this.btnInPN.Location = new System.Drawing.Point(1255, 264);
            this.btnInPN.Name = "btnInPN";
            this.btnInPN.Size = new System.Drawing.Size(118, 56);
            this.btnInPN.TabIndex = 89;
            this.btnInPN.Text = "In Phiếu Nhập";
            this.btnInPN.UseVisualStyleBackColor = true;
            this.btnInPN.Click += new System.EventHandler(this.btnInPN_Click);
            // 
            // btnXoaCTPN
            // 
            this.btnXoaCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCTPN.Location = new System.Drawing.Point(785, 274);
            this.btnXoaCTPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaCTPN.Name = "btnXoaCTPN";
            this.btnXoaCTPN.Size = new System.Drawing.Size(110, 38);
            this.btnXoaCTPN.TabIndex = 88;
            this.btnXoaCTPN.Text = "Xóa chi tiết";
            this.btnXoaCTPN.UseVisualStyleBackColor = true;
            this.btnXoaCTPN.Click += new System.EventHandler(this.btnXoaCTPN_Click);
            // 
            // btnSuaCTPN
            // 
            this.btnSuaCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaCTPN.Location = new System.Drawing.Point(645, 274);
            this.btnSuaCTPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaCTPN.Name = "btnSuaCTPN";
            this.btnSuaCTPN.Size = new System.Drawing.Size(111, 38);
            this.btnSuaCTPN.TabIndex = 87;
            this.btnSuaCTPN.Text = "Sửa chi tiết";
            this.btnSuaCTPN.UseVisualStyleBackColor = true;
            this.btnSuaCTPN.Click += new System.EventHandler(this.btnSuaCTPN_Click);
            // 
            // btnThemCTPN
            // 
            this.btnThemCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCTPN.Location = new System.Drawing.Point(491, 274);
            this.btnThemCTPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemCTPN.Name = "btnThemCTPN";
            this.btnThemCTPN.Size = new System.Drawing.Size(120, 38);
            this.btnThemCTPN.TabIndex = 86;
            this.btnThemCTPN.Text = "Thêm chi tiết";
            this.btnThemCTPN.UseVisualStyleBackColor = true;
            this.btnThemCTPN.Click += new System.EventHandler(this.btnThemCTPN_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dgvChiTietPN);
            this.groupBox7.Location = new System.Drawing.Point(419, 22);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(987, 239);
            this.groupBox7.TabIndex = 85;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Danh sách CT phiếu nhập";
            // 
            // dgvChiTietPN
            // 
            this.dgvChiTietPN.AllowUserToAddRows = false;
            this.dgvChiTietPN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPN.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPN.Location = new System.Drawing.Point(4, 19);
            this.dgvChiTietPN.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChiTietPN.MultiSelect = false;
            this.dgvChiTietPN.Name = "dgvChiTietPN";
            this.dgvChiTietPN.RowHeadersWidth = 51;
            this.dgvChiTietPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPN.Size = new System.Drawing.Size(979, 216);
            this.dgvChiTietPN.TabIndex = 39;
            this.dgvChiTietPN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPN_CellClick);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox6.Controls.Add(this.txtMaSachCTPN);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txtThanhTienPN);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.txtSoLuongPN);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.txtGiaNhapPN);
            this.groupBox6.Controls.Add(this.btnLamMoiCTPN);
            this.groupBox6.Location = new System.Drawing.Point(15, 22);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(396, 298);
            this.groupBox6.TabIndex = 84;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Thông tin";
            // 
            // txtMaSachCTPN
            // 
            this.txtMaSachCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSachCTPN.Location = new System.Drawing.Point(173, 67);
            this.txtMaSachCTPN.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaSachCTPN.Name = "txtMaSachCTPN";
            this.txtMaSachCTPN.Size = new System.Drawing.Size(204, 27);
            this.txtMaSachCTPN.TabIndex = 110;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(29, 204);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 109;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 204);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 107;
            this.label8.Text = "Thành Tiền:";
            // 
            // txtThanhTienPN
            // 
            this.txtThanhTienPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTienPN.Location = new System.Drawing.Point(173, 204);
            this.txtThanhTienPN.Margin = new System.Windows.Forms.Padding(4);
            this.txtThanhTienPN.Name = "txtThanhTienPN";
            this.txtThanhTienPN.ReadOnly = true;
            this.txtThanhTienPN.Size = new System.Drawing.Size(205, 27);
            this.txtThanhTienPN.TabIndex = 108;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(32, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 106;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 105;
            this.label4.Text = "Sách:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(19, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 104;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 102;
            this.label6.Text = "Số Lượng:";
            // 
            // txtSoLuongPN
            // 
            this.txtSoLuongPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongPN.Location = new System.Drawing.Point(174, 111);
            this.txtSoLuongPN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuongPN.Name = "txtSoLuongPN";
            this.txtSoLuongPN.Size = new System.Drawing.Size(204, 27);
            this.txtSoLuongPN.TabIndex = 103;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(30, 156);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 101;
            this.label9.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(48, 156);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 20);
            this.label16.TabIndex = 99;
            this.label16.Text = "Giá nhập:";
            // 
            // txtGiaNhapPN
            // 
            this.txtGiaNhapPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaNhapPN.Location = new System.Drawing.Point(173, 156);
            this.txtGiaNhapPN.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaNhapPN.Name = "txtGiaNhapPN";
            this.txtGiaNhapPN.Size = new System.Drawing.Size(205, 27);
            this.txtGiaNhapPN.TabIndex = 100;
            // 
            // btnLamMoiCTPN
            // 
            this.btnLamMoiCTPN.Location = new System.Drawing.Point(262, 262);
            this.btnLamMoiCTPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoiCTPN.Name = "btnLamMoiCTPN";
            this.btnLamMoiCTPN.Size = new System.Drawing.Size(100, 28);
            this.btnLamMoiCTPN.TabIndex = 85;
            this.btnLamMoiCTPN.Text = "Làm mới";
            this.btnLamMoiCTPN.UseVisualStyleBackColor = true;
            this.btnLamMoiCTPN.Click += new System.EventHandler(this.btnLamMoiCTPN_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.PaleTurquoise;
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.btnLamMoiPN);
            this.groupBox4.Location = new System.Drawing.Point(16, 73);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1409, 382);
            this.groupBox4.TabIndex = 85;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Phiếu nhập";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPhieuNhap);
            this.groupBox3.Location = new System.Drawing.Point(411, 22);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(987, 289);
            this.groupBox3.TabIndex = 84;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách phiếu nhập";
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.AllowUserToAddRows = false;
            this.dgvPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(4, 19);
            this.dgvPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPhieuNhap.MultiSelect = false;
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.RowHeadersWidth = 51;
            this.dgvPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(979, 266);
            this.dgvPhieuNhap.TabIndex = 39;
            this.dgvPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuNhap_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox2.Controls.Add(this.txtMaNVPN);
            this.groupBox2.Controls.Add(this.txtMaNCCPN);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtMaPhieuNhap);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpNgayNhap);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lbPath);
            this.groupBox2.Controls.Add(this.a);
            this.groupBox2.Controls.Add(this.b);
            this.groupBox2.Controls.Add(this.txtTongTienPN);
            this.groupBox2.Location = new System.Drawing.Point(7, 22);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(396, 349);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // txtMaNVPN
            // 
            this.txtMaNVPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNVPN.Location = new System.Drawing.Point(155, 67);
            this.txtMaNVPN.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNVPN.Name = "txtMaNVPN";
            this.txtMaNVPN.Size = new System.Drawing.Size(204, 27);
            this.txtMaNVPN.TabIndex = 105;
            // 
            // txtMaNCCPN
            // 
            this.txtMaNCCPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNCCPN.Location = new System.Drawing.Point(154, 102);
            this.txtMaNCCPN.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNCCPN.Name = "txtMaNCCPN";
            this.txtMaNCCPN.Size = new System.Drawing.Size(204, 27);
            this.txtMaNCCPN.TabIndex = 104;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(27, 34);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 20);
            this.label19.TabIndex = 93;
            this.label19.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(45, 34);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 16);
            this.label20.TabIndex = 91;
            this.label20.Text = "Mã phiếu nhập:";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(155, 37);
            this.txtMaPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.ReadOnly = true;
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(205, 22);
            this.txtMaPhieuNhap.TabIndex = 92;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(11, 97);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 20);
            this.label18.TabIndex = 90;
            this.label18.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 97);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 88;
            this.label10.Text = "Mã nhà cung cấp:";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(155, 146);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(116, 22);
            this.dtpNgayNhap.TabIndex = 87;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(44, 152);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 16);
            this.label17.TabIndex = 80;
            this.label17.Text = "Ngày lập:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimKiemPN);
            this.groupBox1.Controls.Add(this.btnThemPN);
            this.groupBox1.Controls.Add(this.btnSuaPN);
            this.groupBox1.Controls.Add(this.btnTimKiemPN);
            this.groupBox1.Controls.Add(this.btnXoaPN);
            this.groupBox1.Location = new System.Drawing.Point(15, 220);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(373, 121);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tác vụ";
            // 
            // txtTimKiemPN
            // 
            this.txtTimKiemPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemPN.Location = new System.Drawing.Point(172, 81);
            this.txtTimKiemPN.Name = "txtTimKiemPN";
            this.txtTimKiemPN.Size = new System.Drawing.Size(157, 24);
            this.txtTimKiemPN.TabIndex = 11;
            // 
            // btnThemPN
            // 
            this.btnThemPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemPN.Location = new System.Drawing.Point(14, 23);
            this.btnThemPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemPN.Name = "btnThemPN";
            this.btnThemPN.Size = new System.Drawing.Size(102, 38);
            this.btnThemPN.TabIndex = 7;
            this.btnThemPN.Text = "Thêm PN";
            this.btnThemPN.UseVisualStyleBackColor = true;
            this.btnThemPN.Click += new System.EventHandler(this.btnThemPN_Click);
            // 
            // btnSuaPN
            // 
            this.btnSuaPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaPN.Location = new System.Drawing.Point(124, 23);
            this.btnSuaPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaPN.Name = "btnSuaPN";
            this.btnSuaPN.Size = new System.Drawing.Size(98, 38);
            this.btnSuaPN.TabIndex = 8;
            this.btnSuaPN.Text = "Sửa PN";
            this.btnSuaPN.UseVisualStyleBackColor = true;
            this.btnSuaPN.Click += new System.EventHandler(this.btnSuaPN_Click);
            // 
            // btnTimKiemPN
            // 
            this.btnTimKiemPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemPN.Location = new System.Drawing.Point(54, 76);
            this.btnTimKiemPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiemPN.Name = "btnTimKiemPN";
            this.btnTimKiemPN.Size = new System.Drawing.Size(111, 37);
            this.btnTimKiemPN.TabIndex = 10;
            this.btnTimKiemPN.Text = "Tìm kiếm";
            this.btnTimKiemPN.UseVisualStyleBackColor = true;
            this.btnTimKiemPN.Click += new System.EventHandler(this.btnTimKiemPN_Click);
            // 
            // btnXoaPN
            // 
            this.btnXoaPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaPN.Location = new System.Drawing.Point(234, 23);
            this.btnXoaPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaPN.Name = "btnXoaPN";
            this.btnXoaPN.Size = new System.Drawing.Size(110, 38);
            this.btnXoaPN.TabIndex = 9;
            this.btnXoaPN.Text = "Xóa PN";
            this.btnXoaPN.UseVisualStyleBackColor = true;
            this.btnXoaPN.Click += new System.EventHandler(this.btnSuaPN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(26, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 79;
            this.label2.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(26, 181);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 20);
            this.label11.TabIndex = 76;
            this.label11.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(27, 67);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 66;
            this.label15.Text = "*";
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPath.Location = new System.Drawing.Point(131, 151);
            this.lbPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(0, 17);
            this.lbPath.TabIndex = 62;
            this.lbPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPath.Visible = false;
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Location = new System.Drawing.Point(45, 67);
            this.a.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(51, 16);
            this.a.TabIndex = 34;
            this.a.Text = "Mã NV:";
            // 
            // b
            // 
            this.b.AutoSize = true;
            this.b.Location = new System.Drawing.Point(44, 181);
            this.b.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(66, 16);
            this.b.TabIndex = 35;
            this.b.Text = "Tổng tiền:";
            // 
            // txtTongTienPN
            // 
            this.txtTongTienPN.Location = new System.Drawing.Point(154, 184);
            this.txtTongTienPN.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongTienPN.Name = "txtTongTienPN";
            this.txtTongTienPN.ReadOnly = true;
            this.txtTongTienPN.Size = new System.Drawing.Size(205, 22);
            this.txtTongTienPN.TabIndex = 37;
            // 
            // btnLamMoiPN
            // 
            this.btnLamMoiPN.Location = new System.Drawing.Point(415, 315);
            this.btnLamMoiPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoiPN.Name = "btnLamMoiPN";
            this.btnLamMoiPN.Size = new System.Drawing.Size(100, 28);
            this.btnLamMoiPN.TabIndex = 82;
            this.btnLamMoiPN.Text = "Làm mới";
            this.btnLamMoiPN.UseVisualStyleBackColor = true;
            this.btnLamMoiPN.Click += new System.EventHandler(this.btnLamMoiPN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(598, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 52);
            this.label1.TabIndex = 84;
            this.label1.Text = "Phiếu Nhập";
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1441, 817);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhieuNhap";
            this.Text = "frmPhieuNhap";
            this.btn.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPN)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox btn;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvChiTietPN;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnLamMoiCTPN;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimKiemPN;
        private System.Windows.Forms.Button btnThemPN;
        private System.Windows.Forms.Button btnSuaPN;
        private System.Windows.Forms.Button btnTimKiemPN;
        private System.Windows.Forms.Button btnXoaPN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.Label b;
        private System.Windows.Forms.TextBox txtTongTienPN;
        private System.Windows.Forms.Button btnLamMoiPN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtThanhTienPN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoLuongPN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtGiaNhapPN;
        private System.Windows.Forms.Button btnXoaCTPN;
        private System.Windows.Forms.Button btnSuaCTPN;
        private System.Windows.Forms.Button btnThemCTPN;
        private System.Windows.Forms.TextBox txtMaNVPN;
        private System.Windows.Forms.TextBox txtMaNCCPN;
        private System.Windows.Forms.TextBox txtMaSachCTPN;
        private System.Windows.Forms.Button btnInPN;
    }
}