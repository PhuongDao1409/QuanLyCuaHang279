using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyCuaHang279;
using DTO_QuanLyCuaHang279;

namespace BUS_QuanLyCuaHang279
{
    public class SachBUS
    {
        private SachDAL dal = new SachDAL();
        private KhoBUS khoBUS = new KhoBUS();

        public List<SachDTO> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(SachDTO s)
        {
            if (s == null) return false;
            if (string.IsNullOrWhiteSpace(s.TenSach)) return false;
            if (s.GiaBan < 0) return false;

            try
            {
                int newMaSach = dal.Insert(s);

                if (newMaSach > 0)
                {
                    KhoDTO khoMoi = new KhoDTO(newMaSach, 0);
                    bool themKhoResult = khoBUS.ThemKho(khoMoi);

                    if (!themKhoResult)
                    {
                        Console.WriteLine($"Warning: Thêm sách mã {newMaSach} thành công nhưng Kho lỗi!");
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS.SachBUS.Insert: " + ex.Message);
                return false;
            }
        }

        public bool UpdateSach(SachDTO s)
        {
            return dal.Update(s);
        }

        public bool DeleteSach(int maSach)
        {
            return dal.Delete(maSach);
        }

        public List<SachDTO> SearchSach(string keyword)
        {
            return dal.SearchByName(keyword);
        }

        public SachDTO LaySachTheoMa(int maSach)
        {
            if (maSach <= 0) return null;
            try { return dal.GetById(maSach); }
            catch (Exception ex) { Console.WriteLine($"Lỗi BUS.LaySachTheoMa: {ex.Message}"); return null; }
        }
    }
}