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
    public partial class Quan_Ly_Phong_Hat : UserControl
    {
        public int Room_ID = 0;
        public string ten_phong_select;
        public string ten_tai_khoan;
        public Quan_Ly_Phong_Hat()
        {
            InitializeComponent();

            /// Load danh sách phòng hát ///
            danh_sach_phong_hat();
            //Ẩn nút thêm phòng hát
            btn_add.Hide();
        }
        public void set_ten_tk(string tk)
        {
            ten_tai_khoan = tk;

        }

        private bool check_ten_ph(string checkname)
        {
            string query = @"select dbo.Phong_hat.Ten_phong_hat
from dbo.Phong_hat
where dbo.Phong_hat.Ten_phong_hat = N'"+ checkname + "'";
            DAL dAL = new DAL();
            DataTable kiemtra = dAL.Run_Sql(query);
            if (kiemtra.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void danh_sach_phong_hat()
        {
            try
            {
                string query = @"select * 
from dbo.Phong_hat";
                DAL dAL = new DAL();
                DataTable kiemtra = dAL.Run_Sql(query);

                // Tải dữ liệu lên bảng danh sách nv
                //danh_sach_NV.Rows.Add(1, "QQQ", "XXX", "CCC");

                //// Sửa bảng danh sách nhân viên
                //Sửa chiều cao của Rows
                danh_sach_PH.RowTemplate.Height = 35;
                //Tắt kéo Rows , Colums
                danh_sach_PH.AllowUserToResizeRows = false;
                danh_sach_PH.AllowUserToResizeColumns = false;
                //Sửa chiều cao của Collums
                danh_sach_PH.ColumnHeadersHeight = 30;
                //Sửa Font_size của Collums
                danh_sach_PH.ColumnHeadersDefaultCellStyle.Font = new Font("iCiel Andes Rounded", 11F, FontStyle.Regular);

                //Thêm data vào danh sách
                int i = 0;
                int convert = 0;
                foreach (DataRow dr in kiemtra.Rows)
                {
                    Int32.TryParse(kiemtra.Rows[i][2].ToString(), out convert);
                    danh_sach_PH.Rows.Add(kiemtra.Rows[i][0].ToString(), kiemtra.Rows[i][1].ToString(),
                        convert
                        , kiemtra.Rows[i][3].ToString());
                    i++;
                }
            }
            catch
            {
                return;
            }

           


        }

        private void danh_sach_PH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ẩn nút thêm tài khoản
            btn_add.Hide();
            //Đề phòng trường hợp click vào Rows Name
            if (e.RowIndex == -1) return;
            /// Lấy Giá trị rows đang chọn
            DataGridViewRow select_row = danh_sach_PH.Rows[e.RowIndex];
            /// Tạo read-only ID phòng hát
            id_textBox.ReadOnly = true;
            ///Ghi lại ID phòng được chọn kiểm tra chống lỗi khi tạo phòng hát mới và để xóa, sửa phòng hát
            Room_ID = Int32.Parse(select_row.Cells[0].Value.ToString());

            //Ghi lại tên phòng hát được chọn
            ten_phong_select = select_row.Cells[1].Value.ToString();
            ///Hiển thị thông tin tài khoản được chọn lên thông tin chi tiết tài khoản
            id_textBox.Text = select_row.Cells[0].Value.ToString();
            ph_name_textbox.Text = select_row.Cells[1].Value.ToString();
            ph_Price_textbox.Text = select_row.Cells[2].Value.ToString();

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            /// Hiển thị nút thêm tài khoản
            btn_add.Show();
            /// Tạo mới một chi tiết tài khoản
            id_textBox.Text = "# - Tạo phòng mới";
            ph_name_textbox.Text = "";
            ph_Price_textbox.Text = "";
            // Trả acc id = 0 để tạo phòng mới
            Room_ID = 0;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            //Kiểm tra điền thông tin
            if (id_textBox.Text == "" || ph_name_textbox.Text == "" || ph_Price_textbox.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm phòng hát mới nhé");
                return;
            }
            //Kiểm tra tên phòng có bị trùng trên CSDL không
            if (check_ten_ph(ph_name_textbox.Text) == true)
            {
                MessageBox.Show("Tên phòng hát này đã tồn tại, vui lòng chọn tên phòng hát khác");
                return;
            }

            // Kiểm tra giá tiền nhập vào có phải là chữ cái không
            int x = 0;
            bool isNumeric = int.TryParse(ph_Price_textbox.Text.ToString(), out x);

            if (isNumeric == false)
            {
                MessageBox.Show("Vui lòng nhập số tiền là Số, không phải chữ cái!", "Opps, có lỗi");
                return;
            }
            // Tạo phòng mới
            DAL dAL = new DAL();
            string query = @"INSERT INTO dbo.Phong_hat
(Ten_phong_hat,Gia_tien,Tinh_trang)
VALUES (N'"+ ph_name_textbox.Text + "','"+ ph_Price_textbox.Text + "',0)";
            dAL.Update_Sql(query);
            MessageBox.Show("Thêm phòng hát mới thành công");
            //Tải lại bảng danh sách nhân viên
            danh_sach_PH.Rows.Clear();
            danh_sach_phong_hat();

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //Tạo kết nối tới lớp DAL
            DAL dAL = new DAL();

            /// Lấy Giá trị rows đang chọn

            //Kiểm tra đã chọn row nào chưa
            if (Room_ID == 0) return;
            // Hỏi trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng hát " +
                ten_phong_select + " Ra khỏi hệ thống không", "Xóa phòng hát ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"DELETE from dbo.Phong_hat where dbo.Phong_hat.ID_phong_hat = " + Room_ID;
                dAL.Update_Sql(query);
                MessageBox.Show("Xóa phòng hát thành công");
                //Tải lại bảng danh sách nhân viên
                danh_sach_PH.Rows.Clear();
                danh_sach_phong_hat();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá tiền nhập vào có phải là chữ cái không
            int x = 0;
            bool isNumeric = int.TryParse(ph_Price_textbox.Text.ToString(), out x);

            if (isNumeric == false)
            {
                MessageBox.Show("Vui lòng nhập số tiền là Số, không phải chữ cái!", "Opps, có lỗi");
                return;
            }

            //Tạo kết nối tới lớp DAL
            DAL dAL = new DAL();
            //Kiểm tra đã chọn row nào chưa
            if (Room_ID == 0) return;
            // Hỏi trước khi cập nhật
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin cho phòng hát " +
                ten_phong_select + " trên hệ thống không", "Sửa tài khoản ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string up_query = @"UPDATE dbo.Phong_hat 
SET Ten_phong_hat = N'"+ph_name_textbox.Text.ToString()+
"' , Gia_tien = '"+ ph_Price_textbox.Text.ToString() + "'WHERE ID_phong_hat = " + Room_ID;

                dAL.Update_Sql(up_query);
                MessageBox.Show("Đã cập nhật thông tin về phòng hát");
                //Tải lại bảng danh sách nhân viên
                danh_sach_PH.Rows.Clear();
                danh_sach_phong_hat();

            }
            else
            {
                return;
            }
        }
    }
}
