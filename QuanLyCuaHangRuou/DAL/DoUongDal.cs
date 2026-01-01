using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    public static class DoUongDal
    {
        public sealed class DoUongGridRow
        {
            public string MaDoUong { get; set; }
            public string TenDoUong { get; set; }
            public decimal DonGia { get; set; }
            public decimal SoLuongTon { get; set; }
            public string DonViTinh { get; set; }
            public decimal? DungTich { get; set; }
            public DateTime? HanSuDung { get; set; }
            public string GhiChu { get; set; }
            public string TrangThai { get; set; }
            public string HinhPath { get; set; }
            public string TenLoai { get; set; }
            public string MaLoai { get; set; }
        }

        public static List<DoUongGridRow> GetAllForGrid() => DbConfig.Use(db =>
            db.DoUongs.Select(x => new DoUongGridRow
            {
                MaDoUong = x.MaDoUong, TenDoUong = x.TenDoUong, DonGia = x.DonGia,
                SoLuongTon = x.SoLuongTon, DonViTinh = x.DonViTinh,
                DungTich = x.DungTich, HanSuDung = x.HanSuDung,
                GhiChu = x.GhiChu, TrangThai = x.TrangThai, HinhPath = x.HinhPath,
                TenLoai = x.LoaiDoUong.TenLoai, MaLoai = x.MaLoai
            }).ToList());

        public static List<DoUongGridRow> SearchForGrid(string kw) => DbConfig.Use(db =>
        {
            kw = (kw ?? "").Trim();
            var q = db.DoUongs.AsQueryable();
            if (kw.Length > 0)
                q = q.Where(x => x.MaDoUong.Contains(kw) || x.TenDoUong.Contains(kw));
            return q.Select(x => new DoUongGridRow
            {
                MaDoUong = x.MaDoUong, TenDoUong = x.TenDoUong, DonGia = x.DonGia,
                SoLuongTon = x.SoLuongTon, DonViTinh = x.DonViTinh,
                DungTich = x.DungTich, HanSuDung = x.HanSuDung,
                GhiChu = x.GhiChu, TrangThai = x.TrangThai, HinhPath = x.HinhPath,
                TenLoai = x.LoaiDoUong.TenLoai, MaLoai = x.MaLoai
            }).ToList();
        });

        public static DoUong GetById(string id) =>
            string.IsNullOrWhiteSpace(id) ? null : DbConfig.Use(db => db.DoUongs.FirstOrDefault(x => x.MaDoUong == id));

        public static void Add(DoUong e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.MaDoUong) || string.IsNullOrWhiteSpace(e.TenDoUong))
                throw new ArgumentException("Mã và tên đồ uống không hợp lệ");

            DbConfig.Use(db =>
            {
                if (string.IsNullOrWhiteSpace(e.MaLoai))
                    e.MaLoai = db.LoaiDoUongs.Select(x => x.MaLoai).FirstOrDefault() ?? "LOAI01";
                if (string.IsNullOrWhiteSpace(e.DonViTinh)) e.DonViTinh = "Chai";
                if (string.IsNullOrWhiteSpace(e.TrangThai)) e.TrangThai = Res.StatusInStock;
                db.DoUongs.Add(e);
                db.SaveChanges();
            });
        }

        public static void Update(DoUong e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.MaDoUong))
                throw new ArgumentException("Mã đồ uống không hợp lệ");

            DbConfig.Use(db =>
            {
                var ex = db.DoUongs.FirstOrDefault(x => x.MaDoUong == e.MaDoUong)
                    ?? throw new InvalidOperationException("Không tìm thấy đồ uống");
                ex.TenDoUong = e.TenDoUong;
                ex.DonGia = e.DonGia;
                ex.SoLuongTon = e.SoLuongTon;
                ex.DungTich = e.DungTich;
                ex.HanSuDung = e.HanSuDung;
                ex.GhiChu = e.GhiChu;
                ex.HinhPath = e.HinhPath;
                db.SaveChanges();
            });
        }

        public static void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã đồ uống không hợp lệ");

            using (var db = DbConfig.Create())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var e = db.DoUongs.FirstOrDefault(x => x.MaDoUong == id)
                        ?? throw new InvalidOperationException("Không tìm thấy đồ uống");

                    bool hasCT = db.ChiTietHoaDons.Any(x => x.MaDoUong == id);
                    bool hasKG = db.KyGuiRuous.Any(x => x.MaDoUong == id);

                    if (AppSession.IsAdmin)
                    {
                        db.ChiTietHoaDons.RemoveRange(db.ChiTietHoaDons.Where(x => x.MaDoUong == id));
                        foreach (var kg in db.KyGuiRuous.Where(x => x.MaDoUong == id)) kg.MaDoUong = null;
                        db.DoUongs.Remove(e);
                    }
                    else if (hasCT || hasKG)
                    {
                        e.TrangThai = Res.StatusOutOfStock;
                        db.SaveChanges();
                        tx.Commit();
                        var reason = (hasCT ? Res.RelatedInvoice : "") + (hasKG ? (hasCT ? ", " : "") + Res.RelatedConsignment : "");
                        throw new InvalidOperationException(Res.SoftDeleteDrink(reason));
                    }
                    else
                    {
                        db.DoUongs.Remove(e);
                    }

                    db.SaveChanges();
                    tx.Commit();
                }
                catch (InvalidOperationException) { throw; }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("Lỗi khi xóa đồ uống: " + DbConfig.GetInnerMsg(ex), ex);
                }
            }
        }
    }
}
