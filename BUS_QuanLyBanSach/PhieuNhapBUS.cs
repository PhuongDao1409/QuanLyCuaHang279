using System;
using System.Collections.Generic;
using DTO_QuanLyCuaHang279;
using DAL_QuanLyCuaHang279;
using DTO_QuanLyNhaSach279;

namespace BUS_QuanLyCuaHang279
{
    public class PhieuNhapBUS
    {
        private PhieuNhapDAL dal = new PhieuNhapDAL();

        public List<PhieuNhapDTO> LayDanhSachPhieuNhap()
        {
            try { return dal.GetAll(); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.LayDanhSachPhieuNhap: " + ex.Message); return new List<PhieuNhapDTO>(); }
        }

        public PhieuNhapDTO GetPhieuNhapChiTietForReport(int maPN)
        {
            if (maPN <= 0) throw new ArgumentException("Mã phiếu nhập không hợp lệ.", nameof(maPN));
            try
            {
                return dal.GetPhieuNhapByIdForReport(maPN);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi BUS.PhieuNhapBUS.GetPhieuNhapChiTietForReport(MaPN={maPN}): {ex.Message}");
                return null;
            }
        }

        public int ThemPhieuNhap(PhieuNhapDTO pn)
        {
            if (pn == null) throw new ArgumentNullException(nameof(pn));
            if (!pn.MaNV.HasValue) throw new ArgumentException("Chưa chọn nhân viên nhập.", nameof(pn.MaNV));
            if (!pn.MaNCC.HasValue) throw new ArgumentException("Chưa chọn nhà cung cấp.", nameof(pn.MaNCC));
            if (pn.NgayNhap == default(DateTime)) throw new ArgumentException("Ngày nhập không hợp lệ.", nameof(pn.NgayNhap));

            pn.TongTien = 0;

            try { return dal.Insert(pn); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.ThemPhieuNhap: " + ex.Message); return -1; }
        }

        public bool CapNhatPhieuNhap(PhieuNhapDTO pn)
        {
            if (pn == null) throw new ArgumentNullException(nameof(pn));
            if (pn.MaPhieuNhap <= 0) throw new ArgumentException("Mã phiếu nhập không hợp lệ.", nameof(pn.MaPhieuNhap));
            if (!pn.MaNV.HasValue) throw new ArgumentException("Chưa chọn nhân viên nhập.", nameof(pn.MaNV));
            if (!pn.MaNCC.HasValue) throw new ArgumentException("Chưa chọn nhà cung cấp.", nameof(pn.MaNCC));
            if (pn.NgayNhap == default(DateTime)) throw new ArgumentException("Ngày nhập không hợp lệ.", nameof(pn.NgayNhap));
            if (pn.TongTien < 0) throw new ArgumentException("Tổng tiền không được âm.", nameof(pn.TongTien));

            try { return dal.Update(pn); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.CapNhatPhieuNhap: " + ex.Message); return false; }
        }

        public bool CapNhatTongTien(int maPN, decimal tongTien)
        {
            if (maPN <= 0) throw new ArgumentException("Mã phiếu nhập không hợp lệ.", nameof(maPN));
            if (tongTien < 0) throw new ArgumentException("Tổng tiền không được âm.", nameof(tongTien));
            try { return dal.UpdateTongTien(maPN, tongTien); }
            catch (Exception ex) { Console.WriteLine($"Lỗi BUS.CapNhatTongTien(MaPN={maPN}): {ex.Message}"); return false; }
        }

        public bool XoaPhieuNhap(int maPN)
        {
            if (maPN <= 0) throw new ArgumentException("Mã phiếu nhập không hợp lệ.", nameof(maPN));
            try { return dal.Delete(maPN); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.XoaPhieuNhap: " + ex.Message); return false; }
        }
        public List<PhieuNhapDTO> TimKiemTheoTenNCC(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return LayDanhSachPhieuNhap();
            }
            try
            {
                return dal.SearchByTenNCC(keyword);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.TimKiemTheoTenNCC: " + ex.Message);
                return new List<PhieuNhapDTO>();
            }
        }
    }
}