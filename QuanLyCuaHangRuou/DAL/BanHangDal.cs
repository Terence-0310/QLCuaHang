using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Xu ly ban hang - co try-catch va transaction
    /// </summary>
    public static class BanHangDal
    {
        public sealed class GioHangItem
        {
            public string MaDoUong { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
        }

        /// <summary>
        /// Thanh toan don hang - co transaction va rollback khi loi
        /// </summary>
        public static void ThanhToan(string maHd, DateTime ngay, string maKh, string maNv, string ghiChu, List<GioHangItem> items)
        {
            // Validate input truoc khi truy cap DB
            if (string.IsNullOrWhiteSpace(maHd))
                throw new ArgumentException("Ma hoa don khong hop le");
            if (items == null || items.Count == 0)
                throw new ArgumentException("Gio hang trong");

            // Validate tung item
            foreach (var item in items)
            {
                if (string.IsNullOrWhiteSpace(item.MaDoUong))
                    throw new ArgumentException("Ma do uong khong hop le");
                if (item.SoLuong <= 0)
                    throw new ArgumentException("So luong phai > 0");
                if (item.DonGia < 0)
                    throw new ArgumentException("Don gia khong hop le");
            }

            Model1 db = null;
            System.Data.Entity.DbContextTransaction tx = null;

            try
            {
                db = DbConfig.Create();
                tx = db.Database.BeginTransaction();

                // Kiem tra ma HD da ton tai
                if (db.HoaDons.Any(x => x.MaHD == maHd))
                    throw new InvalidOperationException("Ma hoa don da ton tai");

                // Lay danh sach do uong
                var maList = items.Select(x => x.MaDoUong).Distinct().ToList();
                var doUongs = db.DoUongs.Where(d => maList.Contains(d.MaDoUong)).ToList();

                // Validate ton kho
                foreach (var it in items)
                {
                    var du = doUongs.FirstOrDefault(x => x.MaDoUong == it.MaDoUong);
                    if (du == null)
                        throw new InvalidOperationException($"Khong tim thay do uong: {it.MaDoUong}");
                    if (du.SoLuongTon < it.SoLuong)
                        throw new InvalidOperationException($"Ton kho khong du cho {du.TenDoUong}. Con: {du.SoLuongTon}");
                }

                // Tinh tong tien
                decimal tongTien = items.Sum(it => it.DonGia * it.SoLuong);

                // Tao hoa don
                var hoaDon = new HoaDon
                {
                    MaHD = maHd,
                    NgayHoaDon = ngay,
                    MaKH = string.IsNullOrWhiteSpace(maKh) ? null : maKh,
                    MaNV = string.IsNullOrWhiteSpace(maNv) ? null : maNv,
                    GhiChu = ghiChu,
                    TongTien = tongTien
                };
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();

                // Them chi tiet va tru ton kho
                foreach (var it in items)
                {
                    db.ChiTietHoaDons.Add(new ChiTietHoaDon
                    {
                        MaHD = maHd,
                        MaDoUong = it.MaDoUong,
                        DonGia = it.DonGia,
                        SoLuong = it.SoLuong
                    });

                    var du = doUongs.First(x => x.MaDoUong == it.MaDoUong);
                    du.SoLuongTon -= it.SoLuong;
                }

                db.SaveChanges();
                tx.Commit();
            }
            catch (Exception)
            {
                // Rollback transaction neu co loi
                try { tx?.Rollback(); } catch { }
                throw; // Re-throw exception de caller xu ly
            }
            finally
            {
                // Dam bao giai phong resources
                try { tx?.Dispose(); } catch { }
                try { db?.Dispose(); } catch { }
            }
        }
    }
}
