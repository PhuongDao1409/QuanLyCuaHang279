namespace GUI_QuanLyCuaHang279
{
    partial class frmKho
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTimKiemKho = new System.Windows.Forms.Button();
            this.btnLamMoiKho = new System.Windows.Forms.Button();
            this.txtTimKiemSachKho = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox3.Controls.Add(this.btnTimKiemKho);
            this.groupBox3.Controls.Add(this.btnLamMoiKho);
            this.groupBox3.Controls.Add(this.txtTimKiemSachKho);
            this.groupBox3.Location = new System.Drawing.Point(13, 144);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(337, 103);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin Kho";
            // 
            // btnTimKiemKho
            // 
            this.btnTimKiemKho.Location = new System.Drawing.Point(25, 24);
            this.btnTimKiemKho.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiemKho.Name = "btnTimKiemKho";
            this.btnTimKiemKho.Size = new System.Drawing.Size(100, 28);
            this.btnTimKiemKho.TabIndex = 7;
            this.btnTimKiemKho.Text = "Tìm Kiếm";
            this.btnTimKiemKho.UseVisualStyleBackColor = true;
            this.btnTimKiemKho.Click += new System.EventHandler(this.btnTimKiemKho_Click);
            // 
            // btnLamMoiKho
            // 
            this.btnLamMoiKho.Location = new System.Drawing.Point(212, 60);
            this.btnLamMoiKho.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoiKho.Name = "btnLamMoiKho";
            this.btnLamMoiKho.Size = new System.Drawing.Size(100, 28);
            this.btnLamMoiKho.TabIndex = 41;
            this.btnLamMoiKho.Text = "Làm mới";
            this.btnLamMoiKho.UseVisualStyleBackColor = true;
            this.btnLamMoiKho.Click += new System.EventHandler(this.btnLamMoiKho_Click);
            // 
            // txtTimKiemSachKho
            // 
            this.txtTimKiemSachKho.Location = new System.Drawing.Point(148, 30);
            this.txtTimKiemSachKho.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiemSachKho.Name = "txtTimKiemSachKho";
            this.txtTimKiemSachKho.Size = new System.Drawing.Size(164, 22);
            this.txtTimKiemSachKho.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvKho);
            this.groupBox2.Location = new System.Drawing.Point(397, 134);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(480, 522);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách ";
            // 
            // dgvKho
            // 
            this.dgvKho.AllowUserToAddRows = false;
            this.dgvKho.AllowUserToDeleteRows = false;
            this.dgvKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKho.Location = new System.Drawing.Point(4, 19);
            this.dgvKho.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKho.MultiSelect = false;
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.RowHeadersWidth = 51;
            this.dgvKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKho.Size = new System.Drawing.Size(472, 499);
            this.dgvKho.TabIndex = 36;
            this.dgvKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKho_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(282, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 52);
            this.label2.TabIndex = 44;
            this.label2.Text = "Thông tin Kho";
            // 
            // frmKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1000, 743);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKho";
            this.Text = "frmKho";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLamMoiKho;
        private System.Windows.Forms.Button btnTimKiemKho;
        private System.Windows.Forms.TextBox txtTimKiemSachKho;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.Label label2;
    }
}