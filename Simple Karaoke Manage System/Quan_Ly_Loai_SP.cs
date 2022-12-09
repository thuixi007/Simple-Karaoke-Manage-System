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
    public partial class Quan_Ly_Loai_SP : UserControl
    {
        public int LoaiSP_ID = 0;
        public string ten_loai_select;
        public Quan_Ly_Loai_SP()
        {
            InitializeComponent();
            danh_sach_loai_SP();

            //Ẩn nút thêm phân loại
            btn_add.Hide();
        }
        private bool check_ten_Loai_SP(string checkname)
        {
            string query = @"select dbo.Loai_SP.Ten_loai_sp
from dbo.Loai_SP
where dbo.Loai_SP.Ten_loai_sp = N'"+ checkname + "'";
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
        private void danh_sach_loai_SP()
        {
            try
            {
                string query = @"select * from dbo.Loai_SP";
                DAL dAL = new DAL();
                DataTable kiemtra = dAL.Run_Sql(query);

                // Tải dữ liệu lên bảng danh sách nv
                //danh_sach_NV.Rows.Add(1, "QQQ", "XXX", "CCC");

                //// Sửa bảng danh sách nhân viên
                //Sửa chiều cao của Rows
                danh_sach_Phan_loai.RowTemplate.Height = 35;
                //Tắt kéo Rows , Colums
                danh_sach_Phan_loai.AllowUserToResizeRows = false;
                danh_sach_Phan_loai.AllowUserToResizeColumns = false;
                //Sửa chiều cao của Collums
                danh_sach_Phan_loai.ColumnHeadersHeight = 30;
                //Sửa Font_size của Collums
                danh_sach_Phan_loai.ColumnHeadersDefaultCellStyle.Font = new Font("iCiel Andes Rounded", 11F, FontStyle.Regular);

                //Thêm data vào danh sách
                int i = 0;

                foreach (DataRow dr in kiemtra.Rows)
                {
                    danh_sach_Phan_loai.Rows.Add(kiemtra.Rows[i][0], kiemtra.Rows[i][1]);
                    i++;
                }
            }catch
            {
                return;
            }

        }

        private void danh_sach_Phan_loai_ContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ẩn nút thêm tài khoản
            btn_add.Hide();
            //Đề phòng trường hợp click vào Rows Name
            if (e.RowIndex == -1) return;
            /// Lấy Giá trị rows đang chọn
            DataGridViewRow select_row = danh_sach_Phan_loai.Rows[e.RowIndex];
            /// Tạo read-only ID phòng hát
            id_textBox.ReadOnly = true;
            ///Ghi lại ID phòng được chọn kiểm tra chống lỗi khi tạo phân loại mới và để xóa, sửa phân loại
            LoaiSP_ID = Int32.Parse(select_row.Cells[0].Value.ToString());

            //Ghi lại tên phòng hát được chọn
            ten_loai_select = select_row.Cells[1].Value.ToString();
            ///Hiển thị thông tin tài khoản được chọn lên thông tin chi tiết tài khoản
            id_textBox.Text = select_row.Cells[0].Value.ToString();
            pl_name_textbox.Text = select_row.Cells[1].Value.ToString();

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            /// Hiển thị nút thêm tài khoản
            btn_add.Show();
            /// Tạo mới một chi tiết tài khoản
            id_textBox.Text = "# - Tạo phân loại sản phẩm mới";
            pl_name_textbox.Text = "";
            // Trả LoaiSP_ID = 0 để tạo loại sp mới
            LoaiSP_ID = 0;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            ///Kiểm tra điền đầy đủ thông tin
            if (id_textBox.Text == "" || pl_name_textbox.Text == "" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm phòng hát mới nhé");
                return;
            }
            ///Kiểm tra tên phân loại có bị trùng trên CSDL hay không
            if (check_ten_Loai_SP(pl_name_textbox.Text) == true)
            {
                MessageBox.Show("Tên phân loại này đã tồn lại, vui lòng chọn một tên khác");
                return;
            }

            // Tạo tài khoản
            DAL dAL = new DAL();
            string query = @"INSERT INTO dbo.Loai_SP (Ten_loai_sp) VALUES (N'"+ pl_name_textbox.Text.ToString() +"')";
            dAL.Update_Sql(query);
            MessageBox.Show("Thêm phân loại thành công");
            //Tải lại bảng danh sách loại sản phẩm
            danh_sach_Phan_loai.Rows.Clear();
            danh_sach_loai_SP();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //Tạo kết nối tới lớp DAL
            DAL dAL = new DAL();

            /// Lấy Giá trị rows đang chọn

            //Kiểm tra đã chọn row nào chưa
            if (LoaiSP_ID == 0) return;
            // Hỏi trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa loại " +
                ten_loai_select + " Ra khỏi hệ thống không", "Xóa phân loại ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"DELETE from dbo.Loai_SP where dbo.Loai_SP.ID_loai_sp = " + LoaiSP_ID;
                dAL.Update_Sql(query);
                MessageBox.Show("Xóa phân loại thành công");
                //Tải lại bảng danh sách loại sản phẩm
                danh_sach_Phan_loai.Rows.Clear();
                danh_sach_loai_SP();
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
            if (LoaiSP_ID == 0) return;
            // Hỏi trước khi cập nhật
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin cho phân loại " +
                ten_loai_select + " trên hệ thống không", "Sửa phân loại ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string up_query = @"UPDATE dbo.Loai_SP SET Ten_loai_sp = N'"+ pl_name_textbox + "'" +
                    "WHERE dbo.Loai_SP.ID_loai_sp = " + LoaiSP_ID ;

                dAL.Update_Sql(up_query);
                MessageBox.Show("Đã cập nhật thông tin phân loại");
                //Tải lại bảng danh sách nhân viên
                danh_sach_Phan_loai.Rows.Clear();
                danh_sach_loai_SP();

            }
            else
            {
                return;
            }
        }
    }
}
