using System;
using System.Windows.Forms;
using QuanLyTuduCoffe.BLL;
using QuanLyTuduCoffe.DTO;

namespace QuanLyTuduCoffe
{
    public partial class QLTaiKhoan : UserControl
    {
        TaiKhoan_BLL bll = new TaiKhoan_BLL();

        public QLTaiKhoan()
        {
            InitializeComponent();
            this.Load += QLTAIKHOAN_Load;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            //btnThem.Click += btnThem_Click;
            //btnSua.Click += btnSua_Click;
            //btnXoa.Click += btnXoa_Click;
            //btnLamMoi.Click += btnLamMoi_Click;
        }

        private void QLTAIKHOAN_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu chức vụ cho ComboBox
            cbVaiTro.Items.Clear();
            cbVaiTro.Items.Add("Admin");
            cbVaiTro.Items.Add("NhanVien");
            cbVaiTro.SelectedIndex = 0; // Chọn mặc định là Admin

            LoadData();
        }

        private void LoadData()
        {
            dgvTaiKhoan.DataSource = bll.GetTaiKhoan();

            // Trang trí bảng cho đẹp
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            dgvTaiKhoan.RowHeadersVisible = false;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.ReadOnly = true;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtTaiKhoan.Text = row.Cells["Tên Đăng Nhập"].Value.ToString();
                txtMatKhau.Text = row.Cells["Mật Khẩu"].Value.ToString();
                txtHoTen.Text = row.Cells["Tên Người Sử Dụng"].Value.ToString();
                cbVaiTro.Text = row.Cells["Chức Vụ"].Value.ToString();

                txtTaiKhoan.Enabled = false; // Không cho sửa tên đăng nhập khi click vào bảng
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            cbVaiTro.SelectedIndex = 0;
            txtTaiKhoan.Enabled = true; // Mở lại ô tên đăng nhập để thêm mới
            txtTaiKhoan.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Tên đăng nhập và Mật khẩu!", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiKhoan_DTO tk = new TaiKhoan_DTO
            {
                TenDangNhap = txtTaiKhoan.Text, // Đổi TaiKhoan thành TenDangNhap
                MatKhau = txtMatKhau.Text,
                HoTen = txtHoTen.Text,
                VaiTro = cbVaiTro.Text
            };

            if (bll.ThemTaiKhoan(tk))
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnLamMoi_Click(null, null);
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Tên đăng nhập có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoan_DTO tk = new TaiKhoan_DTO
            {
                TenDangNhap = txtTaiKhoan.Text, // Đổi TaiKhoan thành TenDangNhap
                MatKhau = txtMatKhau.Text,
                HoTen = txtHoTen.Text,
                VaiTro = cbVaiTro.Text
            };

            if (bll.SuaTaiKhoan(tk))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản Admin gốc của hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản " + txtTaiKhoan.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bll.XoaTaiKhoan(txtTaiKhoan.Text))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Tài khoản này có thể đang liên kết với phiếu nhập hoặc hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}