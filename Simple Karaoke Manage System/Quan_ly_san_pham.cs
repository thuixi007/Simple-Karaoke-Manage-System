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
    public partial class Quan_ly_san_pham : UserControl
    {
        public int SP_ID = 0;
        public string ten_san_pham_select;

        public Quan_ly_san_pham()
        {
            InitializeComponent();
            danh_sach_san_pham();
            btn_add.Hide();
        }

        public void refesh_table()
        {
            danh_sach_SP.Rows.Clear();
            danh_sach_san_pham();
        }

        private bool check_tenSP(string checkname)
        {
            string query = @"select dbo.San_pham.Ten_san_pham
from dbo.San_pham
where dbo.San_pham.Ten_san_pham = N' "+ checkname + "' ";
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

        private void danh_sach_san_pham()
        {   try
            {
                string query = @"SELECT dbo.San_pham.ID_san_pham,dbo.San_pham.Ten_san_pham,
dbo.San_pham.So_luong,dbo.San_pham.Gia_tien,dbo.Loai_SP.Ten_loai_sp
FROM dbo.San_pham
INNER JOIN dbo.Loai_SP
ON dbo.San_pham.ID_loai_sp = dbo.Loai_SP.ID_loai_sp";
                DAL dAL = new DAL();
                DataTable kiemtra = dAL.Run_Sql(query);

                //// Sửa bảng danh sách sản phẩm
                //Sửa chiều cao của Rows
                danh_sach_SP.RowTemplate.Height = 35;
                //Tắt kéo Rows , columns
                danh_sach_SP.AllowUserToResizeRows = false;
                danh_sach_SP.AllowUserToResizeColumns = false;
                //Sửa chiều cao của Collums
                danh_sach_SP.ColumnHeadersHeight = 30;
                //Sửa Font_size của Collums
                danh_sach_SP.ColumnHeadersDefaultCellStyle.Font = new Font("iCiel Andes Rounded", 11F, FontStyle.Regular);

                //Thêm data vào danh sách sản phẩm
                int i = 0;
                int convert = 0;
                foreach (DataRow dr in kiemtra.Rows)
                {
                    Int32.TryParse(kiemtra.Rows[i][3].ToString(), out convert);
                    danh_sach_SP.Rows.Add(kiemtra.Rows[i][0].ToString(), kiemtra.Rows[i][1].ToString(),
                        kiemtra.Rows[i][2].ToString(), convert, kiemtra.Rows[i][4].ToString());
                    i++;
                }
                //Lấy loại sản phẩm từ cơ sở dữ liệu và thêm vào combobox
                string query1 = @"select * from dbo.Loai_SP";
                DataTable kiemtra1 = dAL.Run_Sql(query1);
                // Tạo combo source để lưu các giá trị key - value của csdl
                Dictionary<string, string> comboSource = new Dictionary<string, string>();

                int x = 0;
                foreach (DataRow dr in kiemtra1.Rows)
                {
                    comboSource.Add(kiemtra1.Rows[x][0].ToString(), kiemtra1.Rows[x][1].ToString());
                    x++;
                }

                cbb_loaiSP.DataSource = new BindingSource(comboSource, null);
                cbb_loaiSP.DisplayMember = "Value";
                cbb_loaiSP.ValueMember = "Key";
            }
            catch
            {
                cbb_loaiSP.DataSource = null;
                return;
            }
            


        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            
                ///MessageBox.Show( ((KeyValuePair<string, string>)cbb_loaiSP.SelectedItem).Key +" " + ((KeyValuePair<string, string>)cbb_loaiSP.SelectedItem).Value );
                /// Hiển thị nút thêm tài khoản
                btn_add.Show();
                /// Tạo mới một chi tiết tài khoản
                id_textBox.Text = "# - Thêm sản phẩm mới";
                TenSP_name_textbox.Text = "";
                Gia_tien_textboxt.Text = "";
                so_luong_Textbox.Text = "";

                //cbb_loaiSP.SelectedIndex = 0;
                // Trả acc id = 0 để tạo sp mới
                SP_ID = 0;
            

            
        }

        private void danh_sach_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Ẩn nút thêm sản phẩm
            btn_add.Hide();
            //Đề phòng trường hợp click vào Rows Name
            if (e.RowIndex == -1) return;
            /// Lấy Giá trị rows đang chọn
            DataGridViewRow select_row = danh_sach_SP.Rows[e.RowIndex];
            /// Tạo read-only ID phòng hát
            id_textBox.ReadOnly = true;
            ///Ghi lại ID phòng được chọn kiểm tra chống lỗi khi tạo phòng hát mới và để xóa, sửa phòng hát
            SP_ID = Int32.Parse(select_row.Cells[0].Value.ToString());

            //Ghi lại tên sản phẩm được chọn
            ten_san_pham_select = select_row.Cells[1].Value.ToString();
            ///Hiển thị thông tin sản phẩm được chọn lên thông tin chi tiết sản phẩm
            id_textBox.Text = select_row.Cells[0].Value.ToString();
            TenSP_name_textbox.Text = select_row.Cells[1].Value.ToString();
            Gia_tien_textboxt.Text = select_row.Cells[3].Value.ToString();
            /// Hiển thị phân loại của sản phẩm
            cbb_loaiSP.SelectedIndex = cbb_loaiSP.FindStringExact(select_row.Cells[4].Value.ToString());
            // Hiển thị số lượng
            so_luong_Textbox.Text = select_row.Cells[2].Value.ToString();

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá tiền nhập vào có phải là chữ cái không
            int x = 0;
            bool isNumeric = int.TryParse(Gia_tien_textboxt.Text.ToString(), out x);

            if (isNumeric == false)
            {
                MessageBox.Show("Vui lòng nhập số tiền là Số, không phải chữ cái!", "Opps, có lỗi");
                return;
            }

            int x1 = 0;
            bool isNumeric1 = int.TryParse(so_luong_Textbox.Text.ToString(), out x1);

            if (isNumeric1 == false)
            {
                MessageBox.Show("Vui lòng nhập số lượng là Số, không phải chữ cái!", "Opps, có lỗi");
                return;
            }

            //Tạo kết nối tới lớp DAL
            DAL dAL = new DAL();
            //Kiểm tra đã chọn row nào chưa
            if (SP_ID == 0) return;
            // Hỏi trước khi cập nhật
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin cho sản phẩm " +
                ten_san_pham_select + " trên hệ thống không", "Sửa tài khoản ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string up_query = @"UPDATE dbo.San_pham
SET Ten_san_pham = N'"+ TenSP_name_textbox.Text + "', ID_loai_sp = '"+
((KeyValuePair<string, string>)cbb_loaiSP.SelectedItem).Key + "' , Gia_tien = '"+ Gia_tien_textboxt.Text +
"' , So_luong = '" + so_luong_Textbox.Text +
"' WHERE ID_san_pham = " + SP_ID;

                dAL.Update_Sql(up_query);
                MessageBox.Show("Đã cập nhật thông tin về sản phẩm");
                //Tải lại bảng danh sách nhân viên
                danh_sach_SP.Rows.Clear();
                danh_sach_san_pham();

            }
            else
            {
                return;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            //Kiểm tra điền thông tin

            if (this.cbb_loaiSP.GetItemText(this.cbb_loaiSP.SelectedItem) == "")
            {
                MessageBox.Show("Vui lòng tạo một phân loại trước khi thêm loại sản phẩm mới nhé");
                return;
            }
            if (TenSP_name_textbox.Text == "" || Gia_tien_textboxt.Text == "" || so_luong_Textbox.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm sản phẩm mới nhé");
                return;
            }
            //Kiểm tra tên sản phẩm có bị trùng trên CSDL không
            if (check_tenSP(TenSP_name_textbox.Text) == true)
            {
                MessageBox.Show("Tên sản phẩm này đã tồn tại, vui lòng chọn tên sản phẩm khác");
                return;
            }

            //Kiểm tra xem số lượng và giá tiền nhập vào có phải là định dạng chữ số không

            // Kiểm tra giá tiền nhập vào có phải là chữ cái không
            int x = 0;
            bool isNumeric = int.TryParse(Gia_tien_textboxt.Text.ToString(), out x);

            if (isNumeric == false)
            {
                MessageBox.Show("Vui lòng nhập số tiền là Số, không phải chữ cái!", "Opps, có lỗi");
                return;
            }

            int x1 = 0;
            bool isNumeric1 = int.TryParse(so_luong_Textbox.Text.ToString(), out x1);

            if (isNumeric1 == false)
            {
                MessageBox.Show("Vui lòng nhập số lượng là Số, không phải chữ cái!", "Opps, có lỗi");
                return;
            }


            // Thêm sản phẩm vào cơ sở dữ liệu
            DAL dAL = new DAL();
            string query = @"INSERT INTO dbo.San_pham
VALUES ( N'"+ TenSP_name_textbox.Text + "', "+ ((KeyValuePair<string, string>)cbb_loaiSP.SelectedItem).Key 
+ ", "+ Gia_tien_textboxt.Text + ", "+ so_luong_Textbox.Text + " );";
            dAL.Update_Sql(query);
            MessageBox.Show("Thêm sản phẩm thành công");
            //Tải lại bảng danh sách sản phẩm
            danh_sach_SP.Rows.Clear();
            danh_sach_san_pham();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //Tạo kết nối tới lớp DAL
            DAL dAL = new DAL();

            /// Lấy Giá trị rows đang chọn

            //Kiểm tra đã chọn row nào chưa
            if (SP_ID == 0) return;
            // Hỏi trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm " +
                ten_san_pham_select + " Ra khỏi hệ thống không", "Xóa phân loại ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"DELETE from dbo.San_pham where dbo.San_pham.ID_san_pham = " + SP_ID;
                dAL.Update_Sql(query);
                MessageBox.Show("Xóa sản phẩm thành công");
                //Tải lại bảng danh sách sản phẩm
                danh_sach_SP.Rows.Clear();
                danh_sach_san_pham();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

   
    }
}
