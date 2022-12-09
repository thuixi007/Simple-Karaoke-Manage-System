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
using System.Globalization;
namespace Simple_Karaoke_Manage_System
{
    public partial class Quan_LY_Tai_Khoan : UserControl
    {
        public int Account_ID = 0;
        public string ten_tai_khoan_select;
        public string ten_tai_khoan;
        public Quan_LY_Tai_Khoan()
        {
            InitializeComponent();
            danh_sach_nhan_ven();
            //Ẩn nút thêm tài khoản
            btn_add.Hide();
        }

        public void set_ten_tk(string tk)
        {
            ten_tai_khoan = tk;
            
        }

        private bool check_tentk(string checkname)
        {
            string query = @"select dbo.Tai_khoan.Ten_dang_nhap
from dbo.Tai_khoan
where dbo.Tai_khoan.Ten_dang_nhap = '"+ checkname + "'";
            DAL dAL = new DAL();
            DataTable kiemtra = dAL.Run_Sql(query);
            if(kiemtra.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void danh_sach_nhan_ven()
        {
            string query = @"select dbo.Tai_khoan.ID_Tai_khoan, dbo.Tai_khoan.Ten_dang_nhap, 
dbo.Tai_khoan.Ten_nhan_vien,dbo.Tai_khoan.Loai_tai_khoan
from dbo.tai_khoan";
            DAL dAL = new DAL();
            DataTable kiemtra = dAL.Run_Sql(query);

            // Tải dữ liệu lên bảng danh sách nv
            //danh_sach_NV.Rows.Add(1, "QQQ", "XXX", "CCC");

            //// Sửa bảng danh sách nhân viên
            //Sửa chiều cao của Rows
            danh_sach_NV.RowTemplate.Height = 35;
            //Tắt kéo Rows , columns
            danh_sach_NV.AllowUserToResizeRows = false;
            danh_sach_NV.AllowUserToResizeColumns = false;
            //Sửa chiều cao của Collums
            danh_sach_NV.ColumnHeadersHeight = 30;
            //Sửa Font_size của Collums
            danh_sach_NV.ColumnHeadersDefaultCellStyle.Font = new Font("iCiel Andes Rounded", 11F, FontStyle.Regular);

            //Thêm data vào danh sách
            int i = 0;
            foreach (DataRow dr in kiemtra.Rows)
            {
                danh_sach_NV.Rows.Add(kiemtra.Rows[i][0].ToString(), kiemtra.Rows[i][1].ToString(),
                    kiemtra.Rows[i][2].ToString() , kiemtra.Rows[i][3].ToString());
                i++;
            }
            
        }

        private void danh_sach_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ẩn nút thêm tài khoản
            btn_add.Hide();
            //Đề phòng trường hợp click vào Rows Name
            if (e.RowIndex == -1) return;
            /// Lấy Giá trị rows đang chọn
            DataGridViewRow select_row = danh_sach_NV.Rows[e.RowIndex];
            /// Tạo read-only tên tài khoản
            account_textbox.ReadOnly = true;

            ///Ghi lại ID kiểm tra chống lỗi khi tạo tài khoản mới
            Account_ID = Int32.Parse(select_row.Cells[0].Value.ToString());
            ///Ghi lại tên tài khoản để tương tác với GUI
            ten_tai_khoan_select = select_row.Cells[1].Value.ToString();

            ///Hiển thị thông tin tài khoản được chọn lên thông tin chi tiết tài khoản
            id_textBox.Text = select_row.Cells[0].Value.ToString();
            account_textbox.Text = select_row.Cells[1].Value.ToString();
            //Lấy mật khâu từ CSDL
            string query = @"select dbo.Tai_khoan.Mat_khau
from dbo.Tai_khoan
where dbo.Tai_khoan.ID_Tai_khoan = " + Account_ID.ToString() ;
            DAL dAL = new DAL();
            DataTable kiemtra = dAL.Run_Sql(query);
            pass_textbox.Text = kiemtra.Rows[0][0].ToString();
            //
            name_textbox.Text = select_row.Cells[2].Value.ToString();
            //Chọn quyền của tài khoản - Quản trị viên hoặc nhân viên

            if( select_row.Cells[3].Value.ToString() == "True")
            {
                cbb_loaiTK.SelectedIndex = 1;
            }
            else
            {
                cbb_loaiTK.SelectedIndex = 0;
            }
            
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            /// Hiển thị nút thêm tài khoản
            btn_add.Show();
            /// Tạo mới một chi tiết tài khoản
            id_textBox.Text = "# - Tạo thông tin mới";
            account_textbox.Text = "";
            //Gỡ Read-only khỏi account textbox
            account_textbox.ReadOnly = false;
            pass_textbox.Text = "";
            name_textbox.Text = "";
            cbb_loaiTK.SelectedIndex = 0;
            // Trả acc id = 0 để tạo tk
            Account_ID = 0;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //Tạo kết nối tới lớp DAL
            DAL dAL = new DAL();

            //Kiểm tra đã chọn row nào chưa
            if (Account_ID == 0) return;
            // Hỏi trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản "+
                ten_tai_khoan_select + " Ra khỏi hệ thống không", "Xóa tài khoản ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Kiểm tra tài khoản được chọn có trùng với tk đang sử dụng
                if(ten_tai_khoan == ten_tai_khoan_select)
                {
                    MessageBox.Show("Bạn không thể xóa tài khoản mình đang sử dụng được", "Ôi bạn ơi");
                    return;
                }
                else
                {
                    string up_query = @"DELETE FROM dbo.Tai_khoan WHERE dbo.Tai_khoan.ID_Tai_khoan = " + Account_ID;
                    dAL.Update_Sql(up_query);
                    MessageBox.Show("Đã Xóa tài khoản " + ten_tai_khoan_select, "Hoàn Thành");
                    //Tải lại bảng danh sách nhân viên
                    danh_sach_NV.Rows.Clear();
                    danh_sach_nhan_ven();
                }
                
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            //Tạo kết nối tới lớp DAL
            DAL dAL = new DAL();
            //Kiểm tra đã chọn row nào chưa
            if (Account_ID == 0) return;
            // Hỏi trước khi cập nhật
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin cho tài khoản " +
                ten_tai_khoan_select + " trên hệ thống không", "Sửa tài khoản ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string up_query = @"UPDATE dbo.Tai_khoan
SET Mat_khau = '"+pass_textbox.Text+ 
"', Ten_nhan_vien = N'"+ name_textbox.Text.ToString() +"' , Loai_tai_khoan =  "+ cbb_loaiTK.SelectedIndex +
"WHERE dbo.Tai_khoan.ID_Tai_khoan = "+id_textBox.Text;

                dAL.Update_Sql(up_query);
                MessageBox.Show("Đã cập nhật thông tin tài khoản");
                //Tải lại bảng danh sách nhân viên
                    danh_sach_NV.Rows.Clear();
                    danh_sach_nhan_ven();

            }
            else
            {
                return;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem đã chọn tài khoản nào chưa
            if (Account_ID > 0)
            {
                MessageBox.Show("Hiện bạn đang chọn 1 tài khoản nên không thể tạo," +
                    " để tạo tài khoản mới, bạn vui lòng chọn vào nút tạo mới và điền đầy đủ thông tin, sau đó bấm THÊM");
                return;
            }
            //Kiểm tra điền thông tin
            account_textbox.Text.ToString();
            if ( account_textbox.Text == "" || pass_textbox.Text == "" || name_textbox.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi tạo tài khoản nhé");
                return;
            }
            //Kiểm tra tên tài khoản có bị trùng trên CSDL không
            if(check_tentk(account_textbox.Text) ==true )
            {
                MessageBox.Show("Tài khoản này đã tồn tại, vui lòng chọn tên đăng nhập khác");
                return;
            }

            // Tạo tài khoản
            DAL dAL = new DAL();
            string query = @"INSERT INTO dbo.Tai_khoan
(Ten_dang_nhap,Mat_khau,Ten_nhan_vien,Loai_tai_khoan) VALUES ('"
+ account_textbox.Text + "', '"
+pass_textbox.Text +"', N'"
+name_textbox.Text +"',"
+cbb_loaiTK.SelectedIndex+" )";
            dAL.Update_Sql(query);
            MessageBox.Show("Thêm Tài khoản thành công");
            //Tải lại bảng danh sách nhân viên
            danh_sach_NV.Rows.Clear();
            danh_sach_nhan_ven();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string search = Search_box.Text;

            danh_sach_NV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in danh_sach_NV.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(search) || string.Equals(row.Cells[1].Value.ToString(),search ))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không tìm thấy kết quả");
            }

        }
    }
}
