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
    public partial class frmKho : Form
    {
      
        private KhoBUS busKho = new KhoBUS();

        // Lưu danh sách đầy đủ để tìm kiếm
        private List<KhoDTO> fullKhoList = new List<KhoDTO>();

        public frmKho()
        {
            InitializeComponent();
            ConfigureForm();
            
            btnTimKiemKho.Text = "Tìm theo Mã sách";
        }

        private void ConfigureForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }

        // Sự kiện khi Form được load
        private void frmKho_Load(object sender, EventArgs e)
        {
            LoadKhoData(); 
        }

  
        private void LoadKhoData()
        {
            try
            {
                // Lấy danh sách tồn kho trực tiếp từ KhoBUS
                fullKhoList = busKho.LayDanhSachKho();
                if (fullKhoList == null)
                {
                    ShowError("Không thể tải danh sách tồn kho.");
                    fullKhoList = new List<KhoDTO>(); // Khởi tạo rỗng
                }

                // Hiển thị danh sách KhoDTO lên DataGridView
                dgvKho.DataSource = null; 
                dgvKho.DataSource = fullKhoList; 
                ConfigureKhoColumns(); 

                txtTimKiemSachKho.Clear(); 
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi tải dữ liệu kho: {ex.Message}");
                fullKhoList = new List<KhoDTO>();
                dgvKho.DataSource = null;
            }
        }

        // Cấu hình hiển thị cho các cột trong DataGridView 
        private void ConfigureKhoColumns()
        {
            if (dgvKho.Columns.Count > 0)
            {
                // Đặt tên tiêu đề cột
                if (dgvKho.Columns.Contains("MaKho")) 
                    dgvKho.Columns["MaKho"].Visible = false;
                if (dgvKho.Columns.Contains("MaSach"))
                    dgvKho.Columns["MaSach"].HeaderText = "Mã Sách";
                if (dgvKho.Columns.Contains("SoLuongTon"))
                    dgvKho.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";

                // Định dạng cột số lượng tồn
                if (dgvKho.Columns.Contains("SoLuongTon"))
                    dgvKho.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                
            }
        }

        // Sự kiện Click nút Làm mới
        private void btnLamMoiKho_Click(object sender, EventArgs e)
        {
            LoadKhoData(); 
        }

        // Sự kiện Click nút Tìm kiếm (Theo Mã Sách)
        private void btnTimKiemKho_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemSachKho.Text.Trim(); // Lấy từ khóa tìm kiếm

            try
            {
                List<KhoDTO> filteredList;
                if (string.IsNullOrEmpty(keyword))
                {
                   
                    filteredList = fullKhoList;
                }
                else if (int.TryParse(keyword, out int maSachCanTim)) 
                {
                    // Lọc danh sách trong bộ nhớ dựa trên MaSach
                    filteredList = fullKhoList
                                    .Where(kho => kho.MaSach == maSachCanTim)
                                    .ToList();
                }
                else
                {
                    // Nếu không phải số, không tìm được theo Mã sách
                    ShowWarning("Vui lòng nhập Mã Sách (số nguyên) để tìm kiếm.");
                    return; 
                }

                // Cập nhật DataGridView
                dgvKho.DataSource = null;
                dgvKho.DataSource = filteredList;
                ConfigureKhoColumns(); // Cấu hình lại cột

                // Thông báo nếu không tìm thấy kết quả
                if (filteredList.Count == 0 && !string.IsNullOrEmpty(keyword))
                {
                    ShowInfo("Không tìm thấy Mã Sách này trong kho.");
                }
            }
            catch (Exception ex)
            {
                 ShowError($"Lỗi khi tìm kiếm kho: {ex.Message}");
                 // Hiển thị lại toàn bộ nếu lỗi
                 dgvKho.DataSource = null;
                 dgvKho.DataSource = fullKhoList;
                 ConfigureKhoColumns();
            }
        }


        private void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Hàm tiện ích hiển thị cảnh báo
        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // --- Các sự kiện không dùng có thể xóa hoặc để trống ---
        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e) 
        {

            if (e.RowIndex >= 0 && e.RowIndex < dgvKho.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvKho.Rows[e.RowIndex];

            }
        }
    }
}