using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quan ly hoa don (de in/xuat)
    /// </summary>
    public static class HoaDonDal
    {
        public sealed class HoaDonGridRow
        {
            public string MaHD { get; set; }
            public DateTime NgayHoaDon { get; set; }
            public string MaKH { get; set; }
            public string TenKH { get; set; }
            public string MaNV { get; set; }
            public string TenNV { get; set; }
            public decimal TongTien { get; set; }
            public string GhiChu { get; set; }
        }

        public sealed class HoaDonPrintDto
        {
            public string MaHD { get; set; }
            public DateTime NgayHoaDon { get; set; }
            public string TenKH { get; set; }
            public string SdtKH { get; set; }
            public string DiaChiKH { get; set; }
            public string TenNV { get; set; }
            public decimal TongTien { get; set; }
            public string GhiChu { get; set; }
            public List<ItemDto> Items { get; set; }
        }

        public sealed class ItemDto
        {
            public int STT { get; set; }
            public string MaDoUong { get; set; }
            public string TenDoUong { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
            public decimal ThanhTien { get; set; }
        }

        /// <summary>
        /// Lay tat ca hoa don
        /// </summary>
        public static List<HoaDonGridRow> GetAll() => DbConfig.Use(db =>
            db.HoaDons
                .Include(x => x.KhachHang)
                .Include(x => x.NhanVien)
                .OrderByDescending(x => x.NgayHoaDon)
                .Select(x => new HoaDonGridRow
                {
                    MaHD = x.MaHD,
                    NgayHoaDon = x.NgayHoaDon,
                    MaKH = x.MaKH,
                    TenKH = x.KhachHang != null ? x.KhachHang.TenKH : "",
                    MaNV = x.MaNV,
                    TenNV = x.NhanVien != null ? x.NhanVien.TenNV : "",
                    TongTien = x.TongTien,
                    GhiChu = x.GhiChu
                }).ToList());

        /// <summary>
        /// Lay hoa don theo khoang ngay
        /// </summary>
        public static List<HoaDonGridRow> GetByDateRange(DateTime from, DateTime to) => DbConfig.Use(db =>
        {
            from = from.Date;
            var toEnd = to.Date.AddDays(1);
            return db.HoaDons
                .Include(x => x.KhachHang)
                .Include(x => x.NhanVien)
                .Where(x => x.NgayHoaDon >= from && x.NgayHoaDon < toEnd)
                .OrderByDescending(x => x.NgayHoaDon)
                .Select(x => new HoaDonGridRow
                {
                    MaHD = x.MaHD,
                    NgayHoaDon = x.NgayHoaDon,
                    MaKH = x.MaKH,
                    TenKH = x.KhachHang != null ? x.KhachHang.TenKH : "",
                    MaNV = x.MaNV,
                    TenNV = x.NhanVien != null ? x.NhanVien.TenNV : "",
                    TongTien = x.TongTien,
                    GhiChu = x.GhiChu
                }).ToList();
        });

        /// <summary>
        /// Tim kiem hoa don theo ma HD, ten KH, ten NV
        /// </summary>
        public static List<HoaDonGridRow> Search(string keyword, DateTime? from = null, DateTime? to = null) => DbConfig.Use(db =>
        {
            keyword = (keyword ?? "").Trim().ToLower();
            var q = db.HoaDons.Include(x => x.KhachHang).Include(x => x.NhanVien).AsQueryable();

            if (from.HasValue)
            {
                var fromDate = from.Value.Date;
                q = q.Where(x => x.NgayHoaDon >= fromDate);
            }
            if (to.HasValue)
            {
                var toDate = to.Value.Date.AddDays(1);
                q = q.Where(x => x.NgayHoaDon < toDate);
            }

            if (keyword.Length > 0)
            {
                q = q.Where(x => x.MaHD.ToLower().Contains(keyword) ||
                                 (x.KhachHang != null && x.KhachHang.TenKH.ToLower().Contains(keyword)) ||
                                 (x.NhanVien != null && x.NhanVien.TenNV.ToLower().Contains(keyword)));
            }

            return q.OrderByDescending(x => x.NgayHoaDon)
                .Select(x => new HoaDonGridRow
                {
                    MaHD = x.MaHD,
                    NgayHoaDon = x.NgayHoaDon,
                    MaKH = x.MaKH,
                    TenKH = x.KhachHang != null ? x.KhachHang.TenKH : "",
                    MaNV = x.MaNV,
                    TenNV = x.NhanVien != null ? x.NhanVien.TenNV : "",
                    TongTien = x.TongTien,
                    GhiChu = x.GhiChu
                }).ToList();
        });

        /// <summary>
        /// Lay chi tiet hoa don de in
        /// </summary>
        public static HoaDonPrintDto GetForPrint(string maHd) => DbConfig.Use(db =>
        {
            maHd = (maHd ?? "").Trim();
            if (maHd.Length == 0) return null;

            var hd = db.HoaDons
                .Include(x => x.KhachHang)
                .Include(x => x.NhanVien)
                .Include(x => x.ChiTietHoaDons)
                .FirstOrDefault(x => x.MaHD == maHd);
            if (hd == null) return null;

            var maDu = hd.ChiTietHoaDons.Select(x => x.MaDoUong).Distinct().ToList();
            var tenMap = db.DoUongs.Where(x => maDu.Contains(x.MaDoUong))
                .ToDictionary(x => x.MaDoUong, x => x.TenDoUong);

            int stt = 0;
            return new HoaDonPrintDto
            {
                MaHD = hd.MaHD,
                NgayHoaDon = hd.NgayHoaDon,
                TenKH = hd.KhachHang?.TenKH ?? "",
                SdtKH = hd.KhachHang?.SoDienThoai ?? "",
                DiaChiKH = hd.KhachHang?.DiaChi ?? "",
                TenNV = hd.NhanVien?.TenNV ?? "",
                TongTien = hd.TongTien,
                GhiChu = hd.GhiChu ?? "",
                Items = hd.ChiTietHoaDons.Select(ct => new ItemDto
                {
                    STT = ++stt,
                    MaDoUong = ct.MaDoUong,
                    TenDoUong = tenMap.ContainsKey(ct.MaDoUong) ? tenMap[ct.MaDoUong] : ct.MaDoUong,
                    DonGia = ct.DonGia,
                    SoLuong = ct.SoLuong,
                    ThanhTien = ct.DonGia * ct.SoLuong
                }).OrderBy(x => x.STT).ToList()
            };
        });
    }
}
