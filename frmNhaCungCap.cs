using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO_QuanLyCuaHang279;
using BUS_QuanLyCuaHang279;
using System.Data.SqlClient;

namespace GUI_QuanLyCuaHang279
{
    public partial class frmNhaCungCap : Form
    {
        private NhaCungCapBUS busNCC = new NhaCungCapBUS();
        private int? currentSelectedMaNCC = null;

        public frmNhaCungCap()
        {
            InitializeComponent();
           
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                dgvNhaCungCap.CellClick += dgvNhaCungCap_CellClick;
                UpdateButtonStates();
            }
            catch (Exception ex) { ShowError($"Lỗi tải form NCC: {ex.Message}"); }
        }

        #region Core Functions
        private void LoadData()
        {
            try
            {
                dgvNhaCungCap.DataSource = null;
                dgvNhaCungCap.DataSource = busNCC.LayDanhSachNhaCungCap();
                ConfigureDataGridViewColumns();
                ClearForm();
            }
            catch (Exception ex) { ShowError($"Lỗi tải danh sách NCC: {ex.Message}"); }
        }

        private void ConfigureDataGridViewColumns()
        {
            if (dgvNhaCungCap.Columns.Count > 0)
            {
               
                dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ClearForm()
        {
            currentSelectedMaNCC = null;
            txtMaNCC.Clear(); txtTenNCC.Clear(); txtDiaChi.Clear(); txtSoDienThoai.Clear();
            txtTenNCC.Focus(); UpdateButtonStates();
        }

        private bool ValidateInput(out NhaCungCapDTO ncc)
        {
            ncc = new NhaCungCapDTO();
            if (!string.IsNullOrWhiteSpace(txtMaNCC.Text)) { if (int.TryParse(txtMaNCC.Text, out int id)) ncc.MaNCC = id; }
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text)) { ShowWarning("Tên NCC trống."); txtTenNCC.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text)) { ShowWarning("Địa chỉ trống."); txtDiaChi.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text)) { ShowWarning("Số điện thoại trống."); txtSoDienThoai.Focus(); return false; }
            ncc.TenNCC = txtTenNCC.Text.Trim(); ncc.DiaChi = txtDiaChi.Text.Trim(); ncc.SoDienThoai = txtSoDienThoai.Text.Trim();
            return true;
        }

        private void ShowError(string message) { MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        private void ShowWarning(string message) { MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        private void ShowInfo(string message) { MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        private void UpdateButtonStates(bool nccSelected = false) { btnThem.Enabled = true; btnSua.Enabled = nccSelected; btnXoa.Enabled = nccSelected; }
        #endregion

        #region Event Handlers
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput(out NhaCungCapDTO ncc))
            {
                try
                {
                    if (busNCC.ThemNhaCungCap(ncc)) { ShowInfo("Thêm thành công!"); LoadData(); }
                    else { ShowError("Thêm thất bại!"); }
                }
                catch (ArgumentException argEx) { ShowWarning($"Lỗi dữ liệu: {argEx.Message}"); }
                catch (Exception ex) { ShowError($"Lỗi khi thêm: {ex.Message}"); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaNCC.HasValue) { ShowWarning("Chọn NCC cần sửa."); return; }
            if (ValidateInput(out NhaCungCapDTO ncc))
            {
                try
                {
                    if (busNCC.CapNhatNhaCungCap(ncc)) { ShowInfo("Cập nhật thành công!"); LoadData(); }
                    else { ShowError("Cập nhật thất bại!"); }
                }
                catch (ArgumentException argEx) { ShowWarning($"Lỗi dữ liệu: {argEx.Message}"); }
                catch (Exception ex) { ShowError($"Lỗi khi cập nhật: {ex.Message}"); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaNCC.HasValue) { ShowWarning("Chọn NCC cần xóa."); return; }
            int maNCC = currentSelectedMaNCC.Value;
            if (MessageBox.Show($"Bạn chắc muốn xóa NCC mã '{maNCC}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (busNCC.XoaNhaCungCap(maNCC)) { ShowInfo("Xóa thành công!"); LoadData(); }
                    else { ShowError("Xóa thất bại! Kiểm tra FK."); }
                }
                catch (ArgumentException argEx) { ShowWarning($"Lỗi: {argEx.Message}"); }
                catch (SqlException sqlEx) when (sqlEx.Number == 547) { ShowWarning("Không thể xóa (lỗi FK)."); }
                catch (Exception ex) { ShowError($"Lỗi khi xóa: {ex.Message}"); }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { LoadData(); }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhaCungCap.Rows.Count)
            {
                DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];
                if (row?.Cells["MaNCC"]?.Value == null || row.Cells["MaNCC"].Value == DBNull.Value) { ClearForm(); return; }
                currentSelectedMaNCC = Convert.ToInt32(row.Cells["MaNCC"].Value);
                Func<string, string> getCell = (cn) => { if (row.DataGridView.Columns.Contains(cn)) { return row.Cells[cn]?.Value?.ToString() ?? ""; } return ""; };
                txtMaNCC.Text = getCell("MaNCC"); txtTenNCC.Text = getCell("TenNCC");
                txtDiaChi.Text = getCell("DiaChi"); txtSoDienThoai.Text = getCell("SoDienThoai");
                UpdateButtonStates(true);
            }
            else { ClearForm(); }
        }


        private void label1_Click(object sender, EventArgs e) { }
        #endregion
    }
}