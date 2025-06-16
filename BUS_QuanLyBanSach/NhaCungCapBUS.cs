using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyCuaHang279;
using DAL_QuanLyCuaHang279;

namespace BUS_QuanLyCuaHang279
{
    public class NhaCungCapBUS
    {
        private NhaCungCapDAL dal = new NhaCungCapDAL();

        public List<NhaCungCapDTO> LayDanhSachNhaCungCap() 
        {
            try { return dal.GetAllNhaCungCap(); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.LayDanhSachNhaCungCap: " + ex.Message); return new List<NhaCungCapDTO>(); }
        }

        public bool ThemNhaCungCap(NhaCungCapDTO ncc)
        {
            // Validation cơ bản
            if (ncc == null) throw new ArgumentNullException(nameof(ncc));
            if (string.IsNullOrWhiteSpace(ncc.TenNCC)) throw new ArgumentException("Tên NCC không được trống.", nameof(ncc.TenNCC));
            if (string.IsNullOrWhiteSpace(ncc.DiaChi)) throw new ArgumentException("Địa chỉ không được trống.", nameof(ncc.DiaChi));
            if (string.IsNullOrWhiteSpace(ncc.SoDienThoai)) throw new ArgumentException("Số điện thoại không được trống.", nameof(ncc.SoDienThoai));

            try { return dal.InsertNhaCungCap(ncc); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.ThemNhaCungCap: " + ex.Message); return false; }
        }

        public bool CapNhatNhaCungCap(NhaCungCapDTO ncc) 
        {
            // Validation cơ bản
            if (ncc == null) throw new ArgumentNullException(nameof(ncc));
            if (ncc.MaNCC <= 0) throw new ArgumentException("Mã NCC không hợp lệ.", nameof(ncc.MaNCC));
            if (string.IsNullOrWhiteSpace(ncc.TenNCC)) throw new ArgumentException("Tên NCC không được trống.", nameof(ncc.TenNCC));
            if (string.IsNullOrWhiteSpace(ncc.DiaChi)) throw new ArgumentException("Địa chỉ không được trống.", nameof(ncc.DiaChi));
            if (string.IsNullOrWhiteSpace(ncc.SoDienThoai)) throw new ArgumentException("Số điện thoại không được trống.", nameof(ncc.SoDienThoai));

            try { return dal.UpdateNhaCungCap(ncc); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.CapNhatNhaCungCap: " + ex.Message); return false; }
        }

        public bool XoaNhaCungCap(int maNCC) 
        {
            // Validation cơ bản
            if (maNCC <= 0) throw new ArgumentException("Mã NCC không hợp lệ.", nameof(maNCC));
            try { return dal.DeleteNhaCungCap(maNCC); }
            catch (Exception ex) { Console.WriteLine("Lỗi BUS.XoaNhaCungCap: " + ex.Message); return false; }
        }

        
    }
}