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
    public class TaiKhoanDAL : DBConnect
    {
        
        public TaiKhoanDTO KiemTraDangNhap(string user, string pass)
        {
            TaiKhoanDTO tk = null;
            SqlDataReader reader = null;

            try
            {
                OpenConnection();

                string sql = "SELECT TenDangNhap, VaiTro FROM TaiKhoan WHERE TenDangNhap = @TenDangNhapInput AND MatKhau = @MatKhauInput";
                // !!! CẢNH BÁO BẢO MẬT !!!
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenDangNhapInput", user);
                cmd.Parameters.AddWithValue("@MatKhauInput", pass);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tk = new TaiKhoanDTO
                    {
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        VaiTro = reader["VaiTro"].ToString()
                        // Không lấy mật khẩu
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DAL.KiemTraDangNhap cho user '{user}': {ex.Message}");
                tk = null;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                CloseConnection();
            }

            return tk;
        }

      
    }
}