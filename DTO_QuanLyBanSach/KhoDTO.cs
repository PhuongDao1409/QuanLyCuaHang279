using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuaHang279 
{
    public class KhoDTO
    {
        public int MaKho { get; set; }      
        public int MaSach { get; set; }     
        public int SoLuongTon { get; set; } 

        public KhoDTO() { }

        public KhoDTO(int maSach, int soLuongTon)
        {
            MaSach = maSach;
            SoLuongTon = soLuongTon;
        }
        public KhoDTO(int maKho, int maSach, int soLuongTon)
        {
            MaKho = maKho;
            MaSach = maSach;
            SoLuongTon = soLuongTon;
        }
    }
}