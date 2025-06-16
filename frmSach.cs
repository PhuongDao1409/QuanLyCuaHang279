using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLyCuaHang279;
using DTO_QuanLyCuaHang279;

namespace GUI_QuanLyCuaHang279
{
    public partial class frmSach : Form
    {
        SachBUS sachBUS = new SachBUS();

        private void LoadData()
        {
            try
            {
                dgvSach.DataSource = null;
                dgvSach.DataSource = sachBUS.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmSach()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.StartPosition = FormStartPosition.CenterParent;
            txtMaSach.ReadOnly = true; // Mã sách chỉ đọc
        }

        private void FrmSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearInput()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTheLoai.Clear();
            txtTacGia.Clear();
            cboNXB.SelectedIndex = -1;
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtHinhAnh.Clear();
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSach.Text)) { MessageBox.Show("Tên sách không được để trống."); txtTenSach.Focus(); return; }
            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out decimal giaBan) || giaBan < 0) { MessageBox.Show("Giá bán không hợp lệ."); txtGiaBan.Focus(); return; }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong < 0) { MessageBox.Show("Số lượng không hợp lệ."); txtSoLuong.Focus(); return; }

            SachDTO s = new SachDTO
            {
                TenSach = txtTenSach.Text.Trim(),
                TheLoai = txtTheLoai.Text.Trim(),
                TacGia = txtTacGia.Text.Trim(),
                NXB = cboNXB.Text.Trim(),
                GiaBan = giaBan,
                SoLuong = soLuong,
                HinhAnh = txtHinhAnh.Text.Trim()
            };

            try
            {
                if (sachBUS.Insert(s)) { MessageBox.Show("Thêm thành công!"); LoadData(); ClearInput(); }
                else { MessageBox.Show("Thêm thất bại!"); }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaSach.Text, out int maSach) || maSach <= 0) { MessageBox.Show("Vui lòng chọn sách cần sửa."); return; }
            if (string.IsNullOrWhiteSpace(txtTenSach.Text)) { MessageBox.Show("Tên sách không được để trống."); txtTenSach.Focus(); return; }
            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out decimal giaBan) || giaBan < 0) { MessageBox.Show("Giá bán không hợp lệ."); txtGiaBan.Focus(); return; }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong < 0) { MessageBox.Show("Số lượng không hợp lệ."); txtSoLuong.Focus(); return; }

            SachDTO s = new SachDTO
            {
                MaSach = maSach,
                TenSach = txtTenSach.Text.Trim(),
                TheLoai = txtTheLoai.Text.Trim(),
                TacGia = txtTacGia.Text.Trim(),
                NXB = cboNXB.Text.Trim(),
                GiaBan = giaBan,
                SoLuong = soLuong,
                HinhAnh = txtHinhAnh.Text.Trim()
            };

            try
            {
                if (sachBUS.UpdateSach(s)) { MessageBox.Show("Cập nhật thành công!"); LoadData(); ClearInput(); }
                else { MessageBox.Show("Cập nhật thất bại!"); }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaSach.Text, out int maSach) || maSach <= 0) { MessageBox.Show("Vui lòng chọn sách cần xoá."); return; }

            if (MessageBox.Show($"Bạn chắc muốn xoá sách mã '{maSach}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (sachBUS.DeleteSach(maSach)) { MessageBox.Show("Xoá thành công!"); LoadData(); ClearInput(); }
                    else { MessageBox.Show("Xoá thất bại!"); }
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            try
            {
                dgvSach.DataSource = null;
                dgvSach.DataSource = sachBUS.SearchSach(keyword);
                if (dgvSach.Rows.Count == 0) { MessageBox.Show("Không tìm thấy kết quả.", "Thông báo"); }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Các hàm sự kiện trống có thể giữ lại hoặc xóa nếu không gây lỗi Designer
        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtHinhAnh_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void txtMaSach_TextChanged(object sender, EventArgs e) { }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSach.Rows.Count)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];
                if (row == null || row.Cells["MaSach"].Value == null) { ClearInput(); return; } // Kiểm tra kỹ hơn

                Func<string, string> getCellValue = (colName) => row.Cells[colName]?.Value?.ToString() ?? "";

                txtMaSach.Text = getCellValue("MaSach");
                txtTenSach.Text = getCellValue("TenSach");
                txtTheLoai.Text = getCellValue("TheLoai");
                txtTacGia.Text = getCellValue("TacGia");
                cboNXB.Text = getCellValue("NXB");
                txtGiaBan.Text = getCellValue("GiaBan");
                txtSoLuong.Text = getCellValue("SoLuong");
                txtHinhAnh.Text = getCellValue("HinhAnh");

                string imagePath = txtHinhAnh.Text;
                if (picHinhAnh.Image != null) { picHinhAnh.Image.Dispose(); picHinhAnh.Image = null; }

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    try
                    {
                        byte[] imageData = File.ReadAllBytes(imagePath);
                        using (var ms = new MemoryStream(imageData)) { picHinhAnh.Image = Image.FromStream(ms); }
                        picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex) { Console.WriteLine($"Lỗi tải ảnh: {ex.Message}"); picHinhAnh.Image = null; }
                }
                else { picHinhAnh.Image = null; }
            }
            else { ClearInput(); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Controls.ContainsKey("txtTimKiem"))
                {
                    TextBox txtTim = this.Controls["txtTimKiem"] as TextBox;
                    if (txtTim != null)
                    {
                        txtTim.Clear();
                    }
                }

                txtTimKiem.Clear();
                LoadData(); 
                ClearInput(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.JPG;*.JPEG;*.PNG;*.BMP;*.GIF)|*.JPG;*.JPEG;*.PNG;*.BMP;*.GIF|All files (*.*)|*.*";

            // --- CHỈNH SỬA TRỰC TIẾP Ở ĐÂY ---
            // Gán thẳng đường dẫn thư mục ảnh của bạn
            openFileDialog.InitialDirectory = @"C:\Users\84325\source\HinhAnhSach"; // <<< THAY ĐỔI ĐƯỜNG DẪN NÀY
                                                                             // --- KẾT THÚC CHỈNH SỬA ---

            openFileDialog.Title = "Chọn ảnh bìa sách";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Phần xử lý sau khi chọn file giữ nguyên như cũ
                try
                {
                    string selectedImagePath = openFileDialog.FileName;
                    txtHinhAnh.Text = selectedImagePath;

                    if (picHinhAnh != null && picHinhAnh.Image != null)
                    {
                        picHinhAnh.Image.Dispose();
                        picHinhAnh.Image = null;
                    }

                    if (picHinhAnh != null)
                    {
                        using (FileStream fs = new FileStream(selectedImagePath, FileMode.Open, FileAccess.Read))
                        {
                            picHinhAnh.Image = Image.FromStream(fs);
                        }
                        picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message, "Lỗi Ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHinhAnh.Clear();
                    if (picHinhAnh != null) picHinhAnh.Image = null;
                }
            }
        }
    }
}