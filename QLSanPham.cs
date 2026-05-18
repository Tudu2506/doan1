using System;
using System.Data;
using System.Windows.Forms;
using QuanLyTuduCoffe.BLL;
using QuanLyTuduCoffe.DTO;

namespace QuanLyTuduCoffe
{
    public partial class QLSanPham : UserControl
    {
        SanPham_BLL bll = new SanPham_BLL();

        public QLSanPham()
        {
            InitializeComponent();

            // Móc nối các sự kiện
            this.Load += QLSANPHAM_Load;
            this.dgvSanPham.CellClick += dgvSanPham_CellClick;
            this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void QLSANPHAM_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCombobox();
        }

        private void LoadData()
        {
            // Đổ dữ liệu từ BLL lên bảng
            dgvSanPham.DataSource = bll.GetList();

            // TRANG TRÍ LẠI BẢNG (DATAGRIDVIEW) CHO CHUYÊN NGHIỆP
            if (dgvSanPham.Columns.Count > 0)
            {
                // 1. Đổi tên tiêu đề cột cho đẹp
                dgvSanPham.Columns["maSP"].HeaderText = "Mã SP";
                dgvSanPham.Columns["tenSP"].HeaderText = "Tên Sản Phẩm";
                dgvSanPham.Columns["tenloaiSP"].HeaderText = "Loại Sản Phẩm";
                dgvSanPham.Columns["giatien"].HeaderText = "Giá Tiền";

                // 2. Ẩn cột mã loại (vì đã có cột tên loại hiển thị rồi)
                dgvSanPham.Columns["maloaiSP"].Visible = false;

                // 3. Căn chỉnh kích thước cột
                dgvSanPham.Columns["maSP"].Width = 80;
                dgvSanPham.Columns["tenloaiSP"].Width = 140;
                dgvSanPham.Columns["giatien"].Width = 120;
                // Riêng cột Tên Sản Phẩm cho nó tự động giãn nở lấp đầy chỗ trống còn lại
                dgvSanPham.Columns["tenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // 4. Định dạng cột Giá tiền có dấu phẩy phân cách (Ví dụ: 35,000)
                dgvSanPham.Columns["giatien"].DefaultCellStyle.Format = "N0";
                dgvSanPham.Columns["giatien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // 5. Cấu hình hành vi thao tác của bảng
                dgvSanPham.ReadOnly = true; // Chống user nhấp đúp vào để gõ bậy bạ lên bảng
                dgvSanPham.AllowUserToAddRows = false; // Tắt cái dòng trống có dấu * dưới cùng
                dgvSanPham.RowHeadersVisible = false; // Tắt cái cột chứa mũi tên đen bên tay trái
                dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Click 1 ô là tự bôi xanh cả dòng
                dgvSanPham.MultiSelect = false; // Chỉ cho phép chọn 1 dòng mỗi lần
                dgvSanPham.BackgroundColor = System.Drawing.Color.White; // Đổi nền xám xỉn thành màu trắng
            }
        }

        private void LoadCombobox()
        {
            cboLoaiSP.DataSource = bll.GetLoaiSP();
            cboLoaiSP.DisplayMember = "tenloaiSP"; // Hiển thị tên (Cà phê năng lượng, Trà...)
            cboLoaiSP.ValueMember = "maloaiSP";    // Giấu mã ở dưới (LSP01, LSP02...)
        }

        // Đẩy dữ liệu từ Lưới lên các ô nhập liệu khi click
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["maSP"].Value.ToString();
                txtTenSP.Text = row.Cells["tenSP"].Value.ToString();
                txtGiaTien.Text = row.Cells["giatien"].Value.ToString();

                // Chọn lại đúng Loại SP trong combobox
                cboLoaiSP.SelectedValue = row.Cells["maloaiSP"].Value.ToString();

                // Khóa mã SP lại không cho sửa khi đang click chọn
                txtMaSP.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem gõ giá tiền có phải là số không
            if (!decimal.TryParse(txtGiaTien.Text, out decimal giaTien))
            {
                MessageBox.Show("Giá tiền phải là con số hợp lệ!");
                return;
            }

            SanPham_DTO sp = new SanPham_DTO(txtMaSP.Text, txtTenSP.Text, cboLoaiSP.SelectedValue.ToString(), giaTien);

            MessageBox.Show(bll.Save(sp, false)); // false = Thêm mới
            LoadData(); // Load lại lưới
            btnLamMoi_Click(null, null); // Xóa trắng form
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtGiaTien.Text, out decimal giaTien))
            {
                MessageBox.Show("Giá tiền phải là con số hợp lệ!");
                return;
            }

            SanPham_DTO sp = new SanPham_DTO(txtMaSP.Text, txtTenSP.Text, cboLoaiSP.SelectedValue.ToString(), giaTien);

            MessageBox.Show(bll.Save(sp, true)); // true = Update
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm để xóa!");
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {txtTenSP.Text} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show(bll.Remove(txtMaSP.Text));
                LoadData();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = false; // Mở khóa lại để gõ mã mới
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaTien.Clear();
            cboLoaiSP.SelectedIndex = 0;
            txtTimKiem.Clear();
            txtMaSP.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("tenSP LIKE '%{0}%'", txtTimKiem.Text.Trim());
            }
        }

        // Nhấn nút TÌM KIẾM cũng gọi hàm gõ chữ luôn cho tiện
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem_TextChanged(null, null);
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}