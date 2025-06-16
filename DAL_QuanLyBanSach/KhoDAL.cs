using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DTO_QuanLyCuaHang279;

namespace DAL_QuanLyCuaHang279 
{
    public class KhoDAL : DBConnect
    {

        public List<KhoDTO> GetAllKho()
        {
            List<KhoDTO> list = new List<KhoDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = "SELECT MaKho, MaSach, SoLuongTon FROM Kho";
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhoDTO kho = new KhoDTO(
                        Convert.ToInt32(reader["MaKho"]),
                        Convert.ToInt32(reader["MaSach"]),
                        Convert.ToInt32(reader["SoLuongTon"])
                    );
                    list.Add(kho);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.GetAllKho: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

        // Thêm bản ghi tồn kho mới
        public bool InsertKho(KhoDTO kho)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "INSERT INTO Kho (MaSach, SoLuongTon) VALUES (@MaSach, @SoLuongTon)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSach", kho.MaSach);
                cmd.Parameters.AddWithValue("@SoLuongTon", kho.SoLuongTon);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.InsertKho: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        // Cập nhật số lượng tồn kho dựa trên MaSach
        public bool UpdateSoLuongTon(int maSach, int soLuongMoi)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "UPDATE Kho SET SoLuongTon = @SoLuongTon WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoLuongTon", soLuongMoi);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                result = cmd.ExecuteNonQuery() > 0;
                if (!result) { Console.WriteLine($"Warning: Không tìm thấy sách mã {maSach} trong kho."); }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.UpdateSoLuongTon (MaSach={maSach}): {ex.Message}"); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        // Lấy thông tin tồn kho theo MaSach
        public KhoDTO GetKhoByMaSach(int maSach)
        {
            KhoDTO kho = null;
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = "SELECT MaKho, MaSach, SoLuongTon FROM Kho WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    kho = new KhoDTO(
                        Convert.ToInt32(reader["MaKho"]),
                        Convert.ToInt32(reader["MaSach"]),
                        Convert.ToInt32(reader["SoLuongTon"])
                    );
                }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.GetKhoByMaSach(MaSach={maSach}): {ex.Message}"); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return kho;
        }

        // Hàm Delete Kho (ít dùng)
        public bool DeleteKho(int maKho)
        {
            bool result = false;
            try { OpenConnection(); string sql = "DELETE FROM Kho WHERE MaKho = @MaKho"; SqlCommand cmd = new SqlCommand(sql, conn); cmd.Parameters.AddWithValue("@MaKho", maKho); result = cmd.ExecuteNonQuery() > 0; }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.DeleteKho(MaKho={maKho}): {ex.Message}"); result = false; }
            finally { CloseConnection(); }
            return result;
        }
    }
}