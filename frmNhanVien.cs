using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO_QuanLyCuaHang279;
using BUS_QuanLyCuaHang279;
using System.Data.SqlClient; 

namespace GUI_QuanLyCuaHang279
{
    public partial class frmNhanVien : Form
    {
        NhanVienBUS busNV = new NhanVienBUS();

        public frmNhanVien()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            txtMaNV.ReadOnly = true;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.AllowUserToAddRows = false;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void LoadData()
        {
            try
            {
                dgvNhanVien.DataSource = null;
                dgvNhanVien.DataSource = busNV.LayDanhSachNhanVien();
                ConfigureDataGridViewColumns(); // Cấu hình hiển thị cột
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ConfigureDataGridViewColumns()
        {
            if (dgvNhanVien.Columns.Count > 0) // Kiểm tra có cột không
            {
                dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                dgvNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvNhanVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Điện Thoại";
                dgvNhanVien.Columns["Email"].HeaderText = "Email";
                dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ";
            }
        }

        private void ClearForm()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now.Date;
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtChucVu.Clear();
            txtHoTen.Focus();
        }

        private bool ValidateInput(out NhanVienDTO nv)
        {
            nv = new NhanVienDTO();
            bool isValid = true;
            string errorMsg = "";

            if (!string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                if (!int.TryParse(txtMaNV.Text, out int maNV) || maNV <= 0) { /* Mã chỉ đọc, bỏ qua lỗi */ }
                else { nv.MaNV = maNV; }
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { isValid = false; errorMsg += "- Họ tên trống.\n"; txtHoTen.Focus(); }
            if (cboGioiTinh.SelectedIndex == -1) { isValid = false; errorMsg += "- Chưa chọn giới tính.\n"; cboGioiTinh.Focus(); }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text)) { isValid = false; errorMsg += "- Địa chỉ trống.\n"; txtDiaChi.Focus(); }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text)) { isValid = false; errorMsg += "- Số điện thoại trống.\n"; txtSoDienThoai.Focus(); }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { isValid = false; errorMsg += "- Email trống.\n"; txtEmail.Focus(); }
            if (string.IsNullOrWhiteSpace(txtChucVu.Text)) { isValid = false; errorMsg += "- Chức vụ trống.\n"; txtChucVu.Focus(); }

            if (!isValid) { MessageBox.Show(errorMsg, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            nv.HoTen = txtHoTen.Text.Trim();
            nv.GioiTinh = cboGioiTinh.SelectedItem.ToString();
            nv.NgaySinh = dtpNgaySinh.Value;
            nv.DiaChi = txtDiaChi.Text.Trim();
            nv.SoDienThoai = txtSoDienThoai.Text.Trim();
            nv.Email = txtEmail.Text.Trim();
            nv.ChucVu = txtChucVu.Text.Trim();
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput(out NhanVienDTO nv))
            {
                try
                {
                    if (busNV.ThemNhanVien(nv)) { MessageBox.Show("Thêm thành công!"); LoadData(); ClearForm(); }
                    else { MessageBox.Show("Thêm thất bại!"); }
                }
                catch (ArgumentException argEx) { MessageBox.Show($"Lỗi dữ liệu: {argEx.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)) { MessageBox.Show("Vui lòng chọn nhân viên cần sửa."); return; }
            if (ValidateInput(out NhanVienDTO nv))
            {
                try
                {
                    if (busNV.CapNhatNhanVien(nv)) { MessageBox.Show("Cập nhật thành công!"); LoadData(); ClearForm(); }
                    else { MessageBox.Show("Cập nhật thất bại!"); }
                }
                catch (ArgumentException argEx) { MessageBox.Show($"Lỗi dữ liệu: {argEx.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaNV.Text, out int maNV) || maNV <= 0) { MessageBox.Show("Vui lòng chọn nhân viên cần xoá."); return; }

            if (MessageBox.Show($"Bạn chắc muốn xoá nhân viên mã '{maNV}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (busNV.XoaNhanVien(maNV)) { MessageBox.Show("Xoá thành công!"); LoadData(); ClearForm(); }
                    else { MessageBox.Show("Xoá thất bại! Kiểm tra dữ liệu liên quan."); }
                }
                catch (ArgumentException argEx) { MessageBox.Show($"Lỗi: {argEx.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                catch (SqlException sqlEx) when (sqlEx.Number == 547) { MessageBox.Show("Không thể xóa nhân viên này vì có dữ liệu liên quan.", "Lỗi Khóa Ngoại", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
            string keyword = txtTimKiemNV.Text.Trim();
            try
            {
                dgvNhanVien.DataSource = null;
                List<NhanVienDTO> ketQua = busNV.SearchNhanVienByName(keyword);
                dgvNhanVien.DataSource = ketQua;
                if (ketQua.Count == 0) { MessageBox.Show("Không tìm thấy kết quả."); }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                if (row == null || row.Cells["MaNV"].Value == null || row.Cells["MaNV"].Value == DBNull.Value) { ClearForm(); return; }

                Func<string, string> getCellValue = (colName) => row.Cells[colName]?.Value?.ToString() ?? "";

                txtMaNV.Text = getCellValue("MaNV");
                txtHoTen.Text = getCellValue("HoTen");
                cboGioiTinh.SelectedItem = getCellValue("GioiTinh");
                txtDiaChi.Text = getCellValue("DiaChi");
                txtSoDienThoai.Text = getCellValue("SoDienThoai");
                txtEmail.Text = getCellValue("Email");
                txtChucVu.Text = getCellValue("ChucVu");

                if (DateTime.TryParse(getCellValue("NgaySinh"), out DateTime ngaySinh)) { dtpNgaySinh.Value = ngaySinh; }
                else { dtpNgaySinh.Value = DateTime.Now.Date; }
            }
            else { ClearForm(); }
        }

        
        private void label1_Click(object sender, EventArgs e) 
        {

        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        { 

        }
    }
}