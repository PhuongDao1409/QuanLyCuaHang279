using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyCuaHang279;
using DAL_QuanLyCuaHang279;

namespace BUS_QuanLyCuaHang279 
{
    public class NhanVienBUS
    {
        private NhanVienDAL dalNV = new NhanVienDAL();

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            try
            {
                return dalNV.GetAllNhanVien();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.LayDanhSachNhanVien: " + ex.Message);
                return new List<NhanVienDTO>(); // Trả về rỗng nếu lỗi
            }
        }

        public bool ThemNhanVien(NhanVienDTO nv)
        {
            // Input Validation cơ bản
            if (nv == null) throw new ArgumentNullException(nameof(nv));
            if (string.IsNullOrWhiteSpace(nv.HoTen)) throw new ArgumentException("Họ tên không được trống.", nameof(nv.HoTen));
            if (string.IsNullOrWhiteSpace(nv.SoDienThoai)) throw new ArgumentException("Số điện thoại không được trống.", nameof(nv.SoDienThoai));
            if (string.IsNullOrWhiteSpace(nv.Email)) throw new ArgumentException("Email không được trống.", nameof(nv.Email));
            if (string.IsNullOrWhiteSpace(nv.ChucVu)) throw new ArgumentException("Chức vụ không được trống.", nameof(nv.ChucVu));
            // Thêm kiểm tra khác nếu cần

            try
            {
                return dalNV.InsertNhanVien(nv);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.ThemNhanVien: " + ex.Message);
                return false;
            }
        }

        public bool CapNhatNhanVien(NhanVienDTO nv)
        {
            // Input Validation cơ bản
            if (nv == null) throw new ArgumentNullException(nameof(nv));
            if (nv.MaNV <= 0) throw new ArgumentException("Mã NV không hợp lệ.", nameof(nv.MaNV));
            if (string.IsNullOrWhiteSpace(nv.HoTen)) throw new ArgumentException("Họ tên không được trống.", nameof(nv.HoTen));
            if (string.IsNullOrWhiteSpace(nv.SoDienThoai)) throw new ArgumentException("Số điện thoại không được trống.", nameof(nv.SoDienThoai));
            if (string.IsNullOrWhiteSpace(nv.Email)) throw new ArgumentException("Email không được trống.", nameof(nv.Email));
            if (string.IsNullOrWhiteSpace(nv.ChucVu)) throw new ArgumentException("Chức vụ không được trống.", nameof(nv.ChucVu));
            // Thêm kiểm tra khác

            try
            {
                return dalNV.UpdateNhanVien(nv);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.CapNhatNhanVien: " + ex.Message);
                return false;
            }
        }

        public bool XoaNhanVien(int maNV)
        {
            // Input Validation cơ bản
            if (maNV <= 0) throw new ArgumentException("Mã NV không hợp lệ.", nameof(maNV));

            try
            {
                return dalNV.DeleteNhanVien(maNV);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.XoaNhanVien: " + ex.Message);
                return false; // Trả về false nếu có lỗi (kể cả lỗi FK từ DAL)
            }
        }

        
       
        public List<NhanVienDTO> SearchNhanVienByName(string keyword)
        {
            try
            {
                
                return dalNV.SearchNhanVienByName(keyword);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.SearchNhanVienByName: " + ex.Message);
                return new List<NhanVienDTO>(); // Trả về rỗng nếu lỗi
            }
        }
    }
}