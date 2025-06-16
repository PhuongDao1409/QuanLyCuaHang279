using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyCuaHang279;
using DAL_QuanLyCuaHang279;

namespace BUS_QuanLyCuaHang279
{
    public class KhoBUS
    {
        private KhoDAL dal = new KhoDAL();

        public List<KhoDTO> LayDanhSachKho()
        {
            try { return dal.GetAllKho(); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.LayDanhSachKho: " + ex.Message); return new List<KhoDTO>(); }
        }

        public bool ThemKho(KhoDTO kho)
        {
            if (kho == null) throw new ArgumentNullException(nameof(kho));
            if (kho.MaSach <= 0) throw new ArgumentException("Mã sách không hợp lệ.", nameof(kho.MaSach));
            if (kho.SoLuongTon < 0) throw new ArgumentException("Số lượng tồn không âm.", nameof(kho.SoLuongTon));
            KhoDTO existing = GetKhoByMaSach(kho.MaSach);
            if (existing != null) { Console.WriteLine($"Sách mã {kho.MaSach} đã có trong kho."); return false; }

            try { return dal.InsertKho(kho); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.ThemKho: " + ex.Message); return false; }
        }

        public bool CapNhatSoLuongTon(int maSach, int soLuongMoi)
        {
            if (maSach <= 0) throw new ArgumentException("Mã sách không hợp lệ.", nameof(maSach));
            if (soLuongMoi < 0) throw new ArgumentException("Số lượng mới không âm.", nameof(soLuongMoi));
            try { return dal.UpdateSoLuongTon(maSach, soLuongMoi); }
            catch (Exception ex) { Console.WriteLine($"Lỗi BUS.CapNhatSoLuongTon(MaSach={maSach}): {ex.Message}"); return false; }
        }

        public KhoDTO GetKhoByMaSach(int maSach)
        {
            if (maSach <= 0) throw new ArgumentException("Mã sách không hợp lệ.", nameof(maSach));
            try { return dal.GetKhoByMaSach(maSach); }
            catch (Exception ex) { Console.WriteLine($"Lỗi BUS.GetKhoByMaSach(MaSach={maSach}): {ex.Message}"); return null; }
        }

        public bool XoaKho(int maKho)
        {
            if (maKho <= 0) throw new ArgumentException("Mã kho không hợp lệ.", nameof(maKho));
            try { return dal.DeleteKho(maKho); }
            catch (Exception ex) { Console.WriteLine($"Lỗi BUS.XoaKho (MaKho={maKho}): {ex.Message}"); return false; }
        }

        public bool ThayDoiSoLuongTon(int maSach, int soLuongThayDoi)
        {
            if (maSach <= 0)
            {
                Console.WriteLine($"Lỗi BUS.ThayDoiSoLuongTon: Mã sách không hợp lệ ({maSach})");
                return false;
            }
            if (soLuongThayDoi == 0)
            {
                return true;
            }

            try
            {
                KhoDTO khoHienTai = dal.GetKhoByMaSach(maSach);

                if (khoHienTai == null)
                {
                    if (soLuongThayDoi > 0)
                    {
                        KhoDTO khoMoi = new KhoDTO(maSach, soLuongThayDoi);
                        return dal.InsertKho(khoMoi);
                    }
                    else
                    {
                        Console.WriteLine($"LỖI: Không thể trừ số lượng cho sách mã {maSach} vì chưa có trong kho.");
                        return false;
                    }
                }
                else
                {
                    int soLuongMoi = khoHienTai.SoLuongTon + soLuongThayDoi;
                    if (soLuongMoi < 0)
                    {
                        Console.WriteLine($"LỖI: Không đủ số lượng tồn kho cho sách mã {maSach}. Hiện có: {khoHienTai.SoLuongTon}, Yêu cầu thay đổi: {soLuongThayDoi}, SL mới sẽ là: {soLuongMoi}");
                        return false;
                    }
                    return dal.UpdateSoLuongTon(maSach, soLuongMoi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi BUS.ThayDoiSoLuongTon(MaSach={maSach}, ThayDoi={soLuongThayDoi}): {ex.Message}");
                return false;
            }
        }
    }
}