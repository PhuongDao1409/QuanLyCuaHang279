using System;
using System.Collections.Generic;
using DTO_QuanLyCuaHang279;
using DAL_QuanLyCuaHang279;

namespace BUS_QuanLyCuaHang279
{
    public class ChiTietPhieuNhapBUS
    {
        private ChiTietPhieuNhapDAL dal = new ChiTietPhieuNhapDAL();
        private KhoBUS khoBUS = new KhoBUS();

        public List<ChiTietPhieuNhapDTO> LayChiTietTheoMaPN(int maPN)
        {
            if (maPN <= 0) throw new ArgumentException("Mã phiếu nhập không hợp lệ.", nameof(maPN));
            try
            {
                return dal.GetByMaPhieuNhap(maPN);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi BUS.ChiTietPhieuNhapBUS.LayChiTietTheoMaPN(MaPN={maPN}): {ex.Message}");
                return new List<ChiTietPhieuNhapDTO>();
            }
        }

        public bool ThemChiTiet(ChiTietPhieuNhapDTO ct)
        {
            if (ct == null) throw new ArgumentNullException(nameof(ct));
            if (ct.MaPhieuNhap <= 0) throw new ArgumentException("Mã phiếu nhập không hợp lệ.", nameof(ct.MaPhieuNhap));
            if (ct.MaSach <= 0) throw new ArgumentException("Mã sách không hợp lệ.", nameof(ct.MaSach));
            if (ct.SoLuong <= 0) throw new ArgumentException("Số lượng phải lớn hơn 0.", nameof(ct.SoLuong));
            if (ct.GiaNhap < 0) throw new ArgumentException("Giá nhập không được âm.", nameof(ct.GiaNhap));

            try
            {
                bool resultDAL = dal.Insert(ct);
                if (resultDAL)
                {
                    bool resultKho = khoBUS.ThayDoiSoLuongTon(ct.MaSach, ct.SoLuong);
                    if (!resultKho)
                    {
                        Console.WriteLine($"CẢNH BÁO NGHIỆP VỤ: Thêm ChiTietPN vào CSDL thành công nhưng thao tác KHO thất bại cho MaSach={ct.MaSach}.");
                        return false; 
                    }
                    return true; 
                }
                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi không xác định trong BUS.ThemChiTiet: " + ex.Message);
                return false;
            }
        }

        public bool CapNhatChiTiet(ChiTietPhieuNhapDTO ct, int soLuongCu)
        {
            if (ct == null) throw new ArgumentNullException(nameof(ct));
            if (ct.MaPhieuNhap <= 0) throw new ArgumentException("Mã phiếu nhập không hợp lệ.", nameof(ct.MaPhieuNhap));
            if (ct.SoLuong <= 0) throw new ArgumentException("Số lượng phải lớn hơn 0.", nameof(ct.SoLuong));
            if (ct.GiaNhap < 0) throw new ArgumentException("Giá nhập không được âm.", nameof(ct.GiaNhap));
            if (soLuongCu <= 0) throw new ArgumentException("Số lượng cũ không hợp lệ.", nameof(soLuongCu));

            try
            {
                bool resultDAL = dal.Update(ct); 
                if (resultDAL)
                {
                    int soLuongThayDoi = ct.SoLuong - soLuongCu;
                    if (soLuongThayDoi != 0)
                    {
                        bool resultKho = khoBUS.ThayDoiSoLuongTon(ct.MaSach, soLuongThayDoi);
                        if (!resultKho)
                        {
                            Console.WriteLine($"CẢNH BÁO NGHIỆP VỤ: Sửa ChiTietPN thành công nhưng cập nhật Kho thất bại cho MaSach={ct.MaSach}.");
                            return false; 
                        }
                    }
                    return true; 
                }
                return false; 
            }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.CapNhatChiTiet: " + ex.Message); return false; }
        }

        public bool XoaChiTiet(int maPN, int maSach, int soLuongBiXoa)
        {
            if (maPN <= 0) throw new ArgumentException("Mã phiếu nhập không hợp lệ.", nameof(maPN));
            if (maSach <= 0) throw new ArgumentException("Mã sách không hợp lệ.", nameof(maSach));
            if (soLuongBiXoa <= 0) throw new ArgumentException("Số lượng xóa không hợp lệ.", nameof(soLuongBiXoa));

            try
            {
                bool resultDAL = dal.Delete(maPN, maSach);
                if (resultDAL)
                {
                    bool resultKho = khoBUS.ThayDoiSoLuongTon(maSach, -soLuongBiXoa);
                    if (!resultKho)
                    {
                        Console.WriteLine($"CẢNH BÁO NGHIỆP VỤ: Xóa ChiTietPN thành công nhưng cập nhật Kho thất bại cho MaSach={maSach}.");
                        return false; 
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.XoaChiTiet: " + ex.Message); return false; }
        }
    }
}