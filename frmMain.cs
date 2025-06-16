using GUI_QuanLyCuaHang279;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLyCuaHang279
{
    public partial class frmMain : Form
    {
        private Form currentChildForm;

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void logocompany_Click(object sender, EventArgs e)
        {

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSach()); 
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDon());
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaCungCap());
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPhieuNhap());
        }

        private void btnQLKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKho());
        }

        private void btnBC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBaoCaoThongKe());
        }
    }
}

