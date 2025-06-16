using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuaHang279
{
    public class ChiTietHoaDonDTO
    {
        public int MaCTHD { get; set; }
        public int MaHD { get; set; }
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public string TenSach { get; set; } 

        public decimal ThanhTien
        {
            get { return SoLuong * DonGia; }
        }

        public ChiTietHoaDonDTO() { }

       
        public ChiTietHoaDonDTO(int maCTHD, int maHD, int maSach, int soLuong, decimal donGia, string tenSach = null)
        {
            MaCTHD = maCTHD;
            MaHD = maHD;
            MaSach = maSach;
            SoLuong = soLuong;
            DonGia = donGia;
            TenSach = tenSach; 
        }
    }
}