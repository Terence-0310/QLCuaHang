using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Data Access Layer cho Ký Gửi Rượu
    /// Chỉ CRUD đơn giản
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

        /// <summary>
        /// Lấy tất cả ký gửi
        /// </summary>
        public static List<KyGuiGridRow> GetAllForGrid() => DbConfig.Use(db =>
            db.KyGuiRuous.Select(x => new KyGuiGridRow
            {
                MaKyGui = x.MaKyGui,
                MaKH = x.MaKH,
                TenKH = x.KhachHang.TenKH,
                TenRuou = x.TenRuou,
                DungTichConLai = x.DungTichConLai,
                DonViTinh = x.DonViTinh,
                NgayKyGui = x.NgayKyGui,
                HanKyGui = x.HanKyGui,
                ViTriLuuTru = x.ViTriLuuTru,
                TrangThai = x.TrangThai,
                HinhPath = x.HinhPath
            }).ToList());

        /// <summary>
        /// Tìm kiếm
        /// </summary>
        public static List<KyGuiGridRow> SearchForGrid(string keyword) => DbConfig.Use(db =>
        {
            keyword = (keyword ?? "").Trim();
            var query = db.KyGuiRuous.AsQueryable();
            
            if (keyword.Length > 0)
            {
                query = query.Where(x => 
                    x.MaKyGui.Contains(keyword) || 
                    x.TenRuou.Contains(keyword) || 
                    x.MaKH.Contains(keyword) || 
                    x.KhachHang.TenKH.Contains(keyword) || 
                    x.ViTriLuuTru.Contains(keyword));
            }
            
            return query.Select(x => new KyGuiGridRow
            {
                MaKyGui = x.MaKyGui,
                MaKH = x.MaKH,
                TenKH = x.KhachHang.TenKH,
                TenRuou = x.TenRuou,
                DungTichConLai = x.DungTichConLai,
                DonViTinh = x.DonViTinh,
                NgayKyGui = x.NgayKyGui,
                HanKyGui = x.HanKyGui,
                ViTriLuuTru = x.ViTriLuuTru,
                TrangThai = x.TrangThai,
                HinhPath = x.HinhPath
            }).ToList();
        });

        /// <summary>
        /// Lấy theo mã
        /// </summary>
        public static KyGuiRuou GetById(string maKyGui)
        {
            if (string.IsNullOrWhiteSpace(maKyGui))
                return null;

            return DbConfig.Use(db => 
                db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == maKyGui));
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        public static void Add(KyGuiRuou entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbConfig.Use(db =>
            {
                db.KyGuiRuous.Add(entity);
                db.SaveChanges();
            });
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        public static void Update(KyGuiRuou entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbConfig.Use(db =>
            {
                var existing = db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == entity.MaKyGui);
                if (existing == null)
                    throw new InvalidOperationException("Không tìm thấy ký gửi");

                existing.TenRuou = entity.TenRuou;
                existing.DungTichConLai = entity.DungTichConLai;
                existing.DonViTinh = entity.DonViTinh;
                existing.HanKyGui = entity.HanKyGui;
                existing.ViTriLuuTru = entity.ViTriLuuTru;
                existing.TrangThai = entity.TrangThai;
                existing.HinhPath = entity.HinhPath;

                db.SaveChanges();
            });
        }

        /// <summary>
        /// Xóa
        /// </summary>
        public static void Delete(string maKyGui)
        {
            if (string.IsNullOrWhiteSpace(maKyGui))
                throw new ArgumentException("Mã ký gửi không hợp lệ");

            DbConfig.Use(db =>
            {
                var entity = db.KyGuiRuous.FirstOrDefault(x => x.MaKyGui == maKyGui);
                if (entity == null)
                    throw new InvalidOperationException("Không tìm thấy ký gửi");

                db.KyGuiRuous.Remove(entity);
                db.SaveChanges();
            });
        }

        /// <summary>
        /// Sinh mã ký gửi - chỉ để đây cho backward compatibility
        /// BLL sẽ dùng GenerateCode()
        /// </summary>
        public static string GenerateMaKyGui() => "KG" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
