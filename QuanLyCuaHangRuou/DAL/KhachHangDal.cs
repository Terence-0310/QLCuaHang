using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Data Access Layer cho Khách Hàng
    /// Chỉ chứa các thao tác CRUD đơn giản với database
    /// Không chứa business logic, validation phức tạp
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

        /// <summary>
        /// Lấy tất cả khách hàng cho hiển thị lưới
        /// </summary>
        public static List<KhachHangGridRow> GetAllForGrid() => DbConfig.Use(db =>
            db.KhachHangs.Select(x => new KhachHangGridRow
            {
                MaKH = x.MaKH,
                TenKH = x.TenKH,
                SoDienThoai = x.SoDienThoai,
                DiaChi = x.DiaChi,
                TrangThai = x.TrangThai,
                HinhPath = x.HinhPath
            }).ToList());

        /// <summary>
        /// Tìm kiếm khách hàng theo từ khóa
        /// </summary>
        public static List<KhachHangGridRow> SearchForGrid(string keyword) => DbConfig.Use(db =>
        {
            keyword = (keyword ?? "").Trim();
            var query = db.KhachHangs.AsQueryable();
            
            if (keyword.Length > 0)
            {
                query = query.Where(x => 
                    x.MaKH.Contains(keyword) || 
                    x.TenKH.Contains(keyword) || 
                    x.SoDienThoai.Contains(keyword));
            }
            
            return query.Select(x => new KhachHangGridRow
            {
                MaKH = x.MaKH,
                TenKH = x.TenKH,
                SoDienThoai = x.SoDienThoai,
                DiaChi = x.DiaChi,
                TrangThai = x.TrangThai,
                HinhPath = x.HinhPath
            }).ToList();
        });

        /// <summary>
        /// Lấy khách hàng theo mã
        /// </summary>
        public static KhachHang GetById(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return null;

            return DbConfig.Use(db => 
                db.KhachHangs.FirstOrDefault(x => x.MaKH == maKH));
        }

        /// <summary>
        /// Kiểm tra các mối quan hệ của khách hàng với bảng khác
        /// </summary>
        public static (bool hasRelations, bool hasConsignments, bool hasInvoices) GetRelationships(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return (false, false, false);

            return DbConfig.Use(db =>
            {
                bool hasKG = db.KyGuiRuous.Any(x => x.MaKH == maKH);
                bool hasHD = db.HoaDons.Any(x => x.MaKH == maKH);
                return (hasKG || hasHD, hasKG, hasHD);
            });
        }

        /// <summary>
        /// Thêm khách hàng mới (không validation - BLL sẽ làm)
        /// </summary>
        public static void Add(KhachHang entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbConfig.Use(db =>
            {
                db.KhachHangs.Add(entity);
                db.SaveChanges();
            });
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        public static void Update(KhachHang entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            DbConfig.Use(db =>
            {
                var existing = db.KhachHangs.FirstOrDefault(x => x.MaKH == entity.MaKH);
                if (existing == null)
                    throw new InvalidOperationException("Không tìm thấy khách hàng");

                existing.TenKH = entity.TenKH;
                existing.SoDienThoai = entity.SoDienThoai;
                existing.DiaChi = entity.DiaChi;
                existing.HinhPath = entity.HinhPath;
                existing.TrangThai = entity.TrangThai;

                db.SaveChanges();
            });
        }

        /// <summary>
        /// Xóa mềm - chỉ đổi trạng thái thành không hoạt động
        /// </summary>
        public static void SoftDelete(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                throw new ArgumentException("Mã khách hàng không hợp lệ");

            DbConfig.Use(db =>
            {
                var entity = db.KhachHangs.FirstOrDefault(x => x.MaKH == maKH);
                if (entity == null)
                    throw new InvalidOperationException("Không tìm thấy khách hàng");

                entity.TrangThai = Common.Res.StatusInactive;
                db.SaveChanges();
            });
        }

        /// <summary>
        /// Xóa cứng - xóa hoàn toàn khỏi database
        /// Chỉ dùng khi Admin hoặc không có ràng buộc
        /// </summary>
        public static void HardDelete(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                throw new ArgumentException("Mã khách hàng không hợp lệ");

            using (var db = DbConfig.Create())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var entity = db.KhachHangs.FirstOrDefault(x => x.MaKH == maKH);
                    if (entity == null)
                        throw new InvalidOperationException("Không tìm thấy khách hàng");

                    // Xóa các ký gửi liên quan
                    var kyGuiList = db.KyGuiRuous.Where(x => x.MaKH == maKH).ToList();
                    db.KyGuiRuous.RemoveRange(kyGuiList);

                    // Gỡ liên kết hóa đơn
                    var hoaDonList = db.HoaDons.Where(x => x.MaKH == maKH).ToList();
                    foreach (var hd in hoaDonList)
                    {
                        hd.MaKH = null;
                    }

                    // Xóa khách hàng
                    db.KhachHangs.Remove(entity);

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
