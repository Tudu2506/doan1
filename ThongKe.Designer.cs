namespace QuanLyTuduCoffe
{
    partial class ThongKe
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlDividerTop = new System.Windows.Forms.Panel();
            this.btnThongKeNhapKho = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnMonBanChay = new System.Windows.Forms.Button();
            this.btnXemDoanhThu = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblTitleTop = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblMonBanChay = new System.Windows.Forms.Label();
            this.lblMonBanChayVal = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTongDoanhThuVal = new System.Windows.Forms.Label();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.chartMonBanChay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonBanChay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            this.pnlTop.Controls.Add(this.pnlDividerTop);
            this.pnlTop.Controls.Add(this.btnThongKeNhapKho);
            this.pnlTop.Controls.Add(this.btnXuatExcel);
            this.pnlTop.Controls.Add(this.btnMonBanChay);
            this.pnlTop.Controls.Add(this.btnXemDoanhThu);
            this.pnlTop.Controls.Add(this.dtpDenNgay);
            this.pnlTop.Controls.Add(this.lblDenNgay);
            this.pnlTop.Controls.Add(this.dtpTuNgay);
            this.pnlTop.Controls.Add(this.lblTuNgay);
            this.pnlTop.Controls.Add(this.lblTitleTop);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 100);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlDividerTop
            // 
            this.pnlDividerTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(204)))), ((int)(((byte)(200)))));
            this.pnlDividerTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDividerTop.Location = new System.Drawing.Point(0, 99);
            this.pnlDividerTop.Name = "pnlDividerTop";
            this.pnlDividerTop.Size = new System.Drawing.Size(1000, 1);
            this.pnlDividerTop.TabIndex = 9;
            // 
            // btnThongKeNhapKho
            // 
            this.btnThongKeNhapKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(110)))), ((int)(((byte)(99)))));
            this.btnThongKeNhapKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKeNhapKho.FlatAppearance.BorderSize = 0;
            this.btnThongKeNhapKho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.btnThongKeNhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeNhapKho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThongKeNhapKho.ForeColor = System.Drawing.Color.White;
            this.btnThongKeNhapKho.Location = new System.Drawing.Point(740, 52);
            this.btnThongKeNhapKho.Name = "btnThongKeNhapKho";
            this.btnThongKeNhapKho.Size = new System.Drawing.Size(130, 35);
            this.btnThongKeNhapKho.TabIndex = 8;
            this.btnThongKeNhapKho.Text = "TK NHẬP KHO";
            this.btnThongKeNhapKho.UseVisualStyleBackColor = false;
            this.btnThongKeNhapKho.Click += new System.EventHandler(this.btnThongKeNhapKho_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(880, 52);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 35);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = "XUẤT EXCEL";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnMonBanChay
            // 
            this.btnMonBanChay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(67)))), ((int)(((byte)(21)))));
            this.btnMonBanChay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMonBanChay.FlatAppearance.BorderSize = 0;
            this.btnMonBanChay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(54)))), ((int)(((byte)(12)))));
            this.btnMonBanChay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonBanChay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMonBanChay.ForeColor = System.Drawing.Color.White;
            this.btnMonBanChay.Location = new System.Drawing.Point(580, 52);
            this.btnMonBanChay.Name = "btnMonBanChay";
            this.btnMonBanChay.Size = new System.Drawing.Size(150, 35);
            this.btnMonBanChay.TabIndex = 6;
            this.btnMonBanChay.Text = "THỐNG KÊ MÓN CHẠY";
            this.btnMonBanChay.UseVisualStyleBackColor = false;
            this.btnMonBanChay.Click += new System.EventHandler(this.btnMonBanChay_Click);
            // 
            // btnXemDoanhThu
            // 
            this.btnXemDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.btnXemDoanhThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnXemDoanhThu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.btnXemDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnXemDoanhThu.Location = new System.Drawing.Point(435, 52);
            this.btnXemDoanhThu.Name = "btnXemDoanhThu";
            this.btnXemDoanhThu.Size = new System.Drawing.Size(135, 35);
            this.btnXemDoanhThu.TabIndex = 5;
            this.btnXemDoanhThu.Text = "XEM DOANH THU";
            this.btnXemDoanhThu.UseVisualStyleBackColor = false;
            this.btnXemDoanhThu.Click += new System.EventHandler(this.btnXemDoanhThu_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(290, 56);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 27);
            this.dtpDenNgay.TabIndex = 4;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblDenNgay.Location = new System.Drawing.Point(215, 60);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(71, 19);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(75, 56);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 27);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblTuNgay.Location = new System.Drawing.Point(15, 60);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(61, 19);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblTitleTop
            // 
            this.lblTitleTop.AutoSize = true;
            this.lblTitleTop.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitleTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblTitleTop.Location = new System.Drawing.Point(15, 15);
            this.lblTitleTop.Name = "lblTitleTop";
            this.lblTitleTop.Size = new System.Drawing.Size(262, 32);
            this.lblTitleTop.TabIndex = 0;
            this.lblTitleTop.Text = "THỐNG KÊ & BÁO CÁO";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(204)))), ((int)(((byte)(200)))));
            this.pnlBottom.Controls.Add(this.lblMonBanChay);
            this.pnlBottom.Controls.Add(this.lblMonBanChayVal);
            this.pnlBottom.Controls.Add(this.lblTongDoanhThu);
            this.pnlBottom.Controls.Add(this.lblTongDoanhThuVal);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 580);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1000, 70);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblMonBanChay
            // 
            this.lblMonBanChay.AutoSize = false;
            this.lblMonBanChay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMonBanChay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(67)))), ((int)(((byte)(21)))));
            this.lblMonBanChay.Location = new System.Drawing.Point(690, 20);
            this.lblMonBanChay.Name = "lblMonBanChay";
            this.lblMonBanChay.Size = new System.Drawing.Size(290, 30);
            this.lblMonBanChay.TabIndex = 3;
            this.lblMonBanChay.Text = "---";
            this.lblMonBanChay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMonBanChayVal
            // 
            this.lblMonBanChayVal.AutoSize = true;
            this.lblMonBanChayVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.lblMonBanChayVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblMonBanChayVal.Location = new System.Drawing.Point(540, 25);
            this.lblMonBanChayVal.Name = "lblMonBanChayVal";
            this.lblMonBanChayVal.Size = new System.Drawing.Size(139, 20);
            this.lblMonBanChayVal.TabIndex = 2;
            this.lblMonBanChayVal.Text = "Món bán chạy nhất:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = false;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(67)))), ((int)(((byte)(21)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(240, 20);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(280, 30);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "0 VNĐ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongDoanhThuVal
            // 
            this.lblTongDoanhThuVal.AutoSize = false;
            this.lblTongDoanhThuVal.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThuVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblTongDoanhThuVal.Location = new System.Drawing.Point(20, 20);
            this.lblTongDoanhThuVal.Name = "lblTongDoanhThuVal";
            this.lblTongDoanhThuVal.Size = new System.Drawing.Size(220, 30);
            this.lblTongDoanhThuVal.TabIndex = 0;
            this.lblTongDoanhThuVal.Text = "TỔNG DOANH THU:";
            this.lblTongDoanhThuVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(241)))), ((int)(((byte)(238)))));
            this.pnlCenter.Controls.Add(this.chartMonBanChay);
            this.pnlCenter.Controls.Add(this.chartDoanhThu);
            this.pnlCenter.Controls.Add(this.dgvThongKe);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 100);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1000, 480);
            this.pnlCenter.TabIndex = 2;
            // 
            // chartMonBanChay
            // 
            this.chartMonBanChay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            chartArea7.Name = "ChartArea1";
            chartArea7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            this.chartMonBanChay.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            legend7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            this.chartMonBanChay.Legends.Add(legend7);
            this.chartMonBanChay.Location = new System.Drawing.Point(510, 240);
            this.chartMonBanChay.Name = "chartMonBanChay";
            this.chartMonBanChay.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartMonBanChay.Series.Add(series7);
            this.chartMonBanChay.Size = new System.Drawing.Size(475, 225);
            this.chartMonBanChay.TabIndex = 2;
            this.chartMonBanChay.Text = "chart2";
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            chartArea8.Name = "ChartArea1";
            chartArea8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            this.chartDoanhThu.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            legend8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            this.chartDoanhThu.Legends.Add(legend8);
            this.chartDoanhThu.Location = new System.Drawing.Point(15, 240);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartDoanhThu.Series.Add(series8);
            this.chartDoanhThu.Size = new System.Drawing.Size(475, 225);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "chart1";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            this.dgvThongKe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThongKe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThongKe.ColumnHeadersHeight = 40;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(204)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongKe.EnableHeadersVisualStyles = false;
            this.dgvThongKe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.dgvThongKe.Location = new System.Drawing.Point(15, 15);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowTemplate.Height = 35;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(970, 210);
            this.dgvThongKe.TabIndex = 0;
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "ThongKe";
            this.Size = new System.Drawing.Size(1000, 650);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMonBanChay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitleTop;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemDoanhThu;
        private System.Windows.Forms.Button btnMonBanChay;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTongDoanhThuVal;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblMonBanChayVal;
        private System.Windows.Forms.Label lblMonBanChay;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMonBanChay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Button btnThongKeNhapKho;
        private System.Windows.Forms.Panel pnlDividerTop;
    }
}