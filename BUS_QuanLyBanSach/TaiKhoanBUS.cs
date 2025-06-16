using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyCuaHang279; 
using DTO_QuanLyCuaHang279; 

namespace BUS_QuanLyCuaHang279 
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        /// <summary>
        /// Gọi DAL để kiểm tra đăng nhập.
        /// </summary>
        /// <returns>TaiKhoanDTO nếu hợp lệ, ngược lại null.</returns>
        public TaiKhoanDTO DangNhap(string user, string pass)
        {
            return taiKhoanDAL.KiemTraDangNhap(user, pass);
        }

    }
}