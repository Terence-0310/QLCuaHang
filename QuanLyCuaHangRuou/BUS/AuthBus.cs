using System;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Xác Thực
    /// </summary>
    public static class AuthBus
    {
        /// <summary>
        /// Đăng nhập
        /// </summary>
        public static BusResult<string> Login(string username, string password)
        {
            try
            {
                username = (username ?? "").Trim();
                if (username.Length == 0)
                    return BusResult<string>.Fail(Res.EnterUsername);

                if (string.IsNullOrEmpty(password))
                    return BusResult<string>.Fail(Res.EnterPassword);

                var result = AuthDal.Login(username, password);
                if (!result.ok)
                    return BusResult<string>.Fail(result.error);

                // Thi?t l?p session
                AppSession.CurrentUser = username;
                AppSession.CurrentRole = result.role;
                try { AppSession.CurrentMaNV = NhanVienDal.GetByUsername(username)?.MaNV; } catch { }

                return BusResult<string>.Ok(result.role);
            }
            catch (Exception ex)
            {
                return BusResult<string>.Fail("L?i ??ng nh?p: " + ex.Message);
            }
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        public static void Logout() => AppSession.Clear();

        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(AppSession.CurrentUser);
    }
}
