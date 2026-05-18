using System;
using System.Data;
using System.Windows.Forms;
using QuanLyTuduCoffe.BLL;
using QuanLyTuduCoffe.DTO;
using System.Drawing;
using System.Drawing.Printing;

namespace QuanLyTuduCoffe
{
    public partial class QLBANHANG : UserControl
    {
        BanHang_BLL bll = new BanHang_BLL();
        string maHoaDonHienTai = "";
        DataTable dtGioHang = new DataTable();

        public QLBANHANG()
        {
            InitializeComponent();
            this.Load += QLBANHANG_Load;

            this.dgvSanPham.CellDoubleClick += DgvSanPham_CellDoubleClick;
            this.dgvHoaDon.CellDoubleClick += DgvHoaDon_CellDoubleClick;
            this.txtTienKhachDua.TextChanged += txtTienKhachDua_TextChanged;
            this.txtTimKiemSP.TextChanged += txtTimKiemSP_TextChanged;

            this.dgvHoaDon.CellValueChanged += DgvHoaDon_CellValueChanged;
            this.dgvHoaDon.CurrentCellDirtyStateChanged += DgvHoaDon_CurrentCellDirtyStateChanged;
            this.dgvHoaDon.DataError += DgvHoaDon_DataError;
        }

        private void QLBANHANG_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = bll.LoadMenu();
            if (dgvSanPham.Columns.Count > 0)
            {
                dgvSanPham.Columns["maSP"].HeaderText = "Mã SP";
                dgvSanPham.Columns["tenSP"].HeaderText = "Tên Sản Phẩm";
                dgvSanPham.Columns["giatien"].HeaderText = "Giá Tiền";
                dgvSanPham.Columns["tenSP"].Width = 180;
            }

            // 1. CẬP NHẬT CẤU TRÚC GIỎ HÀNG: THÊM CỘT TOPPING
            dtGioHang.Columns.Add("Mã SP");
            dtGioHang.Columns.Add("Tên Món");
            dtGioHang.Columns.Add("Size");
            dtGioHang.Columns.Add("Đường");
            dtGioHang.Columns.Add("Đá");
            dtGioHang.Columns.Add("Topping"); // Thêm cột Topping
            dtGioHang.Columns.Add("SL", typeof(int));
            dtGioHang.Columns.Add("Giá Gốc", typeof(decimal));
            dtGioHang.Columns.Add("Đơn Giá", typeof(decimal));
            dtGioHang.Columns.Add("Thành Tiền", typeof(decimal));

            dgvHoaDon.DataSource = dtGioHang;

            // Chỉ dùng ComboBox cho Size M/L
            DataGridViewComboBoxColumn colSize = new DataGridViewComboBoxColumn();
            colSize.DataPropertyName = "Size";
            colSize.HeaderText = "Size";
            colSize.Name = "colSize";
            colSize.Items.AddRange("M", "L");

            dgvHoaDon.Columns.Remove("Size");
            dgvHoaDon.Columns.Insert(2, colSize);

            // Căn chỉnh lại giao diện các cột
            dgvHoaDon.Columns["Mã SP"].Visible = false;
            dgvHoaDon.Columns["Giá Gốc"].Visible = false;
            dgvHoaDon.Columns["Tên Món"].Width = 120;
            dgvHoaDon.Columns["colSize"].Width = 45;
            dgvHoaDon.Columns["Đường"].Width = 55; // Là ô nhập chữ (TextBox)
            dgvHoaDon.Columns["Đá"].Width = 55;    // Là ô nhập chữ (TextBox)
            dgvHoaDon.Columns["Topping"].Width = 80; // Ô nhập tên topping
            dgvHoaDon.Columns["SL"].Width = 35;

            dgvHoaDon.AllowUserToAddRows = false;

            // Cấp quyền sửa cho các cột tùy chọn
            dgvHoaDon.ReadOnly = false;
            foreach (DataGridViewColumn c in dgvHoaDon.Columns)
            {
                if (c.Name == "SL" || c.Name == "colSize" || c.Name == "Đường" || c.Name == "Đá" || c.Name == "Topping")
                    c.ReadOnly = false;
                else
                    c.ReadOnly = true;
            }

