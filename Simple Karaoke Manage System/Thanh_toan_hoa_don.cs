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
   
    public partial class Thanh_toan_hoa_don : Form
    {


        string TenNV;

        string tong_tien;
        public Thanh_toan_hoa_don(object dataSource , string ten_nhan_vien , string money )
        {
            InitializeComponent();

            TenNV = ten_nhan_vien;
            tong_tien = money;

            guna2DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            guna2DataGridView1.DataSource = dataSource;
            guna2DataGridView1.Columns[0].HeaderText = "Tên SP";
            guna2DataGridView1.Columns[1].HeaderText = "SL";
            guna2DataGridView1.Columns[2].HeaderText = "Đơn giá";
            guna2DataGridView1.Columns[3].HeaderText = "Thành tiền";
            guna2DataGridView1.Columns[4].Visible = false;
            guna2DataGridView1.ColumnHeadersHeight = 40;

            guna2DataGridView1.Columns[1].Width = 50;
        }

        private void Thanh_toan_hoa_don_Load(object sender, EventArgs e)
        {


        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_in_hoa_don_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprm", 285, 600);
            printPreviewDialog1.ShowDialog();




        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Graphics graphics = e.Graphics;

            Font font10 = new Font("Arial", 10);
            Font font12 = new Font("Arial", 12);
            Font font14 = new Font("Arial", 14);

            float leading = 4;
            float lineheight10 = font10.GetHeight() + leading;
            float lineheight12 = font12.GetHeight() + leading;
            float lineheight14 = font14.GetHeight() + leading;

            float startX = 0;
            float startY = leading;
            float Offset = 0;

            StringFormat formatLeft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatCenter = new StringFormat(formatLeft);
            StringFormat formatRight = new StringFormat(formatLeft);

            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;

            SizeF layoutSize = new SizeF(285 - Offset * 2, lineheight14);
            RectangleF layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            Brush brush = Brushes.Black;

            graphics.DrawString("Karaoke Bé Chiaa", font14, brush, layout, formatCenter);

            Offset = Offset + lineheight10;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("420 Trần Duy Hưng - Tp. Đà Nẵng" , font10, brush, layout, formatCenter);

           

            Offset = Offset + lineheight12;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Hóa đơn bán hàng", font12, brush, layout, formatCenter);



            /// In hoa don
            /// 
            Offset = Offset + lineheight10;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);

            Bitmap bm = new Bitmap(this.guna2DataGridView1.Width, this.guna2DataGridView1.Height);
            guna2DataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.guna2DataGridView1.Width, this.guna2DataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, startY + Offset);

            /// Tạo tổng hóa đơn
            Offset = 1 + bm.Height;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Tổng số tiền sử dụng : " + tong_tien, font10, brush, layout, formatLeft);

            /// Tạo tên người lập
            Offset = Offset + lineheight12;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Người lập hóa đơn : " + TenNV, font10, brush, layout, formatLeft);

            /// Tạo ngày lập
            Offset = Offset + lineheight12;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Ngày lập : " + DateTime.Now.ToString("dd/mm/yyyy"), font10, brush, layout, formatLeft);

            /// cảm ơn
            Offset = Offset + lineheight12 + 10;
            layout = new RectangleF(new PointF(startX, startY + Offset), layoutSize);
            graphics.DrawString("Xin cảm ơn và hẹn gặp lại quý khách", font10, brush, layout, formatCenter);

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
