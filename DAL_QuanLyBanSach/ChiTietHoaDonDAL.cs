using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_QuanLyCuaHang279;

namespace DAL_QuanLyCuaHang279
{
    public class ChiTietHoaDonDAL : DBConnect
    {
        public List<ChiTietHoaDonDTO> GetByMaHD(int maHD)
        {
            List<ChiTietHoaDonDTO> list = new List<ChiTietHoaDonDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                
                string sql = @"SELECT ct.MaCTHD, ct.MaHD, ct.MaSach, s.TenSach, ct.SoLuong, ct.DonGia 
                               FROM ChiTietHoaDon ct
                               INNER JOIN Sach s ON ct.MaSach = s.MaSach
                               WHERE ct.MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDonDTO ct = new ChiTietHoaDonDTO();
                    ct.MaCTHD = Convert.ToInt32(reader["MaCTHD"]);
                    ct.MaHD = Convert.ToInt32(reader["MaHD"]);
                    ct.MaSach = Convert.ToInt32(reader["MaSach"]);
                    ct.TenSach = reader["TenSach"].ToString(); 
                    ct.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                    ct.DonGia = Convert.ToDecimal(reader["DonGia"]);
                  
                    list.Add(ct);
                }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.ChiTietHoaDonDAL.GetByMaHD(MaHD={maHD}): {ex.Message}"); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

        public bool Insert(ChiTietHoaDonDTO ct)
        {
            bool result = false;
            try
            {
                OpenConnection();
               
                string sql = "INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuong, DonGia) VALUES (@MaHD, @MaSach, @SoLuong, @DonGia)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHD", ct.MaHD);
                cmd.Parameters.AddWithValue("@MaSach", ct.MaSach);
                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.ChiTietHoaDonDAL.Insert: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool Update(ChiTietHoaDonDTO ct)
        {
            bool result = false;
            try
            {
                OpenConnection();

                string sql = "UPDATE ChiTietHoaDon SET SoLuong=@SoLuong, DonGia=@DonGia WHERE MaCTHD=@MaCTHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaCTHD", ct.MaCTHD);
                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.ChiTietHoaDonDAL.Update: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool Delete(int maCTHD)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "DELETE FROM ChiTietHoaDon WHERE MaCTHD = @MaCTHD";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaCTHD", maCTHD);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.ChiTietHoaDonDAL.Delete: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }
    }
}