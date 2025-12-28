using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quan ly do uong - co try-catch day du
    /// </summary>
    public static class DoUongDal
    {
        public sealed class DoUongGridRow
        {
            public string MaDoUong { get; set; }
            public string TenDoUong { get; set; }
            public decimal DonGia { get; set; }
            public decimal SoLuongTon { get; set; }
            public string DonViTinh { get; set; }
            public string GhiChu { get; set; }
            public string TrangThai { get; set; }
            public string HinhPath { get; set; }
            public string TenLoai { get; set; }
            public string MaLoai { get; set; }
        }

        public static List<DoUongGridRow> GetAllForGrid()
        {
            try
            {
                return DbConfig.Use(db =>
                    db.DoUongs.Select(x => new DoUongGridRow
                    {
                        MaDoUong = x.MaDoUong, TenDoUong = x.TenDoUong, DonGia = x.DonGia,
                        SoLuongTon = x.SoLuongTon, DonViTinh = x.DonViTinh, GhiChu = x.GhiChu,
                        TrangThai = x.TrangThai, HinhPath = x.HinhPath,
                        TenLoai = x.LoaiDoUong.TenLoai, MaLoai = x.MaLoai
                    }).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("L\u1ED7i khi t\u1EA3i danh s\u00E1ch \u0111\u1ED3 u\u1ED1ng: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static List<DoUongGridRow> SearchForGrid(string kw)
        {
            try
            {
                return DbConfig.Use(db =>
                {
                    kw = (kw ?? "").Trim();
                    var q = db.DoUongs.AsQueryable();
                    if (kw.Length > 0)
                        q = q.Where(x => x.MaDoUong.Contains(kw) || x.TenDoUong.Contains(kw));
                    return q.Select(x => new DoUongGridRow
                    {
                        MaDoUong = x.MaDoUong, TenDoUong = x.TenDoUong, DonGia = x.DonGia,
                        SoLuongTon = x.SoLuongTon, DonViTinh = x.DonViTinh, GhiChu = x.GhiChu,
                        TrangThai = x.TrangThai, HinhPath = x.HinhPath,
                        TenLoai = x.LoaiDoUong.TenLoai, MaLoai = x.MaLoai
                    }).ToList();
                });
            }
            catch (Exception ex)
            {
                throw new Exception("L\u1ED7i khi t\u00ECm ki\u1EBFm \u0111\u1ED3 u\u1ED1ng: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static DoUong GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return null;
                return DbConfig.Use(db => db.DoUongs.FirstOrDefault(x => x.MaDoUong == id));
            }
            catch { return null; }
        }

        public static void Add(DoUong e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (string.IsNullOrWhiteSpace(e.MaDoUong)) throw new ArgumentException("M\u00E3 \u0111\u1ED3 u\u1ED1ng kh\u00F4ng h\u1EE3p l\u1EC7");
            if (string.IsNullOrWhiteSpace(e.TenDoUong)) throw new ArgumentException("T\u00EAn \u0111\u1ED3 u\u1ED1ng kh\u00F4ng h\u1EE3p l\u1EC7");

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
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (string.IsNullOrWhiteSpace(e.MaDoUong)) throw new ArgumentException("M\u00E3 \u0111\u1ED3 u\u1ED1ng kh\u00F4ng h\u1EE3p l\u1EC7");

            DbConfig.Use(db =>
            {
                var ex = db.DoUongs.FirstOrDefault(x => x.MaDoUong == e.MaDoUong);
                if (ex == null) throw new InvalidOperationException("Kh\u00F4ng t\u00ECm th\u1EA5y \u0111\u1ED3 u\u1ED1ng");
                ex.TenDoUong = e.TenDoUong;
                ex.DonGia = e.DonGia;
                ex.SoLuongTon = e.SoLuongTon;
                ex.GhiChu = e.GhiChu;
                ex.HinhPath = e.HinhPath;
                db.SaveChanges();
            });
        }

        public static void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("M\u00E3 \u0111\u1ED3 u\u1ED1ng kh\u00F4ng h\u1EE3p l\u1EC7");

            Model1 db = null;
            System.Data.Entity.DbContextTransaction tx = null;
            try
            {
                db = DbConfig.Create();
                tx = db.Database.BeginTransaction();

                var e = db.DoUongs.FirstOrDefault(x => x.MaDoUong == id);
                if (e == null) throw new InvalidOperationException("Kh\u00F4ng t\u00ECm th\u1EA5y \u0111\u1ED3 u\u1ED1ng");

                bool hasCT = db.ChiTietHoaDons.Any(x => x.MaDoUong == id);
                bool hasKG = db.KyGuiRuous.Any(x => x.MaDoUong == id);

                if (AppSession.IsAdmin)
                {
                    db.ChiTietHoaDons.RemoveRange(db.ChiTietHoaDons.Where(x => x.MaDoUong == id));
                    foreach (var kg in db.KyGuiRuous.Where(x => x.MaDoUong == id)) kg.MaDoUong = null;
                    db.DoUongs.Remove(e);
                    db.SaveChanges();
                    tx.Commit();
                    return;
                }

                if (hasCT || hasKG)
                {
                    e.TrangThai = Res.StatusOutOfStock;
                    db.SaveChanges();
                    tx.Commit();
                    var reason = (hasCT ? Res.RelatedInvoice : "") + (hasKG ? (hasCT ? ", " : "") + Res.RelatedConsignment : "");
                    throw new InvalidOperationException(Res.SoftDeleteDrink(reason));
                }

                db.DoUongs.Remove(e);
                db.SaveChanges();
                tx.Commit();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                try { tx?.Rollback(); } catch { }
                throw new Exception("L\u1ED7i khi x\u00F3a \u0111\u1ED3 u\u1ED1ng: " + DbConfig.GetInnerMsg(ex), ex);
            }
            finally
            {
                try { tx?.Dispose(); } catch { }
                try { db?.Dispose(); } catch { }
            }
        }
    }
}
