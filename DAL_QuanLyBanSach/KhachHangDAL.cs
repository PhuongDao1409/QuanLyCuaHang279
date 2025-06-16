using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using System.Data.SqlClient;
using DTO_QuanLyCuaHang279;

namespace DAL_QuanLyCuaHang279
{
    public class KhachHangDAL : DBConnect // Đã kế thừa
    {
        public List<KhachHangDTO> GetAllKhachHang()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = "SELECT MaKH, HoTen, SoDienThoai, Email FROM KhachHang"; // Liệt kê cột
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhachHangDTO kh = new KhachHangDTO
                    {
                        MaKH = Convert.ToInt32(reader["MaKH"]),
                        HoTen = reader["HoTen"]?.ToString(),
                        SoDienThoai = reader["SoDienThoai"]?.ToString(),
                        Email = reader["Email"]?.ToString()
                    };
                    list.Add(kh);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.GetAllKhachHang: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

        public bool InsertKhachHang(KhachHangDTO kh)
        {
            bool result = false;
            try
            {
                OpenConnection();
              
                string sql = "INSERT INTO KhachHang (HoTen, SoDienThoai, Email) VALUES (@HoTen, @SoDienThoai, @Email)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                // Xử lý nếu SoDienThoai hoặc Email có thể NULL trong DTO/GUI
                cmd.Parameters.AddWithValue("@SoDienThoai", (object)kh.SoDienThoai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)kh.Email ?? DBNull.Value);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.InsertKhachHang: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool UpdateKhachHang(KhachHangDTO kh)
        {
            bool result = false;
            try
            {
                OpenConnection();
                // << Sửa UPDATE: Chỉ cập nhật các cột có trong bảng KhachHang >>
                string sql = @"UPDATE KhachHang SET
                                 HoTen = @HoTen,
                                 SoDienThoai = @SoDienThoai,
                                 Email = @Email
                               WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH); // Điều kiện WHERE
                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                cmd.Parameters.AddWithValue("@SoDienThoai", (object)kh.SoDienThoai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)kh.Email ?? DBNull.Value);
               
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.UpdateKhachHang: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool DeleteKhachHang(int maKH)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.DeleteKhachHang: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public List<KhachHangDTO> SearchKhachHangByName(string keyword)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = "SELECT MaKH, HoTen, SoDienThoai, Email FROM KhachHang WHERE HoTen LIKE @Keyword"; // Liệt kê cột
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhachHangDTO kh = new KhachHangDTO
                    {
                        MaKH = Convert.ToInt32(reader["MaKH"]),
                        HoTen = reader["HoTen"]?.ToString(),
                        SoDienThoai = reader["SoDienThoai"]?.ToString(),
                        Email = reader["Email"]?.ToString()
                    };
                    list.Add(kh);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.SearchKhachHangByName: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }
    }
}