namespace QuanLyCuaHangRuou.GUI
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoUong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLichSuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuKyGuiRuou = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuNghiepVu,
            this.mnuThongKe});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1200, 31);
            this.menuStrip.TabIndex = 1;
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuDangXuat,
            this.mnuNhanVien,
            this.toolStripSeparator1,
            this.mnuThoat});
            this.mnuHeThong.Image = ((System.Drawing.Image)(resources.GetObject("mnuHeThong.Image")));
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(116, 27);
            this.mnuHeThong.Text = "Hệ thống";
            this.mnuHeThong.Click += new System.EventHandler(this.mnuHeThong_Click);
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("mnuDangNhap.Image")));
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuDangNhap.Size = new System.Drawing.Size(236, 28);
            this.mnuDangNhap.Text = "Đăng nhập";
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("mnuDangXuat.Image")));
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(236, 28);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("mnuNhanVien.Image")));
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(236, 28);
            this.mnuNhanVien.Text = "Quản lý nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(236, 28);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoUong,
            this.mnuKhachHang});
            this.mnuDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("mnuDanhMuc.Image")));
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(123, 27);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuDoUong
            // 
            this.mnuDoUong.Image = ((System.Drawing.Image)(resources.GetObject("mnuDoUong.Image")));
            this.mnuDoUong.Name = "mnuDoUong";
            this.mnuDoUong.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuDoUong.Size = new System.Drawing.Size(212, 28);
            this.mnuDoUong.Text = "Đồ uống";
            this.mnuDoUong.Click += new System.EventHandler(this.mnuDoUong_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("mnuKhachHang.Image")));
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuKhachHang.Size = new System.Drawing.Size(212, 28);
            this.mnuKhachHang.Text = "Khách hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuNghiepVu
            // 
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBanHang,
            this.mnuLichSuHoaDon,
            this.toolStripSeparator2,
            this.mnuKyGuiRuou});
            this.mnuNghiepVu.Image = ((System.Drawing.Image)(resources.GetObject("mnuNghiepVu.Image")));
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Size = new System.Drawing.Size(123, 27);
            this.mnuNghiepVu.Text = "Nghiệp vụ";
            // 
            // mnuBanHang
            // 
            this.mnuBanHang.Image = ((System.Drawing.Image)(resources.GetObject("mnuBanHang.Image")));
            this.mnuBanHang.Name = "mnuBanHang";
            this.mnuBanHang.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuBanHang.Size = new System.Drawing.Size(242, 28);
            this.mnuBanHang.Text = "Bán hàng";
            this.mnuBanHang.Click += new System.EventHandler(this.mnuBanHang_Click);
            // 
            // mnuLichSuHoaDon
            // 
            this.mnuLichSuHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("mnuLichSuHoaDon.Image")));
            this.mnuLichSuHoaDon.Name = "mnuLichSuHoaDon";
            this.mnuLichSuHoaDon.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuLichSuHoaDon.Size = new System.Drawing.Size(242, 28);
            this.mnuLichSuHoaDon.Text = "Lịch sử hóa đơn";
            this.mnuLichSuHoaDon.Click += new System.EventHandler(this.mnuLichSuHoaDon_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(239, 6);
            // 
            // mnuKyGuiRuou
            // 
            this.mnuKyGuiRuou.Image = ((System.Drawing.Image)(resources.GetObject("mnuKyGuiRuou.Image")));
            this.mnuKyGuiRuou.Name = "mnuKyGuiRuou";
            this.mnuKyGuiRuou.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuKyGuiRuou.Size = new System.Drawing.Size(242, 28);
            this.mnuKyGuiRuou.Text = "Ký gửi rượu";
            this.mnuKyGuiRuou.Click += new System.EventHandler(this.mnuKyGuiRuou_Click);
            // 
            // mnuThongKe
            // 
            this.mnuThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBaoCaoDoanhThu,
            this.mnuBaoCaoTonKho});
            this.mnuThongKe.Image = ((System.Drawing.Image)(resources.GetObject("mnuThongKe.Image")));
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Size = new System.Drawing.Size(105, 27);
            this.mnuThongKe.Text = "Báo cáo";
            // 
            // mnuBaoCaoDoanhThu
            // 
            this.mnuBaoCaoDoanhThu.Image = ((System.Drawing.Image)(resources.GetObject("mnuBaoCaoDoanhThu.Image")));
            this.mnuBaoCaoDoanhThu.Name = "mnuBaoCaoDoanhThu";
            this.mnuBaoCaoDoanhThu.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuBaoCaoDoanhThu.Size = new System.Drawing.Size(203, 28);
            this.mnuBaoCaoDoanhThu.Text = "Doanh thu";
            this.mnuBaoCaoDoanhThu.Click += new System.EventHandler(this.mnuBaoCaoDoanhThu_Click);
            // 
            // mnuBaoCaoTonKho
            // 
            this.mnuBaoCaoTonKho.Image = ((System.Drawing.Image)(resources.GetObject("mnuBaoCaoTonKho.Image")));
            this.mnuBaoCaoTonKho.Name = "mnuBaoCaoTonKho";
            this.mnuBaoCaoTonKho.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnuBaoCaoTonKho.Size = new System.Drawing.Size(203, 28);
            this.mnuBaoCaoTonKho.Text = "Tồn kho";
            this.mnuBaoCaoTonKho.Click += new System.EventHandler(this.mnuBaoCaoTonKho_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblRole,
            this.lblSpacer,
            this.lblTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 670);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 30);
            this.statusStrip.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(118, 24);
            this.lblUser.Text = "Chưa đăng nhập";
            // 
            // lblRole
            // 
            this.lblRole.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(25, 24);
            this.lblRole.Text = "--";
            // 
            // lblSpacer
            // 
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Size = new System.Drawing.Size(975, 24);
            this.lblSpacer.Spring = true;
            // 
            // lblTime
            // 
            this.lblTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(67, 24);
            this.lblTime.Text = "00:00:00";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Cửa Hàng Rượu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuDoUong;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem mnuBanHang;
        private System.Windows.Forms.ToolStripMenuItem mnuLichSuHoaDon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuKyGuiRuou;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCaoTonKho;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblRole;
        private System.Windows.Forms.ToolStripStatusLabel lblSpacer;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timerClock;
    }
}
