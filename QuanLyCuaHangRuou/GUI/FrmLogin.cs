using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmLogin : Form
    {
        public string LoggedUser { get; private set; }
        public string LoggedRole { get; private set; }

        public FrmLogin() { InitializeComponent(); }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiem tra ket noi khi load form
                var conn = DbConfig.TestConnection();
                if (!conn.ok)
                    ShowError(conn.msg + "\n\nKiem tra App.config va SQL Server.");
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                ShowError("Loi khi khoi tao: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            try { txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*'; }
            catch { }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUsername.Text.Trim();
                string pass = txtPassword.Text;

                if (user.Length == 0) { ShowWarn(Res.EnterUsername); txtUsername.Focus(); return; }
                if (pass.Length == 0) { ShowWarn(Res.EnterPassword); txtPassword.Focus(); return; }

                // Disable button de tranh click nhieu lan
                btnLogin.Enabled = false;
                Application.DoEvents();

                var result = AuthDal.Login(user, pass);

                if (!result.ok)
                {
                    ShowWarn(result.error ?? Res.LoginFailed);
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    return;
                }

                LoggedUser = user;
                LoggedRole = result.role;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ShowError("Loi dang nhap: " + DbConfig.GetInnerMsg(ex));
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try { DialogResult = DialogResult.Cancel; }
            catch { Application.Exit(); }
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
