using System;
using System.Data;
using System.Windows.Forms;
using QuanLyTuduCoffe.BLL;
using QuanLyTuduCoffe.DTO;

namespace QuanLyTuduCoffe
{
    public partial class QLNhapKho : UserControl
    {
        NhapKho_BLL bll = new NhapKho_BLL();
        DataTable dtPhieuNhap = new DataTable(); // Giỏ hàng ảo chứa NL cần nhập
        string maPhieuHienTai = "";
        string maNLDangChon = "";
        string tenNLDangChon = "";

        public QLNhapKho()
        {
            InitializeComponent();
            this.Load += QLNHAPKHO_Load;

            // Móc sự kiện click vào bảng bên trái
            this.dgvNguyenLieu.CellClick += dgvNguyenLieu_CellClick;

            // Chặn gõ chữ vào ô số lượng & giá
            this.txtSoLuong.KeyPress += ChiChoPhepNhapSo_KeyPress;
            this.txtGiaNhap.KeyPress += ChiChoPhepNhapSo_KeyPress;

            // BẬT CÔNG TẮC CHO CÁC NÚT BẤM 
            this.btnLapPhieuMoi.Click += btnLapPhieuMoi_Click;
            this.btnThemVaoPhieu.Click += btnThemVaoPhieu_Click;

            // Nút Hủy phiếu 
            this.btnHuyPhieu.Click += btnHuyPhieu_Click;

            //  nút LƯU PHIẾU
            this.btnLuuPhieu.Click += btnLuuPhieu_Click;
        }

        private void QLNHAPKHO_Load(object sender, EventArgs e)
        {
            // 1. Load kho nguyên liệu lên bảng bên trái (dgvNguyenLieu)
            dgvNguyenLieu.DataSource = bll.LoadNguyenLieu();
            if (dgvNguyenLieu.Columns.Count > 0)
            {
                dgvNguyenLieu.Columns["maNL"].HeaderText = "Mã";
                dgvNguyenLieu.Columns["tenNL"].HeaderText = "Nguyên Liệu";
                dgvNguyenLieu.Columns["nhacc"].Visible = false; // Ẩn bớt cho gọn
                dgvNguyenLieu.Columns["giatien"].HeaderText = "Giá Đề Xuất";

                dgvNguyenLieu.Columns["giatien"].DefaultCellStyle.Format = "N0";
                dgvNguyenLieu.Columns["tenNL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNguyenLieu.ReadOnly = true;
                dgvNguyenLieu.AllowUserToAddRows = false;
                dgvNguyenLieu.RowHeadersVisible = false;
            }

            // 2. Khởi tạo cấu trúc bảng Chi tiết phiếu bên phải (dgvChiTietPhieu)
            dtPhieuNhap.Columns.Add("Mã NL");
            dtPhieuNhap.Columns.Add("Tên NL");
            dtPhieuNhap.Columns.Add("SL", typeof(int));
            dtPhieuNhap.Columns.Add("Giá Nhập", typeof(decimal));
            dtPhieuNhap.Columns.Add("Thành Tiền", typeof(decimal));

            // Đổ cấu trúc này vào DataGridView sếp đã đặt tên
            dgvChiTietPhieu.DataSource = dtPhieuNhap;
            dgvChiTietPhieu.AllowUserToAddRows = false;

            if (dgvChiTietPhieu.Columns.Count > 0)
            {
                // Căn chỉnh kích thước cột cố định
                dgvChiTietPhieu.Columns["Mã NL"].Width = 60;
                dgvChiTietPhieu.Columns["SL"].Width = 50;
                dgvChiTietPhieu.Columns["Giá Nhập"].Width = 90;
                dgvChiTietPhieu.Columns["Thành Tiền"].Width = 100;

                // ÉP CỘT "Tên NL" GIÃN NỞ TRÀN KHUNG (Ăn tiền là dòng này)
                dgvChiTietPhieu.Columns["Tên NL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Định dạng phẩy hàng nghìn cho đẹp mắt
                dgvChiTietPhieu.Columns["Giá Nhập"].DefaultCellStyle.Format = "N0";
                dgvChiTietPhieu.Columns["Giá Nhập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTietPhieu.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
                dgvChiTietPhieu.Columns["Thành Tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTietPhieu.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Tắt mũi tên đen bên trái, đổi nền trắng
                dgvChiTietPhieu.RowHeadersVisible = false;
                dgvChiTietPhieu.BackgroundColor = System.Drawing.Color.White;
                dgvChiTietPhieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvChiTietPhieu.ReadOnly = true; // Chỉ cho xem, không cho nhấp đúp gõ bậy
            }

        }

        private void ChiChoPhepNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        // BƯỚC 1: BẤM LẬP PHIẾU MỚI (Nút màu xanh lơ)
        private void btnLapPhieuMoi_Click(object sender, EventArgs e)
        {
            maPhieuHienTai = bll.SinhMaPhieu();
            lblMaPN.Text = "PHIẾU NHẬP: #" + maPhieuHienTai; // Cập nhật tên label
            dtPhieuNhap.Rows.Clear();
            TinhTongTien();
            MessageBox.Show("Đã khởi tạo phiếu nhập mới. Hãy chọn nguyên liệu bên trái để nhập kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // BƯỚC 2: CLICK CHỌN MÓN BÊN TRÁI -> HIỆN LÊN Ô NHẬP LIỆU
        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguyenLieu.Rows[e.RowIndex];
                maNLDangChon = row.Cells["maNL"].Value.ToString();
                tenNLDangChon = row.Cells["tenNL"].Value.ToString();

                // Lấy giá mặc định gợi ý lên ô nhập
                decimal giaGoiY = Convert.ToDecimal(row.Cells["giatien"].Value);
                txtGiaNhap.Text = Math.Round(giaGoiY, 0).ToString();
                txtSoLuong.Text = "1";
                txtSoLuong.Focus();
            }
        }

        // BƯỚC 3: BẤM NÚT "THÊM VÀO PHIẾU" (Màu xanh lá)
        private void btnThemVaoPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhieuHienTai))
            {
                MessageBox.Show("Vui lòng bấm LẬP PHIẾU NHẬP MỚI trước!");
                return;
            }
            if (string.IsNullOrEmpty(maNLDangChon))
            {
                MessageBox.Show("Vui lòng chọn 1 loại nguyên liệu ở bảng bên trái!");
                return;
            }

            int.TryParse(txtSoLuong.Text, out int sl);
            decimal.TryParse(txtGiaNhap.Text, out decimal gia);

            if (sl <= 0 || gia <= 0)
            {
                MessageBox.Show("Số lượng và Giá nhập phải lớn hơn 0!");
                return;
            }

            // Kiểm tra xem đã thêm chưa, có rồi thì cộng dồn số lượng
            bool daCo = false;
            foreach (DataRow row in dtPhieuNhap.Rows)
            {
                if (row["Mã NL"].ToString() == maNLDangChon && Convert.ToDecimal(row["Giá Nhập"]) == gia)
                {
                    row["SL"] = Convert.ToInt32(row["SL"]) + sl;
                    row["Thành Tiền"] = Convert.ToInt32(row["SL"]) * gia;
                    daCo = true; break;
                }
            }

            if (!daCo)
                dtPhieuNhap.Rows.Add(maNLDangChon, tenNLDangChon, sl, gia, sl * gia);

            TinhTongTien();
        }

        // Tính tổng tiền cái nhãn màu đỏ đỏ
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataRow row in dtPhieuNhap.Rows)
            {
                tongTien += Convert.ToDecimal(row["Thành Tiền"]);
            }
            lblTongTienVal.Text = tongTien.ToString("#,##0") + " VNĐ";
        }

