using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyTuduCoffe.BLL;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyTuduCoffe
{
    public partial class ThongKe : UserControl
    {
        ThongKe_BLL bll = new ThongKe_BLL();

        // BẢNG MÀU TONE CÀ PHÊ TRUNG NGUYÊN
        Color MauNauDam = Color.FromArgb(62, 39, 35);
        Color MauCamDat = Color.FromArgb(216, 67, 21);
        Color MauKem = Color.FromArgb(239, 235, 233);
        Color MauNhat = Color.FromArgb(141, 110, 99);

        public ThongKe()
        {
            InitializeComponent();
            this.Load += QLTHONGKE_Load;
            btnXemDoanhThu.Click += btnXemDoanhThu_Click;
            btnMonBanChay.Click += btnMonBanChay_Click;
            //btnXuatExcel.Click += btnXuatExcel_Click;
            this.VisibleChanged += QLTHONGKE_VisibleChanged;
            this.VisibleChanged += (s, e) => {
                if (this.Visible) btnXemDoanhThu_Click(null, null);
            };
        }
        private void QLTHONGKE_VisibleChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu màn hình này đang được hiển thị cho người dùng thấy
            if (this.Visible)
            {
                // Tự động gọi lại sự kiện click của nút Xem Doanh Thu
                // (null, null) nghĩa là mình giả vờ như có người vừa bấm vào nút đó
                btnXemDoanhThu_Click(null, null);
            }
        }
        private void QLTHONGKE_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            // Bật khử răng cưa cho nét vẽ mượt mà
            chartDoanhThu.AntiAliasing = AntiAliasingStyles.All;
            chartMonBanChay.AntiAliasing = AntiAliasingStyles.All;
            chartDoanhThu.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            chartMonBanChay.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

            chartDoanhThu.Series.Clear();
            chartMonBanChay.Series.Clear();
        }

        private void btnXemDoanhThu_Click(object sender, EventArgs e)
        {
            // 1. Đổ dữ liệu CHI TIẾT vào Bảng (DataGridView)
            DataTable dtChiTiet = bll.LoadChiTietDoanhThu(dtpTuNgay.Value, dtpDenNgay.Value);
            dgvThongKe.DataSource = dtChiTiet;
            TrangTriBangDuLieu(true);

            // 2. Tính tổng tiền dựa trên bảng chi tiết
            decimal tong = 0;
            if (dtChiTiet.Rows.Count > 0)
                foreach (DataRow r in dtChiTiet.Rows) tong += Convert.ToDecimal(r["Doanh Thu"]);

            lblTongDoanhThu.Text = tong.ToString("#,##0") + " VNĐ";
            lblMonBanChayVal.Text = "Đang hiển thị:";
            lblMonBanChay.Text = "Báo cáo Doanh Thu";

            // 3. Đổ dữ liệu GỘP THEO NGÀY vào Biểu Đồ (để biểu đồ không bị rối)
            DataTable dtGopTheoNgay = bll.LoadDoanhThu(dtpTuNgay.Value, dtpDenNgay.Value);
            VeBieuDoCachDieu(dtGopTheoNgay, true);
        }

        private void btnMonBanChay_Click(object sender, EventArgs e)
        {

            DataTable dt = bll.LoadMonBanChay(dtpTuNgay.Value, dtpDenNgay.Value);
            dgvThongKe.DataSource = dt;
            TrangTriBangDuLieu(false);
            lblMonBanChayVal.Text = "Món Bán Chạy Nhất:";

            if (dt.Rows.Count > 0)
                lblMonBanChay.Text =  dt.Rows[0]["Tên Sản Phẩm"].ToString();
            else
                lblMonBanChay.Text = "Chưa có dữ liệu";

            lblTongDoanhThu.Text = "--- VNĐ";

            VeBieuDoCachDieu(dt, false);
        }

        // ==========================================
        // KHU VỰC CODE "MAKE UP" ĐỘC QUYỀN
        // ==========================================

        private void TrangTriBangDuLieu(bool isDoanhThu)
        {
            // 1. Phá bỏ thiết kế phèn mặc định
            dgvThongKe.EnableHeadersVisualStyles = false;
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.BackgroundColor = Color.White;
            dgvThongKe.BorderStyle = BorderStyle.None;
            dgvThongKe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvThongKe.RowHeadersVisible = false;
            dgvThongKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 2. Trang trí Tiêu đề cột (Header)
            dgvThongKe.ColumnHeadersDefaultCellStyle.BackColor = MauNauDam;
            dgvThongKe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvThongKe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvThongKe.ColumnHeadersHeight = 40;
            dgvThongKe.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // 3. Trang trí Dòng dữ liệu (Rows)
            dgvThongKe.DefaultCellStyle.BackColor = Color.White;
            dgvThongKe.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250); // Sọc xen kẽ nhẹ
            dgvThongKe.DefaultCellStyle.SelectionBackColor = MauKem; // Click vào dòng có màu kem
            dgvThongKe.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvThongKe.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvThongKe.RowTemplate.Height = 35;
            dgvThongKe.GridColor = Color.FromArgb(224, 224, 224); // Kẻ ngang mờ tinh tế

            // 4. Format số tiền và cột ngày tháng
            if (isDoanhThu && dgvThongKe.Columns.Contains("Doanh Thu"))
            {
                dgvThongKe.Columns["Doanh Thu"].DefaultCellStyle.Format = "N0";
                dgvThongKe.Columns["Doanh Thu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Định dạng hiển thị thêm Giờ:Phút cho chi tiết
                if (dgvThongKe.Columns.Contains("Thời Gian"))
                {
                    dgvThongKe.Columns["Thời Gian"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
        }

        private void VeBieuDoCachDieu(DataTable dt, bool isDoanhThu)
        {
            chartDoanhThu.Series.Clear(); chartDoanhThu.Titles.Clear();
            chartMonBanChay.Series.Clear(); chartMonBanChay.Titles.Clear();

            // Tắt viền đen xì bên ngoài biểu đồ
            chartDoanhThu.BorderlineColor = Color.Transparent;
            chartMonBanChay.BorderlineColor = Color.Transparent;

            // MÀU SẮC CHỦ ĐẠO
            Color MauNauDam = Color.FromArgb(62, 39, 35);

            if (isDoanhThu)
            {
                // ==========================================
                // 1. BIỂU ĐỒ CỘT (DOANH THU)
                // ==========================================
                chartDoanhThu.Titles.Add("XU HƯỚNG DOANH THU THEO NGÀY").Font = new Font("Segoe UI", 12, FontStyle.Bold);
                chartDoanhThu.Titles[0].ForeColor = MauNauDam;

                Series s = new Series("DoanhThu");
                s.ChartType = SeriesChartType.Column;
                s.XValueMember = "Ngày";
                s.YValueMembers = "Doanh Thu";
                s.IsValueShownAsLabel = true;
                s.LabelFormat = "#,##0";
                s.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                s.Color = Color.FromArgb(216, 67, 21); // Cột màu cam đất

                ChartArea ca = chartDoanhThu.ChartAreas[0];
                ca.BackColor = Color.White;
                ca.AxisX.LabelStyle.Format = "dd/MM";
                ca.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
                ca.AxisX.MajorGrid.Enabled = false;
                ca.AxisX.LineColor = Color.LightGray;

                ca.AxisY.LabelStyle.Format = "#,##0";
                ca.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
                ca.AxisY.MajorGrid.LineColor = Color.FromArgb(235, 235, 235);
                ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                ca.AxisY.LineColor = Color.Transparent;

                chartDoanhThu.Series.Add(s);
                chartDoanhThu.DataSource = dt;
                chartDoanhThu.DataBind();
            }
            else
            {
                // ==========================================
                // 2. BIỂU ĐỒ TRÒN DẠNG DONUT (ĐÃ CODE LẠI SIÊU XỊN)
                // ==========================================
                chartMonBanChay.Titles.Add("TỶ TRỌNG SẢN PHẨM BÁN RA").Font = new Font("Segoe UI", 12, FontStyle.Bold);
                chartMonBanChay.Titles[0].ForeColor = MauNauDam;

                Series s = new Series("Mon");
                // ĐỔI SANG BIỂU ĐỒ DONUT NHÌN HIỆN ĐẠI HƠN GẤP 10 LẦN
                s.ChartType = SeriesChartType.Doughnut;
                s["DoughnutRadius"] = "40"; // Độ dày của vòng tròn (40%)

                s.XValueMember = "Tên Sản Phẩm";
                s.YValueMembers = "Số Lượng";

                // Format chữ: Hiện Tên món + Phần trăm (%)
                s.IsValueShownAsLabel = true;
                s.Label = "#VALX\n#PERCENT{P0}";
                s.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                s.LabelForeColor = MauNauDam; // Chữ màu nâu đậm cho dễ đọc

                // Đẩy chữ ra ngoài miếng bánh, nối bằng đường kẻ (Callout Line)
                s["PieLabelStyle"] = "Outside";
                s["PieLineColor"] = "Black";

                // Tự định nghĩa Bảng màu Cà Phê sang chảnh thay vì màu cầu vồng lòe loẹt mặc định
                chartMonBanChay.Palette = ChartColorPalette.None;
                chartMonBanChay.PaletteCustomColors = new Color[] {
                    Color.FromArgb(141, 110, 99),  // Nâu nhạt
                    Color.FromArgb(216, 67, 21),   // Cam cháy
                    Color.FromArgb(62, 39, 35),    // Nâu đen
                    Color.FromArgb(255, 171, 145), // Cam pastel
                    Color.FromArgb(161, 136, 127)  // Nâu xám
                };

                // Tắt cái bảng chú thích (Legend) rườm rà đi để biểu đồ được phình to ra giữa màn hình
                chartMonBanChay.Legends[0].Enabled = false;

                chartMonBanChay.Series.Add(s);
                chartMonBanChay.DataSource = dt;
                chartMonBanChay.DataBind();
            }
        }

        // ==========================================
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo đối tượng Excel
                Excel.Application app = new Excel.Application();
                // Tạm thời ẩn đi để xử lý ngầm cho nhanh, xong xuôi mới hiện
                app.Visible = false;
                app.DisplayAlerts = false; // Tắt các cảnh báo phiền phức của Excel

                Excel.Workbook wb = app.Workbooks.Add(1);
                Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];
                ws.Name = "Báo cáo Tudu Coffee";

                // 1. Đổ tiêu đề cột
                for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1] = dgvThongKe.Columns[i].HeaderText;
                    // Làm đẹp tiêu đề: In đậm, nền vàng cho chuyên nghiệp
                    ws.Cells[1, i + 1].Font.Bold = true;
                    ws.Cells[1, i + 1].Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                }

                // 2. Đổ dữ liệu
                for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1] = dgvThongKe.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // 3. Tự động căn chỉnh độ rộng cột
                ws.Columns.AutoFit();

                // 4. Cuối cùng mới hiện Excel lên cho sếp xem
                app.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đừng quên đăng ký sự kiện trong hàm khởi tạo QLTHONGKE():
        // btnThongKeNhapKho.Click += btnThongKeNhapKho_Click;

        private void btnThongKeNhapKho_Click(object sender, EventArgs e)
        {
            // 1. Đổ dữ liệu chi tiết vào bảng
            DataTable dtChiTiet = bll.LoadChiTietNhapKho(dtpTuNgay.Value, dtpDenNgay.Value);
            dgvThongKe.DataSource = dtChiTiet;

            // Trang trí bảng (isDoanhThu = false để nó không format theo cột doanh thu bán hàng)
            TrangTriBangDuLieu(false);
            if (dgvThongKe.Columns.Contains("Tiền Nhập"))
            {
                dgvThongKe.Columns["Tiền Nhập"].DefaultCellStyle.Format = "N0";
                dgvThongKe.Columns["Ngày Nhập"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // 2. Tính tổng chi phí nhập
            decimal tongChi = 0;
            foreach (DataRow r in dtChiTiet.Rows) tongChi += Convert.ToDecimal(r["Tiền Nhập"]);

            lblTongDoanhThu.Text = tongChi.ToString("#,##0") + " VNĐ";
            lblTongDoanhThuVal.Text = "Tổng Chi Phí:";
            lblMonBanChayVal.Text = "Đang hiển thị:";
            lblMonBanChay.Text = "Báo cáo Nhập Kho Chi Tiết";

            // 3. Vẽ biểu đồ xu hướng chi phí (Dùng chartDoanhThu nhưng đổi dữ liệu)
            DataTable dtBieuDo = bll.LoadTongNhapTheoNgay(dtpTuNgay.Value, dtpDenNgay.Value);

            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("XU HƯỚNG CHI PHÍ NHẬP HÀNG").Font = new Font("Segoe UI", 12, FontStyle.Bold);

            Series s = new Series("Tiền Nhập");
            s.ChartType = SeriesChartType.Column;
            s.XValueMember = "Ngày";
            s.YValueMembers = "Tiền Nhập";
            s.Color = Color.FromArgb(121, 85, 72); // Màu nâu cà phê cho chi phí
            s.IsValueShownAsLabel = true;
            s.LabelFormat = "#,##0";

            chartDoanhThu.Series.Add(s);
            chartDoanhThu.DataSource = dtBieuDo;
            chartDoanhThu.DataBind();

            // Tùy chỉnh trục X cho đẹp
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
        }
    }
}