using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DTO_QuanLyCuaHang279;
using DTO_QuanLyNhaSach279;

namespace DAL_QuanLyCuaHang279
{
    public class PhieuNhapDAL : DBConnect
    {
        public List<PhieuNhapDTO> GetAll()
        {
            List<PhieuNhapDTO> list = new List<PhieuNhapDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = @"SELECT pn.MaPhieuNhap, pn.MaNV, nv.HoTen AS TenNhanVien,
                                      pn.MaNCC, ncc.TenNCC AS TenNhaCungCap,
                                      pn.NgayNhap, pn.TongTien
                               FROM PhieuNhap pn
                               LEFT JOIN NhanVien nv ON pn.MaNV = nv.MaNV
                               LEFT JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                               ORDER BY pn.NgayNhap DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.MaPhieuNhap = Convert.ToInt32(reader["MaPhieuNhap"]);
                    pn.MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : (int?)null;
                    pn.TenNhanVien = reader["TenNhanVien"] != DBNull.Value ? reader["TenNhanVien"].ToString() : null;
                    pn.MaNCC = reader["MaNCC"] != DBNull.Value ? Convert.ToInt32(reader["MaNCC"]) : (int?)null;
                    pn.TenNhaCungCap = reader["TenNhaCungCap"] != DBNull.Value ? reader["TenNhaCungCap"].ToString() : null;
                    pn.NgayNhap = Convert.ToDateTime(reader["NgayNhap"]);
                    pn.TongTien = Convert.ToDecimal(reader["TongTien"]);
                    list.Add(pn);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.PhieuNhapDAL.GetAll: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }

        public PhieuNhapDTO GetPhieuNhapByIdForReport(int maPN)
        {
            PhieuNhapDTO pn = null;
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = @"SELECT pn.MaPhieuNhap, pn.MaNV, nv.HoTen AS TenNhanVien,
                                      pn.MaNCC, ncc.TenNCC AS TenNhaCungCap,
                                      pn.NgayNhap, pn.TongTien
                               FROM PhieuNhap pn
                               LEFT JOIN NhanVien nv ON pn.MaNV = nv.MaNV
                               LEFT JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                               WHERE pn.MaPhieuNhap = @MaPhieuNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", maPN);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pn = new PhieuNhapDTO();
                    pn.MaPhieuNhap = Convert.ToInt32(reader["MaPhieuNhap"]);
                    pn.MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : (int?)null;
                    pn.TenNhanVien = reader["TenNhanVien"] != DBNull.Value ? reader["TenNhanVien"].ToString() : null;
                    pn.MaNCC = reader["MaNCC"] != DBNull.Value ? Convert.ToInt32(reader["MaNCC"]) : (int?)null;
                    pn.TenNhaCungCap = reader["TenNhaCungCap"] != DBNull.Value ? reader["TenNhaCungCap"].ToString() : null;
                    pn.NgayNhap = Convert.ToDateTime(reader["NgayNhap"]);
                    pn.TongTien = Convert.ToDecimal(reader["TongTien"]);
                }
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.PhieuNhapDAL.GetPhieuNhapByIdForReport(MaPN={maPN}): {ex.Message}"); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return pn;
        }

        public int Insert(PhieuNhapDTO pn)
        {
            int newMaPN = -1;
            try
            {
                OpenConnection();
                string sql = @"INSERT INTO PhieuNhap (MaNV, MaNCC, NgayNhap, TongTien)
                             VALUES (@MaNV, @MaNCC, @NgayNhap, @TongTien);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNV", pn.MaNV.HasValue ? (object)pn.MaNV.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@MaNCC", pn.MaNCC.HasValue ? (object)pn.MaNCC.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayNhap", pn.NgayNhap);
                cmd.Parameters.AddWithValue("@TongTien", pn.TongTien);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value) { newMaPN = Convert.ToInt32(result); }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.PhieuNhapDAL.Insert: " + ex.Message); newMaPN = -1; }
            finally { CloseConnection(); }
            return newMaPN;
        }

        public bool Update(PhieuNhapDTO pn)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = @"UPDATE PhieuNhap SET MaNV=@MaNV, MaNCC=@MaNCC, NgayNhap=@NgayNhap, TongTien=@TongTien
                             WHERE MaPhieuNhap=@MaPhieuNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", pn.MaPhieuNhap);
                cmd.Parameters.AddWithValue("@MaNV", pn.MaNV.HasValue ? (object)pn.MaNV.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@MaNCC", pn.MaNCC.HasValue ? (object)pn.MaNCC.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayNhap", pn.NgayNhap);
                cmd.Parameters.AddWithValue("@TongTien", pn.TongTien);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.PhieuNhapDAL.Update: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool UpdateTongTien(int maPN, decimal tongTien)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "UPDATE PhieuNhap SET TongTien = @TongTien WHERE MaPhieuNhap = @MaPhieuNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", maPN);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi DAL.PhieuNhapDAL.UpdateTongTien(MaPN={maPN}): {ex.Message}"); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public bool Delete(int maPN)
        {
            bool result = false;
            try
            {
                OpenConnection();
                string sql = "DELETE FROM PhieuNhap WHERE MaPhieuNhap=@MaPhieuNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", maPN);
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 547)
            {
                Console.WriteLine($"Lỗi DAL.PhieuNhapDAL.Delete: Không thể xóa PN mã {maPN} do FK.");
                result = false;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.PhieuNhapDAL.Delete: " + ex.Message); result = false; }
            finally { CloseConnection(); }
            return result;
        }

        public List<PhieuNhapDTO> SearchByTenNCC(string keyword)
        {
            List<PhieuNhapDTO> list = new List<PhieuNhapDTO>();
            SqlDataReader reader = null;
            try
            {
                OpenConnection();
                string sql = @"SELECT pn.MaPhieuNhap, pn.MaNV, nv.HoTen AS TenNhanVien,
                                      pn.MaNCC, ncc.TenNCC AS TenNhaCungCap,
                                      pn.NgayNhap, pn.TongTien
                               FROM PhieuNhap pn
                               LEFT JOIN NhanVien nv ON pn.MaNV = nv.MaNV
                               LEFT JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                               WHERE ncc.TenNCC LIKE @Keyword
                               ORDER BY pn.NgayNhap DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.MaPhieuNhap = Convert.ToInt32(reader["MaPhieuNhap"]);
                    pn.MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : (int?)null;
                    pn.TenNhanVien = reader["TenNhanVien"] != DBNull.Value ? reader["TenNhanVien"].ToString() : null;
                    pn.MaNCC = reader["MaNCC"] != DBNull.Value ? Convert.ToInt32(reader["MaNCC"]) : (int?)null;
                    pn.TenNhaCungCap = reader["TenNhaCungCap"] != DBNull.Value ? reader["TenNhaCungCap"].ToString() : null;
                    pn.NgayNhap = Convert.ToDateTime(reader["NgayNhap"]);
                    pn.TongTien = Convert.ToDecimal(reader["TongTien"]);
                    list.Add(pn);
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi DAL.SearchByTenNCC: " + ex.Message); }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                CloseConnection();
            }
            return list;
        }
    }
}