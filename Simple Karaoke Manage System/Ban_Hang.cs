using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simple_Karaoke_Manage_System.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Simple_Karaoke_Manage_System
{
    public partial class Ban_Hang : UserControl
    {
        public int loai_SP_ID = 0;

        public int room_ID = 0;

        public string phong_select;



        public string ID_Hoa_don;

        int tongtien = 0;

        int tinh_tat_ca = 0;

        public string ten_NV;

        public Ban_Hang()
        {
            InitializeComponent();
            get_phan_loai();
            load_phong_hat();

            // Ẩn bảng oder , nút bấm giờ hát
            guna2Panel2.Hide();
            btn_bam_gio_Hat.Hide();
        }

        public void set_ten_nv( string x)
        {
            this.ten_NV = x;
        }

        public void refest_get_phan_loai()
        {
            get_phan_loai();
        }


        void btn_click_set(object sender, EventArgs e)
        {
            Button btn = sender as Button;


            DAL dAL = new DAL();

            /// lấy về tình trạng phòng hát được chọn
            string query1 = @"select dbo.Phong_hat.Tinh_trang, dbo.Phong_hat.Ten_phong_hat
from dbo.Phong_hat
where dbo.Phong_hat.ID_phong_hat = '" + btn.Name.ToString() + "'";
            DataTable get_status = dAL.Run_Sql(query1);

         
            int x;
            Int32.TryParse(btn.Name.ToString(), out x);
            room_ID = x;

            // Ghi lại tên phòng lên biến toàn cục để sử dụng nút bấm giờ hát
            phong_select = get_status.Rows[0][1].ToString();

            /// Thiết lập chi tiết nút bấm 
            /// 
            if (get_status.Rows[0][0].ToString() == "True")
            {
                guna2Panel2.Show();
                btn_bam_gio_Hat.Hide();
                // Load thông tin về hóa đơn phòng chọn lên bảng oder
                load_hoa_don();
                // thay chữ oder
                label1.Text = "Oder : " + phong_select;

                /// Load lại danh sách chuyển phòng
                get_cbb_Chuyenphong();
            }
            else
            {
                guna2Panel2.Hide();
                btn_bam_gio_Hat.Show();
            }



        }


        private void load_hoa_don()
        {

            DAL dAL = new DAL();
            /// -> Lấy danh sản phẩm trong hóa đơn từ cơ sở dữ liệu
            /// Lấy id hóa đơn của phòng 
           
            string query = @"select dbo.Hoa_don.ID_hoa_don
from dbo.Hoa_don
where dbo.Hoa_don.Tinh_trang_hoa_don = 0 AND dbo.Hoa_don.ID_phong_hat = " + room_ID.ToString() ;
            DataTable get_id_hoa_don = dAL.Run_Sql(query);

            // đặt giá trị vào biến toàn cục ID hóa đơn
            ID_Hoa_don = get_id_hoa_don.Rows[0][0].ToString();

            //Clear bảng hóa đơn cũ
            hoa_don_ban_hang.Rows.Clear();
            // load chi tiết hóa đơn
            load_chi_tiet_hoa_don();

            //mở nút tính tiền giờ
            btn_tinh_tien_gio.Text = "Tính tiền giờ";
            btn_tinh_tien_gio.Enabled = true;

        }

        public void load_chi_tiet_hoa_don()
        {
            /// Thiết lập thuộc tính cho bảng chi tiết hóa đơn
            /// 
             //Sửa chiều cao của Rows
            hoa_don_ban_hang.RowTemplate.Height = 35;
            //Tắt kéo Rows , columns
            hoa_don_ban_hang.AllowUserToResizeRows = false;
            hoa_don_ban_hang.AllowUserToResizeColumns = false;
            //Sửa chiều cao của Collums
            hoa_don_ban_hang.ColumnHeadersHeight = 33;
            //Sửa Font_size của Collums
            hoa_don_ban_hang.ColumnHeadersDefaultCellStyle.Font = new Font("iCiel Andes Rounded", 9F, FontStyle.Regular);

            hoa_don_ban_hang.DefaultCellStyle.Font = new Font("Arial", 14.5F, GraphicsUnit.Pixel);

            DAL dAL = new DAL();
            //Load chi tiết hóa đơn
            string query = @"select dbo.San_pham.Ten_san_pham , dbo.Chi_tiet_hoa_don.So_luong ,dbo.San_pham.Gia_tien
from dbo.San_pham
INNER JOIN dbo.Chi_tiet_hoa_don
on dbo.San_pham.ID_san_pham = dbo.Chi_tiet_hoa_don.ID_san_pham
where dbo.Chi_tiet_hoa_don.ID_hoa_don = "
            + ID_Hoa_don;

            DataTable kiemtra = dAL.Run_Sql(query);
            // tải lên bảng hóa đơn bán hàng

            int x = 0;
            foreach (DataRow dr in kiemtra.Rows)
            {
                hoa_don_ban_hang.Rows.Add(kiemtra.Rows[x][0].ToString(),
                    Convert.ToInt32(kiemtra.Rows[x][1]), Convert.ToInt32(kiemtra.Rows[x][2]),
                    Convert.ToInt32(kiemtra.Rows[x][1]) * Convert.ToInt32(kiemtra.Rows[x][2])

                    );
                x++;
            }

           



            int sum = 0;

            /// Set lại tổng tiền
            tongtien = 0;
            foreach (DataRow dr in kiemtra.Rows)
            {
                tongtien += Convert.ToInt32(hoa_don_ban_hang.Rows[sum].Cells[3].Value);
                sum++;
            }

            textbox_tinh_tien.Text = tongtien.ToString("#,### VNĐ");



            
        }
        public void load_phong_hat()
        {
            DAL dAL = new DAL();
            string query1 = @"select * from dbo.Phong_hat";
            DataTable get_phong_hat = dAL.Run_Sql(query1);


            int x = 0;
            foreach (DataRow dr in get_phong_hat.Rows)
            {
                // Tạo Button tương ứng
                Button btn = new Button();
                btn.Width = 100;
                btn.Height = 100;

                // Tạo tên nút bấm = ID phòng hát để sử dụng đặt hàng
                btn.Name = get_phong_hat.Rows[x][0].ToString();
                // Lấy trạng thái của phòng hát
                string get_status = get_phong_hat.Rows[x][3].ToString();
                // thiết lập string trạng thái
                string set_status;

                if (get_status == "True")
                {
                    set_status = "Đang hát";
                }
                else
                {
                    set_status = "Phòng trống";
                }
                //Lấy các giá trị của phòng hát thêm vào nút
                btn.Text = get_phong_hat.Rows[x][1].ToString()
                   + Environment.NewLine + Environment.NewLine + set_status; // Thêm vào tên phòng + trạng thái phòng

                // Chuyển đổi màu săc nút bấm và trạng thái phòng
                switch( get_status )
                {
                    case "True":
                        btn.BackColor = Color.LightPink;
                        break;
                    default:
                        btn.BackColor = Color.Aqua;
                        break;
                }


                // Add nút vô danh sách phòng hát
                DS_phonghat_panel.Controls.Add(btn);

                // Tạo sự kiện click cho button
                btn.Click += new EventHandler(this.btn_click_set);

                x++;
            }

        }
        private void get_phan_loai()
        {
            try {
                DAL dAL = new DAL();

                //Lấy loại sản phẩm từ cơ sở dữ liệu và thêm vào combobox
                string query1 = @"select * from dbo.Loai_SP";
                DataTable kiemtra1 = dAL.Run_Sql(query1);
                // Tạo combo source để lưu các giá trị key - value của csdl
                Dictionary<string, string> comboSource = new Dictionary<string, string>();

                ///Thêm mục tất cả vào comboSource
                comboSource.Add("0", "Tất cả sản phẩm");
                int x = 0;
                foreach (DataRow dr in kiemtra1.Rows)
                {
                    comboSource.Add(kiemtra1.Rows[x][0].ToString(), kiemtra1.Rows[x][1].ToString());
                    x++;
                }

                cbb_pl_san_pham.DataSource = new BindingSource(comboSource, null);
                cbb_pl_san_pham.DisplayMember = "Value";
                cbb_pl_san_pham.ValueMember = "Key";
            }
            catch
            {
                cbb_pl_san_pham.DataSource = null;
                return;
            }
            
        }

        ///Thay đổi chọn loại sản phẩm để hiển thị ra sản phẩm phù hợp
        private void cbb_pl_san_pham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAL dAL = new DAL();

                /// Lấy giá trị value của combobox đang chọn và ép kiểu sang kiểu INT
                string key_convert = ((KeyValuePair<string, string>)cbb_pl_san_pham.SelectedItem).Key;
                Int32.TryParse(key_convert, out loai_SP_ID);


                /// Truy vấn thông tin về loại sản phẩm theo phân loại trên cơ sở dữ liệu
                /// Nếu chọn tất cả
                string query1;

                if (loai_SP_ID == 0)
                {

                    //Lấy loại sản phẩm từ cơ sở dữ liệu và thêm vào combobox
                     query1 = @"select * from dbo.San_pham";

                }
                else
                {
                     query1 = @"select * from dbo.San_pham Where ID_loai_sp = " + loai_SP_ID;
                }

                // Lấy sản phẩm theo phân loại
                DataTable kiemtra1 = dAL.Run_Sql(query1);
                // Tạo combo source để lưu các giá trị key - value của csdl
                Dictionary<string, string> comboSource = new Dictionary<string, string>();

                int x = 0;
                foreach (DataRow dr in kiemtra1.Rows)
                {
                    comboSource.Add(kiemtra1.Rows[x][0].ToString(), kiemtra1.Rows[x][1].ToString());
                    x++;
                }

                cbb_san_pham.DataSource = new BindingSource(comboSource, null);
                cbb_san_pham.DisplayMember = "Value";
                cbb_san_pham.ValueMember = "Key";

                // Chống lỗi nếu như chưa có sản phẩm nmaof
                if (kiemtra1.Rows.Count <1)
                {
                    cbb_san_pham.DataSource = null;
                    return;
                }

            }
            catch
            {
                cbb_san_pham.DataSource = null;
                return;
            }
            

            }

        public void refesh_phong_hat()
        {
            DS_phonghat_panel.Controls.Clear();
            load_phong_hat();
        }

        private void btn_refesh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã làm mới trạng thái phòng hát theo hệ thống");
            refesh_phong_hat();
        }

        private void btn_bam_gio_Hat_Click(object sender, EventArgs e)
        {
            // Hỏi trước khi bấm giờ hát
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn bấm giờ hát cho phòng " + phong_select + " Không", "Xác nhận bấm giờ hát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }


            // chuyển đổi trạng thái hoạt động của phòng sang TRUE ( đang hát )
            DAL dAL = new DAL();
            string query = @"UPDATE dbo.Phong_hat 
