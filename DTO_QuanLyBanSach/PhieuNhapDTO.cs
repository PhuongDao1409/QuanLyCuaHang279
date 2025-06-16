using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuaHang279
{
    public class PhieuNhapDTO
    {
        public int MaPhieuNhap { get; set; }
        public int? MaNV { get; set; }
        public int? MaNCC { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }

        
        public string TenNhanVien { get; set; }
        public string TenNhaCungCap { get; set; }

        public PhieuNhapDTO() { }

        
        public PhieuNhapDTO(int maPhieuNhap, int? maNV, int? maNCC, DateTime ngayNhap, decimal tongTien, string tenNhanVien = null, string tenNhaCungCap = null)
        {
            MaPhieuNhap = maPhieuNhap;
            MaNV = maNV;
            MaNCC = maNCC;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
            TenNhanVien = tenNhanVien;
            TenNhaCungCap = tenNhaCungCap;
        }
    }
}
