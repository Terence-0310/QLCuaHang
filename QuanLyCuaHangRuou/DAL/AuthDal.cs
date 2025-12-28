using System;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Xu ly dang nhap - co try-catch day du
    /// </summary>
    public static class AuthDal
    {
        public static (bool ok, string role, string error) Login(string username, string password)
        {
            try
            {
                // Validate input
                username = (username ?? "").Trim();
                password = password ?? "";

                if (username.Length == 0) return (false, null, Res.EnterUsername);
                if (password.Length == 0) return (false, null, Res.EnterPassword);

                // Kiem tra ket noi truoc
                var connTest = DbConfig.TestConnection();
                if (!connTest.ok) return (false, null, Res.DbConnectionError + "\n" + connTest.msg);

                // Tim tai khoan
                TaiKhoan tk = null;
                try
                {
                    tk = TaiKhoanDal.GetByUsername(username);
                }
                catch (Exception ex)
                {
                    return (false, null, Res.DbConnectionError + "\n" + DbConfig.GetInnerMsg(ex));
                }

                // Validate tai khoan
                if (tk == null) return (false, null, Res.LoginFailed);
                if (!tk.TrangThai) return (false, null, Res.LoginFailed);
                if (tk.Password != password) return (false, null, Res.LoginFailed);

                // Lay role
                var role = (tk.MaVaiTro ?? PermissionKeys.RoleStaff).Trim().ToUpperInvariant();
                return (true, role, null);
            }
            catch (Exception ex)
            {
                return (false, null, Res.DbConnectionError + "\n" + DbConfig.GetInnerMsg(ex));
            }
        }
    }
}
