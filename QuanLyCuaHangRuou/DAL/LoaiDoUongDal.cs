using System.Collections.Generic;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quan ly loai do uong
    /// </summary>
    public static class LoaiDoUongDal
    {
        public static List<LoaiDoUong> GetAll() =>
            DbConfig.Use(db => db.LoaiDoUongs.AsNoTracking().OrderBy(x => x.TenLoai).ToList());

        public static LoaiDoUong GetById(string id) =>
            DbConfig.Use(db => db.LoaiDoUongs.FirstOrDefault(x => x.MaLoai == id));

        /// <summary>
        /// Lấy mã loại mặc định
        /// </summary>
        public static string GetDefaultCategoryCode() =>
            DbConfig.Use(db => db.LoaiDoUongs.Select(x => x.MaLoai).FirstOrDefault()) ?? "LOAI01";
    }
}
