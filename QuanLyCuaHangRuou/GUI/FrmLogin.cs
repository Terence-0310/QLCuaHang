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
                var conn = DbConfig.TestConnection();
                if (!conn.ok)
                    ShowError(conn.msg + "\n\nKiểm tra App.config và SQL Server.");
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi khởi tạo: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUsername.Text.Trim();
                string pass = txtPassword.Text;

                if (user.Length == 0) { ShowWarn(Res.EnterUsername); txtUsername.Focus(); return; }
                if (pass.Length == 0) { ShowWarn(Res.EnterPassword); txtPassword.Focus(); return; }

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
                ShowError("Lỗi đăng nhập: " + DbConfig.GetInnerMsg(ex));
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
