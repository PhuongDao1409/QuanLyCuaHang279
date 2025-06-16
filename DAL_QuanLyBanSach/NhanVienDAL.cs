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
    public class NhanVienDAL : DBConnect
    {

        public List<NhanVienDTO> GetAllNhanVien()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = "SELECT MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai, Email, ChucVu FROM NhanVien"; // Thêm ChucVu
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new NhanVienDTO
                    {
                        MaNV = Convert.ToInt32(reader["MaNV"]),
                        HoTen = reader["HoTen"]?.ToString(),
                        GioiTinh = reader["GioiTinh"]?.ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        DiaChi = reader["DiaChi"]?.ToString(),
                        SoDienThoai = reader["SoDienThoai"]?.ToString(),
                        Email = reader["Email"]?.ToString(),
                        ChucVu = reader["ChucVu"]?.ToString() // Thêm ChucVu
                    });
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.GetAllNhanVien: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

        public bool InsertNhanVien(NhanVienDTO nv)
        {
            bool result = false;
            try
            {
                OpenConnection();
                // Thêm ChucVu vào INSERT
                string sql = @"INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai, Email, ChucVu)
                              VALUES (@HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SoDienThoai, @Email, @ChucVu)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", nv.Email);
                cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu); // Thêm ChucVu
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.InsertNhanVien: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool UpdateNhanVien(NhanVienDTO nv)
        {
            bool result = false;
            try
            {
                OpenConnection();
                // Thêm ChucVu vào UPDATE
                string sql = @"UPDATE NhanVien SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh,
                              DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email, ChucVu = @ChucVu
                              WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", nv.Email);
                cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu); // Thêm ChucVu
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.UpdateNhanVien: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        // --- Cần thêm try-finally ---
        public bool DeleteNhanVien(int maNV)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.DeleteNhanVien: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        // --- Phương thức tìm kiếm mới ---
        public List<NhanVienDTO> SearchNhanVienByName(string keyword)
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                // Tìm kiếm gần đúng trong cột HoTen
                string sql = "SELECT MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, SoDienThoai, Email, ChucVu FROM NhanVien WHERE HoTen LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%"); // Thêm % cho LIKE

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nv = new NhanVienDTO
                    {
                        MaNV = Convert.ToInt32(reader["MaNV"]),
                        HoTen = reader["HoTen"]?.ToString(),
                        GioiTinh = reader["GioiTinh"]?.ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        DiaChi = reader["DiaChi"]?.ToString(),
                        SoDienThoai = reader["SoDienThoai"]?.ToString(),
                        Email = reader["Email"]?.ToString(),
                        ChucVu = reader["ChucVu"]?.ToString()
                    };
                    list.Add(nv);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.SearchNhanVienByName: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }
    }
}