using System;
using System.Data;
using System.Windows.Forms;
using QuanLyTuduCoffe.BLL;
using QuanLyTuduCoffe.DTO;

namespace QuanLyTuduCoffe
{
    public partial class QLNguyenLieu : UserControl
    {
        NguyenLieu_BLL bll = new NguyenLieu_BLL();

        public QLNguyenLieu()
        {
            InitializeComponent();

            this.Load += QLNGUYENLIEU_Load;
            this.dgvNguyenLieu.CellClick += dgvNguyenLieu_CellClick;
            this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // Chặn gõ chữ vào ô Đơn giá và Số lượng
            this.txtGiaTien.KeyPress += ChiChoPhepNhapSo_KeyPress;
            this.txtSoLuong.KeyPress += ChiChoPhepNhapSo_KeyPress;
            this.VisibleChanged += QLNGUYENLIEU_VisibleChanged;
        }
        private void QLNGUYENLIEU_VisibleChanged(object sender, EventArgs e)
        {
            // Nếu UserControl này được hiển thị lên (Visible = true)
            if (this.Visible)
            {
                LoadData(); // Gọi lại hàm load dữ liệu từ SQL Server lên bảng
            }
        }

        private void QLNGUYENLIEU_Load(object sender, EventArgs e)
        {
            LoadData();
            txtMaNL.ReadOnly = true;
            btnLamMoi_Click(null, null); // Load xong tự sinh mã mới
        }

        private void ChiChoPhepNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void LoadData()
        {
            dgvNguyenLieu.DataSource = bll.GetList();

            if (dgvNguyenLieu.Columns.Count > 0)
            {
                dgvNguyenLieu.Columns["maNL"].HeaderText = "Mã NL";
                dgvNguyenLieu.Columns["tenNL"].HeaderText = "Tên Nguyên Liệu";
                dgvNguyenLieu.Columns["nhacc"].HeaderText = "Nhà Cung Cấp";
                dgvNguyenLieu.Columns["giatien"].HeaderText = "Đơn Giá";
                dgvNguyenLieu.Columns["soluongTK"].HeaderText = "Số Lượng Tồn";

                dgvNguyenLieu.Columns["giatien"].DefaultCellStyle.Format = "N0";
                dgvNguyenLieu.Columns["giatien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvNguyenLieu.Columns["soluongTK"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvNguyenLieu.Columns["maNL"].Width = 60;
                dgvNguyenLieu.Columns["soluongTK"].Width = 100;
                dgvNguyenLieu.Columns["giatien"].Width = 100;
                dgvNguyenLieu.Columns["tenNL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvNguyenLieu.ReadOnly = true;
                dgvNguyenLieu.AllowUserToAddRows = false;
                dgvNguyenLieu.RowHeadersVisible = false;
                dgvNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNguyenLieu.BackgroundColor = System.Drawing.Color.White;
            }
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguyenLieu.Rows[e.RowIndex];
                txtMaNL.Text = row.Cells["maNL"].Value.ToString();
                txtTenNL.Text = row.Cells["tenNL"].Value.ToString();
                txtNhaCC.Text = row.Cells["nhacc"].Value.ToString();

                decimal giaTien = Convert.ToDecimal(row.Cells["giatien"].Value);
                txtGiaTien.Text = Math.Round(giaTien, 0).ToString();

                txtSoLuong.Text = row.Cells["soluongTK"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtGiaTien.Text, out decimal gia);
            int.TryParse(txtSoLuong.Text, out int sl);

            NguyenLieu_DTO nl = new NguyenLieu_DTO(txtMaNL.Text, txtTenNL.Text, txtNhaCC.Text, gia, sl);
            string kq = bll.Save(nl, false);

            MessageBox.Show(kq, kq.Contains("THÀNH CÔNG") ? "Hoàn tất" : "Cảnh báo", MessageBoxButtons.OK, kq.Contains("THÀNH CÔNG") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.Contains("THÀNH CÔNG")) { LoadData(); btnLamMoi_Click(null, null); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtGiaTien.Text, out decimal gia);
            int.TryParse(txtSoLuong.Text, out int sl);

            NguyenLieu_DTO nl = new NguyenLieu_DTO(txtMaNL.Text, txtTenNL.Text, txtNhaCC.Text, gia, sl);
            string kq = bll.Save(nl, true);

            MessageBox.Show(kq, kq.Contains("THÀNH CÔNG") ? "Hoàn tất" : "Cảnh báo", MessageBoxButtons.OK, kq.Contains("THÀNH CÔNG") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.Contains("THÀNH CÔNG")) LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNL.Text)) return;

            DialogResult dr = MessageBox.Show($"Xóa nguyên liệu '{txtTenNL.Text}' sẽ xóa luôn lịch sử tồn kho của nó. Bạn có chắc chắn không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string kq = bll.Remove(txtMaNL.Text);
                MessageBox.Show(kq, kq.Contains("THÀNH CÔNG") ? "Hoàn tất" : "Cảnh báo", MessageBoxButtons.OK, kq.Contains("THÀNH CÔNG") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                LoadData();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNL.Text = bll.SinhMaTuDong();
            txtTenNL.Clear();
            txtNhaCC.Clear();
            txtGiaTien.Clear();
            txtSoLuong.Text = "0";
            txtTimKiem.Clear();
            txtTenNL.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dgvNguyenLieu.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("tenNL LIKE '%{0}%' OR nhacc LIKE '%{0}%'", txtTimKiem.Text.Trim());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem_TextChanged(null, null);
        }
    }
}