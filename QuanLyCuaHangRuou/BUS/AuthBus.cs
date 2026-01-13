using System;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.BLL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Xác Th?c (Facade cho GUI)
    /// </summary>
    public static class AuthBus
    {
        /// <summary>
        /// ??ng nh?p
        /// </summary>
        public static BusResult<string> Login(string username, string password)
        {
            var (success, message, role) = AuthBll.Login(username, password);
            return success 
                ? BusResult<string>.Ok(role, message) 
                : BusResult<string>.Fail(message);
        }

        /// <summary>
        /// ??ng xu?t
        /// </summary>
        public static void Logout() => AuthBll.Logout();

        /// <summary>
        /// Ki?m tra ?ã ??ng nh?p
        /// </summary>
        public static bool IsLoggedIn => AuthBll.IsLoggedIn;
    }
}
