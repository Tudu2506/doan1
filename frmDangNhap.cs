using System;
using System.Windows.Forms;
using static QuanLyTuduCoffe.Program;

namespace QuanLyTuduCoffe
{
    public partial class frmDangNhap : Form
    {
        // BƯỚC 1: BỔ SUNG DÒNG NÀY ĐỂ KHAI BÁO LỚP BLL
        TaiKhoan_BLL bll = new TaiKhoan_BLL();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            // Giả sử hàm CheckLogin của bạn trả về đối tượng TaiKhoan_DTO
            TaiKhoan_DTO account = bll.CheckLogin(txtDangNhap.Text, txtMatKhau.Text);

            if (account != null)
            {
                // QUAN TRỌNG: Lưu lại toàn bộ thông tin (bao gồm vaiTro)
                LuuThongTin.User = account;

                MessageBox.Show("Đăng nhập thành công với quyền: " + account.VaiTro);

                this.Hide();
                frmTrangChu main = new frmTrangChu(); // Tên Form trang chủ của bạn
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
        // Mấy cái label1_Click, Form1_Load không dùng thì bro xóa đi cho code gọn nhé
    }
}