using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
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
                ShowError("Lỗi khi khởi tạo: " + ex.Message);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            Application.DoEvents();

            try
            {
                string user = txtUsername.Text.Trim();
                string pass = txtPassword.Text;

                var result = AuthBus.Login(user, pass);

                if (!result.Success)
                {
                    ShowWarn(result.Message ?? Res.LoginFailed);
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    return;
                }

                LoggedUser = user;
                LoggedRole = result.Data;
                DialogResult = DialogResult.OK;
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
