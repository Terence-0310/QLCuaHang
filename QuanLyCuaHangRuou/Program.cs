using System;
using System.Threading;
using System.Windows.Forms;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.GUI;

namespace QuanLyCuaHangRuou
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Global exception handlers - dam bao ung dung khong crash
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += OnThreadException;
                AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

                // Login
                using (var login = new FrmLogin())
                {
                    var result = login.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        AppSession.CurrentUser = login.LoggedUser;
                        AppSession.CurrentRole = login.LoggedRole;
                        Application.Run(new FrmMain(login.LoggedUser, login.LoggedRole));
                    }
                }
            }
            catch (Exception ex)
            {
                ShowFatalError(ex);
            }
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowError(e.Exception);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowError(e.ExceptionObject as Exception);
        }

        private static void ShowError(Exception ex)
        {
            try
            {
                var msg = "C\u00F3 l\u1ED7i x\u1EA3y ra. Vui l\u00F2ng th\u1EED l\u1EA1i.";
                if (ex != null)
                {
                    var inner = ex;
                    while (inner.InnerException != null)
                        inner = inner.InnerException;
                    msg += "\n\nChi ti\u1EBFt: " + inner.Message;
                }
                MessageBox.Show(msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                // Trong truong hop hiem hoi khong the hien MessageBox
                try { Console.WriteLine("Fatal error: " + ex?.Message); } catch { }
            }
        }

        private static void ShowFatalError(Exception ex)
        {
            try
            {
                var msg = "L\u1ED7i nghi\u00EAm tr\u1ECDng khi kh\u1EDFi \u0111\u1ED9ng \u1EE9ng d\u1EE5ng!";
                if (ex != null) msg += "\n\n" + ex.Message;
                MessageBox.Show(msg, "L\u1ED7i h\u1EC7 th\u1ED1ng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch { }
        }
    }
}
