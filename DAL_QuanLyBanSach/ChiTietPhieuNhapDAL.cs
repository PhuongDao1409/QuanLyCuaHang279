using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DTO_QuanLyCuaHang279;

namespace DAL_QuanLyCuaHang279
{
    public class ChiTietPhieuNhapDAL : DBConnect
    {
        public List<ChiTietPhieuNhapDTO> GetByMaPhieuNhap(int maPN)
        {
            List<ChiTietPhieuNhapDTO> list = new List<ChiTietPhieuNhapDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = @"SELECT ct.MaPhieuNhap, ct.MaSach, s.TenSach, ct.SoLuong, ct.GiaNhap 
                               FROM ChiTietPhieuNhap ct
                               INNER JOIN Sach s ON ct.MaSach = s.MaSach
                               WHERE ct.MaPhieuNhap = @MaPhieuNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", maPN);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietPhieuNhapDTO ct = new ChiTietPhieuNhapDTO();
                    ct.MaPhieuNhap = Convert.ToInt32(reader["MaPhieuNhap"]);
                    ct.MaSach = Convert.ToInt32(reader["MaSach"]);
                    ct.TenSach = reader["TenSach"].ToString(); // Lấy TenSach
                    ct.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                    ct.GiaNhap = Convert.ToDecimal(reader["GiaNhap"]);
                    list.Add(ct);
                }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.ChiTietPhieuNhapDAL.GetByMaPhieuNhap(MaPN={maPN}): {ex.Message}"); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

        public bool Insert(ChiTietPhieuNhapDTO ct)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSach, SoLuong, GiaNhap) VALUES (@MaPhieuNhap, @MaSach, @SoLuong, @GiaNhap)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", ct.MaPhieuNhap);
                cmd.Parameters.AddWithValue("@MaSach", ct.MaSach);
                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmd.Parameters.AddWithValue("@GiaNhap", ct.GiaNhap);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.ChiTietPhieuNhapDAL.Insert: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool Update(ChiTietPhieuNhapDTO ct)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = @"UPDATE ChiTietPhieuNhap SET SoLuong=@SoLuong, GiaNhap=@GiaNhap
                             WHERE MaPhieuNhap=@MaPhieuNhap AND MaSach=@MaSach";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmd.Parameters.AddWithValue("@GiaNhap", ct.GiaNhap);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", ct.MaPhieuNhap);
                cmd.Parameters.AddWithValue("@MaSach", ct.MaSach);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.ChiTietPhieuNhapDAL.Update: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool Delete(int maPN, int maSach)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap AND MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", maPN);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.ChiTietPhieuNhapDAL.Delete: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }
    }
}