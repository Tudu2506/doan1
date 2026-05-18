using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyTuduCoffe.Program;

namespace QuanLyTuduCoffe
{
    public partial class frmTrangChu : Form
    {
        // Tạo một biến để hứng dữ liệu tài khoản
        private TaiKhoan_DTO taiKhoanDangNhap;

        // SỬA LẠI CONSTRUCTOR NÀY: Thêm tham số TaiKhoan_DTO vào
        public frmTrangChu(TaiKhoan_DTO account)
        {
            InitializeComponent();
            this.taiKhoanDangNhap = account; // Hứng dữ liệu lưu vào biến
        }

        public frmTrangChu()
        {
            InitializeComponent(); // Dòng này bắt buộc phải có và không được viết sai chính tả!
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem User có thực sự được lưu lại không
            if (LuuThongTin.User == null) return;
            lblUser.Text = "Xin chào: " + LuuThongTin.User.HoTen;

            // 2. Chuyển tất cả về chữ thường và xóa khoảng trắng để so sánh chính xác
            string vaitro = LuuThongTin.User.VaiTro.Trim().ToLower();

            if (vaitro == "nhanvien")
            {
                // Ẩn các nút Admin
                btnSanPham.Visible = false;
                btnNguyenLieu.Visible = false;
                btnNhapKho.Visible = false;
                btnKhuyenMai.Visible = false;
                btnThongKe.Visible = false;
                btnTaiKhoan.Visible = false;

                // Chỉ để lại Bán hàng và Khách hàng
                btnBanHang.Visible = true;
                btnKhachHang.Visible = true;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

        }

        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            QLNguyenLieu ucNguyenLieu = new QLNguyenLieu();

            ucNguyenLieu.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucNguyenLieu);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            // 1. Dọn dẹp sạch sẽ cái panel chính trước khi nhét cái mới vào
            pnlMain.Controls.Clear();

            // 2. Gọi cái UserControl Bán hàng của sếp ra
            QLBANHANG ucBanHang = new QLBANHANG();

            // 3. ĐÂY LÀ DÒNG QUAN TRỌNG NHẤT: Ra lệnh cho nó giãn nở lấp đầy Panel
            ucBanHang.Dock = DockStyle.Fill;

            // 4. Nhét nó vào panel chính
            pnlMain.Controls.Add(ucBanHang);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            QLKhachHang ucKhachHang = new QLKhachHang();

            ucKhachHang.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucKhachHang);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            QLSanPham ucSanPham = new QLSanPham();

            ucSanPham.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucSanPham);
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            QLNhapKho ucNhapKho = new QLNhapKho();

            ucNhapKho.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucNhapKho);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            QLKhuyenMai ucKhuyenMai = new QLKhuyenMai();

            ucKhuyenMai.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucKhuyenMai);
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ThongKe ucThongKe = new ThongKe();

            ucThongKe.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucThongKe);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            QLTaiKhoan ucTaiKhoan = new QLTaiKhoan();

            ucTaiKhoan.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucTaiKhoan);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            Trang_Chủ ucTrangChu = new Trang_Chủ();

            ucTrangChu.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucTrangChu);
        }

        private void picHomeIcon_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            Trang_Chủ ucTrangChu = new Trang_Chủ();

            ucTrangChu.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(ucTrangChu);
        }
    }
}
