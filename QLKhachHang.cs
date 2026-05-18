using System;
using System.Data;
using System.Windows.Forms;
using QuanLyTuduCoffe.BLL;
using QuanLyTuduCoffe.DTO;

namespace QuanLyTuduCoffe
{
    public partial class QLKhachHang : UserControl
    {
        KhachHang_BLL bll = new KhachHang_BLL();

        public QLKhachHang()
        {
            InitializeComponent();

            this.Load += QLKHACHHANG_Load;
            this.dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // BẬT CÔNG TẮC CHẶN GÕ CHỮ CHO 2 Ô SĐT VÀ ĐIỂM
            this.txtSDT.KeyPress += ChiChoPhepNhapSo_KeyPress;
            this.txtDiem.KeyPress += ChiChoPhepNhapSo_KeyPress;
        }

        private void QLKHACHHANG_Load(object sender, EventArgs e)
        {
            LoadData();
            txtMaKH.ReadOnly = true; // Khóa vĩnh viễn ô Mã KH không cho người dùng gõ
            btnLamMoi_Click(null, null); // Vừa mở form lên là tự động sinh mã KH00x luôn
        }

        // HÀM CHẶN GÕ CHỮ TỪ BÀN PHÍM
        private void ChiChoPhepNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép gõ số (0-9) và phím xóa (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn lại, không cho chữ hiển thị lên ô TextBox
            }
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = bll.GetList();

            if (dgvKhachHang.Columns.Count > 0)
            {
                dgvKhachHang.Columns["maKH"].HeaderText = "Mã KH";
                dgvKhachHang.Columns["tenKH"].HeaderText = "Tên Khách Hàng";
                dgvKhachHang.Columns["sodienthoai"].HeaderText = "Số Điện Thoại";
                dgvKhachHang.Columns["diemTichLuy"].HeaderText = "Điểm Tích Lũy";

                dgvKhachHang.Columns["maKH"].Width = 80;
                dgvKhachHang.Columns["sodienthoai"].Width = 120;
                dgvKhachHang.Columns["diemTichLuy"].Width = 100;
                dgvKhachHang.Columns["tenKH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvKhachHang.ReadOnly = true;
                dgvKhachHang.AllowUserToAddRows = false;
                dgvKhachHang.RowHeadersVisible = false;
                dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvKhachHang.BackgroundColor = System.Drawing.Color.White;
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["maKH"].Value.ToString();
                txtTenKH.Text = row.Cells["tenKH"].Value.ToString();
                txtSDT.Text = row.Cells["sodienthoai"].Value.ToString();
                txtDiem.Text = row.Cells["diemTichLuy"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int diem = 0;
            int.TryParse(txtDiem.Text, out diem);

            KhachHang_DTO kh = new KhachHang_DTO(txtMaKH.Text, txtTenKH.Text, txtSDT.Text, diem);

            string ketQua = bll.Save(kh, false); // false = Thêm mới

            // Hiện bảng thông báo thân thiện
            if (ketQua.StartsWith("THÀNH CÔNG"))
            {
                MessageBox.Show(ketQua, "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnLamMoi_Click(null, null); // Thêm xong tự động nhảy sang mã kế tiếp
            }
            else
            {
                MessageBox.Show(ketQua, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int diem = 0;
            int.TryParse(txtDiem.Text, out diem);

            KhachHang_DTO kh = new KhachHang_DTO(txtMaKH.Text, txtTenKH.Text, txtSDT.Text, diem);

            string ketQua = bll.Save(kh, true); // true = Update

            if (ketQua.StartsWith("THÀNH CÔNG"))
            {
                MessageBox.Show(ketQua, "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show(ketQua, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = bll.SinhMaTuDong(); // Gọi BLL tự lấy mã mới tinh gán vào
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiem.Text = "0";
            txtTimKiem.Clear();
            txtTenKH.Focus(); // Đưa con trỏ chuột thẳng vào ô Tên để gõ luôn cho lẹ
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("sodienthoai LIKE '%{0}%' OR tenKH LIKE '%{0}%'", txtTimKiem.Text.Trim());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem_TextChanged(null, null);
        }
    }
}