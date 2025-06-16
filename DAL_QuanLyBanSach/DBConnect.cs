using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL_QuanLyCuaHang279 
{
    public class DBConnect
    {
        private const string connectionString = @"Data Source=MSI;Initial Catalog=QL_NhaSach279;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
       
        protected SqlConnection conn = null;

        
        /// <exception cref="Exception"
        protected void OpenConnection()
        {
            try
            {
                // Khởi tạo conn nếu nó đang là null
                if (conn == null)
                {
                    conn = new SqlConnection(connectionString); 
                }

                // Chỉ mở kết nối nếu nó đang ở trạng thái đóng
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL khi mở kết nối (DBConnect): {ex.Message}");
                throw new Exception($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi không xác định khi mở kết nối (DBConnect): {ex.Message}");
                throw new Exception("Đã xảy ra lỗi không mong muốn khi mở kết nối.", ex);
            }
        }

        /// <summary>
        /// Đóng kết nối đến cơ sở dữ liệu nếu nó đang mở.
        /// </summary>
        protected void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}