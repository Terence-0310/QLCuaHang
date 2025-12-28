using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Bao cao thong ke
    /// </summary>
    public static class ReportDal
    {
        public sealed class DoanhThuRow
        {
            public DateTime Ngay { get; set; }
            public int SoHoaDon { get; set; }
            public decimal TongTien { get; set; }
        }

        public static List<DoanhThuRow> GetDoanhThuByDateRange(DateTime from, DateTime to) => DbConfig.Use(db =>
        {
            from = from.Date;
            var toEnd = to.Date.AddDays(1);
            return db.HoaDons
                .Where(x => x.NgayHoaDon >= from && x.NgayHoaDon < toEnd)
                .GroupBy(x => DbFunctions.TruncateTime(x.NgayHoaDon))
                .Select(g => new DoanhThuRow
                {
                    Ngay = g.Key.Value,
                    SoHoaDon = g.Count(),
                    TongTien = g.Sum(x => x.TongTien)
                })
                .OrderBy(x => x.Ngay)
                .ToList();
        });

        public static List<vw_TonKho> GetTonKho() =>
            DbConfig.Use(db => db.vw_TonKho.AsNoTracking().ToList());

        public static List<vw_TonKho> SearchTonKho(string kw) => DbConfig.Use(db =>
        {
            kw = (kw ?? "").Trim();
            var q = db.vw_TonKho.AsNoTracking().AsQueryable();
            if (kw.Length > 0)
                q = q.Where(x => x.MaDoUong.Contains(kw) || x.TenDoUong.Contains(kw) || x.TenLoai.Contains(kw));
            return q.ToList();
        });
    }
}
