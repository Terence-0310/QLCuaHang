using System;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Cau hinh va helper truy cap Database
    /// </summary>
    public static class DbConfig
    {
        /// <summary>
        /// Tao DbContext moi voi cau hinh chuan
        /// </summary>
        public static Model1 Create()
        {
            var db = new Model1();
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            // Đảm bảo không cache dữ liệu cũ
            db.Configuration.AutoDetectChangesEnabled = true;
            return db;
        }

        /// <summary>
        /// Su dung DbContext va tra ve ket qua (co try-catch)
        /// </summary>
        public static T Use<T>(Func<Model1, T> func)
        {
            Model1 db = null;
            try
            {
                db = Create();
                return func(db);
            }
            finally
            {
                db?.Dispose();
            }
        }

        /// <summary>
        /// Su dung DbContext khong tra ve ket qua (co try-catch)
        /// </summary>
        public static void Use(Action<Model1> action)
        {
            Model1 db = null;
            try
            {
                db = Create();
                action(db);
            }
            finally
            {
                db?.Dispose();
            }
        }

        /// <summary>
        /// Su dung DbContext voi ket qua va bat loi
        /// </summary>
        public static (bool ok, T result, string error) TryUse<T>(Func<Model1, T> func)
        {
            Model1 db = null;
            try
            {
                db = Create();
                var result = func(db);
                return (true, result, null);
            }
            catch (Exception ex)
            {
                return (false, default, GetInnerMsg(ex));
            }
            finally
            {
                db?.Dispose();
            }
        }

        /// <summary>
        /// Su dung DbContext khong ket qua va bat loi
        /// </summary>
        public static (bool ok, string error) TryUse(Action<Model1> action)
        {
            Model1 db = null;
            try
            {
                db = Create();
                action(db);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, GetInnerMsg(ex));
            }
            finally
            {
                db?.Dispose();
            }
        }

        /// <summary>
        /// Kiem tra ket noi database
        /// </summary>
        public static (bool ok, string msg) TestConnection()
        {
            Model1 db = null;
            try
            {
                db = Create();
                db.Database.Connection.Open();
                if (db.Database.Exists())
                {
                    // Kiểm tra thêm bằng query đơn giản
                    var serverVersion = db.Database.Connection.ServerVersion;
                    return (true, $"Kết nối thành công!\nServer: {db.Database.Connection.DataSource}\nDatabase: {db.Database.Connection.Database}\nSQL Server: {serverVersion}");
                }
                return (false, "Database không tồn tại!");
            }
            catch (Exception ex)
            {
                return (false, GetInnerMsg(ex));
            }
            finally
            {
                try { db?.Database?.Connection?.Close(); } catch { }
                db?.Dispose();
            }
        }

        /// <summary>
        /// Kiểm tra kết nối và đếm số bản ghi trong các bảng chính
        /// </summary>
        public static (bool ok, string msg) TestConnectionWithStats()
        {
            Model1 db = null;
            try
            {
                db = Create();
                db.Database.Connection.Open();

                if (!db.Database.Exists())
                    return (false, "Database không tồn tại!");

                // Đếm số bản ghi trong các bảng
                int vaiTroCount = 0, taiKhoanCount = 0, nhanVienCount = 0;
                int khachHangCount = 0, doUongCount = 0, hoaDonCount = 0;

                try { vaiTroCount = db.VaiTroes.Count(); } catch { }
                try { taiKhoanCount = db.TaiKhoans.Count(); } catch { }
                try { nhanVienCount = db.NhanViens.Count(); } catch { }
                try { khachHangCount = db.KhachHangs.Count(); } catch { }
                try { doUongCount = db.DoUongs.Count(); } catch { }
                try { hoaDonCount = db.HoaDons.Count(); } catch { }

                var stats = $"Kết nối thành công!\n" +
                           $"Server: {db.Database.Connection.DataSource}\n" +
                           $"Database: {db.Database.Connection.Database}\n\n" +
                           $"=== THỐNG KÊ DỮ LIỆU ===\n" +
                           $"• Vai trò: {vaiTroCount}\n" +
                           $"• Tài khoản: {taiKhoanCount}\n" +
                           $"• Nhân viên: {nhanVienCount}\n" +
                           $"• Khách hàng: {khachHangCount}\n" +
                           $"• Đồ uống: {doUongCount}\n" +
                           $"• Hóa đơn: {hoaDonCount}";

                return (true, stats);
            }
            catch (Exception ex)
            {
                return (false, GetInnerMsg(ex));
            }
            finally
            {
                try { db?.Database?.Connection?.Close(); } catch { }
                db?.Dispose();
            }
        }

        /// <summary>
        /// Làm mới dữ liệu từ database (bỏ cache)
        /// </summary>
        public static void RefreshEntity<T>(Model1 db, T entity) where T : class
        {
            try
            {
                db.Entry(entity).Reload();
            }
            catch { }
        }

        /// <summary>
        /// Lay message trong cung cua Exception
        /// </summary>
        public static string GetInnerMsg(Exception ex)
        {
            if (ex == null) return "L\u1ED7i kh\u00F4ng x\u00E1c \u0111\u1ECBnh";
            var inner = ex;
            while (inner.InnerException != null)
                inner = inner.InnerException;
            return inner.Message;
        }
    }
}