        // BƯỚC 4: NÚT LƯU PHIẾU (Chốt Phiếu Nhập kho xuống SQL)
        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhieuHienTai) || dtPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu nhập đang trống!"); return;
            }

            // Xóa chữ VNĐ để lấy số tổng tiền
            decimal tongTien = 0;
            decimal.TryParse(lblTongTienVal.Text.Replace(" VNĐ", "").Replace(",", ""), out tongTien);

            NhapKho_DTO nk = new NhapKho_DTO
            {
                MaNK = maPhieuHienTai,
                NgayNK = DateTime.Now,
                TaiKhoan = "admin", // Tạm để admin, sau này tích hợp form đăng nhập vô
                TongGiaTri = tongTien
            };

            string kq = bll.ChotPhieuNhap(nk, dtPhieuNhap);
            MessageBox.Show(kq, kq.Contains("THÀNH CÔNG") ? "Hoàn tất" : "Lỗi", MessageBoxButtons.OK, kq.Contains("THÀNH CÔNG") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (kq.Contains("THÀNH CÔNG"))
            {
                lblMaPN.Text = "PHIẾU NHẬP: #MỚI";
                maPhieuHienTai = "";
                dtPhieuNhap.Rows.Clear();
                TinhTongTien();
            }
        }

        // BƯỚC 5: HỦY PHIẾU NHẬP (Làm sạch giỏ)
        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            lblMaPN.Text = "PHIẾU NHẬP: #MỚI";
            maPhieuHienTai = "";
            dtPhieuNhap.Rows.Clear();
            TinhTongTien();
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }
    }
}