SET Tinh_trang = 1
WHERE ID_phong_hat = " + room_ID.ToString() ;
            dAL.Update_Sql(query);


            // -> // Tạo hóa đơn gắn với phòng hát đó

            // Lấy thời gian hiện tại của hệ thống và thêm vào hóa đơn
            string cur_time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
  
            string cur_day = DateTime.Now.ToString("dd/MM/yyyy");

            // Tạo hóa đơn có thời gian bấm giờ hát
            ///query = @"INSERT INTO dbo.Hoa_don
            ///VALUES ( 0 , '" +cur_time+ "' , " + room_ID +" , 0 , 0 , " + cur_day + ")";
            ///

            query = @"INSERT INTO dbo.Hoa_don
VALUES (0, '"+ cur_time + "' , "+ room_ID + ", 0, 0 , '"+ cur_day + "')";
            dAL.Update_Sql(query);


            // tải lại danh sách phòng hát
            refesh_phong_hat();

            
        }

        private void btn_add_sp_Click(object sender, EventArgs e)
        {
            /// Lấy số lượng sản phẩm cần thêm
            int soluong_add = int.Parse(So_Luong.Value.ToString());
            DAL dAL = new DAL();
            /// Mở lại nút tính tiền giờ

            btn_tinh_tien_gio.Text = "Tính tiền giờ";
            btn_tinh_tien_gio.Enabled = true;


          


            /// Thêm sản phẩm vào hóa đơn
            /// lấy key của sản phẩm  - key là id sản phẩm

            /// Chống lỗi khi chưa thêm sản phẩm
            if( cbb_san_pham.Text.ToString() == "")
            {
                MessageBox.Show("Không có gì ở đây cả! hãy thêm một sản phẩm gì đó vào phân loại này nhé","opps");
                return;
            }
            string key_san_pham = ((KeyValuePair<string, string>)cbb_san_pham.SelectedItem).Key;
            string name_sp = ((KeyValuePair<string, string>)cbb_san_pham.SelectedItem).Value;
            // kiểm tra sản phẩm đã tồn tại trong cơ sở dữ liệu chi tiết hóa đơn của phòng chưa,

            /// Kiểm tra còn đủ số lượng của sản phẩm trong kho
            string check_sp_kho = @"select dbo.San_pham.So_luong
from dbo.San_pham
where dbo.San_pham.ID_san_pham = " + key_san_pham;
            DataTable check_kho = dAL.Run_Sql(check_sp_kho);

            if ( int.Parse(check_kho.Rows[0][0].ToString() ) < soluong_add)
            {
                MessageBox.Show("Sân phẩm :" + name_sp + " | trong kho chỉ còn : " + check_kho.Rows[0][0].ToString() 
                    +Environment.NewLine + "Vui lòng chọn một sản phẩm khác hoặc chỉnh lại số lượng"
                    );
                return;
            }



            // nếu có đủ trong kho rồi thì sẽ thêm số lương của sản phẩm vào hóa đơn

            string query = @"select ID_san_pham , So_luong
from dbo.Chi_tiet_hoa_don where ID_hoa_don = "+ID_Hoa_don+" and ID_san_pham = " + key_san_pham;
            DataTable kiemtra1 = dAL.Run_Sql(query);

            if (kiemtra1.Rows.Count < 1) // Điều kiện chưa có sản phẩm này trong chi tiết hóa đơn
            {
                // thêm id sản phẩm vào chi tiết hóa đơn
                query = @"INSERT INTO dbo.Chi_tiet_hoa_don
VALUES (" +ID_Hoa_don+", "+ key_san_pham + ", "+ So_Luong.Value.ToString() +");";

            }
            else // điều kiện sản phẩm đã có trong chi tiết hóa đơn thì kiểm tra để tăng số lượng hoặc cảnh báo nếu sản phẩm bị giảm dưới 1
            {

                int soluongsp_CSDL = int.Parse(kiemtra1.Rows[0][1].ToString() ) ;
                
                int sum = soluongsp_CSDL + soluong_add;
                
                if ( sum < 1)
                {
                    MessageBox.Show("Số lượng sản phẩm thêm hoặc bớt không thể nhỏ hơn 1", "OppS, có lỗi xảy ra");
                    return;
                }

                query = @"update dbo.Chi_tiet_hoa_don
set So_luong = So_luong + "+ So_Luong.Value.ToString()  +
"where ID_hoa_don = " + ID_Hoa_don + " AND ID_san_pham = " + key_san_pham;
            }

            /// Chạy câu lênh truy vấn
            dAL.Update_Sql(query);

            // load lại bảng hóa đơn :3
            //Clear bảng hóa đơn cũ
            hoa_don_ban_hang.Rows.Clear();
            // load chi tiết hóa đơn
            load_chi_tiet_hoa_don();

            /// cập nhật số lượng trong kho
            /// 
            int soluong_update = (-1) * soluong_add;
            query = @"UPDATE dbo.San_pham
set So_luong = So_luong + " + soluong_update.ToString() + " where ID_san_pham = " + key_san_pham;
            /// Chạy câu lênh truy vấn
            dAL.Update_Sql(query);

        }

        private void btn_tinh_tien_gio_Click(object sender, EventArgs e)
        {
            /// Tiền giờ nằm trong hóa đơn
            string cur_time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            DAL dAL = new DAL();
            string query = @"select dbo.Hoa_don.Thoi_gian_hat, dbo.Phong_hat.Gia_tien
from dbo.Hoa_don
INNER JOIN dbo.Phong_hat
ON dbo.Hoa_don.ID_phong_hat = dbo.Phong_hat.ID_phong_hat
where dbo.Hoa_don.ID_hoa_don = " + ID_Hoa_don;
            
            DataTable kiemtra = dAL.Run_Sql(query);

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn phòng " + phong_select + " Đã kết thúc việc đặt dịch vụ và hát để yêu cầu tính tiền?"
                + Environment.NewLine + "Bắt đầu hát : " + kiemtra.Rows[0][0].ToString() +
                "  -  Thời gian kết thúc hát : " + cur_time

                ,
                "Tính tiền giờ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Lấy thời gian bắt đầu hát
                DateTime time_bat_dat_hat = DateTime.Parse( kiemtra.Rows[0][0].ToString() );
                // lấy thời gian kết thúc hát
                DateTime time_ket_thuc = DateTime.Parse(cur_time);
                string minutes = ( (int)(time_ket_thuc.Subtract(time_bat_dat_hat).TotalMinutes) ).ToString();

                /// Tính số tiền trong 1 phút sử dụng phòng

                double tien_phut = (Double.Parse(kiemtra.Rows[0][1].ToString() ) / 60 ) ;
                double tien_gio= tien_phut * (Double.Parse(minutes));

                int Tong_tien_gio = (int)tien_gio;

                /// Add tIền giờ vào hóa đơn
                hoa_don_ban_hang.Rows.Add( phong_select + " hát " +
                    time_bat_dat_hat.ToString() + " -> " + time_ket_thuc.ToString()
                , 1 , Tong_tien_gio , Tong_tien_gio
                    );

                tinh_tat_ca = 0;
                tinh_tat_ca = tongtien + Tong_tien_gio;

                textbox_tinh_tien.Text = tinh_tat_ca.ToString("#,### VNĐ");

                btn_tinh_tien_gio.Text = "Đã tính";
                btn_tinh_tien_gio.Enabled = false;

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void hoa_don_ban_hang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
            if (hoa_don_ban_hang.Columns[e.ColumnIndex].HeaderText == "Thao tác")
            {
                /// Mở lại nút tính tiền giờ

                btn_tinh_tien_gio.Text = "Tính tiền giờ";
                btn_tinh_tien_gio.Enabled = true;

                DAL dAL = new DAL();


                DialogResult dialogResult = MessageBox.Show("Bạn có muốn thu hồi toàn bộ sản phẩm : "
                    
                    + hoa_don_ban_hang.Rows[e.RowIndex].Cells[0].FormattedValue.ToString() 
                    +Environment.NewLine
                    + "tại : " + phong_select

                    , "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    string string1 = @"DELETE FROM dbo.Chi_tiet_hoa_don WHERE dbo.Chi_tiet_hoa_don.ID_hoa_don = ";
                    string string2 = @" AND ID_san_pham IN(select dbo.San_pham.ID_san_pham from dbo.San_pham Where dbo.San_pham.Ten_san_pham = N'"; 
                    string string3 = hoa_don_ban_hang.Rows[e.RowIndex].Cells[0].FormattedValue.ToString() + "')";
                    
                        string query = string1 + ID_Hoa_don + string2 + string3;
                        dAL.Update_Sql(query);


                    string get_sl = hoa_don_ban_hang.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string name_SP = hoa_don_ban_hang.Rows[e.RowIndex].Cells[0].Value.ToString();
                    query = @"UPDATE dbo.San_pham
set So_luong = So_luong + " + get_sl.ToString() + " where Ten_san_pham = N'" + name_SP +"'";
                    /// Chạy câu lênh truy vấn
                    dAL.Update_Sql(query);


                    //Clear bảng hóa đơn cũ
                    hoa_don_ban_hang.Rows.Clear();
                    // load chi tiết hóa đơn
                    load_chi_tiet_hoa_don();

                }
                else if (dialogResult == DialogResult.No)
                {
                    //Clear bảng hóa đơn cũ
                    hoa_don_ban_hang.Rows.Clear();
                    // load chi tiết hóa đơn
                    load_chi_tiet_hoa_don();
                    return ;
                }
            }
        }

        private void btn_thanh_toan_Click(object sender, EventArgs e)
        {
            /// Kiểm tra xem đã bấm tính tiền giờ chưa
            if (btn_tinh_tien_gio.Enabled == true)
            {
                MessageBox.Show("Bạn vui lòng tính tiền giờ cho phòng này trước nhé");
                return;
            }

            /// Xác nhận thanh toán
            DialogResult dialogResult = MessageBox.Show("Xác nhận thanh toán và in hóa đơn cho phòng : " + phong_select, "Xác nhận thanh toán !", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                return ;
            }

            

            /// Trả phòng hát về trạng thái trống
            DAL dAL = new DAL();
            string query = @"UPDATE dbo.Phong_hat
set Tinh_trang = 0
where ID_phong_hat = "+room_ID;
            dAL.Update_Sql(query);

            /// Xác nhận thanh toán trong hóa đơn, tổng hóa đơn
            query = @"UPDATE dbo.Hoa_don
set Tinh_trang_hoa_don = 1 , Tong_hoa_don = " + tinh_tat_ca.ToString() + " where ID_hoa_don = " + ID_Hoa_don;
            dAL.Update_Sql(query);

            /// Thay đổi nhân viên thanh toán trong hóa đơn
            /// 
            string lenh1 = @"UPDATE dbo.Hoa_don";
            lenh1 += @" set ID_nguoi_dat = (";
            lenh1 += @" select dbo.Tai_khoan.ID_Tai_khoan from dbo.Tai_khoan where dbo.Tai_khoan.ten_nhan_vien = N'" + ten_NV;
            lenh1 += @"' )";
            lenh1 += @" where ID_hoa_don ="  + ID_Hoa_don;

            dAL.Update_Sql(lenh1);

            Thanh_toan_hoa_don form = new Thanh_toan_hoa_don( GetDataTableFromDGV(hoa_don_ban_hang) , ten_NV , textbox_tinh_tien.Text );
            form.Show();

            /// Trả lại trạng thái bám giờ hát
            refesh_phong_hat();
            guna2Panel2.Hide();
            btn_bam_gio_Hat.Show();


        }

        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }

        private void btn_chuyen_phong_Click(object sender, EventArgs e)
        {
            DAL dAL = new DAL();

            /// lấy key - name của phòng - key là id sản phẩm
            if (cbb_Chuyen_phong.Text.ToString() == "")
            {
                MessageBox.Show("Hết phòng trống để chuyển mất rồi! ", "opps");
                return;
            }
            string key_phong = ((KeyValuePair<string, string>)cbb_Chuyen_phong.SelectedItem).Key;
            string name_phong = ((KeyValuePair<string, string>)cbb_Chuyen_phong.SelectedItem).Value;

            DialogResult dialogResult = MessageBox.Show("Xác nhận chuyển từ phòng " + phong_select
                + " Sang phòng : " + name_phong
                , "Xác nhận chuyển phòng", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Trả về trạng thái không hoạt động cho phòng hát

                string query = @"UPDATE dbo.Phong_hat 
SET Tinh_trang = 0
WHERE ID_phong_hat = " + room_ID.ToString();
                dAL.Update_Sql(query);

                /// Tạo trạng thái hoạt động cho phòng mới

                query = @"UPDATE dbo.Phong_hat 
SET Tinh_trang = 1
WHERE ID_phong_hat = " + key_phong.ToString();
                dAL.Update_Sql(query);

                /// Update số phòng trong hóa đơn

                query = @"UPDATE dbo.Hoa_don
SET ID_phong_hat = " + key_phong  + "WHERE ID_hoa_don = " + ID_Hoa_don;

                dAL.Update_Sql(query);

                /// Refest lại chọn phòng hát
                /// /// Trả lại trạng thái bám giờ hát
                refesh_phong_hat();
                guna2Panel2.Hide();
                btn_bam_gio_Hat.Show();


            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            ///
        }

        private void get_cbb_Chuyenphong()
        {
            cbb_Chuyen_phong.DataSource = null;

            try
            {
                DAL dAL = new DAL();

                //Lấy loại sản phẩm từ cơ sở dữ liệu và thêm vào combobox
                string query1 = @"select * from dbo.Phong_hat where Tinh_trang = 0";
                DataTable kiemtra1 = dAL.Run_Sql(query1);
                // Tạo combo source để lưu các giá trị key - value của csdl
                Dictionary<string, string> comboSource = new Dictionary<string, string>();

                int x = 0;
                foreach (DataRow dr in kiemtra1.Rows)
                {
                    comboSource.Add(kiemtra1.Rows[x][0].ToString(), kiemtra1.Rows[x][1].ToString());
                    x++;
                }

                cbb_Chuyen_phong.DataSource = new BindingSource(comboSource, null);
                cbb_Chuyen_phong.DisplayMember = "Value";
                cbb_Chuyen_phong.ValueMember = "Key";
            }
            catch
            {
                cbb_Chuyen_phong.DataSource = null;
                return;
            }

        }
        

    }
    }

