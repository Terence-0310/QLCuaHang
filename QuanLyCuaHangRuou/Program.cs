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

                // Global exception handlers - đảm bảo ứng dụng không crash
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
                var msg = "Có lỗi xảy ra. Vui lòng thử lại.";
                if (ex != null)
                {
                    var inner = ex;
                    while (inner.InnerException != null)
                        inner = inner.InnerException;
                    msg += "\n\nChi tiết: " + inner.Message;
                }
                MessageBox.Show(msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                // Trong trường hợp hiếm hoi không thể hiện MessageBox
                try { Console.WriteLine("Fatal error: " + ex?.Message); } catch { }
            }
        }

        private static void ShowFatalError(Exception ex)
        {
            try
            {
                var msg = "Lỗi nghiêm trọng khi khởi động ứng dụng!";
                if (ex != null) msg += "\n\n" + ex.Message;
                MessageBox.Show(msg, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch { }
        }
    }
}