            cboKhuyenMai.DataSource = bll.LoadKhuyenMai();
            cboKhuyenMai.DisplayMember = "hienThi";
            cboKhuyenMai.ValueMember = "maKM";
        }

        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("tenSP LIKE '%{0}%'", txtTimKiemSP.Text);
            }
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            maHoaDonHienTai = bll.LapHoaDonMoi("admin");
            if (maHoaDonHienTai != null)
            {
                lblMaHD.Text = "HÓA ĐƠN: #" + maHoaDonHienTai;
                dtGioHang.Rows.Clear();
                TinhTongTien();
                MessageBox.Show("Đã tạo hóa đơn mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(maHoaDonHienTai))
            {
                MessageBox.Show("Sếp phải bấm LẬP ĐƠN (F1) trước nha!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.RowIndex >= 0)
            {
                string maSP = dgvSanPham.Rows[e.RowIndex].Cells["maSP"].Value.ToString();
                string tenSP = dgvSanPham.Rows[e.RowIndex].Cells["tenSP"].Value.ToString();
                decimal giaTien = Convert.ToDecimal(dgvSanPham.Rows[e.RowIndex].Cells["giatien"].Value);

                bool daCoTrongGio = false;
                foreach (DataRow row in dtGioHang.Rows)
                {
                    // Xét gộp dòng: Cùng món, cùng size, cùng đường, đá, và KHÔNG CÓ topping khác biệt
                    if (row["Mã SP"].ToString() == maSP && row["Size"].ToString() == "M" &&
                        row["Đường"].ToString() == "100%" && row["Đá"].ToString() == "100%" &&
                        row["Topping"].ToString() == "")
                    {
                        row["SL"] = Convert.ToInt32(row["SL"]) + 1;
                        row["Thành Tiền"] = Convert.ToInt32(row["SL"]) * giaTien;
                        daCoTrongGio = true;
                        break;
                    }
                }

                if (!daCoTrongGio)
                {
                    // Mặc định lúc thêm vào: Size M, 100% Đường, 100% Đá, Topping trống
                    dtGioHang.Rows.Add(maSP, tenSP, "M", "100%", "100%", "", 1, giaTien, giaTien, giaTien);
                }

                TinhTongTien();
            }
        }

        private void DgvHoaDon_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.IsCurrentCellDirty)
            {
                dgvHoaDon.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvHoaDon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void DgvHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string colName = dgvHoaDon.Columns[e.ColumnIndex].Name;

                if (colName == "SL" || colName == "colSize" || colName == "Đường" || colName == "Đá" || colName == "Topping")
                {
                    DataRow row = ((DataRowView)dgvHoaDon.Rows[e.RowIndex].DataBoundItem).Row;

                    int sl = 1;
                    if (!int.TryParse(row["SL"].ToString(), out sl) || sl <= 0)
                    {
                        MessageBox.Show("Số lượng phải là số lớn hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sl = 1;
                        row["SL"] = 1;
                    }

                    decimal giaGoc = Convert.ToDecimal(row["Giá Gốc"]);
                    string size = row["Size"].ToString();

                    // Size L cộng thêm 10.000đ. 
                    decimal giaMoi = giaGoc;
                    if (size == "L") giaMoi += 10000;

                    row["Đơn Giá"] = giaMoi;
                    row["Thành Tiền"] = giaMoi * sl;

                    TinhTongTien();
                }
            }
        }

        private void TinhTongTien()
        {
            decimal tongTienHang = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTienHang += Convert.ToDecimal(row["Thành Tiền"]);
            }

            decimal tienGiam = 0;
            if (cboKhuyenMai.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)cboKhuyenMai.SelectedItem;
                tienGiam = Convert.ToDecimal(drv["mucGiam"]);
            }

            decimal tongThanhToan = tongTienHang - tienGiam;
            if (tongThanhToan < 0) tongThanhToan = 0;

            lblTongTienVal.Text = tongThanhToan.ToString("#,##0") + " VNĐ";
            txtTienKhachDua_TextChanged(null, null);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maHoaDonHienTai) || dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal tongTien = 0;
            for (int i = 0; i < dtGioHang.Rows.Count; i++)
            {
                DataRow r = dtGioHang.Rows[i];

                // Nối chuỗi thông minh: Nếu có topping thì mới ghi vào Tên SP
                string strTopping = string.IsNullOrWhiteSpace(r["Topping"].ToString()) ? "" : $", +{r["Topping"]}";
                string tenSanPhamTuyChinh = $"{r["Tên Món"]} (Size {r["Size"]}, {r["Đường"]} Đường, {r["Đá"]} Đá{strTopping})";

                ChiTietHoaDon_DTO ct = new ChiTietHoaDon_DTO
                {
                    MaCTHD = maHoaDonHienTai + "_" + (i + 1).ToString(),
                    MaDH = maHoaDonHienTai,
                    MaSP = r["Mã SP"].ToString(),
                    TenSP = tenSanPhamTuyChinh,
                    SoLuong = Convert.ToInt32(r["SL"]),
                    GiaTien = Convert.ToDecimal(r["Đơn Giá"])
                };
                bll.ThemMonVaoHoaDon(ct);
                tongTien += ct.SoLuong * ct.GiaTien;
            }

            string maKMDangChon = cboKhuyenMai.SelectedValue != null ? cboKhuyenMai.SelectedValue.ToString() : "KM_NONE";
            bll.HoanTatThanhToan(maHoaDonHienTai, tongTien, maKMDangChon);

            MessageBox.Show($"Thanh toán thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

            InHoaDon(tongTien);

            lblMaHD.Text = "HÓA ĐƠN: #MỚI";
            maHoaDonHienTai = "";
            dtGioHang.Rows.Clear();
            TinhTongTien();
            txtTienKhachDua.Text = "";
            txtTienThua.Text = "";
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maHoaDonHienTai))
            {
                lblMaHD.Text = "HÓA ĐƠN: #MỚI";
                maHoaDonHienTai = "";
                dtGioHang.Rows.Clear();
                TinhTongTien();
                MessageBox.Show("Đã hủy đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            string tongTienStr = lblTongTienVal.Text.Replace(" VNĐ", "").Replace(",", "").Trim();
            if (decimal.TryParse(tongTienStr, out decimal tongTien) &&
                decimal.TryParse(txtTienKhachDua.Text, out decimal tienKhachDua))
            {
                decimal tienThua = tienKhachDua - tongTien;
                txtTienThua.Text = tienThua >= 0 ? tienThua.ToString("#,##0") : "Khách đưa thiếu!";
            }
            else { txtTienThua.Text = ""; }
        }

        private void DgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string colName = dgvHoaDon.Columns[e.ColumnIndex].Name;
                // Nếu đang bấm vào cột để gõ chữ thì không hiển thị thông báo XÓA
                if (colName == "colSize" || colName == "Đường" || colName == "Đá" || colName == "Topping" || colName == "SL")
                    return;

                DataRow row = ((DataRowView)dgvHoaDon.Rows[e.RowIndex].DataBoundItem).Row;
                int soLuongHienTai = Convert.ToInt32(row["SL"]);
                decimal giaTien = Convert.ToDecimal(row["Đơn Giá"]);

                if (soLuongHienTai > 1)
                {
                    row["SL"] = soLuongHienTai - 1;
                    row["Thành Tiền"] = (soLuongHienTai - 1) * giaTien;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Xóa món này khỏi hóa đơn?", "Xóa món", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes) dtGioHang.Rows.Remove(((DataRowView)dgvHoaDon.Rows[e.RowIndex].DataBoundItem).Row);
                }
                TinhTongTien();
            }
        }

        private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void InHoaDon(decimal tongTienGoc)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(VeHoaDon);
            pd.DefaultPageSettings.PaperSize = new PaperSize("ThermalBill", 380, 800);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
        }

        private void VeHoaDon(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Courier New", 18, FontStyle.Bold);
            Font fontHeader = new Font("Courier New", 10, FontStyle.Bold);
            Font fontBody = new Font("Courier New", 10, FontStyle.Regular);
            Font fontTotal = new Font("Courier New", 12, FontStyle.Bold);
            Font fontItalic = new Font("Courier New", 10, FontStyle.Italic);

            Brush brush = Brushes.Black;
            int yPos = 20;
            int billWidth = 340;
            int leftMargin = (e.PageBounds.Width - billWidth) / 2;

            g.DrawString("TUDU COFFEE PREMIUM", fontTitle, brush, leftMargin + 10, yPos);
            yPos += 30;
            g.DrawString("Đ/c: UTEHY, Khoa CNTT", fontBody, brush, leftMargin + 60, yPos);
            yPos += 20;
            g.DrawString("Hotline: 0909.090.909", fontBody, brush, leftMargin + 60, yPos);
            yPos += 40;

            g.DrawString("HÓA ĐƠN THANH TOÁN", fontTotal, brush, leftMargin + 60, yPos);
            yPos += 30;
            g.DrawString("Mã HĐ: " + maHoaDonHienTai, fontBody, brush, leftMargin, yPos);
            yPos += 20;
            g.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontBody, brush, leftMargin, yPos);
            yPos += 20;
            g.DrawString("Thu ngân: Đỗ Ngọc Tú", fontBody, brush, leftMargin, yPos);
            yPos += 30;

            g.DrawString("-----------------------------------------", fontBody, brush, leftMargin, yPos);
            yPos += 20;
            g.DrawString("Tên Món", fontHeader, brush, leftMargin, yPos);
            g.DrawString("SL", fontHeader, brush, leftMargin + 190, yPos);
            g.DrawString("Đ.Giá", fontHeader, brush, leftMargin + 230, yPos);
            g.DrawString("T.Tiền", fontHeader, brush, leftMargin + 290, yPos);
            yPos += 20;
            g.DrawString("-----------------------------------------", fontBody, brush, leftMargin, yPos);
            yPos += 20;

            decimal totalTemp = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                // In thêm Size và Topping (nếu có) lên bill
                string strTopping = string.IsNullOrWhiteSpace(row["Topping"].ToString()) ? "" : $", +{row["Topping"]}";
                string tenMon = $"{row["Tên Món"]} (Sz {row["Size"]}{strTopping})";
                if (tenMon.Length > 18) tenMon = tenMon.Substring(0, 18) + "..";

                string sl = row["SL"].ToString();
                string donGia = Convert.ToDecimal(row["Đơn Giá"]).ToString("#,##0");
                decimal tien = Convert.ToDecimal(row["Thành Tiền"]);
                totalTemp += tien;

                g.DrawString(tenMon, fontBody, brush, leftMargin, yPos);
                g.DrawString(sl, fontBody, brush, leftMargin + 190, yPos);
                g.DrawString(donGia, fontBody, brush, leftMargin + 220, yPos);
                g.DrawString(tien.ToString("#,##0"), fontBody, brush, leftMargin + 280, yPos);
                yPos += 25;
            }

            g.DrawString("-----------------------------------------", fontBody, brush, leftMargin, yPos);
            yPos += 20;

            decimal tienGiam = 0;
            if (cboKhuyenMai.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)cboKhuyenMai.SelectedItem;
                tienGiam = Convert.ToDecimal(drv["mucGiam"]);
            }
            decimal tongThanhToan = totalTemp - tienGiam;
            if (tongThanhToan < 0) tongThanhToan = 0;

            g.DrawString("Tổng tiền hàng:", fontBody, brush, leftMargin, yPos);
            g.DrawString(totalTemp.ToString("#,##0") + " đ", fontBody, brush, leftMargin + 240, yPos);
            yPos += 25;

            g.DrawString("Khuyến mãi:", fontBody, brush, leftMargin, yPos);
            g.DrawString("-" + tienGiam.ToString("#,##0") + " đ", fontBody, brush, leftMargin + 240, yPos);
            yPos += 30;

            g.DrawString("TỔNG CỘNG:", fontTotal, brush, leftMargin, yPos);
            g.DrawString(tongThanhToan.ToString("#,##0") + " đ", fontTotal, brush, leftMargin + 220, yPos);
            yPos += 40;

            g.DrawString("Cảm ơn Quý khách & Hẹn gặp lại!", fontItalic, brush, leftMargin + 30, yPos);
            yPos += 20;
            g.DrawString("Pass Wifi: dotu2506", fontItalic, brush, leftMargin + 65, yPos);
        }
    }
}