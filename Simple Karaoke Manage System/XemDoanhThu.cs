using Simple_Karaoke_Manage_System.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Karaoke_Manage_System
{
    public partial class XemDoanhThu : UserControl
    {
        public XemDoanhThu()
        {
            InitializeComponent();
        }

        private void btn_thong_ke_Click(object sender, EventArgs e)
        {
            DateTime thoigian1 = guna2DateTimePicker1.Value.Date;
            DateTime thoigian2 = guna2DateTimePicker2.Value.Date;
            int result = DateTime.Compare(thoigian1, thoigian2);

            bang_thong_ke.DataSource = null;

            if(result > 0)
            {
                MessageBox.Show("Bạn vui lòng chọn lại thời gian cho phù hợp nhé");
                return;
            }
            DAL dAL = new DAL();

            string query;
            /// Doanh thu theo phòng


            query = @"select dbo.Phong_hat.Ten_phong_hat as ""Tên phòng hát"" , sum(dbo.Hoa_don.Tong_hoa_don) as ""Tổng hóa đơn""
from dbo.Hoa_don
INNER JOIN dbo.Phong_hat
ON dbo.Hoa_don.ID_phong_hat = dbo.Phong_hat.ID_phong_hat
Where dbo.Hoa_don.Tinh_trang_hoa_don = 1 AND dbo.Hoa_don.Ngay_lap_HD BETWEEN ";

            query += @" '" + thoigian1.ToString("yyyy/MM/dd") + "' AND '"+ thoigian2.ToString("yyyy/MM/dd") + "'";

            query += @" GROUP BY Ten_phong_hat";



            DataTable ketqua = dAL.Run_Sql(query);

            /// Hiện kết quả thống kê
            bang_thong_ke.DataSource = ketqua;

            /// đỏi lại style bảng thống kê
            bang_thong_ke.ColumnHeadersHeight = 30;
            bang_thong_ke.Font = new Font("Arial", 13.00F, FontStyle.Regular);
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "#,### đ";



            bang_thong_ke.Columns[1].DefaultCellStyle = style;
        }
    }
}
