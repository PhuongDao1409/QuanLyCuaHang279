using DAL_QuanLyCuaHang279;
using DTO_QuanLyCuaHang279;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL_QuanLyCuaHang279
{
    public class HoaDonDAL : DBConnect
    {
        //  lấy  TenNhanVien, TenKhachHang
        public List<HoaDonDTO> GetAll()
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                // Sửa câu SQL để JOIN và lấy tên
                string sql = @"SELECT hd.MaHD, hd.MaNV, nv.HoTen AS TenNhanVien,
                                      hd.MaKH, kh.HoTen AS TenKhachHang,
                                      hd.NgayLap, hd.TongTien
                               FROM HoaDon hd
                               LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                               LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                               ORDER BY hd.NgayLap DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.MaHD = Convert.ToInt32(reader["MaHD"]);
                    hd.MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : (int?)null;
                    hd.TenNhanVien = reader["TenNhanVien"] != DBNull.Value ? reader["TenNhanVien"].ToString() : null; // Lấy TenNhanVien
                    hd.MaKH = reader["MaKH"] != DBNull.Value ? Convert.ToInt32(reader["MaKH"]) : (int?)null;
                    hd.TenKhachHang = reader["TenKhachHang"] != DBNull.Value ? reader["TenKhachHang"].ToString() : "Khách lẻ"; // Lấy TenKhachHang, nếu null thì là "Khách lẻ"
                    hd.NgayLap = Convert.ToDateTime(reader["NgayLap"]);
                    hd.TongTien = Convert.ToDecimal(reader["TongTien"]);
                    list.Add(hd);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.HoaDonDAL.GetAll: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

        // Phương thức mới để lấy một hóa đơn với đầy đủ thông tin cho report
        public HoaDonDTO GetHoaDonByIdForReport(int maHD)
        {
            HoaDonDTO hd = null;
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = @"SELECT hd.MaHD, hd.MaNV, nv.HoTen AS TenNhanVien,
                                      hd.MaKH, kh.HoTen AS TenKhachHang,
                                      hd.NgayLap, hd.TongTien
                               FROM HoaDon hd
                               LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                               LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                               WHERE hd.MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hd = new HoaDonDTO();
                    hd.MaHD = Convert.ToInt32(reader["MaHD"]);
                    hd.MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : (int?)null;
                    hd.TenNhanVien = reader["TenNhanVien"] != DBNull.Value ? reader["TenNhanVien"].ToString() : null;
                    hd.MaKH = reader["MaKH"] != DBNull.Value ? Convert.ToInt32(reader["MaKH"]) : (int?)null;
                    hd.TenKhachHang = reader["TenKhachHang"] != DBNull.Value ? reader["TenKhachHang"].ToString() : "Khách lẻ";
                    hd.NgayLap = Convert.ToDateTime(reader["NgayLap"]);
                    hd.TongTien = Convert.ToDecimal(reader["TongTien"]);
                }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.HoaDonDAL.GetHoaDonByIdForReport(MaHD={maHD}): {ex.Message}"); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return hd;
        }


        public int Insert(HoaDonDTO hd)
        {
            int newMaHD = -1;
            try
            {
                OpenConnection();
                string sql = @"INSERT INTO HoaDon (MaNV, MaKH, NgayLap, TongTien)
                             VALUES (@MaNV, @MaKH, @NgayLap, @TongTien);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNV", hd.MaNV.HasValue ? (object)hd.MaNV.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@MaKH", hd.MaKH.HasValue ? (object)hd.MaKH.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value) { newMaHD = Convert.ToInt32(result); } // Sửa lại điều kiện kiểm tra result
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.HoaDonDAL.Insert: " + ex.Message); newMaHD = -1; }
            finally { CloseConnection(); }
            return newMaHD;
        }

        public bool Update(HoaDonDTO hd)
        {
            bool result = false;
            try
            {
                OpenConnection();

                string sql = @"UPDATE HoaDon SET MaNV=@MaNV, MaKH=@MaKH, NgayLap=@NgayLap, TongTien=@TongTien WHERE MaHD=@MaHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHD", hd.MaHD);
                cmd.Parameters.AddWithValue("@MaNV", hd.MaNV.HasValue ? (object)hd.MaNV.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@MaKH", hd.MaKH.HasValue ? (object)hd.MaKH.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.HoaDonDAL.Update: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }


        public bool UpdateTongTien(int maHD, decimal tongTien)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "UPDATE HoaDon SET TongTien = @TongTien WHERE MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.UpdateTongTien(MaHD={maHD}): {ex.Message}"); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool Delete(int maHD)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "DELETE FROM HoaDon WHERE MaHD=@MaHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.HoaDonDAL.Delete: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        // Sửa đổi SearchByMaKH để lấy thêm TenNhanVien, TenKhachHang
        public List<HoaDonDTO> SearchByMaKH(int maKHSearch) // Đổi tên tham số để tránh nhầm lẫn với cột MaKH
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                // Sửa câu SQL để JOIN và lấy tên
                string sql = @"SELECT hd.MaHD, hd.MaNV, nv.HoTen AS TenNhanVien,
                                      hd.MaKH, kh.HoTen AS TenKhachHang,
                                      hd.NgayLap, hd.TongTien
                               FROM HoaDon hd
                               LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                               LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                               WHERE hd.MaKH = @MaKH_SearchValue
                               ORDER BY hd.NgayLap DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKH_SearchValue", maKHSearch);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.MaHD = Convert.ToInt32(reader["MaHD"]);
                    hd.MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : (int?)null;
                    hd.TenNhanVien = reader["TenNhanVien"] != DBNull.Value ? reader["TenNhanVien"].ToString() : null;
                    hd.MaKH = reader["MaKH"] != DBNull.Value ? Convert.ToInt32(reader["MaKH"]) : (int?)null;
                    hd.TenKhachHang = reader["TenKhachHang"] != DBNull.Value ? reader["TenKhachHang"].ToString() : "Khách lẻ";
                    hd.NgayLap = Convert.ToDateTime(reader["NgayLap"]);
                    hd.TongTien = Convert.ToDecimal(reader["TongTien"]);
                    list.Add(hd);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.HoaDonDAL.SearchByMaKH: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }
    }
}