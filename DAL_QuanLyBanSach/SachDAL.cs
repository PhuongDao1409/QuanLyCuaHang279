using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO_QuanLyCuaHang279;
using System.Data;

namespace DAL_QuanLyCuaHang279
{
    public class SachDAL : DBConnect
    {
        public List<SachDTO> GetAll()
        {
            List<SachDTO> list = new List<SachDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string query = "SELECT MaSach, TenSach, TheLoai, TacGia, NXB, GiaBan, SoLuong, HinhAnh FROM Sach";
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SachDTO s = new SachDTO();
                    s.MaSach = Convert.ToInt32(reader["MaSach"]);
                    s.TenSach = reader["TenSach"]?.ToString();
                    s.TheLoai = reader["TheLoai"]?.ToString();
                    s.TacGia = reader["TacGia"]?.ToString();
                    s.NXB = reader["NXB"]?.ToString();
                    s.GiaBan = Convert.ToDecimal(reader["GiaBan"]);
                    s.SoLuong = Convert.ToInt32(reader["SoLuong"]); 
                    s.HinhAnh = reader["HinhAnh"]?.ToString();
                    list.Add(s);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.SachDAL.GetAll: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

 
        public int Insert(SachDTO s)
        {
            int newMaSach = -1;
            try
            {
                OpenConnection();
 
                string query = @"INSERT INTO Sach (TenSach, TheLoai, TacGia, NXB, GiaBan, SoLuong, HinhAnh)
                                 VALUES (@TenSach, @TheLoai, @TacGia, @NXB, @GiaBan, @SoLuong, @HinhAnh);
                                 SELECT CAST(SCOPE_IDENTITY() AS INT);"; 
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TenSach", s.TenSach);
                cmd.Parameters.AddWithValue("@TheLoai", (object)s.TheLoai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TacGia", (object)s.TacGia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NXB", (object)s.NXB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GiaBan", s.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong); 
                cmd.Parameters.AddWithValue("@HinhAnh", (object)s.HinhAnh ?? DBNull.Value);

                object result = cmd.ExecuteScalar(); 

                if (result != null && result != DBNull.Value)
                {
                    newMaSach = Convert.ToInt32(result);
                }
                else
                {
                    Console.WriteLine("Lỗi DAL.SachDAL.Insert: Không lấy được SCOPE_IDENTITY().");
                    newMaSach = -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL.SachDAL.Insert: " + ex.Message);
                newMaSach = -1;
            }
            finally
            {
                CloseConnection();
            }
            return newMaSach; 
        }


        public bool Update(SachDTO s)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string query = @"UPDATE Sach SET TenSach = @TenSach, TheLoai = @TheLoai, TacGia = @TacGia,
                                 NXB = @NXB, GiaBan = @GiaBan, SoLuong = @SoLuong, HinhAnh = @HinhAnh
                                 WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaSach", s.MaSach);
                cmd.Parameters.AddWithValue("@TenSach", s.TenSach);
                cmd.Parameters.AddWithValue("@TheLoai", (object)s.TheLoai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TacGia", (object)s.TacGia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NXB", (object)s.NXB ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GiaBan", s.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong);
                cmd.Parameters.AddWithValue("@HinhAnh", (object)s.HinhAnh ?? DBNull.Value);

                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.SachDAL.Update: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

 
        public bool Delete(int maSach)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.SachDAL.Delete: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public List<SachDTO> SearchByName(string keyword)
        {
            List<SachDTO> list = new List<SachDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string query = "SELECT MaSach, TenSach, TheLoai, TacGia, NXB, GiaBan, SoLuong, HinhAnh FROM Sach WHERE TenSach LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SachDTO s = new SachDTO();
                    s.MaSach = Convert.ToInt32(reader["MaSach"]);
                    s.TenSach = reader["TenSach"]?.ToString();
                    s.TheLoai = reader["TheLoai"]?.ToString();
                    s.TacGia = reader["TacGia"]?.ToString();
                    s.NXB = reader["NXB"]?.ToString();
                    s.GiaBan = Convert.ToDecimal(reader["GiaBan"]);
                    s.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                    s.HinhAnh = reader["HinhAnh"]?.ToString();
                    list.Add(s);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.SachDAL.SearchByName: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }


        public SachDTO GetById(int maSach)
        {
            SachDTO s = null;
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string query = "SELECT MaSach, TenSach, TheLoai, TacGia, NXB, GiaBan, SoLuong, HinhAnh FROM Sach WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    s = new SachDTO();
                    s.MaSach = Convert.ToInt32(reader["MaSach"]);
                    s.TenSach = reader["TenSach"]?.ToString();
                    s.TheLoai = reader["TheLoai"]?.ToString();
                    s.TacGia = reader["TacGia"]?.ToString();
                    s.NXB = reader["NXB"]?.ToString();
                    s.GiaBan = Convert.ToDecimal(reader["GiaBan"]);
                    s.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                    s.HinhAnh = reader["HinhAnh"]?.ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.SachDAL.GetById(MaSach={maSach}): {ex.Message}"); s = null; }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return s;
        }
    }
}