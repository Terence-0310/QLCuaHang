using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
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

        public static List<KhachHangGridRow> GetAllForGrid() => DbConfig.Use(db =>
            db.KhachHangs.Select(x => new KhachHangGridRow
            {
                MaKH = x.MaKH, TenKH = x.TenKH, SoDienThoai = x.SoDienThoai,
                DiaChi = x.DiaChi, TrangThai = x.TrangThai, HinhPath = x.HinhPath
            }).ToList());

        public static List<KhachHangGridRow> SearchForGrid(string kw) => DbConfig.Use(db =>
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

        public static KhachHang GetById(string id) =>
            string.IsNullOrWhiteSpace(id) ? null : DbConfig.Use(db => db.KhachHangs.FirstOrDefault(x => x.MaKH == id));

        public static void Add(KhachHang e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.MaKH) || string.IsNullOrWhiteSpace(e.TenKH))
                throw new ArgumentException("Mã và tên khách hàng không hợp lệ");

            DbConfig.Use(db =>
            {
                if (string.IsNullOrWhiteSpace(e.TrangThai)) e.TrangThai = Res.StatusActive;
                db.KhachHangs.Add(e);
                db.SaveChanges();
            });
        }

        public static void Update(KhachHang e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.MaKH))
                throw new ArgumentException("Mã khách hàng không hợp lệ");

            DbConfig.Use(db =>
            {
                var ex = db.KhachHangs.FirstOrDefault(x => x.MaKH == e.MaKH) 
                    ?? throw new InvalidOperationException("Không tìm thấy khách hàng");
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
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã KH không hợp lệ");

            using (var db = DbConfig.Create())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var e = db.KhachHangs.FirstOrDefault(x => x.MaKH == id)
                        ?? throw new InvalidOperationException("Không tìm thấy khách hàng");

                    bool hasKG = db.KyGuiRuous.Any(x => x.MaKH == id);
                    bool hasHD = db.HoaDons.Any(x => x.MaKH == id);

                    if (AppSession.IsAdmin)
                    {
                        db.KyGuiRuous.RemoveRange(db.KyGuiRuous.Where(x => x.MaKH == id));
                        foreach (var hd in db.HoaDons.Where(x => x.MaKH == id)) hd.MaKH = null;
                        db.KhachHangs.Remove(e);
                    }
                    else if (hasKG || hasHD)
                    {
                        e.TrangThai = Res.StatusInactive;
                        db.SaveChanges();
                        tx.Commit();
                        var reason = (hasKG ? Res.RelatedConsignment : "") + (hasHD ? (hasKG ? ", " : "") + Res.RelatedInvoice : "");
                        throw new InvalidOperationException(Res.SoftDeleteCustomer(reason));
                    }
                    else
                    {
                        db.KhachHangs.Remove(e);
                    }

                    db.SaveChanges();
                    tx.Commit();
                }
                catch (InvalidOperationException) { throw; }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("Lỗi khi xóa khách hàng: " + DbConfig.GetInnerMsg(ex), ex);
                }
            }
        }
    }
}
