using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Simple_Karaoke_Manage_System.Class
{

    internal class DAL
    {
        /// Lưu lại tên đăng nhập


        ///Trả về bảng dữ liệu
        public DataTable Run_Sql(string query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=BEIUKIMNGAN\MSSQLSERVER01;Initial Catalog=Karaoke;Integrated Security=True");
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable ketqua = new DataTable();
                sda.Fill(ketqua);
                conn.Close();
                return ketqua;
            }
            catch
            {
                return null;
            }
        }
        ///Thực hiện câu lệnh không trả về
        public void Update_Sql(string query)
        {
            try {
                SqlConnection conn = new SqlConnection(@"Data Source=BEIUKIMNGAN\MSSQLSERVER01;Initial Catalog=Karaoke;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                return;
            }
            
        }
    }
}
