using DAL_QuanLyCuaHang279;
using DTO_QuanLyCuaHang279;
using System.Collections.Generic;
using System;

namespace BUS_QuanLyCuaHang279
{
    public class HoaDonBUS
    {
        private HoaDonDAL dal = new HoaDonDAL();

        public List<HoaDonDTO> GetAll()
        {
            try { return dal.GetAll(); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.HoaDonBUS.GetAll: " + ex.Message); return new List<HoaDonDTO>(); }
        }

        
        public HoaDonDTO GetHoaDonChiTietForReport(int maHD)
        {
            if (maHD <= 0)
            {
                
                Console.WriteLine($"Lỗi BUS.HoaDonBUS.GetHoaDonChiTietForReport: MaHD không hợp lệ ({maHD})");
                return null; 
            }
            try
            {
                return dal.GetHoaDonByIdForReport(maHD);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi BUS.HoaDonBUS.GetHoaDonChiTietForReport(MaHD={maHD}): {ex.Message}");
                return null; 
            }
        }
       

        public int Insert(HoaDonDTO hd)
        {
            if (hd == null) throw new ArgumentNullException(nameof(hd));

            
            if (!hd.MaNV.HasValue && !hd.MaKH.HasValue) throw new ArgumentException("Hóa đơn phải có Mã NV hoặc Mã KH.");
            if (hd.NgayLap == default(DateTime)) throw new ArgumentException("Ngày lập không hợp lệ.", nameof(hd.NgayLap));
            if (hd.TongTien < 0) throw new ArgumentException("Tổng tiền không được âm.", nameof(hd.TongTien));

            try { return dal.Insert(hd); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.HoaDonBUS.Insert: " + ex.Message); return -1; }
        }

        public bool Update(HoaDonDTO hd)
        {
            if (hd == null) throw new ArgumentNullException(nameof(hd));
            if (hd.MaHD <= 0) throw new ArgumentException("Mã hóa đơn không hợp lệ.", nameof(hd.MaHD));
            if (!hd.MaNV.HasValue && !hd.MaKH.HasValue) throw new ArgumentException("Hóa đơn phải có Mã NV hoặc Mã KH.");
            if (hd.NgayLap == default(DateTime)) throw new ArgumentException("Ngày lập không hợp lệ.", nameof(hd.NgayLap));
            if (hd.TongTien < 0) throw new ArgumentException("Tổng tiền không được âm.", nameof(hd.TongTien));

            try { return dal.Update(hd); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.HoaDonBUS.Update: " + ex.Message); return false; }
        }


        public bool UpdateTongTien(int maHD, decimal tongTien)
        {
            if (maHD <= 0) throw new ArgumentException("Mã hóa đơn không hợp lệ.", nameof(maHD));
            if (tongTien < 0) throw new ArgumentException("Tổng tiền không được âm.", nameof(tongTien));
            try
            {
                return dal.UpdateTongTien(maHD, tongTien);
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi BUS.UpdateTongTien(MaHD={maHD}): {ex.Message}"); return false; }
        }


        public bool Delete(int maHD)
        {
            if (maHD <= 0) throw new ArgumentException("Mã hóa đơn không hợp lệ.", nameof(maHD));
            try { return dal.Delete(maHD); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.HoaDonBUS.Delete: " + ex.Message); return false; }
        }

        public List<HoaDonDTO> SearchByMaKH(int maKH)
        {
            if (maKH <= 0) throw new ArgumentException("Mã khách hàng không hợp lệ.", nameof(maKH));
            
            try { return dal.SearchByMaKH(maKH); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.HoaDonBUS.SearchByMaKH: " + ex.Message); return new List<HoaDonDTO>(); }
        }
    }
}