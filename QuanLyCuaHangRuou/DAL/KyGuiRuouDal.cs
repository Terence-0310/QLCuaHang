using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quản lý ký gửi rượu
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
            public string ViTriLuuTru { get; set; }
            public string TrangThai { get; set; }
            public string HinhPath { get; set; }
        }

        public static List<KyGuiGridRow> GetAllForGrid() => DbConfig.Use(db =>
            db.KyGuiRuous.Select(x => new KyGuiGridRow
            {
                MaKyGui = x.MaKyGui, MaKH = x.MaKH, TenKH = x.KhachHang.TenKH,
                TenRuou = x.TenRuou, DungTichConLai = x.DungTichConLai, DonViTinh = x.DonViTinh,
                NgayKyGui = x.NgayKyGui, HanKyGui = x.HanKyGui,
                ViTriLuuTru = x.ViTriLuuTru, TrangThai = x.TrangThai, HinhPath = x.HinhPath
            }).ToList());

        public static List<KyGuiGridRow> SearchForGrid(string kw) => DbConfig.Use(db =>
        {
            kw = (kw ?? "").Trim();
            var q = db.KyGuiRuous.AsQueryable();
            if (kw.Length > 0)
                q = q.Where(x => x.MaKyGui.Contains(kw) || x.TenRuou.Contains(kw) || 
                    x.MaKH.Contains(kw) || x.KhachHang.TenKH.Contains(kw) || x.ViTriLuuTru.Contains(kw));
            return q.Select(x => new KyGuiGridRow
            {
                MaKyGui = x.MaKyGui, MaKH = x.MaKH, TenKH = x.KhachHang.TenKH,
                TenRuou = x.TenRuou, DungTichConLai = x.DungTichConLai, DonViTinh = x.DonViTinh,
                NgayKyGui = x.NgayKyGui, HanKyGui = x.HanKyGui,
                ViTriLuuTru = x.ViTriLuuTru, TrangThai = x.TrangThai, HinhPath = x.HinhPath
            }).ToList();
        });

        public static KyGuiRuou GetById(string id) =>
            string.IsNullOrWhiteSpace(id) ? null : DbConfig.Use(db => db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == id));

        public static void Add(KyGuiRuou e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.MaKyGui) || string.IsNullOrWhiteSpace(e.TenRuou))
                throw new ArgumentException("Thông tin ký gửi không hợp lệ");

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
            if (e == null || string.IsNullOrWhiteSpace(e.MaKyGui))
                throw new ArgumentException("Mã ký gửi không hợp lệ");

            DbConfig.Use(db =>
            {
                var ex = db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == e.MaKyGui)
                    ?? throw new InvalidOperationException("Không tìm thấy ký gửi");
                ex.TenRuou = e.TenRuou;
                ex.DungTichConLai = e.DungTichConLai;
                ex.HanKyGui = e.HanKyGui;
                ex.ViTriLuuTru = e.ViTriLuuTru;
                ex.TrangThai = e.TrangThai;
                db.SaveChanges();
            });
        }

        public static void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã ký gửi không hợp lệ");

            DbConfig.Use(db =>
            {
                var e = db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == id)
                    ?? throw new InvalidOperationException("Không tìm thấy ký gửi");
                db.KyGuiRuous.Remove(e);
                db.SaveChanges();
            });
        }

        public static string GenerateMaKyGui() => "KG" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
