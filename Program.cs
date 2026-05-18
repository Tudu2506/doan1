using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTuduCoffe
{
    internal static class Program
    {
        public static class LuuThongTin
        {
            // Lưu lại đối tượng người dùng vừa đăng nhập thành công
            public static TaiKhoan_DTO User;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
        }
    }
}
