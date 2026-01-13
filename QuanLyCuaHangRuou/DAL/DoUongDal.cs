using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Data Access Layer cho Đồ Uống
    /// Chỉ chứa CRUD đơn giản
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
            public decimal? DungTich { get; set; }
            public DateTime? HanSuDung { get; set; }
            public string GhiChu { get; set; }
            public string TrangThai { get; set; }
            public string HinhPath { get; set; }
            public string TenLoai { get; set; }
            public string MaLoai { get; set; }
        }

        /// <summary>
        /// Lấy tất cả đồ uống
        /// </summary>
        public static List<DoUongGridRow> GetAllForGrid() => DbConfig.Use(db =>
            db.DoUongs.Select(x => new DoUongGridRow
            {
                MaDoUong = x.MaDoUong,
                TenDoUong = x.TenDoUong,
                DonGia = x.DonGia,
                SoLuongTon = x.SoLuongTon,
                DonViTinh = x.DonViTinh,
                DungTich = x.DungTich,
                HanSuDung = x.HanSuDung,
                GhiChu = x.GhiChu,
                TrangThai = x.TrangThai,
                HinhPath = x.HinhPath,
                TenLoai = x.LoaiDoUong.TenLoai,
                MaLoai = x.MaLoai
            }).ToList());

        /// <summary>
        /// Tìm kiếm đồ uống
        /// </summary>
        public static List<DoUongGridRow> SearchForGrid(string keyword) => DbConfig.Use(db =>
        {
            keyword = (keyword ?? "").Trim();
            var query = db.DoUongs.AsQueryable();
            
            if (keyword.Length > 0)
            {
                query = query.Where(x => 
                    x.MaDoUong.Contains(keyword) || 
                    x.TenDoUong.Contains(keyword));
            }
            
            return query.Select(x => new DoUongGridRow
            {
                MaDoUong = x.MaDoUong,
                TenDoUong = x.TenDoUong,
                DonGia = x.DonGia,
                SoLuongTon = x.SoLuongTon,
                DonViTinh = x.DonViTinh,
                DungTich = x.DungTich,
                HanSuDung = x.HanSuDung,
                GhiChu = x.GhiChu,
                TrangThai = x.TrangThai,
                HinhPath = x.HinhPath,
                TenLoai = x.LoaiDoUong.TenLoai,
                MaLoai = x.MaLoai
            }).ToList();
        });

        /// <summary>
        /// Lấy đồ uống theo mã
        /// </summary>
        public static DoUong GetById(string maDoUong)
        {
            if (string.IsNullOrWhiteSpace(maDoUong))
                return null;

            return DbConfig.Use(db => 
                db.DoUongs.FirstOrDefault(x => x.MaDoUong == maDoUong));
        }

        /// <summary>
        /// Kiểm tra mối quan hệ
        /// </summary>
        public static (bool hasRelations, bool hasInvoiceDetails, bool hasConsignments) GetRelationships(string maDoUong)
        {
            if (string.IsNullOrWhiteSpace(maDoUong))
                return (false, false, false);

            return DbConfig.Use(db =>
            {
                bool hasCT = db.ChiTietHoaDons.Any(x => x.MaDoUong == maDoUong);
                bool hasKG = db.KyGuiRuous.Any(x => x.MaDoUong == maDoUong);
                return (hasCT || hasKG, hasCT, hasKG);
            });
        }

        /// <summary>
        /// Thêm đồ uống mới
        /// </summary>
        public static void Add(DoUong entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbConfig.Use(db =>
            {
                db.DoUongs.Add(entity);
                db.SaveChanges();
            });
        }

        /// <summary>
        /// Cập nhật đồ uống
        /// </summary>
        public static void Update(DoUong entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbConfig.Use(db =>
            {
                var existing = db.DoUongs.FirstOrDefault(x => x.MaDoUong == entity.MaDoUong);
                if (existing == null)
                    throw new InvalidOperationException("Không tìm thấy đồ uống");

                existing.TenDoUong = entity.TenDoUong;
                existing.DonGia = entity.DonGia;
                existing.SoLuongTon = entity.SoLuongTon;
                existing.DonViTinh = entity.DonViTinh;
                existing.DungTich = entity.DungTich;
                existing.HanSuDung = entity.HanSuDung;
                existing.GhiChu = entity.GhiChu;
                existing.TrangThai = entity.TrangThai;
                existing.HinhPath = entity.HinhPath;
                existing.MaLoai = entity.MaLoai;

                db.SaveChanges();
            });
        }

        /// <summary>
        /// Cập nhật số lượng tồn kho
        /// </summary>
        public static void UpdateQuantity(string maDoUong, int quantityChange)
        {
            if (string.IsNullOrWhiteSpace(maDoUong))
                throw new ArgumentException("Mã đồ uống không hợp lệ");

            DbConfig.Use(db =>
            {
                var entity = db.DoUongs.FirstOrDefault(x => x.MaDoUong == maDoUong);
                if (entity == null)
                    throw new InvalidOperationException("Không tìm thấy đồ uống");

                entity.SoLuongTon += quantityChange;

                if (entity.SoLuongTon < 0)
                    throw new InvalidOperationException("Số lượng tồn không được âm");

                db.SaveChanges();
            });
        }

        /// <summary>
        /// Xóa mềm
        /// </summary>
        public static void SoftDelete(string maDoUong)
        {
            if (string.IsNullOrWhiteSpace(maDoUong))
                throw new ArgumentException("Mã đồ uống không hợp lệ");

            DbConfig.Use(db =>
            {
                var entity = db.DoUongs.FirstOrDefault(x => x.MaDoUong == maDoUong);
                if (entity == null)
                    throw new InvalidOperationException("Không tìm thấy đồ uống");

                entity.TrangThai = Common.Res.StatusOutOfStock;
                db.SaveChanges();
            });
        }

        /// <summary>
        /// Xóa cứng
        /// </summary>
        public static void HardDelete(string maDoUong)
        {
            if (string.IsNullOrWhiteSpace(maDoUong))
                throw new ArgumentException("Mã đồ uống không hợp lệ");

            using (var db = DbConfig.Create())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var entity = db.DoUongs.FirstOrDefault(x => x.MaDoUong == maDoUong);
                    if (entity == null)
                        throw new InvalidOperationException("Không tìm thấy đồ uống");

                    // Xóa chi tiết hóa đơn
                    var chiTietList = db.ChiTietHoaDons.Where(x => x.MaDoUong == maDoUong).ToList();
                    db.ChiTietHoaDons.RemoveRange(chiTietList);

                    // Gỡ liên kết ký gửi
                    var kyGuiList = db.KyGuiRuous.Where(x => x.MaDoUong == maDoUong).ToList();
                    foreach (var kg in kyGuiList)
                    {
                        kg.MaDoUong = null;
                    }

                    // Xóa đồ uống
                    db.DoUongs.Remove(entity);

                    db.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
