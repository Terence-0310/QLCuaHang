using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quan ly khach hang - co try-catch day du
    /// </summary>
    public static class KhachHangDal
    {
        public sealed class KhachHangGridRow
        {
            public string MaKH { get; set; }
            public string TenKH { get; set; }
            public string SoDienThoai { get; set; }
            public string DiaChi { get; set; }
            public string TrangThai { get; set; }
            public string HinhPath { get; set; }
        }

        public static List<KhachHangGridRow> GetAllForGrid()
        {
            try
            {
                return DbConfig.Use(db =>
                    db.KhachHangs.Select(x => new KhachHangGridRow
                    {
                        MaKH = x.MaKH, TenKH = x.TenKH, SoDienThoai = x.SoDienThoai,
                        DiaChi = x.DiaChi, TrangThai = x.TrangThai, HinhPath = x.HinhPath
                    }).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("L\u1ED7i khi t\u1EA3i danh s\u00E1ch kh\u00E1ch h\u00E0ng: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static List<KhachHangGridRow> SearchForGrid(string kw)
        {
            try
            {
                return DbConfig.Use(db =>
                {
                    kw = (kw ?? "").Trim();
                    var q = db.KhachHangs.AsQueryable();
                    if (kw.Length > 0)
                        q = q.Where(x => x.MaKH.Contains(kw) || x.TenKH.Contains(kw) || x.SoDienThoai.Contains(kw));
                    return q.Select(x => new KhachHangGridRow
                    {
                        MaKH = x.MaKH, TenKH = x.TenKH, SoDienThoai = x.SoDienThoai,
                        DiaChi = x.DiaChi, TrangThai = x.TrangThai, HinhPath = x.HinhPath
                    }).ToList();
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi tim kiem khach hang: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static KhachHang GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return null;
                return DbConfig.Use(db => db.KhachHangs.FirstOrDefault(x => x.MaKH == id));
            }
            catch { return null; }
        }

        public static void Add(KhachHang e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (string.IsNullOrWhiteSpace(e.MaKH)) throw new ArgumentException("M\u00E3 KH kh\u00F4ng h\u1EE3p l\u1EC7");
            if (string.IsNullOrWhiteSpace(e.TenKH)) throw new ArgumentException("T\u00EAn KH kh\u00F4ng h\u1EE3p l\u1EC7");

            DbConfig.Use(db =>
            {
                if (string.IsNullOrWhiteSpace(e.TrangThai)) e.TrangThai = Res.StatusActive;
                db.KhachHangs.Add(e);
                db.SaveChanges();
            });
        }

        public static void Update(KhachHang e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (string.IsNullOrWhiteSpace(e.MaKH)) throw new ArgumentException("M\u00E3 KH kh\u00F4ng h\u1EE3p l\u1EC7");

            DbConfig.Use(db =>
            {
                var ex = db.KhachHangs.FirstOrDefault(x => x.MaKH == e.MaKH);
                if (ex == null) throw new InvalidOperationException("Kh\u00F4ng t\u00ECm th\u1EA5y kh\u00E1ch h\u00E0ng");
                ex.TenKH = e.TenKH;
                ex.SoDienThoai = e.SoDienThoai;
                ex.DiaChi = e.DiaChi;
                ex.HinhPath = e.HinhPath;
                if (!string.IsNullOrWhiteSpace(e.TrangThai)) ex.TrangThai = e.TrangThai;
                db.SaveChanges();
            });
        }

        public static void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("M\u00E3 KH kh\u00F4ng h\u1EE3p l\u1EC7");

            Model1 db = null;
            System.Data.Entity.DbContextTransaction tx = null;
            try
            {
                db = DbConfig.Create();
                tx = db.Database.BeginTransaction();

                var e = db.KhachHangs.FirstOrDefault(x => x.MaKH == id);
                if (e == null) throw new InvalidOperationException("Kh\u00F4ng t\u00ECm th\u1EA5y kh\u00E1ch h\u00E0ng");

                bool hasKG = db.KyGuiRuous.Any(x => x.MaKH == id);
                bool hasHD = db.HoaDons.Any(x => x.MaKH == id);

                if (AppSession.IsAdmin)
                {
                    db.KyGuiRuous.RemoveRange(db.KyGuiRuous.Where(x => x.MaKH == id));
                    foreach (var hd in db.HoaDons.Where(x => x.MaKH == id)) hd.MaKH = null;
                    db.KhachHangs.Remove(e);
                    db.SaveChanges();
                    tx.Commit();
                    return;
                }

                if (hasKG || hasHD)
                {
                    e.TrangThai = Res.StatusInactive;
                    db.SaveChanges();
                    tx.Commit();
                    var reason = (hasKG ? Res.RelatedConsignment : "") + (hasHD ? (hasKG ? ", " : "") + Res.RelatedInvoice : "");
                    throw new InvalidOperationException(Res.SoftDeleteCustomer(reason));
                }

                db.KhachHangs.Remove(e);
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
                throw new Exception("L\u1ED7i khi x\u00F3a kh\u00E1ch h\u00E0ng: " + DbConfig.GetInnerMsg(ex), ex);
            }
            finally
            {
                try { tx?.Dispose(); } catch { }
                try { db?.Dispose(); } catch { }
            }
        }
    }
}
