using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLyCuaHang279;   
using DTO_QuanLyCuaHang279;

namespace GUI_QuanLyCuaHang279 
{
    public partial class frmBaoCaoThongKe : Form
    {
        private BaoCaoBUS busBC = new BaoCaoBUS();

        public frmBaoCaoThongKe()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            dtpFromDateBC.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
            dtpToDateBC.Value = DateTime.Now.Date.AddDays(1).AddTicks(-1); 
            
            SetupDataGridView(dgvSachBanChayNhat);
            SetupDataGridView(dgvSachBanItNhat);
            SetupDataGridView(dgvDoanhThuChiTietBC);
        }

        // Hàm cấu hình chung cho DataGridView
        private void SetupDataGridView(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false; 
        }


        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            LoadAllReports(); 

        }

 
        private void btnCapNhatBC_Click(object sender, EventArgs e)
        {
            LoadAllReports(); 
        }

        // Hàm chính để tải và hiển thị tất cả các phần của báo cáo
        private void LoadAllReports()
        {
            DateTime fromDate = dtpFromDateBC.Value.Date; 
            DateTime toDate = dtpToDateBC.Value.Date;   

            try
            {
                
                busBC.ValidateDateRange(fromDate, toDate); 

                // 1. Load sách bán chạy
                var topChay = busBC.LayTopSachBanChay(fromDate, toDate); 
                dgvSachBanChayNhat.DataSource = null;
                dgvSachBanChayNhat.DataSource = topChay;
                ConfigureSachBanChayColumns();

                
                var topIt = busBC.LayTopSachBanItNhat(fromDate, toDate); 
                dgvSachBanItNhat.DataSource = null;
                dgvSachBanItNhat.DataSource = topIt;
                ConfigureSachBanItColumns();

                
                DataTable dtDoanhThu = busBC.LayDoanhThuChiTiet(fromDate, toDate);
                dgvDoanhThuChiTietBC.DataSource = null;
                dgvDoanhThuChiTietBC.DataSource = dtDoanhThu;
                ConfigureDoanhThuColumns();

                
                TinhVaHienThiTongDoanhThu(dtDoanhThu);

            }
            catch (ArgumentException argEx) 
            {
                MessageBox.Show(argEx.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                dgvSachBanChayNhat.DataSource = null;
                dgvSachBanItNhat.DataSource = null;
                dgvDoanhThuChiTietBC.DataSource = null;
                txtTongDoanhThuBC.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                dgvSachBanChayNhat.DataSource = null;
                dgvSachBanItNhat.DataSource = null;
                dgvDoanhThuChiTietBC.DataSource = null;
                txtTongDoanhThuBC.Text = "0";
            }
        }

        // Cấu hình cột cho lưới Sách bán chạy
        private void ConfigureSachBanChayColumns()
        {
            if (dgvSachBanChayNhat.Columns.Count > 0)
            {
                dgvSachBanChayNhat.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvSachBanChayNhat.Columns["TenSach"].HeaderText = "Tên Sách";
                dgvSachBanChayNhat.Columns["TongSoLuongBan"].HeaderText = "SL Bán"; 
                dgvSachBanChayNhat.Columns["TongSoLuongBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSachBanChayNhat.Columns["MaSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvSachBanChayNhat.Columns["TongSoLuongBan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvSachBanChayNhat.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
            }
        }

        // Cấu hình cột cho lưới Sách bán ít (giống bán chạy)
        private void ConfigureSachBanItColumns()
        {
            if (dgvSachBanItNhat.Columns.Count > 0)
            {
                dgvSachBanItNhat.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvSachBanItNhat.Columns["TenSach"].HeaderText = "Tên Sách";
                dgvSachBanItNhat.Columns["TongSoLuongBan"].HeaderText = "SL Bán";
                dgvSachBanItNhat.Columns["TongSoLuongBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSachBanItNhat.Columns["MaSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvSachBanItNhat.Columns["TongSoLuongBan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvSachBanItNhat.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        // Cấu hình cột cho lưới Doanh thu chi tiết
        private void ConfigureDoanhThuColumns()
        {
            if (dgvDoanhThuChiTietBC.Columns.Count > 0)
            {
                dgvDoanhThuChiTietBC.Columns["MaHD"].HeaderText = "Mã HĐ";
                dgvDoanhThuChiTietBC.Columns["TenKH"].HeaderText = "Khách Hàng";
                dgvDoanhThuChiTietBC.Columns["TenNV"].HeaderText = "Nhân Viên";
                dgvDoanhThuChiTietBC.Columns["NgayLap"].HeaderText = "Ngày Lập";
                dgvDoanhThuChiTietBC.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvDoanhThuChiTietBC.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvDoanhThuChiTietBC.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvDoanhThuChiTietBC.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDoanhThuChiTietBC.Columns["MaHD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDoanhThuChiTietBC.Columns["NgayLap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        // Tính và hiển thị tổng doanh thu
        private void TinhVaHienThiTongDoanhThu(DataTable dataTable)
        {
            decimal tongDoanhThu = 0;
            try
            {
                
                tongDoanhThu = busBC.TinhTongDoanhThu(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tính tổng doanh thu: {ex.Message}");
                tongDoanhThu = 0; 
            }
            txtTongDoanhThuBC.Text = tongDoanhThu.ToString("N0"); 
        }
    }
}