using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmMain : Form
    {
        public FrmMain() : this("", "") { }

        public FrmMain(string user, string role)
        {
            InitializeComponent();
            AppSession.CurrentUser = string.IsNullOrWhiteSpace(user) ? null : user;
            AppSession.CurrentRole = string.IsNullOrWhiteSpace(role) ? null : role;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateUserDisplay();
                ApplyPermissions();
                UpdateClock();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi khởi tạo: " + ex.Message);
            }
        }

        private void timerClock_Tick(object sender, EventArgs e) => UpdateClock();

        private void UpdateClock() => lblTime.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");

        private void UpdateUserDisplay()
        {
            lblUser.Text = AppSession.CurrentUser ?? Res.NotLoggedIn;
            lblRole.Text = AppSession.IsAdmin ? Res.RoleAdmin
                         : AppSession.IsManager ? Res.RoleManager
                         : AppSession.IsStaff ? Res.RoleStaff
                         : AppSession.IsWarehouse ? Res.RoleWarehouse
                         : "--";
        }

        private void ApplyPermissions()
        {
            mnuNhanVien.Visible = AppSession.CanViewEmployees;
            mnuThongKe.Visible = AppSession.CanViewStatistics;
        }

        // === MENU HANDLERS ===
        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmLogin())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateUserDisplay();
                    ApplyPermissions();
                }
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (var child in MdiChildren)
                try { child.Close(); } catch { }
            
            AuthBus.Logout();
            UpdateUserDisplay();
            ApplyPermissions();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Res.ExitConfirm, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e) => OpenChild<FrmNhanVien>();
        private void mnuDoUong_Click(object sender, EventArgs e) => OpenChild<FrmDoUong>();
        private void mnuKhachHang_Click(object sender, EventArgs e) => OpenChild<FrmKhachHang>();
        private void mnuBanHang_Click(object sender, EventArgs e) => OpenChild<FrmBanHang>();
        private void mnuLichSuHoaDon_Click(object sender, EventArgs e) => OpenChild<FrmLichSuHoaDon>();
        private void mnuKyGuiRuou_Click(object sender, EventArgs e) => OpenChild<FrmKyGuiRuou>();
        private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e) => OpenChild<FrmBaoCaoDoanhThu>();
        private void mnuBaoCaoTonKho_Click(object sender, EventArgs e) => OpenChild<FrmBaoCaoTonKho>();

        private void OpenChild<T>() where T : Form, new()
        {
            try
            {
                foreach (var child in MdiChildren)
                {
                    if (child is T)
                    {
                        child.Activate();
                        child.BringToFront();
                        if (child.WindowState == FormWindowState.Minimized)
                            child.WindowState = FormWindowState.Maximized;
                        return;
                    }
                }
                var frm = new T { MdiParent = this };
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi mở form: " + ex.Message);
            }
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void mnuHeThong_Click(object sender, EventArgs e)
        {

        }
    }
}
