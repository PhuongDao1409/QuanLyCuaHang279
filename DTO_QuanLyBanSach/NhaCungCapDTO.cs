using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuaHang279 
{
    public class NhaCungCapDTO
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public NhaCungCapDTO() { }

    
        public NhaCungCapDTO(string tenNCC, string diaChi, string soDienThoai)
        {
            TenNCC = tenNCC;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }

 
        public NhaCungCapDTO(int maNCC, string tenNCC, string diaChi, string soDienThoai)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }
    }
}