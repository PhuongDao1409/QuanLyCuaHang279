using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DTO_QuanLyCuaHang279;

namespace DAL_QuanLyCuaHang279 // << Đảm bảo Namespace đúng
{
    public class NhaCungCapDAL : DBConnect
    {
        // Lấy tất cả Nhà Cung Cấp
        public List<NhaCungCapDTO> GetAllNhaCungCap()
        {
            List<NhaCungCapDTO> list = new List<NhaCungCapDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = "SELECT MaNCC, TenNCC, DiaChi, SoDienThoai FROM NhaCungCap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCapDTO ncc = new NhaCungCapDTO();
                    ncc.MaNCC = Convert.ToInt32(reader["MaNCC"]);
                    ncc.TenNCC = reader["TenNCC"]?.ToString();
                    ncc.DiaChi = reader["DiaChi"]?.ToString();
                    ncc.SoDienThoai = reader["SoDienThoai"]?.ToString();
                    list.Add(ncc);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.GetAllNhaCungCap: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

        // Thêm Nhà Cung Cấp mới
        public bool InsertNhaCungCap(NhaCungCapDTO ncc)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = @"INSERT INTO NhaCungCap (TenNCC, DiaChi, SoDienThoai)
                             VALUES (@TenNCC, @DiaChi, @SoDienThoai)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", ncc.SoDienThoai);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.InsertNhaCungCap: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        // Cập nhật Nhà Cung Cấp
        public bool UpdateNhaCungCap(NhaCungCapDTO ncc)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = @"UPDATE NhaCungCap SET TenNCC=@TenNCC, DiaChi=@DiaChi, SoDienThoai=@SoDienThoai
                             WHERE MaNCC=@MaNCC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", ncc.SoDienThoai);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.UpdateNhaCungCap: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        // Xóa Nhà Cung Cấp
        public bool DeleteNhaCungCap(int maNCC)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547)
            { // Lỗi FK
                Console.WriteLine($"Lỗi DAL.DeleteNhaCungCap: Không thể xóa NCC mã {maNCC} do FK.");
                result = false;
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.DeleteNhaCungCap: {ex.Message}"); result = false; }
            finally { CloseConnection(); }
            return result;
        }
    }
}