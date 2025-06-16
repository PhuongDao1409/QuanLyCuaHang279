using System;
using System.Data; 
using System.Collections.Generic; 
using System.Linq; 
using DAL_QuanLyCuaHang279; 
using DTO_QuanLyCuaHang279; 

namespace BUS_QuanLyCuaHang279 
{
    public class BaoCaoBUS
    {
        private BaoCaoDAL dal = new BaoCaoDAL();


        public bool ValidateDateRange(DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Date > toDate.Date) 
            {
                throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
            }
            return true;
        }

        // Hàm lấy top sách bán chạy 
        public List<SachBanChayViewModel> LayTopSachBanChay(DateTime fromDate, DateTime toDate, int topN = 5)
        {
            List<SachBanChayViewModel> resultList = new List<SachBanChayViewModel>();
            if (!ValidateDateRange(fromDate, toDate)) 
            {
                return resultList; 
            }

            try
            {
                DataTable dt = dal.GetTopSachBanChay(fromDate, toDate, topN); 

                foreach (DataRow row in dt.Rows)
                {
                    resultList.Add(new SachBanChayViewModel
                    {
                        MaSach = Convert.ToInt32(row["MaSach"]),
                        TenSach = row["TenSach"]?.ToString() ?? "N/A", 
                        TongSoLuongBan = Convert.ToInt32(row["TongSoLuongBan"])
                    });
                }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi BUS.LayTopSachBanChay: {ex.Message}"); } 
            return resultList;
        }

        // Hàm lấy top sách bán ít nhất 
        public List<SachBanChayViewModel> LayTopSachBanItNhat(DateTime fromDate, DateTime toDate, int topN = 5)
        {
            List<SachBanChayViewModel> resultList = new List<SachBanChayViewModel>();
            if (!ValidateDateRange(fromDate, toDate)) { return resultList; }

            try
            {
                DataTable dt = dal.GetTopSachBanItNhat(fromDate, toDate, topN); 
                                                                                
                foreach (DataRow row in dt.Rows)
                {
                    resultList.Add(new SachBanChayViewModel
                    {
                        MaSach = Convert.ToInt32(row["MaSach"]),
                        TenSach = row["TenSach"]?.ToString() ?? "N/A",
                        TongSoLuongBan = Convert.ToInt32(row["TongSoLuongBan"])
                    });
                }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi BUS.LayTopSachBanItNhat: {ex.Message}"); }
            return resultList;
        }

        // Hàm lấy chi tiết doanh thu 
        public DataTable LayDoanhThuChiTiet(DateTime fromDate, DateTime toDate)
        {
            if (!ValidateDateRange(fromDate, toDate)) { return new DataTable(); } 

            try
            {
                return dal.GetDoanhThuChiTiet(fromDate, toDate); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi BUS.LayDoanhThuChiTiet: {ex.Message}");
                return new DataTable(); 
            }
        }

        // Hàm tính tổng doanh thu
 
        public decimal TinhTongDoanhThu(DataTable dtDoanhThu)
        {
            decimal tong = 0;
            if (dtDoanhThu != null && dtDoanhThu.Columns.Contains("TongTien"))
            {
                try
                {
                  
                    tong = dtDoanhThu.AsEnumerable()
                                     .Sum(row => row.Field<decimal?>("TongTien") ?? 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi BUS.TinhTongDoanhThu: {ex.Message}");
                    tong = 0;
                }
            }
            return tong;
        }
    }
}