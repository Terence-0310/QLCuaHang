using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quan ly ky gui ruou - co try-catch day du
    /// </summary>
    public static class KyGuiRuouDal
    {
        public sealed class KyGuiGridRow
        {
            public string MaKyGui { get; set; }
            public string MaKH { get; set; }
            public string TenKH { get; set; }
            public string TenRuou { get; set; }
            public decimal DungTichConLai { get; set; }
            public string DonViTinh { get; set; }
            public DateTime NgayKyGui { get; set; }
            public DateTime HanKyGui { get; set; }
            public string TrangThai { get; set; }
            public string HinhPath { get; set; }
        }

        public static List<KyGuiGridRow> GetAllForGrid()
        {
            try
            {
                return DbConfig.Use(db =>
                    db.KyGuiRuous.Select(x => new KyGuiGridRow
                    {
                        MaKyGui = x.MaKyGui, MaKH = x.MaKH, TenKH = x.KhachHang.TenKH,
                        TenRuou = x.TenRuou, DungTichConLai = x.DungTichConLai, DonViTinh = x.DonViTinh,
                        NgayKyGui = x.NgayKyGui, HanKyGui = x.HanKyGui, TrangThai = x.TrangThai, HinhPath = x.HinhPath
                    }).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("L\u1ED7i khi t\u1EA3i danh s\u00E1ch k\u00FD g\u1EADi: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static List<KyGuiGridRow> SearchForGrid(string kw)
        {
            try
            {
                return DbConfig.Use(db =>
                {
                    kw = (kw ?? "").Trim();
                    var q = db.KyGuiRuous.AsQueryable();
                    if (kw.Length > 0)
                        q = q.Where(x => x.MaKyGui.Contains(kw) || x.TenRuou.Contains(kw) || x.MaKH.Contains(kw) || x.KhachHang.TenKH.Contains(kw));
                    return q.Select(x => new KyGuiGridRow
                    {
                        MaKyGui = x.MaKyGui, MaKH = x.MaKH, TenKH = x.KhachHang.TenKH,
                        TenRuou = x.TenRuou, DungTichConLai = x.DungTichConLai, DonViTinh = x.DonViTinh,
                        NgayKyGui = x.NgayKyGui, HanKyGui = x.HanKyGui, TrangThai = x.TrangThai, HinhPath = x.HinhPath
                    }).ToList();
                });
            }
            catch (Exception ex)
            {
                throw new Exception("L\u1ED7i khi t\u00ECm ki\u1EBFm k\u00FD g\u1EADi: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static KyGuiRuou GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return null;
                return DbConfig.Use(db => db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == id));
            }
            catch { return null; }
        }

        public static void Add(KyGuiRuou e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (string.IsNullOrWhiteSpace(e.MaKyGui)) throw new ArgumentException("M\u00E3 k\u00FD g\u1EADi kh\u00F4ng h\u1EE3p l\u1EC7");
            if (string.IsNullOrWhiteSpace(e.TenRuou)) throw new ArgumentException("T\u00EAn r\u01B0\u1EE3u kh\u00F4ng h\u1EE3p l\u1EC7");

            DbConfig.Use(db =>
            {
                if (string.IsNullOrWhiteSpace(e.DonViTinh)) e.DonViTinh = "ml";
                if (string.IsNullOrWhiteSpace(e.TrangThai)) e.TrangThai = Res.StatusConsigning;
                db.KyGuiRuous.Add(e);
                db.SaveChanges();
            });
        }

        public static void Update(KyGuiRuou e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            if (string.IsNullOrWhiteSpace(e.MaKyGui)) throw new ArgumentException("M\u00E3 k\u00FD g\u1EADi kh\u00F4ng h\u1EE3p l\u1EC7");

            DbConfig.Use(db =>
            {
                var ex = db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == e.MaKyGui);
                if (ex == null) throw new InvalidOperationException("Kh\u00F4ng t\u00ECm th\u1EA5y k\u00FD g\u1EADi");
                ex.TenRuou = e.TenRuou;
                ex.DungTichConLai = e.DungTichConLai;
                ex.TrangThai = e.TrangThai;
                db.SaveChanges();
            });
        }

        public static void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Ma ky gui khong hop le");

            try
            {
                DbConfig.Use(db =>
                {
                    var e = db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == id);
                    if (e == null) throw new InvalidOperationException("Khong tim thay ky gui");
                    db.KyGuiRuous.Remove(e);
                    db.SaveChanges();
                });
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi xoa ky gui: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static string GenerateMaKyGui() => "KG" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
