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
    public partial class doi_mat_khau : UserControl
    {

        public string ten_tai_khoan ;

        //

        public doi_mat_khau()
        {
            InitializeComponent();
            //Lấy tài khoản 
            // Thêm tên tài khoản
            
        }


        //Lấy tên tài khoản từ main.
        public void set_account(string tk)
        {
           textbox_ten_dang_nhap.Text = tk;
            ten_tai_khoan = tk;
        }

        private void btn_change_pass_Click(object sender, EventArgs e)
        {
            ///Kiểm tra các ô nhập vào đã đc nhập chưa

            if ( guna2TextBox2.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "")
            {
                MessageBox.Show("Bạn vui lòng điền đầy đủ thông tin vào để đổi mật khẩu nhé", "Ôi bạn ơi");
            }
            else
            {
                ////Kiểm tra mật khẩu cũ

                //Gọi lớp DAL
                DAL dAL = new DAL();
                //lệnh truy vấn CSDL lấy mật khẩu của tài khoản
                string query = @"select dbo.Tai_khoan.Mat_khau
from dbo.Tai_khoan
where dbo.Tai_khoan.Ten_dang_nhap = '" + ten_tai_khoan + "'";

                DataTable kiemtra = dAL.Run_Sql(query);
                //So sánh mk cũ nhập vào với mk cũ trên csdl

                if(kiemtra.Rows[0][0].ToString() == guna2TextBox2.Text)//Nếu đúng mk cũ |
                {
                    //Kiểm tra 2 mật khẩu mới nhập vào khớp nhau
                    if(guna2TextBox3.Text == guna2TextBox4.Text) {
                        string up_query = @"UPDATE dbo.Tai_khoan SET Mat_khau = '" + guna2TextBox3.Text +
    "' WHERE Ten_dang_nhap = '" + ten_tai_khoan + "'";

                        dAL.Update_Sql(up_query);
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo!");
                    }
                    else
                    {
                        MessageBox.Show("Bạn vui lòng nhập lại mật khẩu mới chính xác nhé", "Bình Tĩnh");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu cũ rồi bạn ơi", "Bình Tĩnh");
                }
            }
        }
    }
}
