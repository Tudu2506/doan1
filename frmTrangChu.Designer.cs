namespace QuanLyTuduCoffe
{
    partial class frmTrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrangChu));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnKhuyenMai = new System.Windows.Forms.Button();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.btnNguyenLieu = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picHomeIcon = new System.Windows.Forms.Label();
            this.lblOnlineStatus = new System.Windows.Forms.Label();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.trang_Chủ2 = new QuanLyTuduCoffe.Trang_Chủ();
            this.qlTaiKhoan1 = new QuanLyTuduCoffe.QLTaiKhoan();
            this.thongKe1 = new QuanLyTuduCoffe.ThongKe();
            this.qlKhuyenMai1 = new QuanLyTuduCoffe.QLKhuyenMai();
            this.qlNhapKho1 = new QuanLyTuduCoffe.QLNhapKho();
            this.qlNguyenLieu1 = new QuanLyTuduCoffe.QLNguyenLieu();
            this.qlSanPham1 = new QuanLyTuduCoffe.QLSanPham();
            this.qlKhachHang1 = new QuanLyTuduCoffe.QLKhachHang();
            this.qlbanhang1 = new QuanLyTuduCoffe.QLBANHANG();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(34)))), ((int)(((byte)(25)))));
            this.pnlSidebar.Controls.Add(this.btnDangXuat);
            this.pnlSidebar.Controls.Add(this.btnTaiKhoan);
            this.pnlSidebar.Controls.Add(this.btnThongKe);
            this.pnlSidebar.Controls.Add(this.btnKhuyenMai);
            this.pnlSidebar.Controls.Add(this.btnNhapKho);
            this.pnlSidebar.Controls.Add(this.btnNguyenLieu);
            this.pnlSidebar.Controls.Add(this.btnSanPham);
            this.pnlSidebar.Controls.Add(this.btnKhachHang);
            this.pnlSidebar.Controls.Add(this.btnBanHang);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(260, 752);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(67)))), ((int)(((byte)(21)))));
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 687);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(260, 65);
            this.btnDangXuat.TabIndex = 8;
            this.btnDangXuat.Text = "🚪  ĐĂNG XUẤT";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 480);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(260, 60);
            this.btnTaiKhoan.TabIndex = 7;
            this.btnTaiKhoan.Text = "  👤   Quản lý Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnThongKe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnThongKe.Location = new System.Drawing.Point(0, 420);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnThongKe.Size = new System.Drawing.Size(260, 60);
            this.btnThongKe.TabIndex = 6;
            this.btnThongKe.Text = "  📊   Thống kê Báo cáo";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click_1);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhuyenMai.FlatAppearance.BorderSize = 0;
            this.btnKhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhuyenMai.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnKhuyenMai.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnKhuyenMai.Location = new System.Drawing.Point(0, 360);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnKhuyenMai.Size = new System.Drawing.Size(260, 60);
            this.btnKhuyenMai.TabIndex = 5;
            this.btnKhuyenMai.Text = "  🎁   Quản lý Khuyến mãi";
            this.btnKhuyenMai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhuyenMai.UseVisualStyleBackColor = true;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapKho.FlatAppearance.BorderSize = 0;
            this.btnNhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapKho.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnNhapKho.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNhapKho.Location = new System.Drawing.Point(0, 300);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNhapKho.Size = new System.Drawing.Size(260, 60);
            this.btnNhapKho.TabIndex = 4;
            this.btnNhapKho.Text = "  📦   Quản lý Nhập kho";
            this.btnNhapKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapKho.UseVisualStyleBackColor = true;
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);
            // 
            // btnNguyenLieu
            // 
            this.btnNguyenLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNguyenLieu.FlatAppearance.BorderSize = 0;
            this.btnNguyenLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNguyenLieu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnNguyenLieu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNguyenLieu.Location = new System.Drawing.Point(0, 240);
            this.btnNguyenLieu.Name = "btnNguyenLieu";
            this.btnNguyenLieu.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNguyenLieu.Size = new System.Drawing.Size(260, 60);
            this.btnNguyenLieu.TabIndex = 3;
            this.btnNguyenLieu.Text = "  🌾   Quản lý Nguyên liệu";
            this.btnNguyenLieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNguyenLieu.UseVisualStyleBackColor = true;
            this.btnNguyenLieu.Click += new System.EventHandler(this.btnNguyenLieu_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSanPham.FlatAppearance.BorderSize = 0;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnSanPham.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSanPham.Location = new System.Drawing.Point(0, 180);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSanPham.Size = new System.Drawing.Size(260, 60);
            this.btnSanPham.TabIndex = 2;
            this.btnSanPham.Text = "  ☕   Quản lý Sản phẩm";
            this.btnSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnKhachHang.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 120);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnKhachHang.Size = new System.Drawing.Size(260, 60);
            this.btnKhachHang.TabIndex = 1;
            this.btnKhachHang.Text = "  👥   Quản lý Khách hàng";
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F);
            this.btnBanHang.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBanHang.Location = new System.Drawing.Point(0, 0);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnBanHang.Size = new System.Drawing.Size(260, 120);
            this.btnBanHang.TabIndex = 0;
            this.btnBanHang.Text = "  🛒   Quản lý Bán hàng";
            this.btnBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.UseVisualStyleBackColor = true;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.picHomeIcon);
            this.pnlHeader.Controls.Add(this.lblOnlineStatus);
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(260, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(990, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // picHomeIcon
            // 
            this.picHomeIcon.AutoSize = true;
            this.picHomeIcon.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.picHomeIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(67)))), ((int)(((byte)(21)))));
            this.picHomeIcon.Location = new System.Drawing.Point(20, 22);
            this.picHomeIcon.Name = "picHomeIcon";
            this.picHomeIcon.Size = new System.Drawing.Size(54, 37);
            this.picHomeIcon.TabIndex = 3;
            this.picHomeIcon.Text = "🏠";
            this.picHomeIcon.Click += new System.EventHandler(this.picHomeIcon_Click);
            // 
            // lblOnlineStatus
            // 
            this.lblOnlineStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOnlineStatus.AutoSize = true;
            this.lblOnlineStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOnlineStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblOnlineStatus.Location = new System.Drawing.Point(750, 36);
            this.lblOnlineStatus.Name = "lblOnlineStatus";
            this.lblOnlineStatus.Size = new System.Drawing.Size(14, 15);
            this.lblOnlineStatus.TabIndex = 4;
            this.lblOnlineStatus.Text = "●";
            // 
            // pnlHeaderLine
            // 
            this.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(67)))), ((int)(((byte)(21)))));
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderLine.Location = new System.Drawing.Point(0, 78);
            this.pnlHeaderLine.Name = "pnlHeaderLine";
            this.pnlHeaderLine.Size = new System.Drawing.Size(990, 2);
            this.pnlHeaderLine.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Italic);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.lblUser.Location = new System.Drawing.Point(770, 32);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(200, 23);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Đỗ Ngọc Tú (Admin)";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblTitle.Location = new System.Drawing.Point(70, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(292, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRANG CHỦ HỆ THỐNG";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.trang_Chủ2);
            this.pnlMain.Controls.Add(this.qlTaiKhoan1);
            this.pnlMain.Controls.Add(this.thongKe1);
            this.pnlMain.Controls.Add(this.qlKhuyenMai1);
            this.pnlMain.Controls.Add(this.qlNhapKho1);
            this.pnlMain.Controls.Add(this.qlNguyenLieu1);
            this.pnlMain.Controls.Add(this.qlSanPham1);
            this.pnlMain.Controls.Add(this.qlKhachHang1);
            this.pnlMain.Controls.Add(this.qlbanhang1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(260, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(990, 672);
            this.pnlMain.TabIndex = 2;
            // 
            // trang_Chủ2
            // 
            this.trang_Chủ2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("trang_Chủ2.BackgroundImage")));
            this.trang_Chủ2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.trang_Chủ2.Location = new System.Drawing.Point(0, -5);
            this.trang_Chủ2.Name = "trang_Chủ2";
            this.trang_Chủ2.Size = new System.Drawing.Size(1020, 677);
            this.trang_Chủ2.TabIndex = 9;
            // 
            // qlTaiKhoan1
            // 
            this.qlTaiKhoan1.Location = new System.Drawing.Point(0, 0);
            this.qlTaiKhoan1.Name = "qlTaiKhoan1";
            this.qlTaiKhoan1.Size = new System.Drawing.Size(1000, 650);
            this.qlTaiKhoan1.TabIndex = 1;
            // 
            // thongKe1
            // 
            this.thongKe1.Location = new System.Drawing.Point(0, 0);
            this.thongKe1.Name = "thongKe1";
            this.thongKe1.Size = new System.Drawing.Size(1000, 650);
            this.thongKe1.TabIndex = 2;
            // 
            // qlKhuyenMai1
            // 
            this.qlKhuyenMai1.Location = new System.Drawing.Point(0, 0);
            this.qlKhuyenMai1.Name = "qlKhuyenMai1";
            this.qlKhuyenMai1.Size = new System.Drawing.Size(1000, 650);
            this.qlKhuyenMai1.TabIndex = 3;
            // 
            // qlNhapKho1
            // 
            this.qlNhapKho1.Location = new System.Drawing.Point(0, 0);
            this.qlNhapKho1.Name = "qlNhapKho1";
            this.qlNhapKho1.Size = new System.Drawing.Size(1000, 650);
            this.qlNhapKho1.TabIndex = 4;
            // 
            // qlNguyenLieu1
            // 
            this.qlNguyenLieu1.Location = new System.Drawing.Point(0, 0);
            this.qlNguyenLieu1.Name = "qlNguyenLieu1";
            this.qlNguyenLieu1.Size = new System.Drawing.Size(1000, 650);
            this.qlNguyenLieu1.TabIndex = 5;
            // 
            // qlSanPham1
            // 
            this.qlSanPham1.Location = new System.Drawing.Point(0, 0);
            this.qlSanPham1.Name = "qlSanPham1";
            this.qlSanPham1.Size = new System.Drawing.Size(1000, 650);
            this.qlSanPham1.TabIndex = 6;
            // 
            // qlKhachHang1
            // 
            this.qlKhachHang1.Location = new System.Drawing.Point(0, 0);
            this.qlKhachHang1.Name = "qlKhachHang1";
            this.qlKhachHang1.Size = new System.Drawing.Size(1000, 650);
            this.qlKhachHang1.TabIndex = 7;
            // 
            // qlbanhang1
            // 
            this.qlbanhang1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            this.qlbanhang1.Location = new System.Drawing.Point(0, 0);
            this.qlbanhang1.Name = "qlbanhang1";
            this.qlbanhang1.Size = new System.Drawing.Size(1000, 650);
            this.qlbanhang1.TabIndex = 8;
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 752);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tudu Coffee Management System";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnKhuyenMai;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Button btnNguyenLieu;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private QLBANHANG qlbanhang1;
        private QLKhachHang qlKhachHang1;
        private QLSanPham qlSanPham1;
        private QLNguyenLieu qlNguyenLieu1;
        private QLNhapKho qlNhapKho1;
        private QLKhuyenMai qlKhuyenMai1;
        private ThongKe thongKe1;
        private QLTaiKhoan qlTaiKhoan1;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private System.Windows.Forms.Label picHomeIcon;
        private System.Windows.Forms.Label lblOnlineStatus;
        private Trang_Chủ trang_Chủ2;
    }
}