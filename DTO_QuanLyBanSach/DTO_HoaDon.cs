using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuaHang279
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public int? MaNV { get; set; }
        public int? MaKH { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }

        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }

        public HoaDonDTO() { }

        public HoaDonDTO(int maHD, int? maNV, int? maKH, DateTime ngayLap, decimal tongTien, string tenNhanVien = null, string tenKhachHang = null)
        {
            MaHD = maHD;
            MaNV = maNV;
            MaKH = maKH;
            NgayLap = ngayLap;
            TongTien = tongTien;
            TenNhanVien = tenNhanVien;
            TenKhachHang = tenKhachHang;
        }
    }
}