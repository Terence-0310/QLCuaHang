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
        public sealed class HoaDonPrintDto
        {
            public string MaHD { get; set; }
            public System.DateTime NgayHoaDon { get; set; }
            public string TenKH { get; set; }
            public string TenNV { get; set; }
            public decimal TongTien { get; set; }
            public List<ItemDto> Items { get; set; }
        }

        public sealed class ItemDto
        {
            public string MaDoUong { get; set; }
            public string TenDoUong { get; set; }
            public decimal DonGia { get; set; }
            public decimal SoLuong { get; set; }
            public decimal ThanhTien { get; set; }
        }

        public static HoaDonPrintDto GetForPrint(string maHd) => DbConfig.Use(db =>
        {
            maHd = (maHd ?? "").Trim();
            if (maHd.Length == 0) return null;

            var hd = db.HoaDons.Include(x => x.KhachHang).Include(x => x.NhanVien).Include(x => x.ChiTietHoaDons)
                .FirstOrDefault(x => x.MaHD == maHd);
            if (hd == null) return null;

            var maDu = hd.ChiTietHoaDons.Select(x => x.MaDoUong).Distinct().ToList();
            var tenMap = db.DoUongs.Where(x => maDu.Contains(x.MaDoUong)).ToDictionary(x => x.MaDoUong, x => x.TenDoUong);

            return new HoaDonPrintDto
            {
                MaHD = hd.MaHD, NgayHoaDon = hd.NgayHoaDon,
                TenKH = hd.KhachHang?.TenKH ?? "", TenNV = hd.NhanVien?.TenNV ?? "",
                TongTien = hd.TongTien,
                Items = hd.ChiTietHoaDons.Select(ct => new ItemDto
                {
                    MaDoUong = ct.MaDoUong, TenDoUong = tenMap.ContainsKey(ct.MaDoUong) ? tenMap[ct.MaDoUong] : ct.MaDoUong,
                    DonGia = ct.DonGia, SoLuong = ct.SoLuong, ThanhTien = ct.DonGia * ct.SoLuong
                }).OrderBy(x => x.MaDoUong).ToList()
            };
        });
    }
}
