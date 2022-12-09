using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Simple_Karaoke_Manage_System.Class;

namespace Simple_Karaoke_Manage_System
{
    public partial class Login_Form : Form
    {
        //Tạo kết nối tới lớp BLL//
        
        public Login_Form()
        {
            InitializeComponent();



        }

        private void Panel_Login_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //Kiểm tra đã nhập tài khoản / mật khẩu vào chưa?
            if ( login_input.Text == "" || pass_input.Text == "")
            {
                MessageBox.Show("Bạn vui lòng điền đầy đủ thông tin đăng nhập nhé", "Ôi bạn ơi");
            }
            else 
            {
                /// Kiểm tra tài khoản ( Gọi trực tiếp tới lớp DAL cho lẹ)
                DAL dAL = new DAL();

                string query = @"select * from dbo.Tai_khoan
where dbo.Tai_khoan.Ten_dang_nhap = '" + login_input.Text.Trim() +
"' and Mat_khau ='" + pass_input.Text.Trim() + "';";

                DataTable kiemtra = dAL.Run_Sql(query);

                if (kiemtra.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    this.Hide();
                    App_Main App_main = new App_Main(login_input.Text);
                    App_main.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai, vui lòng kiểm tra lại ","Ôi bạn ơi");
                }
            }

        }



        private void btn_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
