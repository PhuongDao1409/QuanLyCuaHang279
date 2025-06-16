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
    public partial class frmPhieuNhap : Form
    {
        private PhieuNhapBUS busPN = new PhieuNhapBUS();
        private ChiTietPhieuNhapBUS busCTPN = new ChiTietPhieuNhapBUS();
        private NhanVienBUS busNV = new NhanVienBUS();
        private NhaCungCapBUS busNCC = new NhaCungCapBUS(); 
        private SachBUS busSach = new SachBUS(); 

        private int? currentSelectedMaPN = null;
        private int? currentSelectedDetailMaSach = null;
        private int currentSelectedDetailSoLuongCu = 0;

        public frmPhieuNhap()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            dgvPhieuNhap.AllowUserToAddRows = false; dgvPhieuNhap.AllowUserToDeleteRows = false; dgvPhieuNhap.ReadOnly = true; dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvPhieuNhap.MultiSelect = false; dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPN.AllowUserToAddRows = false; dgvChiTietPN.AllowUserToDeleteRows = false; dgvChiTietPN.ReadOnly = true; dgvChiTietPN.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgvChiTietPN.MultiSelect = false; dgvChiTietPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtMaPhieuNhap.ReadOnly = true;
            txtTongTienPN.ReadOnly = true;
            txtThanhTienPN.ReadOnly = true;
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPhieuNhapData();
                AssignEventHandlers();
            }
            catch (Exception ex) { ShowError($"Lỗi khởi tạo Form Phiếu Nhập: {ex.Message}"); }
        }

        private void AssignEventHandlers()
        {
            dgvPhieuNhap.CellClick -= dgvPhieuNhap_CellClick; dgvPhieuNhap.CellClick += dgvPhieuNhap_CellClick;
            dgvChiTietPN.CellClick -= dgvChiTietPN_CellClick; dgvChiTietPN.CellClick += dgvChiTietPN_CellClick;
            txtSoLuongPN.TextChanged -= CalculateThanhTienEvent; txtSoLuongPN.TextChanged += CalculateThanhTienEvent;
            txtGiaNhapPN.TextChanged -= CalculateThanhTienEvent; txtGiaNhapPN.TextChanged += CalculateThanhTienEvent;
            
        }

        #region Load Data & UI Config
        private void LoadPhieuNhapData()
        {
            try
            {
                dgvPhieuNhap.DataSource = null;
                dgvPhieuNhap.DataSource = busPN.LayDanhSachPhieuNhap();
                ConfigurePhieuNhapColumns();
                ClearAllInputs();
            }
            catch (Exception ex) { ShowError($"Lỗi tải danh sách Phiếu Nhập: {ex.Message}"); }
        }

        private void LoadChiTietData(int maPN)
        {
            try
            {
                dgvChiTietPN.DataSource = null;
                dgvChiTietPN.DataSource = busCTPN.LayChiTietTheoMaPN(maPN);
                ConfigureChiTietColumns();
                TinhVaHienThiTongTien();
            }
            catch (Exception ex) { ShowError($"Lỗi tải chi tiết cho PN {maPN}: {ex.Message}"); }
        }

        private void ConfigurePhieuNhapColumns()
        {
            if (dgvPhieuNhap.Columns.Count > 0)
            {
                dgvPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã PN";
                dgvPhieuNhap.Columns["MaNV"].HeaderText = "Mã NV";
                dgvPhieuNhap.Columns["MaNCC"].HeaderText = "Mã NCC";
                dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvPhieuNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvPhieuNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPhieuNhap.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
        }

        private void ConfigureChiTietColumns()
        {
            if (dgvChiTietPN.Columns.Count > 0)
            {
                if (dgvChiTietPN.Columns.Contains("MaPhieuNhap")) dgvChiTietPN.Columns["MaPhieuNhap"].Visible = false;
                dgvChiTietPN.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvChiTietPN.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvChiTietPN.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                dgvChiTietPN.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvChiTietPN.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                dgvChiTietPN.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                dgvChiTietPN.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTietPN.Columns["GiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTietPN.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        #endregion

        #region Clear, Validate, Calculate & Helpers
        private void ClearAllInputs()
        {
            currentSelectedMaPN = null;
            txtMaPhieuNhap.Clear();
            txtMaNVPN.Clear();
            txtMaNCCPN.Clear();
            dtpNgayNhap.Value = DateTime.Now.Date;
            txtTongTienPN.Text = "0";
            ClearChiTietInput();
            dgvChiTietPN.DataSource = null;
            txtTimKiemPN.Clear();
        }

        private void ClearChiTietInput()
        {
            currentSelectedDetailMaSach = null;
            currentSelectedDetailSoLuongCu = 0;
            txtMaSachCTPN.Clear();
            txtMaSachCTPN.ReadOnly = false; // Cho phép nhập lại mã sách
            txtSoLuongPN.Clear();
            txtGiaNhapPN.Clear();
            txtThanhTienPN.Clear();
            txtMaSachCTPN.Focus();
        }

        private bool ValidatePhieuNhapMasterInput(out PhieuNhapDTO pn)
        {
            pn = new PhieuNhapDTO();
            if (string.IsNullOrWhiteSpace(txtMaNVPN.Text)) { ShowWarning("Vui lòng nhập Mã Nhân viên."); txtMaNVPN.Focus(); return false; }
            if (!int.TryParse(txtMaNVPN.Text.Trim(), out int maNV) || maNV <= 0) { ShowWarning("Mã Nhân viên không hợp lệ."); txtMaNVPN.Focus(); txtMaNVPN.SelectAll(); return false; }

            if (string.IsNullOrWhiteSpace(txtMaNCCPN.Text)) { ShowWarning("Vui lòng nhập Mã Nhà cung cấp."); txtMaNCCPN.Focus(); return false; }
            if (!int.TryParse(txtMaNCCPN.Text.Trim(), out int maNCC) || maNCC <= 0) { ShowWarning("Mã Nhà cung cấp không hợp lệ."); txtMaNCCPN.Focus(); txtMaNCCPN.SelectAll(); return false; }

            pn.MaNV = maNV;
            pn.MaNCC = maNCC;
            pn.NgayNhap = dtpNgayNhap.Value;
            if (currentSelectedMaPN.HasValue) { pn.MaPhieuNhap = currentSelectedMaPN.Value; }
            return true;
        }

        private bool ValidateChiTietInput(out ChiTietPhieuNhapDTO ct)
        {
            ct = new ChiTietPhieuNhapDTO();
            if (string.IsNullOrWhiteSpace(txtMaSachCTPN.Text)) { ShowWarning("Vui lòng nhập Mã Sách."); txtMaSachCTPN.Focus(); return false; }
            if (!int.TryParse(txtMaSachCTPN.Text.Trim(), out int maSach) || maSach <= 0) { ShowWarning("Mã Sách không hợp lệ."); txtMaSachCTPN.Focus(); txtMaSachCTPN.SelectAll(); return false; }

            if (!int.TryParse(txtSoLuongPN.Text.Trim(), out int soLuong) || soLuong <= 0) { ShowWarning("Số lượng phải lớn hơn 0."); txtSoLuongPN.Focus(); return false; }
            if (!decimal.TryParse(txtGiaNhapPN.Text.Trim().Replace(",", ""), out decimal giaNhap) || giaNhap < 0) { ShowWarning("Giá nhập không hợp lệ."); txtGiaNhapPN.Focus(); return false; }
            ct.MaSach = maSach;
            ct.SoLuong = soLuong;
            ct.GiaNhap = giaNhap;
            // MaPhieuNhap sẽ được gán sau
            return true;
        }

        private decimal TinhTongTienDataGridView()
        {
            decimal tong = 0;
            var dataSource = dgvChiTietPN.DataSource as IList<ChiTietPhieuNhapDTO>;
            if (dataSource != null) { tong = dataSource.Sum(item => item.ThanhTien); }
            return tong;
        }

        private void TinhVaHienThiTongTien()
        {
            txtTongTienPN.Text = TinhTongTienDataGridView().ToString("N0");
        }

        private void TinhThanhTienChiTiet()
        {
            if (int.TryParse(txtSoLuongPN.Text, out int sl) && decimal.TryParse(txtGiaNhapPN.Text.Replace(",", ""), out decimal gn))
            { txtThanhTienPN.Text = (sl * gn).ToString("N0"); }
            else { txtThanhTienPN.Clear(); }
        }

        private void CapNhatTongTienPhieuNhapCha(int maPN)
        {
            decimal tongTienMoi = TinhTongTienDataGridView();
            try
            {
                if (!busPN.CapNhatTongTien(maPN, tongTienMoi)) { Console.WriteLine($"Warning: Update TongTien PN failed for MaPN={maPN}."); }
                else
                {
                    txtTongTienPN.Text = tongTienMoi.ToString("N0");
                    var rowToUpdate = dgvPhieuNhap.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["MaPhieuNhap"].Value) == maPN);
                    if (rowToUpdate != null) { rowToUpdate.Cells["TongTien"].Value = tongTienMoi; }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error updating TongTien PN for MaPN={maPN}: {ex.Message}"); }
        }

        private void ShowError(string message) { MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        private void ShowWarning(string message) { MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        private void ShowInfo(string message) { MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        #endregion

        #region Phiếu Nhập Master Events
        private void btnThemPN_Click(object sender, EventArgs e)
        {
            if (ValidatePhieuNhapMasterInput(out PhieuNhapDTO pn))
            {
                pn.TongTien = 0;
                try
                {
                    int newMaPN = busPN.ThemPhieuNhap(pn);
                    if (newMaPN > 0)
                    {
                        ShowInfo($"Thêm PN mã {newMaPN} thành công!");
                        LoadPhieuNhapData();
                        var rowToSelect = dgvPhieuNhap.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["MaPhieuNhap"].Value) == newMaPN);
                        if (rowToSelect != null) { dgvPhieuNhap.ClearSelection(); rowToSelect.Selected = true; dgvPhieuNhap.CurrentCell = rowToSelect.Cells[1]; dgvPhieuNhap_CellClick(dgvPhieuNhap, new DataGridViewCellEventArgs(1, rowToSelect.Index)); }
                    }
                    else { ShowError("Thêm Phiếu Nhập thất bại!"); }
                }
                catch (Exception ex) { ShowError($"Lỗi khi thêm Phiếu Nhập: {ex.Message}"); }
            }
        }

        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaPN.HasValue) { ShowWarning("Vui lòng chọn phiếu nhập cần sửa."); return; }
            if (ValidatePhieuNhapMasterInput(out PhieuNhapDTO pn))
            {
                if (decimal.TryParse(txtTongTienPN.Text.Replace(",", ""), out decimal tt)) pn.TongTien = tt; else pn.TongTien = 0;
                pn.MaPhieuNhap = currentSelectedMaPN.Value;
                try
                {
                    if (busPN.CapNhatPhieuNhap(pn))
                    {
                        ShowInfo("Cập nhật PN thành công!");
                        int selectedIdx = dgvPhieuNhap.CurrentRow?.Index ?? -1;
                        LoadPhieuNhapData();
                        if (selectedIdx >= 0 && selectedIdx < dgvPhieuNhap.Rows.Count) { dgvPhieuNhap.ClearSelection(); dgvPhieuNhap.Rows[selectedIdx].Selected = true; dgvPhieuNhap.CurrentCell = dgvPhieuNhap.Rows[selectedIdx].Cells[1]; }
                    }
                    else { ShowError("Cập nhật PN thất bại!"); }
                }
                catch (Exception ex) { ShowError($"Lỗi khi cập nhật PN: {ex.Message}"); }
            }
        }

        private void btnXoaPN_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaPN.HasValue) { ShowWarning("Vui lòng chọn phiếu nhập cần xoá."); return; }
            int maPNCanXoa = currentSelectedMaPN.Value;
            if (MessageBox.Show($"Bạn chắc chắn muốn xoá phiếu nhập mã '{maPNCanXoa}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (busPN.XoaPhieuNhap(maPNCanXoa)) { ShowInfo("Xoá PN thành công!"); LoadPhieuNhapData(); }
                    else { ShowError("Xoá PN thất bại!"); }
                }
                catch (SqlException sqlEx) when (sqlEx.Number == 547) { ShowWarning("Không thể xóa PN này (lỗi FK)."); }
                catch (Exception ex) { ShowError($"Lỗi khi xóa PN: {ex.Message}"); }
            }
        }

        private void btnLamMoiPN_Click(object sender, EventArgs e)
        {
            txtTimKiemPN.Clear();
            LoadPhieuNhapData();
        }

        private void btnTimKiemPN_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemPN.Text.Trim();
            try
            {
                dgvPhieuNhap.DataSource = null;
                var ketQua = busPN.TimKiemTheoTenNCC(keyword);
                dgvPhieuNhap.DataSource = ketQua;
                ConfigurePhieuNhapColumns();
                if (ketQua.Count == 0) ShowInfo("Không tìm thấy phiếu nhập nào.");
                ClearAllInputs();
                dgvPhieuNhap.DataSource = ketQua;
                ConfigurePhieuNhapColumns();
            }
            catch (Exception ex) { ShowError($"Lỗi tìm kiếm PN: {ex.Message}"); }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhieuNhap.Rows.Count)
            {
                DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];
                if (row?.Cells["MaPhieuNhap"]?.Value != null && int.TryParse(row.Cells["MaPhieuNhap"].Value.ToString(), out int selectedMaPN))
                {
                    currentSelectedMaPN = selectedMaPN;
                    txtMaPhieuNhap.Text = selectedMaPN.ToString();
                    Func<string, string> getCellValue = (colName) => row.Cells[colName]?.Value?.ToString() ?? "";
                    txtMaNVPN.Text = getCellValue("MaNV");
                    txtMaNCCPN.Text = getCellValue("MaNCC");
                    dtpNgayNhap.Value = DateTime.TryParse(getCellValue("NgayNhap"), out DateTime nn) ? nn : DateTime.Now.Date;
                    LoadChiTietData(selectedMaPN);
                    ClearChiTietInput();
                }
                else { ClearAllInputs(); }
            }
            else { ClearAllInputs(); }
        }
        #endregion

        #region Chi Tiết Phiếu Nhập Events
        private void btnThemCTPN_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaPN.HasValue) { ShowWarning("Vui lòng chọn Phiếu Nhập trước."); return; }
            if (ValidateChiTietInput(out ChiTietPhieuNhapDTO ct))
            {
                ct.MaPhieuNhap = currentSelectedMaPN.Value;
                try
                {
                    var currentDetails = busCTPN.LayChiTietTheoMaPN(currentSelectedMaPN.Value);
                    if (currentDetails.Any(item => item.MaSach == ct.MaSach))
                    { ShowWarning("Sách này đã tồn tại trong phiếu nhập."); return; }

                    if (busCTPN.ThemChiTiet(ct))
                    {
                        LoadChiTietData(currentSelectedMaPN.Value);
                        CapNhatTongTienPhieuNhapCha(currentSelectedMaPN.Value);
                        ClearChiTietInput();
                    }
                    else { ShowError("Thêm chi tiết thất bại!"); }
                }
                catch (InvalidOperationException khoEx) { ShowWarning(khoEx.Message); }
                catch (Exception ex) { ShowError($"Lỗi khi thêm chi tiết PN: {ex.Message}"); }
            }
        }

        private void btnSuaCTPN_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaPN.HasValue) { ShowWarning("Chọn Phiếu Nhập chứa chi tiết cần sửa."); return; }
            if (!currentSelectedDetailMaSach.HasValue) { ShowWarning("Chọn dòng chi tiết cần sửa."); return; }

            if (ValidateChiTietInput(out ChiTietPhieuNhapDTO ct))
            {
                ct.MaPhieuNhap = currentSelectedMaPN.Value;
                ct.MaSach = currentSelectedDetailMaSach.Value; // Lấy mã sách đã lưu

                try
                {
                    if (busCTPN.CapNhatChiTiet(ct, currentSelectedDetailSoLuongCu))
                    {
                        ShowInfo("Cập nhật chi tiết thành công!");
                        LoadChiTietData(currentSelectedMaPN.Value);
                        CapNhatTongTienPhieuNhapCha(currentSelectedMaPN.Value);
                        ClearChiTietInput();
                    }
                    else { ShowError("Cập nhật chi tiết thất bại!"); }
                }
                catch (InvalidOperationException khoEx) { ShowWarning(khoEx.Message); }
                catch (Exception ex) { ShowError($"Lỗi khi cập nhật chi tiết PN: {ex.Message}"); }
            }
        }

        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {
            if (!currentSelectedMaPN.HasValue) { ShowWarning("Chọn Phiếu Nhập chứa chi tiết cần xóa."); return; }
            if (!currentSelectedDetailMaSach.HasValue) { ShowWarning("Chọn dòng chi tiết cần xóa."); return; }

            int maPN = currentSelectedMaPN.Value;
            int maSachCanXoa = currentSelectedDetailMaSach.Value;
            int soLuongCanXoa = currentSelectedDetailSoLuongCu;

            if (MessageBox.Show($"Bạn chắc muốn xóa sách mã '{maSachCanXoa}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (busCTPN.XoaChiTiet(maPN, maSachCanXoa, soLuongCanXoa))
                    {
                        ShowInfo("Xóa chi tiết thành công!");
                        LoadChiTietData(maPN);
                        CapNhatTongTienPhieuNhapCha(maPN);
                        ClearChiTietInput();
                    }
                    else { ShowError("Xóa chi tiết thất bại!"); }
                }
                catch (InvalidOperationException khoEx) { ShowWarning(khoEx.Message); }
                catch (Exception ex) { ShowError($"Lỗi khi xóa chi tiết PN: {ex.Message}"); }
            }
        }

        private void dgvChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChiTietPN.Rows.Count)
            {
                DataGridViewRow row = dgvChiTietPN.Rows[e.RowIndex];
                if (row?.Cells["MaSach"]?.Value != null && int.TryParse(row.Cells["MaSach"].Value.ToString(), out int selectedMaSach))
                {
                    currentSelectedDetailMaSach = selectedMaSach;
                    Func<string, string> getCellValue = (colName) => { if (row.DataGridView.Columns.Contains(colName)) { var cell = row.Cells[colName]; if (cell?.Value != null && cell.Value != DBNull.Value) return cell.Value.ToString(); } return ""; };

                    txtMaSachCTPN.Text = selectedMaSach.ToString();
                    txtSoLuongPN.Text = getCellValue("SoLuong");
                    txtGiaNhapPN.Text = getCellValue("GiaNhap");
                    TinhThanhTienChiTiet();

                    if (int.TryParse(txtSoLuongPN.Text, out int slCu)) { currentSelectedDetailSoLuongCu = slCu; } else { currentSelectedDetailSoLuongCu = 0; }

                    txtMaSachCTPN.ReadOnly = true; 
                }
                else { ClearChiTietInput(); }
            }
            else { ClearChiTietInput(); }
        }

        private void btnLamMoiCTPN_Click(object sender, EventArgs e) { ClearChiTietInput(); }
        #endregion

        #region Helper Methods & Other Events
        private void CalculateThanhTienEvent(object sender, EventArgs e) { TinhThanhTienChiTiet(); }
        #endregion

       
        private void label1_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }

        private void btnInPN_Click(object sender, EventArgs e)
        {
            {
                if (!currentSelectedMaPN.HasValue || currentSelectedMaPN.Value <= 0)
                {
                    ShowWarning("Vui lòng chọn một phiếu nhập từ danh sách để in.");
                    return;
                }

                int maPNCanIn = currentSelectedMaPN.Value;

                PhieuNhapDTO phieuNhapXuat = busPN.GetPhieuNhapChiTietForReport(maPNCanIn);
                if (phieuNhapXuat == null)
                {
                    ShowError($"Không tìm thấy thông tin cho phiếu nhập có mã: {maPNCanIn}");
                    return;
                }

                List<ChiTietPhieuNhapDTO> chiTietXuat = busCTPN.LayChiTietTheoMaPN(maPNCanIn);
                if (chiTietXuat == null)
                {
                    ShowError($"Không thể lấy chi tiết cho phiếu nhập có mã: {maPNCanIn}");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Lưu Phiếu Nhập Kho PDF";
                saveFileDialog.FileName = $"PN_{phieuNhapXuat.MaPhieuNhap}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

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

                        iTextFont fontTieuDeTrang = new iTextFont(bf, 20, iTextFont.BOLD);
                        iTextFont fontTieuDeMuc = new iTextFont(bf, 14, iTextFont.BOLD);
                        iTextFont fontBold = new iTextFont(bf, 11, iTextFont.BOLD);
                        iTextFont fontNormal = new iTextFont(bf, 11);
                        iTextFont fontSmallItalic = new iTextFont(bf, 9, iTextFont.ITALIC);

                        Paragraph tenCuaHang = new Paragraph("CỬA HÀNG SÁCH 279", new iTextFont(bf, 16, iTextFont.BOLD | iTextFont.UNDERLINE));
                        tenCuaHang.Alignment = Element.ALIGN_CENTER;
                        doc.Add(tenCuaHang);

                        Paragraph diaChiCuaHang = new Paragraph("Địa chỉ: - Số 279 Điện Biên II, Thành phố Hưng Yên, Tỉnh Hưng Yên -", fontSmallItalic);
                        diaChiCuaHang.Alignment = Element.ALIGN_CENTER;
                        doc.Add(diaChiCuaHang);

                        Paragraph sdtCuaHang = new Paragraph("Điện thoại: - 02213863077 -", fontSmallItalic);
                        sdtCuaHang.Alignment = Element.ALIGN_CENTER;
                        doc.Add(sdtCuaHang);
                        doc.Add(Chunk.NEWLINE);

                        Paragraph title = new Paragraph("PHIẾU NHẬP KHO", fontTieuDeTrang);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingBefore = 10f;
                        title.SpacingAfter = 20f;
                        doc.Add(title);

                        PdfPTable infoTable = new PdfPTable(2);
                        infoTable.WidthPercentage = 80;
                        infoTable.HorizontalAlignment = Element.ALIGN_CENTER;
                        infoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        infoTable.DefaultCell.PaddingBottom = 5f;

                        infoTable.AddCell(new Phrase($"Số Phiếu Nhập:", fontBold));
                        infoTable.AddCell(new Phrase($"{phieuNhapXuat.MaPhieuNhap}", fontNormal));
                        infoTable.AddCell(new Phrase($"Ngày nhập:", fontBold));
                        infoTable.AddCell(new Phrase($"{phieuNhapXuat.NgayNhap:dd/MM/yyyy HH:mm:ss}", fontNormal));
                        infoTable.AddCell(new Phrase($"Nhà cung cấp:", fontBold));
                        infoTable.AddCell(new Phrase($"{(!string.IsNullOrEmpty(phieuNhapXuat.TenNhaCungCap) ? phieuNhapXuat.TenNhaCungCap : "N/A")}", fontNormal));
                        infoTable.AddCell(new Phrase($"Nhân viên nhập:", fontBold));
                        infoTable.AddCell(new Phrase($"{(!string.IsNullOrEmpty(phieuNhapXuat.TenNhanVien) ? phieuNhapXuat.TenNhanVien : "N/A")}", fontNormal));
                        doc.Add(infoTable);
                        doc.Add(Chunk.NEWLINE);

                        Paragraph tblHeader = new Paragraph("CHI TIẾT HÀNG NHẬP", fontTieuDeMuc);
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
                        cellHeader = new PdfPCell(new Phrase("Giá Nhập (VNĐ)", fontBold)) { HorizontalAlignment = Element.ALIGN_RIGHT, VerticalAlignment = Element.ALIGN_MIDDLE, BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 };
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
                                cellData = new PdfPCell(new Phrase(ct.GiaNhap.ToString("N0"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4 };
                                table.AddCell(cellData);
                                cellData = new PdfPCell(new Phrase(ct.ThanhTien.ToString("N0"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4 };
                                table.AddCell(cellData);
                                stt++;
                            }
                        }
                        else
                        {
                            PdfPCell emptyCell = new PdfPCell(new Phrase("Không có chi tiết hàng nhập.", fontNormal)) { Colspan = 5, HorizontalAlignment = Element.ALIGN_CENTER, Padding = 10 };
                            table.AddCell(emptyCell);
                        }
                        doc.Add(table);
                        doc.Add(Chunk.NEWLINE);

                        Paragraph tongCong = new Paragraph($"Tổng tiền nhập: {phieuNhapXuat.TongTien:N0} VNĐ", new iTextFont(bf, 13, iTextFont.BOLD));
                        tongCong.Alignment = Element.ALIGN_RIGHT;
                        tongCong.SpacingBefore = 10f;
                        doc.Add(tongCong);
                        doc.Add(Chunk.NEWLINE);

                        Paragraph kyTen = new Paragraph("Người lập phiếu", new iTextFont(bf, 11, iTextFont.ITALIC));
                        kyTen.Alignment = Element.ALIGN_RIGHT;
                        kyTen.SpacingBefore = 20f;
                        kyTen.IndentationRight = 50f;
                        doc.Add(kyTen);

                        Paragraph hoTenNguoiLap = new Paragraph($"({phieuNhapXuat.TenNhanVien ?? "N/A"})", new iTextFont(bf, 11, iTextFont.ITALIC));
                        hoTenNguoiLap.Alignment = Element.ALIGN_RIGHT;
                        hoTenNguoiLap.SpacingBefore = 40f;
                        hoTenNguoiLap.IndentationRight = 50f;
                        doc.Add(hoTenNguoiLap);

                        doc.Close();
                        writer.Close();

                        ShowInfo("Xuất phiếu nhập PDF thành công!\nĐã lưu tại: " + filePath);

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
}