using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyTuduCoffe.DAL
{
    public class DBConnect
    {
        // Chuỗi kết nối lấy từ máy bro: TUDUx256
        protected string strConnect = @"Data Source=TUDUx256;Initial Catalog=QL_TuduCoffee;Integrated Security=True;TrustServerCertificate=True";
        protected SqlConnection _conn;

        public DBConnect()
        {
            _conn = new SqlConnection(strConnect);
        }
    }
}
