using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

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
                ShowError("L\u1ED7i khi kh\u1EDFi t\u1EA1o: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            try { UpdateClock(); } catch { }
        }

        private void UpdateClock()
        {
            try { lblTime.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy"); } catch { }
        }

        private void UpdateUserDisplay()
        {
            try
            {
                lblUser.Text = AppSession.CurrentUser ?? Res.NotLoggedIn;
                lblRole.Text = AppSession.IsAdmin ? Res.RoleAdmin
                             : AppSession.IsManager ? Res.RoleManager
                             : AppSession.IsStaff ? Res.RoleStaff
                             : "--";
            }
            catch { }
        }

        private void ApplyPermissions()
        {
            try
            {
                mnuNhanVien.Visible = AppSession.CanViewEmployees;
                mnuThongKe.Visible = AppSession.CanViewStatistics;
            }
            catch { }
        }

        // === MENU HANDLERS ===
        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmLogin())
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        AppSession.CurrentUser = frm.LoggedUser;
                        AppSession.CurrentRole = frm.LoggedRole;
                        UpdateUserDisplay();
                        ApplyPermissions();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("L\u1ED7i \u0111\u0103ng nh\u1EADp: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var child in MdiChildren)
                    try { child.Close(); } catch { }
                AppSession.Clear();
                UpdateUserDisplay();
                ApplyPermissions();
            }
            catch { }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, Res.ExitConfirm, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();
            }
            catch { Application.Exit(); }
        }

        private void mnuNhanVien_Click(object sender, EventArgs e) => SafeOpenChild<FrmNhanVien>();
        private void mnuDoUong_Click(object sender, EventArgs e) => SafeOpenChild<FrmDoUong>();
        private void mnuKhachHang_Click(object sender, EventArgs e) => SafeOpenChild<FrmKhachHang>();
        private void mnuBanHang_Click(object sender, EventArgs e) => SafeOpenChild<FrmBanHang>();
        private void mnuKyGuiRuou_Click(object sender, EventArgs e) => SafeOpenChild<FrmKyGuiRuou>();
        private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e) => SafeOpenChild<FrmBaoCaoDoanhThu>();
        private void mnuBaoCaoTonKho_Click(object sender, EventArgs e) => SafeOpenChild<FrmBaoCaoTonKho>();

        private void SafeOpenChild<T>() where T : Form, new()
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
                ShowError("L\u1ED7i khi m\u1EDF form: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
