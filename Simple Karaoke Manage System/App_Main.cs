using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simple_Karaoke_Manage_System.Class;

namespace Simple_Karaoke_Manage_System
{

    public partial class App_Main : Form
    {
        public string ten_tai_khoan;

        public string ten_nhan_vien;


        public App_Main()
        {
            InitializeComponent();

        }

        public App_Main(string ten_tai_khoan)
        {
            InitializeComponent();
            this.ten_tai_khoan = ten_tai_khoan;
            hello_set();

            //Hiển thị trang chủ khi vào ứng dụng
            trang_chu1.BringToFront();


        }
        public void hello_set()
        {
            ///Lấy tên nhân viên từ cơ sở dữ liệu
            string query = @"select dbo.Tai_khoan.Ten_nhan_vien, dbo.Tai_khoan.Loai_tai_khoan
from dbo.Tai_khoan
where dbo.Tai_khoan.Ten_dang_nhap = '" + ten_tai_khoan + "';";
            DAL dAL = new DAL();
            DataTable kiemtra = dAL.Run_Sql(query);
            /// Set tên nhân viên lên App_Main
            user_name.Text = kiemtra.Rows[0][0].ToString();

            ten_nhan_vien = kiemtra.Rows[0][0].ToString();
            ///Set loại tài khoản
            if ( kiemtra.Rows[0][1].ToString() == "True")
            {
                user_type.Text = "Quản trị viên";
            }
            else { 
                user_type.Text = "Nhân viên"; 
            /// Ẩn các lựa chọn quản lý khi là nhân viên
                btn_ql_sp.Hide();
                btn_ql_loai_sp.Hide();
                btn_ql_ph.Hide();
                btn_ql_TK.Hide();
                btn_Xem_doanh_thu.Hide();
            }
            trang_chu1.BringToFront();
        }
        ///<-> Các chức năng của ứng dụng <->

        /// Hiện trang chủ
        private void btn_trang_chu_Click(object sender, EventArgs e)
        {
            trang_chu1.BringToFront();
        }



        private void btn_doi_mk_Click(object sender, EventArgs e)
        {
            doi_mat_khau1.BringToFront();
            doi_mat_khau1.set_account(this.ten_tai_khoan);

        }

        private void btn_ql_TK_Click(object sender, EventArgs e)
        {
            quan_LY_Tai_Khoan1.BringToFront();
            quan_LY_Tai_Khoan1.set_ten_tk(ten_tai_khoan);
        }

        private void btn_ql_ph_Click(object sender, EventArgs e)
        {
            quan_Ly_Phong_Hat1.BringToFront();
        }

        private void btn_ql_loai_sp_Click(object sender, EventArgs e)
        {
            quan_Ly_Loai_SP1.BringToFront();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btn_ql_sp_Click(object sender, EventArgs e)
        {
            quan_ly_san_pham1.BringToFront();
            quan_ly_san_pham1.refesh_table();
        }

        private void btn_ban_hang_Click(object sender, EventArgs e)
        {
            ban_Hang1.BringToFront();
            ban_Hang1.refest_get_phan_loai();
            ban_Hang1.refesh_phong_hat();
            ban_Hang1.set_ten_nv(ten_nhan_vien);
        }


        private void btn_Xem_doanh_thu_Click(object sender, EventArgs e)
        {
            xemDoanhThu1.BringToFront();
        }

        ///
    }
}
