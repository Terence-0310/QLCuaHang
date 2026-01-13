using System;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BLL
{
    /// <summary>
    /// Business Logic Layer cho Xác Th?c
    /// </summary>
    public static class AuthBll
    {
        #region Validation

        /// <summary>
        /// Validate thông tin ??ng nh?p
        /// </summary>
        public static string ValidateLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                return Res.EnterUsername;

            if (string.IsNullOrEmpty(password))
                return Res.EnterPassword;

            return null;
        }

        #endregion

        #region Business Operations

        /// <summary>
        /// ??ng nh?p
        /// </summary>
        public static (bool success, string message, string role) Login(string username, string password)
        {
            try
            {
                username = (username ?? "").Trim();

                // Validate
                var error = ValidateLogin(username, password);
                if (error != null)
                    return (false, error, null);

                // G?i DAL
                var result = AuthDal.Login(username, password);
                if (!result.ok)
                    return (false, result.error, null);

                // Thi?t l?p session
                AppSession.CurrentUser = username;
                AppSession.CurrentRole = result.role;
                
                try 
                { 
                    AppSession.CurrentMaNV = NhanVienDal.GetByUsername(username)?.MaNV; 
                } 
                catch { }

                return (true, "??ng nh?p thành công!", result.role);
            }
            catch (Exception ex)
            {
                return (false, "L?i ??ng nh?p: " + ex.Message, null);
            }
        }

        /// <summary>
        /// ??ng xu?t
        /// </summary>
        public static void Logout()
        {
            AppSession.Clear();
        }

        /// <summary>
        /// Ki?m tra ?ã ??ng nh?p ch?a
        /// </summary>
        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(AppSession.CurrentUser);

        #endregion
    }
}
