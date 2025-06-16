using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLyCuaHang279;
using DTO_QuanLyCuaHang279;
using GUI_QuanLyCuaHang279;

namespace GUI_QuanLyCuaHang279
{
    public partial class frmDangNhap : Form
    {
        TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();
        public frmDangNhap()
        {
            InitializeComponent();

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            TaiKhoanDTO tk = taiKhoanBUS.DangNhap(user, pass);

            if (tk != null)
            {
                MessageBox.Show("Đăng nhập thành công!");

                frmMain frmMain = new frmMain();
                this.Hide();
                frmMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
