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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using iTextFont = iTextSharp.text.Font;

namespace GUI_QuanLyCuaHang279
{
    public partial class frmHoaDon : Form
    {
        private HoaDonBUS busHD = new HoaDonBUS();
        private NhanVienBUS busNV = new NhanVienBUS();
        private KhachHangBUS busKH = new KhachHangBUS();
        private ChiTietHoaDonBUS busCTHD = new ChiTietHoaDonBUS();
        private SachBUS busSach = new SachBUS();
        private int? currentSelectedMaHD = null;
        private int? currentSelectedMaCTHD = null;
        private int? currentSelectedDetailMaSach = null;
        private int currentSelectedDetailSoLuongCu = 0;
        public frmHoaDon()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            dgvHoaDon.AllowUserToAddRows = false; dgvHoaDon.AllowUserToDeleteRows = false; dgvHoaDon.ReadOnly = true; dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvHoaDon.MultiSelect = false; dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHD.AllowUserToAddRows = false; dgvChiTietHD.AllowUserToDeleteRows = false; dgvChiTietHD.ReadOnly = true; dgvChiTietHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvChiTietHD.MultiSelect = false; dgvChiTietHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtMaHD.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtMaCTHD.ReadOnly = true;
            txtThanhTienCT.ReadOnly = true;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHoaDonData();
                AssignEventHandlers();
            }
            catch (Exception ex) { ShowError($"Lỗi khởi tạo Form Hóa Đơn: {ex.Message}"); }
        }

        private void AssignEventHandlers()
        {
            dgvHoaDon.CellClick -= dgvHoaDon_CellClick; dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            dgvChiTietHD.CellClick -= dgvChiTietHD_CellClick; dgvChiTietHD.CellClick += dgvChiTietHD_CellClick;
            txtSoLuongCT.TextChanged -= CalculateThanhTienEvent; txtSoLuongCT.TextChanged += CalculateThanhTienEvent;
            txtDonGiaCT.TextChanged -= CalculateThanhTienEvent; txtDonGiaCT.TextChanged += CalculateThanhTienEvent;
        }

        private void LoadHoaDonData()
        {
            try
            {
                dgvHoaDon.DataSource = null;
                dgvHoaDon.DataSource = busHD.GetAll();
                ConfigureHoaDonColumns();
                ClearAllInputs();
            }
            catch (Exception ex) { ShowError($"Lỗi tải danh sách Hóa Đơn: {ex.Message}"); }
        }

        private void LoadChiTietData(int maHD)
        {
            try
            {
                dgvChiTietHD.DataSource = null;
                dgvChiTietHD.DataSource = busCTHD.GetByMaHD(maHD);
                ConfigureChiTietColumns();
                TinhVaHienThiTongTien();
            }
            catch (Exception ex) { ShowError($"Lỗi tải chi tiết cho HĐ {maHD}: {ex.Message}"); }
        }

        private void ConfigureHoaDonColumns()
        {
            if (dgvHoaDon.Columns.Count > 0)
            {
                dgvHoaDon.Columns["MaHD"].HeaderText = "Mã HĐ";
                dgvHoaDon.Columns["MaNV"].HeaderText = "Mã NV";
                dgvHoaDon.Columns["MaKH"].HeaderText = "Mã KH";
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
        }

        private void ConfigureChiTietColumns()
        {
            if (dgvChiTietHD.Columns.Count > 0)
            {
                if (dgvChiTietHD.Columns.Contains("MaHD")) dgvChiTietHD.Columns["MaHD"].Visible = false;
                dgvChiTietHD.Columns["MaCTHD"].HeaderText = "Mã CT";
                dgvChiTietHD.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvChiTietHD.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvChiTietHD.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvChiTietHD.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvChiTietHD.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvChiTietHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
        }

        private void ClearAllInputs()
        {
            currentSelectedMaHD = null;
            txtMaHD.Clear();
            txtMaNV.Clear();
            txtMaKH.Clear();
            dtpNgayLap.Value = DateTime.Now;
            txtTongTien.Text = "0";
            ClearChiTietInput();
            dgvChiTietHD.DataSource = null;
            txtTimKiem.Clear();
        }

        private void ClearChiTietInput()
        {
            currentSelectedMaCTHD = null;
            currentSelectedDetailMaSach = null;
            currentSelectedDetailSoLuongCu = 0;
            txtMaCTHD.Clear();
            txtMaSachCT.Clear();
            txtSoLuongCT.Clear();
            txtDonGiaCT.Clear();
            txtThanhTienCT.Clear();
            txtMaSachCT.Focus();
        }

        private bool ValidateHoaDonMasterInput(out HoaDonDTO hd)
        {
            hd = new HoaDonDTO();
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)) { ShowWarning("Vui lòng nhập Mã Nhân viên."); txtMaNV.Focus(); return false; }
            if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV) || maNV <= 0) { ShowWarning("Mã Nhân viên không hợp lệ."); txtMaNV.Focus(); txtMaNV.SelectAll(); return false; }

            if (string.IsNullOrWhiteSpace(txtMaKH.Text)) { ShowWarning("Vui lòng nhập Mã Khách hàng."); txtMaKH.Focus(); return false; }
            if (!int.TryParse(txtMaKH.Text.Trim(), out int maKH) || maKH <= 0) { ShowWarning("Mã Khách hàng không hợp lệ."); txtMaKH.Focus(); txtMaKH.SelectAll(); return false; }

            hd.MaNV = maNV;
            hd.MaKH = maKH;
            hd.NgayLap = dtpNgayLap.Value;
            if (currentSelectedMaHD.HasValue) { hd.MaHD = currentSelectedMaHD.Value; }
            return true;
        }

        private bool ValidateChiTietInput(out ChiTietHoaDonDTO ct)
        {
            ct = new ChiTietHoaDonDTO();
            if (string.IsNullOrWhiteSpace(txtMaSachCT.Text)) { ShowWarning("Vui lòng nhập Mã Sách."); txtMaSachCT.Focus(); return false; }
            if (!int.TryParse(txtMaSachCT.Text.Trim(), out int maSach) || maSach <= 0) { ShowWarning("Mã Sách không hợp lệ."); txtMaSachCT.Focus(); txtMaSachCT.SelectAll(); return false; }

            if (!int.TryParse(txtSoLuongCT.Text.Trim(), out int soLuong) || soLuong <= 0) { ShowWarning("Số lượng phải là số nguyên lớn hơn 0."); txtSoLuongCT.Focus(); return false; }
            if (!decimal.TryParse(txtDonGiaCT.Text.Trim().Replace(",", ""), out decimal donGia) || donGia < 0) { ShowWarning("Đơn giá không hợp lệ."); txtDonGiaCT.Focus(); return false; }
            ct.MaSach = maSach;
            ct.SoLuong = soLuong;
            ct.DonGia = donGia;
            if (currentSelectedMaCTHD.HasValue) { ct.MaCTHD = currentSelectedMaCTHD.Value; }
            return true;
        }

        private decimal TinhTongTienDataGridView()
        {
            decimal tong = 0;
            var dataSource = dgvChiTietHD.DataSource as IList<ChiTietHoaDonDTO>;
            if (dataSource != null) { tong = dataSource.Sum(item => item.ThanhTien); }
            return tong;
        }

        private void TinhVaHienThiTongTien()
        {
            txtTongTien.Text = TinhTongTienDataGridView().ToString("N0");
        }

        private void TinhThanhTienChiTiet()
        {
            if (int.TryParse(txtSoLuongCT.Text, out int sl) && decimal.TryParse(txtDonGiaCT.Text.Replace(",", ""), out decimal dg))
            { txtThanhTienCT.Text = (sl * dg).ToString("N0"); }
            else { txtThanhTienCT.Clear(); }
        }

        private void CapNhatTongTienHoaDonCha(int maHD)
        {
            decimal tongTienMoi = TinhTongTienDataGridView();
            try
            {
                if (!busHD.UpdateTongTien(maHD, tongTienMoi)) { Console.WriteLine($"Warning: Update TongTien failed for MaHD={maHD}."); }
                else
                {
                    txtTongTien.Text = tongTienMoi.ToString("N0");
                    var rowToUpdate = dgvHoaDon.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["MaHD"].Value) == maHD);
                    if (rowToUpdate != null) { rowToUpdate.Cells["TongTien"].Value = tongTienMoi; }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error updating TongTien for MaHD={maHD}: {ex.Message}"); }
        }

        private void ShowError(string message) { MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        private void ShowWarning(string message) { MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        private void ShowInfo(string message) { MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateHoaDonMasterInput(out HoaDonDTO hd))
            {
                hd.TongTien = 0;
                try
                {
                    int newMaHD = busHD.Insert(hd);
                    if (newMaHD > 0)
                    {
                        ShowInfo($"Thêm HĐ mã {newMaHD} thành công!");
                        LoadHoaDonData();
                        var rowToSelect = dgvHoaDon.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["MaHD"].Value) == newMaHD);
                        if (rowToSelect != null) { dgvHoaDon.ClearSelection(); rowToSelect.Selected = true; dgvHoaDon.CurrentCell = rowToSelect.Cells[1]; dgvHoaDon_CellClick(dgvHoaDon, new DataGridViewCellEventArgs(1, rowToSelect.Index)); }
                    }
                    else { ShowError("Thêm Hóa Đơn thất bại!"); }
                }
                catch (Exception ex) { ShowError($"Lỗi khi thêm Hóa Đơn: {ex.Message}"); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaHD.HasValue) { ShowWarning("Vui lòng chọn hóa đơn cần sửa."); return; }
            if (ValidateHoaDonMasterInput(out HoaDonDTO hd))
            {
                if (decimal.TryParse(txtTongTien.Text.Replace(",", ""), out decimal tongTien)) hd.TongTien = tongTien; else hd.TongTien = 0;
                hd.MaHD = currentSelectedMaHD.Value;
                try
                {
                    if (busHD.Update(hd))
                    {
                        ShowInfo("Cập nhật HĐ thành công!");
                        int selectedIdx = dgvHoaDon.CurrentRow?.Index ?? -1;
                        LoadHoaDonData();
                        if (selectedIdx >= 0 && selectedIdx < dgvHoaDon.Rows.Count) { dgvHoaDon.ClearSelection(); dgvHoaDon.Rows[selectedIdx].Selected = true; dgvHoaDon.CurrentCell = dgvHoaDon.Rows[selectedIdx].Cells[1]; }
                    }
                    else { ShowError("Cập nhật HĐ thất bại!"); }
                }
                catch (Exception ex) { ShowError($"Lỗi khi cập nhật HĐ: {ex.Message}"); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaHD.HasValue) { ShowWarning("Vui lòng chọn hóa đơn cần xoá."); return; }
            int maHDCanXoa = currentSelectedMaHD.Value;
            if (MessageBox.Show($"Bạn chắc chắn muốn xoá hóa đơn mã '{maHDCanXoa}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (busHD.Delete(maHDCanXoa)) { ShowInfo("Xoá HĐ thành công!"); LoadHoaDonData(); }
                    else { ShowError("Xoá HĐ thất bại!"); }
                }
                catch (SqlException sqlEx) when (sqlEx.Number == 547) { ShowWarning("Không thể xóa HĐ này (lỗi FK)."); }
                catch (Exception ex) { ShowError($"Lỗi khi xóa HĐ: {ex.Message}"); }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadHoaDonData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTimKiem.Text.Trim(), out int maKHTim))
            {
                try
                {
                    dgvHoaDon.DataSource = null;
                    var ketQua = busHD.SearchByMaKH(maKHTim);
                    dgvHoaDon.DataSource = ketQua;
                    ConfigureHoaDonColumns();
                    if (ketQua.Count == 0) ShowInfo("Không tìm thấy hóa đơn.");
                    ClearAllInputs();
                    dgvHoaDon.DataSource = ketQua;
                    ConfigureHoaDonColumns();
                }
                catch (Exception ex) { ShowError($"Lỗi tìm kiếm HĐ: {ex.Message}"); }
            }
            else { ShowWarning("Vui lòng nhập Mã Khách Hàng hợp lệ."); }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHoaDon.Rows.Count)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                if (row?.Cells["MaHD"]?.Value != null && int.TryParse(row.Cells["MaHD"].Value.ToString(), out int selectedMaHD))
                {
                    currentSelectedMaHD = selectedMaHD;
                    txtMaHD.Text = selectedMaHD.ToString();
                    Func<string, string> getCellValue = (colName) => row.Cells[colName]?.Value?.ToString() ?? "";
                    txtMaNV.Text = getCellValue("MaNV");
                    txtMaKH.Text = getCellValue("MaKH");
                    dtpNgayLap.Value = DateTime.TryParse(getCellValue("NgayLap"), out DateTime nl) ? nl : DateTime.Now;
                    LoadChiTietData(selectedMaHD);
                    ClearChiTietInput();
                }
                else { ClearAllInputs(); }
            }
            else { ClearAllInputs(); }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaHD.HasValue) { ShowWarning("Vui lòng chọn hóa đơn trước."); return; }
            if (ValidateChiTietInput(out ChiTietHoaDonDTO ct))
            {
                ct.MaHD = currentSelectedMaHD.Value;
                try
                {
                    var currentDetails = busCTHD.GetByMaHD(currentSelectedMaHD.Value);
                    if (currentDetails.Any(item => item.MaSach == ct.MaSach))
                    { ShowWarning("Sách này đã tồn tại trong hóa đơn."); return; }

                    if (busCTHD.Insert(ct))
                    {
                        LoadChiTietData(currentSelectedMaHD.Value);
                        CapNhatTongTienHoaDonCha(currentSelectedMaHD.Value);
                        ClearChiTietInput();
                    }
                    else { ShowError("Thêm chi tiết thất bại!"); }
                }
                catch (InvalidOperationException khoEx) { ShowWarning(khoEx.Message); }
                catch (Exception ex) { ShowError($"Lỗi khi thêm chi tiết: {ex.Message}"); }
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaCTHD.HasValue) { ShowWarning("Vui lòng chọn chi tiết cần sửa."); return; }
            if (currentSelectedDetailSoLuongCu <= 0) { ShowWarning("Không lấy được số lượng cũ hợp lệ để cập nhật kho."); return; }

            if (ValidateChiTietInput(out ChiTietHoaDonDTO ct))
            {
                ct.MaHD = currentSelectedMaHD ?? 0;
                ct.MaCTHD = currentSelectedMaCTHD.Value;

                try
                {
                    if (busCTHD.Update(ct, currentSelectedDetailSoLuongCu))
                    {
                        ShowInfo("Cập nhật chi tiết thành công!");
                        if (currentSelectedMaHD.HasValue)
                        {
                            LoadChiTietData(currentSelectedMaHD.Value);
                            CapNhatTongTienHoaDonCha(currentSelectedMaHD.Value);
                        }
                        ClearChiTietInput();
                    }
                    else { ShowError("Cập nhật chi tiết thất bại!"); }
                }
                catch (InvalidOperationException khoEx) { ShowWarning(khoEx.Message); }
                catch (Exception ex) { ShowError($"Lỗi khi cập nhật chi tiết: {ex.Message}"); }
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaCTHD.HasValue) { ShowWarning("Vui lòng chọn chi tiết cần xóa."); return; }
            if (!currentSelectedDetailMaSach.HasValue) { ShowWarning("Không lấy được Mã Sách của chi tiết cần xóa."); return; }
            if (currentSelectedDetailSoLuongCu <= 0) { ShowWarning("Không lấy được Số Lượng của chi tiết cần xóa."); return; }

            int maCTHDCanXoa = currentSelectedMaCTHD.Value;
            int maSachCanXoa = currentSelectedDetailMaSach.Value;
            int soLuongCanXoa = currentSelectedDetailSoLuongCu;

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa chi tiết này (Sách: {maSachCanXoa}, SL: {soLuongCanXoa})?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (busCTHD.Delete(maCTHDCanXoa, maSachCanXoa, soLuongCanXoa))
                    {
                        ShowInfo("Xóa chi tiết thành công!");
                        if (currentSelectedMaHD.HasValue)
                        {
                            LoadChiTietData(currentSelectedMaHD.Value);
                            CapNhatTongTienHoaDonCha(currentSelectedMaHD.Value);
                        }
                        ClearChiTietInput();
                    }
                    else { ShowError("Xóa chi tiết thất bại!"); }
                }
                catch (InvalidOperationException khoEx) { ShowWarning(khoEx.Message); }
                catch (Exception ex) { ShowError($"Lỗi khi xóa chi tiết: {ex.Message}"); }
            }
        }


        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChiTietHD.Rows.Count)
            {
                DataGridViewRow row = dgvChiTietHD.Rows[e.RowIndex];
                if (row?.Cells["MaCTHD"]?.Value != null && int.TryParse(row.Cells["MaCTHD"].Value.ToString(), out int selectedMaCTHD))
                {
                    currentSelectedMaCTHD = selectedMaCTHD;
                    Func<string, string> getCellValue = (colName) => { if (row.DataGridView.Columns.Contains(colName)) { var cell = row.Cells[colName]; if (cell?.Value != null && cell.Value != DBNull.Value) return cell.Value.ToString(); } return ""; };
                    txtMaCTHD.Text = selectedMaCTHD.ToString();
                    txtMaSachCT.Text = getCellValue("MaSach");
                    txtSoLuongCT.Text = getCellValue("SoLuong");
                    txtDonGiaCT.Text = getCellValue("DonGia");
                    TinhThanhTienChiTiet();

                    if (int.TryParse(txtMaSachCT.Text, out int maSach)) { currentSelectedDetailMaSach = maSach; } else { currentSelectedDetailMaSach = null; }
                    if (int.TryParse(txtSoLuongCT.Text, out int slCu)) { currentSelectedDetailSoLuongCu = slCu; } else { currentSelectedDetailSoLuongCu = 0; }
                }
                else { ClearChiTietInput(); }
            }
            else { ClearChiTietInput(); }
        }


        private void btnLamMoiCT_Click(object sender, EventArgs e)
        {
            ClearChiTietInput();
        }

        private void CalculateThanhTienEvent(object sender, EventArgs e)
        {
            TinhThanhTienChiTiet();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtSearchBox_TextChanged(object sender, EventArgs e) { }
        private void groupBox5_Enter(object sender, EventArgs e) { }

        private void btnInHDB_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaHD.HasValue || currentSelectedMaHD.Value <= 0)
            {
                ShowWarning("Vui lòng chọn một hóa đơn từ danh sách để in.");
                return;
            }

            int maHDCanIn = currentSelectedMaHD.Value;

            HoaDonDTO hoaDonXuat = busHD.GetHoaDonChiTietForReport(maHDCanIn);
            if (hoaDonXuat == null)
            {
                ShowError($"Không tìm thấy thông tin cho hóa đơn có mã: {maHDCanIn}");
                return;
            }

            List<ChiTietHoaDonDTO> chiTietXuat = busCTHD.GetByMaHD(maHDCanIn);
            if (chiTietXuat == null)
            {
                ShowError($"Không thể lấy chi tiết cho hóa đơn có mã: {maHDCanIn}");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Lưu Hóa Đơn Bán Hàng PDF";
            saveFileDialog.FileName = $"HDB_{hoaDonXuat.MaHD}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    Document doc = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                    doc.Open();

                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    // Sử dụng iTextFont ở đây và các chỗ khác
                    iTextFont fontTieuDeTrang = new iTextFont(bf, 20, iTextFont.BOLD);
                    iTextFont fontTieuDeMuc = new iTextFont(bf, 14, iTextFont.BOLD);
                    iTextFont fontBold = new iTextFont(bf, 11, iTextFont.BOLD);
                    iTextFont fontNormal = new iTextFont(bf, 11);
                    iTextFont fontSmallItalic = new iTextFont(bf, 9, iTextFont.ITALIC);

                    Paragraph tenCuaHang = new Paragraph("CỬA HÀNG SÁCH 279", new iTextFont(bf, 16, iTextFont.BOLD | iTextFont.UNDERLINE));
                    tenCuaHang.Alignment = Element.ALIGN_CENTER;
                    doc.Add(tenCuaHang);

                    Paragraph diaChiCuaHang = new Paragraph("Địa chỉ: [Số 279 Điện Biên II, Thành phố Hưng Yên, Tỉnh Hưng Yên]", fontSmallItalic);
                    diaChiCuaHang.Alignment = Element.ALIGN_CENTER;
                    doc.Add(diaChiCuaHang);

                    Paragraph sdtCuaHang = new Paragraph("Điện thoại: [02213863077]", fontSmallItalic);
                    sdtCuaHang.Alignment = Element.ALIGN_CENTER;
                    doc.Add(sdtCuaHang);
                    doc.Add(Chunk.NEWLINE);

                    Paragraph title = new Paragraph("HÓA ĐƠN BÁN HÀNG", fontTieuDeTrang);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingBefore = 10f;
                    title.SpacingAfter = 20f;
                    doc.Add(title);

                    PdfPTable infoTable = new PdfPTable(2);
                    infoTable.WidthPercentage = 80;
                    infoTable.HorizontalAlignment = Element.ALIGN_CENTER;
                    infoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    infoTable.DefaultCell.PaddingBottom = 5f;

                    infoTable.AddCell(new Phrase($"Số HĐ:", fontBold));
                    infoTable.AddCell(new Phrase($"{hoaDonXuat.MaHD}", fontNormal));
                    infoTable.AddCell(new Phrase($"Ngày lập:", fontBold));
                    infoTable.AddCell(new Phrase($"{hoaDonXuat.NgayLap:dd/MM/yyyy HH:mm:ss}", fontNormal));
                    infoTable.AddCell(new Phrase($"Khách hàng:", fontBold));
                    infoTable.AddCell(new Phrase($"{(!string.IsNullOrEmpty(hoaDonXuat.TenKhachHang) ? hoaDonXuat.TenKhachHang : "Khách lẻ")}", fontNormal));
                    infoTable.AddCell(new Phrase($"Nhân viên:", fontBold));
                    infoTable.AddCell(new Phrase($"{(!string.IsNullOrEmpty(hoaDonXuat.TenNhanVien) ? hoaDonXuat.TenNhanVien : "N/A")}", fontNormal));
                    doc.Add(infoTable);
                    doc.Add(Chunk.NEWLINE);

                    Paragraph tblHeader = new Paragraph("CHI TIẾT SẢN PHẨM", fontTieuDeMuc);
                    tblHeader.SpacingBefore = 10f;
                    tblHeader.SpacingAfter = 5f;
                    doc.Add(tblHeader);

                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 0.8f, 4f, 1f, 1.8f, 2.2f });

                    PdfPCell cellHeader;
                    cellHeader = new PdfPCell(new Phrase("STT", fontBold)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 };
                    table.AddCell(cellHeader);
                    cellHeader = new PdfPCell(new Phrase("Tên Sách", fontBold)) { VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 };
                    table.AddCell(cellHeader);
                    cellHeader = new PdfPCell(new Phrase("SL", fontBold)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 };
                    table.AddCell(cellHeader);
                    cellHeader = new PdfPCell(new Phrase("Đơn Giá (VNĐ)", fontBold)) { HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 };
                    table.AddCell(cellHeader);
                    cellHeader = new PdfPCell(new Phrase("Thành Tiền (VNĐ)", fontBold)) { HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 };
                    table.AddCell(cellHeader);
                    table.HeaderRows = 1;

                    int stt = 1;
                    PdfPCell cellData;
                    if (chiTietXuat != null && chiTietXuat.Any())
                    {
                        foreach (var ct in chiTietXuat)
                        {
                            cellData = new PdfPCell(new Phrase(stt.ToString(), fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 };
                            table.AddCell(cellData);
                            cellData = new PdfPCell(new Phrase(ct.TenSach ?? "N/A", fontNormal)) { Padding = 4 };
                            table.AddCell(cellData);
                            cellData = new PdfPCell(new Phrase(ct.SoLuong.ToString(), fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4 };
                            table.AddCell(cellData);
                            cellData = new PdfPCell(new Phrase(ct.DonGia.ToString("N0"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4 };
                            table.AddCell(cellData);
                            cellData = new PdfPCell(new Phrase(ct.ThanhTien.ToString("N0"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4 };
                            table.AddCell(cellData);
                            stt++;
                        }
                    }
                    else
                    {
                        PdfPCell emptyCell = new PdfPCell(new Phrase("Không có chi tiết sản phẩm.", fontNormal)) { Colspan = 5, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 10 };
                        table.AddCell(emptyCell);
                    }
                    doc.Add(table);
                    doc.Add(Chunk.NEWLINE);

                    Paragraph tongCong = new Paragraph($"Tổng cộng thanh toán: {hoaDonXuat.TongTien:N0} VNĐ", new iTextFont(bf, 13, iTextFont.BOLD));
                    tongCong.Alignment = Element.ALIGN_RIGHT;
                    tongCong.SpacingBefore = 10f;
                    doc.Add(tongCong);
                    doc.Add(Chunk.NEWLINE);

                    Paragraph loiCamOn = new Paragraph("Xin chân thành cảm ơn Quý khách!", new iTextFont(bf, 11, iTextFont.ITALIC));
                    loiCamOn.Alignment = Element.ALIGN_CENTER;
                    loiCamOn.SpacingBefore = 20f;
                    doc.Add(loiCamOn);

                    Paragraph henGapLai = new Paragraph("Hẹn gặp lại!", new iTextFont(bf, 11, iTextFont.ITALIC));
                    henGapLai.Alignment = Element.ALIGN_CENTER;
                    doc.Add(henGapLai);

                    PdfPTable signatureTable = new PdfPTable(2);
                    signatureTable.WidthPercentage = 80;
                    signatureTable.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin - 100;
                    signatureTable.HorizontalAlignment = Element.ALIGN_CENTER;
                    signatureTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    signatureTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    signatureTable.DefaultCell.PaddingTop = 40f;

                    signatureTable.AddCell(new Phrase("Khách hàng\n(Ký, họ tên)", fontNormal));
                    signatureTable.AddCell(new Phrase("Người bán hàng\n(Ký, họ tên)", fontNormal));
                    doc.Add(signatureTable);

                    doc.Close();
                    writer.Close();

                    ShowInfo("Xuất hóa đơn PDF thành công!\nĐã lưu tại: " + filePath);

                    DialogResult dr = MessageBox.Show("Bạn có muốn mở file PDF vừa xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                    }
                }
                catch (IOException ioEx)
                {
                    ShowError("Lỗi IO khi tạo file PDF: File có thể đang được sử dụng bởi một ứng dụng khác.\n" + ioEx.Message);
                }
                catch (Exception ex)
                {
                    ShowError("Lỗi không xác định khi tạo file PDF: " + ex.Message);
                }
            }
        }
    }
}