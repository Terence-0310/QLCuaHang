using System;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Cấu hình và helper truy cập Database
    /// </summary>
    public static class DbConfig
    {
        /// <summary>
        /// Tạo DbContext mới
        /// </summary>
        public static Model1 Create()
        {
            var db = new Model1();
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            return db;
        }

        /// <summary>
        /// Sử dụng DbContext với kết quả
        /// </summary>
        public static T Use<T>(Func<Model1, T> func)
        {
            using (var db = Create())
                return func(db);
        }

        /// <summary>
        /// Sử dụng DbContext không kết quả
        /// </summary>
        public static void Use(Action<Model1> action)
        {
            using (var db = Create())
                action(db);
        }

        /// <summary>
        /// Kiểm tra kết nối database
        /// </summary>
        public static (bool ok, string msg) TestConnection()
        {
            try
            {
                using (var db = Create())
                {
                    db.Database.Connection.Open();
                    if (!db.Database.Exists())
                        return (false, "Database không tồn tại!");

                    var stats = $"Kết nối thành công!\n" +
                               $"Server: {db.Database.Connection.DataSource}\n" +
                               $"Database: {db.Database.Connection.Database}\n\n" +
                               $"Vai trò: {db.VaiTroes.Count()}, " +
                               $"Tài khoản: {db.TaiKhoans.Count()}, " +
                               $"Đồ uống: {db.DoUongs.Count()}";
                    return (true, stats);
                }
            }
            catch (Exception ex)
            {
                return (false, GetInnerMsg(ex));
            }
        }

        /// <summary>
        /// Lấy message trong cùng của Exception
        /// </summary>
        public static string GetInnerMsg(Exception ex)
        {
            if (ex == null) return "Lỗi không xác định";
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex.Message;
        }
    }
}
