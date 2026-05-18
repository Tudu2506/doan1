using System;
using System.Data;
using System.Windows.Forms;
using QuanLyTuduCoffe.BLL;
using QuanLyTuduCoffe.DTO;

namespace QuanLyTuduCoffe
{
    public partial class QLKhuyenMai : UserControl
    {
        KhuyenMai_BLL bll = new KhuyenMai_BLL();

        public QLKhuyenMai()
        {
            InitializeComponent();

            this.Load += QLKHUYENMAI_Load;
            this.dgvKhuyenMai.CellClick += dgvKhuyenMai_CellClick;
            this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            this.txtGiamGia.KeyPress += txtGiamGia_KeyPress; // Chặn gõ chữ vào Mức giảm
        }

        private void QLKHUYENMAI_Load(object sender, EventArgs e)
        {
            LoadData();
            cboTrangThai.SelectedIndex = 0; // Mặc định chọn dòng đầu tiên (Đang hoạt động)
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true; // Chặn các ký tự không phải số
        }

        private void LoadData()
        {
            dgvKhuyenMai.DataSource = bll.GetList();

            if (dgvKhuyenMai.Columns.Count > 0)
            {
                dgvKhuyenMai.Columns["maKM"].HeaderText = "Mã KM";
                dgvKhuyenMai.Columns["tenKM"].HeaderText = "Tên Chương Trình";
                dgvKhuyenMai.Columns["mucGiam"].HeaderText = "Mức Giảm (VNĐ)";
                dgvKhuyenMai.Columns["ngayBD"].HeaderText = "Từ Ngày";
                dgvKhuyenMai.Columns["ngayKT"].HeaderText = "Đến Ngày";
                dgvKhuyenMai.Columns["trangThai"].HeaderText = "Trạng Thái Hoạt Động";

                // Định dạng tiền tệ
                dgvKhuyenMai.Columns["mucGiam"].DefaultCellStyle.Format = "N0";
                // Định dạng ngày tháng
                dgvKhuyenMai.Columns["ngayBD"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvKhuyenMai.Columns["ngayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvKhuyenMai.Columns["maKM"].Width = 80;
                dgvKhuyenMai.Columns["mucGiam"].Width = 100;
                dgvKhuyenMai.Columns["tenKM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvKhuyenMai.ReadOnly = true;
                dgvKhuyenMai.AllowUserToAddRows = false;
                dgvKhuyenMai.RowHeadersVisible = false;
                dgvKhuyenMai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvKhuyenMai.BackgroundColor = System.Drawing.Color.White;
            }
        }

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhuyenMai.Rows[e.RowIndex];
                txtMaKM.Text = row.Cells["maKM"].Value.ToString();
                txtTenKM.Text = row.Cells["tenKM"].Value.ToString();

                // Cắt đuôi .0000 của kiểu Decimal SQL
                decimal mucGiam = Convert.ToDecimal(row.Cells["mucGiam"].Value);
                txtGiamGia.Text = Math.Round(mucGiam, 0).ToString();

                dtpNgayBD.Value = Convert.ToDateTime(row.Cells["ngayBD"].Value);
                dtpNgayKT.Value = Convert.ToDateTime(row.Cells["ngayKT"].Value);

                // Xử lý Checkbox/TrangThai: 1 (True) -> Index 0, 0 (False) -> Index 1
                bool dangHoatDong = Convert.ToBoolean(row.Cells["trangThai"].Value);
                cboTrangThai.SelectedIndex = dangHoatDong ? 0 : 1;

                txtMaKM.ReadOnly = true; // Khóa mã không cho sửa
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            decimal giam = 0;
            decimal.TryParse(txtGiamGia.Text, out giam);
            bool tt = (cboTrangThai.SelectedIndex == 0); // 0 là Đang hoạt động -> True

            KhuyenMai_DTO km = new KhuyenMai_DTO(txtMaKM.Text, txtTenKM.Text, giam, dtpNgayBD.Value.Date, dtpNgayKT.Value.Date, tt);
            string ketQua = bll.Save(km, false);

            MessageBox.Show(ketQua, ketQua.Contains("THÀNH CÔNG") ? "Thành công" : "Cảnh báo", MessageBoxButtons.OK, ketQua.Contains("THÀNH CÔNG") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (ketQua.Contains("THÀNH CÔNG")) { LoadData(); btnLamMoi_Click(null, null); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            decimal giam = 0;
            decimal.TryParse(txtGiamGia.Text, out giam);
            bool tt = (cboTrangThai.SelectedIndex == 0);

            KhuyenMai_DTO km = new KhuyenMai_DTO(txtMaKM.Text, txtTenKM.Text, giam, dtpNgayBD.Value.Date, dtpNgayKT.Value.Date, tt);
            string ketQua = bll.Save(km, true);

            MessageBox.Show(ketQua, ketQua.Contains("THÀNH CÔNG") ? "Thành công" : "Cảnh báo", MessageBoxButtons.OK, ketQua.Contains("THÀNH CÔNG") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (ketQua.Contains("THÀNH CÔNG")) LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Bạn muốn Dừng/Xóa mã khuyến mãi '{txtMaKM.Text}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string ketQua = bll.RemoveOrStop(txtMaKM.Text);
                MessageBox.Show(ketQua, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKM.ReadOnly = false;
            txtMaKM.Clear();
            txtTenKM.Clear();
            txtGiamGia.Clear();
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now.AddDays(7);
            cboTrangThai.SelectedIndex = 0;
            txtTimKiem.Clear();
            txtMaKM.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dgvKhuyenMai.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("maKM LIKE '%{0}%' OR tenKM LIKE '%{0}%'", txtTimKiem.Text.Trim());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem_TextChanged(null, null);
        }
    }
}