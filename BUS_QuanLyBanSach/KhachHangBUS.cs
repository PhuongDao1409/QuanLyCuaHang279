using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyCuaHang279;
using DAL_QuanLyCuaHang279;

namespace BUS_QuanLyCuaHang279
{
    public class KhachHangBUS
    {
        KhachHangDAL dal = new KhachHangDAL();

        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            return dal.GetAllKhachHang();
        }

        public bool ThemKhachHang(KhachHangDTO kh)
        {
            return dal.InsertKhachHang(kh);
        }

        public bool CapNhatKhachHang(KhachHangDTO kh)
        {
            return dal.UpdateKhachHang(kh);
        }

        public bool XoaKhachHang(int maKH)
        {
            return dal.DeleteKhachHang(maKH);
        }
        public List<KhachHangDTO> TimKiemKhachHang(string keyword)
        {
            return dal.SearchKhachHangByName(keyword);
        }
    }
}