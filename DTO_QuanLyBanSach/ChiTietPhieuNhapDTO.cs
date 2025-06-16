using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuaHang279
{
    public class ChiTietPhieuNhapDTO
    {
        public int MaPhieuNhap { get; set; }
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }

        
        public string TenSach { get; set; }

        public decimal ThanhTien
        {
            get { return SoLuong * GiaNhap; }
        }

        public ChiTietPhieuNhapDTO() { }

        public ChiTietPhieuNhapDTO(int maPhieuNhap, int maSach, int soLuong, decimal giaNhap, string tenSach = null)
        {
            MaPhieuNhap = maPhieuNhap;
            MaSach = maSach;
            SoLuong = soLuong;
            GiaNhap = giaNhap;
            TenSach = tenSach;
        }
    }
}
