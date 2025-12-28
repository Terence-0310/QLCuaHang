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
            // menuStrip
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuNghiepVu,
            this.mnuThongKe});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1200, 27);
            // mnuHeThong
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuDangXuat,
            this.mnuNhanVien,
            this.toolStripSeparator1,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Text = "H\u1EC7 th\u1ED1ng";
            // mnuDangNhap
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuDangNhap.Text = "\u0110\u0103ng nh\u1EADp";
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            // mnuDangXuat
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Text = "\u0110\u0103ng xu\u1EA5t";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // mnuNhanVien
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Text = "Qu\u1EA3n l\u00FD nh\u00E2n vi\u00EAn";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // toolStripSeparator1
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // mnuThoat
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Text = "Tho\u00E1t";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // mnuDanhMuc
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoUong,
            this.mnuKhachHang});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Text = "Danh m\u1EE5c";
            // mnuDoUong
            this.mnuDoUong.Name = "mnuDoUong";
            this.mnuDoUong.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuDoUong.Text = "\u0110\u1ED3 u\u1ED1ng";
            this.mnuDoUong.Click += new System.EventHandler(this.mnuDoUong_Click);
            // mnuKhachHang
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuKhachHang.Text = "Kh\u00E1ch h\u00E0ng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // mnuNghiepVu
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBanHang,
            this.mnuKyGuiRuou});
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Text = "Nghi\u1EC7p v\u1EE5";
            // mnuBanHang
            this.mnuBanHang.Name = "mnuBanHang";
            this.mnuBanHang.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuBanHang.Text = "B\u00E1n h\u00E0ng";
            this.mnuBanHang.Click += new System.EventHandler(this.mnuBanHang_Click);
            // mnuKyGuiRuou
            this.mnuKyGuiRuou.Name = "mnuKyGuiRuou";
            this.mnuKyGuiRuou.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuKyGuiRuou.Text = "K\u00FD g\u1EEDi r\u01B0\u1EE3u";
            this.mnuKyGuiRuou.Click += new System.EventHandler(this.mnuKyGuiRuou_Click);
            // mnuThongKe
            this.mnuThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBaoCaoDoanhThu,
            this.mnuBaoCaoTonKho});
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Text = "B\u00E1o c\u00E1o";
            // mnuBaoCaoDoanhThu
            this.mnuBaoCaoDoanhThu.Name = "mnuBaoCaoDoanhThu";
            this.mnuBaoCaoDoanhThu.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuBaoCaoDoanhThu.Text = "Doanh thu";
            this.mnuBaoCaoDoanhThu.Click += new System.EventHandler(this.mnuBaoCaoDoanhThu_Click);
            // mnuBaoCaoTonKho
            this.mnuBaoCaoTonKho.Name = "mnuBaoCaoTonKho";
            this.mnuBaoCaoTonKho.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnuBaoCaoTonKho.Text = "T\u1ED3n kho";
            this.mnuBaoCaoTonKho.Click += new System.EventHandler(this.mnuBaoCaoTonKho_Click);
            // statusStrip
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblRole,
            this.lblSpacer,
            this.lblTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 678);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            // lblUser
            this.lblUser.Name = "lblUser";
            this.lblUser.Text = "Ch\u01B0a \u0111\u0103ng nh\u1EADp";
            // lblRole
            this.lblRole.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblRole.Name = "lblRole";
            this.lblRole.Text = "--";
            // lblSpacer
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Spring = true;
            // lblTime
            this.lblTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "00:00:00";
            // timerClock
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // FrmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qu\u1EA3n L\u00FD C\u1EEDa H\u00E0ng R\u01B0\u1EE3u";
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
