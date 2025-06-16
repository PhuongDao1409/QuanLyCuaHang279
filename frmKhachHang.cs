using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLyCuaHang279;
using BUS_QuanLyCuaHang279;
using System.Data.SqlClient;

namespace GUI_QuanLyCuaHang279
{
    public partial class frmKhachHang : Form
    {
        private KhachHangBUS busKH = new KhachHangBUS();

        public frmKhachHang()
        {
            InitializeComponent();
           
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
          
        }

        private void LoadData()
        {
            try
            {
                dgvKhachHang.DataSource = null;
                dgvKhachHang.DataSource = busKH.LayDanhSachKhachHang();
                ConfigureDataGridViewColumns();
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải danh sách KH: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ConfigureDataGridViewColumns()
        {
            if (dgvKhachHang.Columns.Count > 0)
            {
                dgvKhachHang.Columns["MaKH"].HeaderText = "Mã KH";
                dgvKhachHang.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Điện Thoại";
                dgvKhachHang.Columns["Email"].HeaderText = "Email";
            }
        }

        private void ClearForm()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtTenKH.Focus();
        }

        private bool ValidateInput(out KhachHangDTO kh)
        {
            kh = new KhachHangDTO();
            if (!string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                if (int.TryParse(txtMaKH.Text, out int maKH) && maKH > 0) { kh.MaKH = maKH; }
            }
            if (string.IsNullOrWhiteSpace(txtTenKH.Text)) { MessageBox.Show("- Họ tên trống."); txtTenKH.Focus(); return false; }
           

            kh.HoTen = txtTenKH.Text.Trim();
            kh.SoDienThoai = txtSoDienThoai.Text.Trim();
            kh.Email = txtEmail.Text.Trim();
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput(out KhachHangDTO kh))
            {
                try
                {
                    if (busKH.ThemKhachHang(kh)) { MessageBox.Show("Thêm thành công!"); LoadData(); ClearForm(); }
                    else { MessageBox.Show("Thêm thất bại!"); }
                }
                catch (ArgumentException argEx) { MessageBox.Show($"Lỗi dữ liệu: {argEx.Message}", "Cảnh báo"); }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi thêm KH: {ex.Message}", "Lỗi Hệ Thống"); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text)) { MessageBox.Show("Vui lòng chọn khách hàng cần sửa."); return; }
            if (ValidateInput(out KhachHangDTO kh))
            {
                try
                {
                    if (busKH.CapNhatKhachHang(kh)) { MessageBox.Show("Cập nhật thành công!"); LoadData(); ClearForm(); }
                    else { MessageBox.Show("Cập nhật thất bại!"); }
                }
                catch (ArgumentException argEx) { MessageBox.Show($"Lỗi dữ liệu: {argEx.Message}", "Cảnh báo"); }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi cập nhật KH: {ex.Message}", "Lỗi Hệ Thống"); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKH.Text, out int maKH) || maKH <= 0) { MessageBox.Show("Vui lòng chọn khách hàng cần xoá."); return; }

            if (MessageBox.Show($"Bạn chắc muốn xoá khách hàng mã '{maKH}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (busKH.XoaKhachHang(maKH)) { MessageBox.Show("Xoá thành công!"); LoadData(); ClearForm(); }
                    else { MessageBox.Show("Xoá thất bại! Kiểm tra dữ liệu liên quan."); }
                }
                catch (ArgumentException argEx) { MessageBox.Show($"Lỗi: {argEx.Message}", "Cảnh báo"); }
                catch (SqlException sqlEx) when (sqlEx.Number == 547) { MessageBox.Show("Không thể xóa KH này vì có dữ liệu liên quan.", "Lỗi Khóa Ngoại"); }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi xóa KH: {ex.Message}", "Lỗi Hệ Thống"); }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemKH.Text.Trim();
            try
            {
                dgvKhachHang.DataSource = null;
                List<KhachHangDTO> ketQua = busKH.TimKiemKhachHang(keyword);
                dgvKhachHang.DataSource = ketQua;
                if (ketQua.Count == 0) { MessageBox.Show("Không tìm thấy kết quả."); }
                ConfigureDataGridViewColumns();
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi Hệ Thống"); }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                if (row?.Cells["MaKH"]?.Value == null || row.Cells["MaKH"].Value == DBNull.Value) { ClearForm(); return; }

                Func<string, string> getCellValue = (colName) => row.Cells[colName]?.Value?.ToString() ?? "";

                txtMaKH.Text = getCellValue("MaKH");
                txtTenKH.Text = getCellValue("HoTen");
                txtSoDienThoai.Text = getCellValue("SoDienThoai");
                txtEmail.Text = getCellValue("Email");
            }
            else { ClearForm(); }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtSearchBox_TextChanged(object sender, EventArgs e) { }

    }
}