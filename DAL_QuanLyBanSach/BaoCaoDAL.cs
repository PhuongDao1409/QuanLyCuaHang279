using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLyCuaHang279
{
    public class BaoCaoDAL : DBConnect 
    {

        public DataTable GetTopSachBanChay(DateTime fromDate, DateTime toDate, int topN)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                string sql = @"
            SELECT TOP (@TopN) WITH TIES
                S.MaSach,
                S.TenSach,
                SUM(CT.SoLuong) AS TongSoLuongBan
            FROM ChiTietHoaDon CT -- Xuất phát từ ChiTietHoaDon
            JOIN Sach S ON CT.MaSach = S.MaSach
            JOIN HoaDon HD ON CT.MaHD = HD.MaHD
            WHERE HD.NgayLap >= @FromDate AND HD.NgayLap < @ToDatePlusOne -- Lọc hóa đơn theo ngày
            GROUP BY S.MaSach, S.TenSach
            HAVING SUM(CT.SoLuong) > 0 -- Chỉ lấy những sách có tổng số lượng bán > 0
            ORDER BY TongSoLuongBan DESC"; // Sắp xếp giảm dần
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TopN", topN);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDatePlusOne", toDate.Date.AddDays(1));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.GetTopSachBanChay: {ex.Message}"); }
            finally { CloseConnection(); }
            return dt;
        }

        // Lấy Top N sách bán ít nhất 
        public DataTable GetTopSachBanItNhat(DateTime fromDate, DateTime toDate, int topN)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();

                string sql = @"
                    SELECT TOP (@TopN) WITH TIES
                        S.MaSach,
                        S.TenSach,
                        ISNULL(SUM(CT.SoLuong), 0) AS TongSoLuongBan 
                    FROM Sach S
                    LEFT JOIN ChiTietHoaDon CT ON S.MaSach = CT.MaSach
                    LEFT JOIN HoaDon HD ON CT.MaHD = HD.MaHD
                        AND HD.NgayLap >= @FromDate AND HD.NgayLap < @ToDatePlusOne 
                    GROUP BY S.MaSach, S.TenSach
                    ORDER BY TongSoLuongBan ASC"; 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TopN", topN);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDatePlusOne", toDate.Date.AddDays(1));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.GetTopSachBanItNhat: {ex.Message}"); }
            finally { CloseConnection(); }
            return dt;
        }

 
        public DataTable GetDoanhThuChiTiet(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();

                string sql = @"SELECT
                                 HD.MaHD,
                                 KH.HoTen AS TenKH,
                                 NV.HoTen AS TenNV,
                                 HD.NgayLap,
                                 HD.TongTien
                             FROM HoaDon HD
                             LEFT JOIN KhachHang KH ON HD.MaKH = KH.MaKH
                             LEFT JOIN NhanVien NV ON HD.MaNV = NV.MaNV
                             WHERE HD.NgayLap >= @FromDate AND HD.NgayLap < @ToDatePlusOne
                             ORDER BY HD.NgayLap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDatePlusOne", toDate.Date.AddDays(1));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.GetDoanhThuChiTiet: {ex.Message}"); }
            finally { CloseConnection(); }
            return dataTable;
        }
    }
}
