using System;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Xử lý đăng nhập
    /// </summary>
    public static class AuthDal
    {
        public static (bool ok, string role, string error) Login(string username, string password)
        {
            try
            {
                username = (username ?? "").Trim();
                password = password ?? "";

                if (username.Length == 0) return (false, null, Res.EnterUsername);
                if (password.Length == 0) return (false, null, Res.EnterPassword);

                var connTest = DbConfig.TestConnection();
                if (!connTest.ok) return (false, null, Res.DbConnectionError + "\n" + connTest.msg);

                TaiKhoan tk = null;
                try { tk = TaiKhoanDal.GetByUsername(username); }
                catch (Exception ex) { return (false, null, Res.DbConnectionError + "\n" + DbConfig.GetInnerMsg(ex)); }

                if (tk == null || !tk.TrangThai || tk.Password != password)
                    return (false, null, Res.LoginFailed);

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
