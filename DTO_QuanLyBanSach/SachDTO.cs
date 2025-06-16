using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuaHang279
{
    public class SachDTO
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public string NXB { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }
    

    // Constructor không tham số
    public SachDTO() { }

        // Constructor đầy đủ
        public SachDTO(int maSach, string tenSach, string theLoai, string tacGia, string nxb, decimal giaBan, int soLuong, string hinhAnh)
        {
            MaSach = maSach;
            TenSach = tenSach;
            TheLoai = theLoai;
            TacGia = tacGia;
            NXB = nxb;
            GiaBan = giaBan;
            SoLuong = soLuong;
            HinhAnh = hinhAnh;
        }
    }
}
