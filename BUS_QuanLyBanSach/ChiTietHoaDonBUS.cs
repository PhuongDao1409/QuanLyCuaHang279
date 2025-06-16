using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyCuaHang279;
using DTO_QuanLyCuaHang279;

namespace BUS_QuanLyCuaHang279
{
    public class ChiTietHoaDonBUS
    {
        private ChiTietHoaDonDAL dal = new ChiTietHoaDonDAL();
        private KhoBUS khoBUS = new KhoBUS();

        public List<ChiTietHoaDonDTO> GetByMaHD(int maHD)
        {
            if (maHD <= 0) throw new ArgumentException("Mã hóa đơn không hợp lệ.", nameof(maHD));
            try
            {
                return dal.GetByMaHD(maHD);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi BUS.ChiTietHoaDonBUS.GetByMaHD(MaHD={maHD}): {ex.Message}");
                return new List<ChiTietHoaDonDTO>();
            }
        }

        public bool Insert(ChiTietHoaDonDTO ct)
        {
            if (ct == null) throw new ArgumentNullException(nameof(ct));
            if (ct.MaHD <= 0) throw new ArgumentException("Mã hóa đơn không hợp lệ.", nameof(ct.MaHD));
            if (ct.MaSach <= 0) throw new ArgumentException("Mã sách không hợp lệ.", nameof(ct.MaSach));
            if (ct.SoLuong <= 0) throw new ArgumentException("Số lượng phải lớn hơn 0.", nameof(ct.SoLuong));
            if (ct.DonGia < 0) throw new ArgumentException("Đơn giá không được âm.", nameof(ct.DonGia));

            try
            {
                bool resultDAL = dal.Insert(ct);
                if (resultDAL)
                {
                    bool resultKho = khoBUS.ThayDoiSoLuongTon(ct.MaSach, -ct.SoLuong);
                    if (!resultKho)
                    {
                        Console.WriteLine($"CẢNH BÁO: Thêm ChiTietHD thành công nhưng cập nhật Kho thất bại cho MaSach={ct.MaSach}");
                    }
                }
                return resultDAL;
            }
            catch (InvalidOperationException khoEx)
            {
                Console.WriteLine("Lỗi Kho BUS khi thêm chi tiết HD: " + khoEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.ChiTietHoaDonBUS.Insert: " + ex.Message);
                return false;
            }
        }

        public bool Update(ChiTietHoaDonDTO ct, int soLuongCu)
        {
            if (ct == null) throw new ArgumentNullException(nameof(ct));
            if (ct.MaCTHD <= 0) throw new ArgumentException("Mã chi tiết hóa đơn không hợp lệ.", nameof(ct.MaCTHD));
            if (ct.SoLuong <= 0) throw new ArgumentException("Số lượng phải lớn hơn 0.", nameof(ct.SoLuong));
            if (ct.DonGia < 0) throw new ArgumentException("Đơn giá không được âm.", nameof(ct.DonGia));
            if (soLuongCu <= 0) throw new ArgumentException("Số lượng cũ không hợp lệ.", nameof(soLuongCu));

            try
            {
                bool resultDAL = dal.Update(ct);
                if (resultDAL)
                {
                    int soLuongThayDoi = ct.SoLuong - soLuongCu;
                    if (soLuongThayDoi != 0)
                    {
                        bool resultKho = khoBUS.ThayDoiSoLuongTon(ct.MaSach, -soLuongThayDoi);
                        if (!resultKho)
                        {
                            Console.WriteLine($"CẢNH BÁO: Sửa ChiTietHD thành công nhưng cập nhật Kho thất bại cho MaSach={ct.MaSach}");
                        }
                    }
                }
                return resultDAL;
            }
            catch (InvalidOperationException khoEx)
            {
                Console.WriteLine("Lỗi Kho BUS khi sửa chi tiết HD: " + khoEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.ChiTietHoaDonBUS.Update: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int maCTHD, int maSach, int soLuongBiXoa)
        {
            if (maCTHD <= 0) throw new ArgumentException("Mã chi tiết hóa đơn không hợp lệ.", nameof(maCTHD));
            if (maSach <= 0) throw new ArgumentException("Mã sách không hợp lệ.", nameof(maSach));
            if (soLuongBiXoa <= 0) throw new ArgumentException("Số lượng xóa không hợp lệ.", nameof(soLuongBiXoa));

            try
            {
                bool resultDAL = dal.Delete(maCTHD);
                if (resultDAL)
                {
                    bool resultKho = khoBUS.ThayDoiSoLuongTon(maSach, soLuongBiXoa);
                    if (!resultKho)
                    {
                        Console.WriteLine($"CẢNH BÁO: Xóa ChiTietHD thành công nhưng cập nhật Kho thất bại cho MaSach={maSach}");
                    }
                }
                return resultDAL;
            }
            catch (InvalidOperationException khoEx)
            {
                Console.WriteLine("Lỗi Kho BUS khi xóa chi tiết HD: " + khoEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.ChiTietHoaDonBUS.Delete: " + ex.Message);
                return false;
            }
        }
    }
}