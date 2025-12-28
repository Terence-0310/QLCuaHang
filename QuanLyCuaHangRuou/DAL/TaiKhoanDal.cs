using System;
using System.Data.Entity;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quan ly tai khoan
    /// </summary>
    public static class TaiKhoanDal
    {
        public static TaiKhoan GetByUsername(string username)
        {
            username = (username ?? "").Trim();
            return DbConfig.Use(db => db.TaiKhoans.Include(t => t.VaiTro).FirstOrDefault(x => x.Username == username));
        }

        public static bool ExistsUsername(string username)
        {
            username = (username ?? "").Trim();
            return username.Length > 0 && DbConfig.Use(db => db.TaiKhoans.Any(x => x.Username == username));
        }

        public static void Add(TaiKhoan entity)
        {
            DbConfig.Use(db => { db.TaiKhoans.Add(entity); db.SaveChanges(); });
        }

        public static void Update(TaiKhoan entity)
        {
            DbConfig.Use(db => { db.Entry(entity).State = EntityState.Modified; db.SaveChanges(); });
        }

        public static string GenerateMaTK() => "TK" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
