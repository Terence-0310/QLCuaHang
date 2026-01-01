using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quản lý vị trí lưu trữ
    /// </summary>
    public static class ViTriLuuTruDal
    {
        public sealed class ViTriGridRow
        {
            public string MaViTri { get; set; }
            public string TenViTri { get; set; }
            public string MoTa { get; set; }
            public string TrangThai { get; set; }
        }

        /// <summary>
        /// Lấy tất cả vị trí lưu trữ đang hoạt động cho ComboBox
        /// </summary>
        public static List<ViTriGridRow> GetAllForCombo()
        {
            try
            {
                return DbConfig.Use(db =>
                    db.ViTriLuuTrus
                        .Where(x => x.TrangThai == "Hoạt động")
                        .Select(x => new ViTriGridRow
                        {
                            MaViTri = x.MaViTri,
                            TenViTri = x.TenViTri,
                            MoTa = x.MoTa,
                            TrangThai = x.TrangThai
                        })
                        .OrderBy(x => x.MaViTri)
                        .ToList());
            }
            catch
            {
                // Nếu bảng chưa tồn tại hoặc lỗi, trả về list rỗng
                return new List<ViTriGridRow>();
            }
        }

        /// <summary>
        /// Lấy tất cả vị trí lưu trữ cho Grid
        /// </summary>
        public static List<ViTriGridRow> GetAllForGrid()
        {
            try
            {
                return DbConfig.Use(db =>
                    db.ViTriLuuTrus
                        .Select(x => new ViTriGridRow
                        {
                            MaViTri = x.MaViTri,
                            TenViTri = x.TenViTri,
                            MoTa = x.MoTa,
                            TrangThai = x.TrangThai
                        })
                        .OrderBy(x => x.MaViTri)
                        .ToList());
            }
            catch
            {
                return new List<ViTriGridRow>();
            }
        }

        /// <summary>
        /// Lấy vị trí theo mã
        /// </summary>
        public static ViTriLuuTru GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return null;
                return DbConfig.Use(db => db.ViTriLuuTrus.FirstOrDefault(x => x.MaViTri == id));
            }
            catch { return null; }
        }

        /// <summary>
        /// Thêm vị trí mới
        /// </summary>
        public static void Add(ViTriLuuTru e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.MaViTri) || string.IsNullOrWhiteSpace(e.TenViTri))
                throw new ArgumentException("Mã và tên vị trí không hợp lệ");

            DbConfig.Use(db =>
            {
                if (string.IsNullOrWhiteSpace(e.TrangThai)) e.TrangThai = Res.StatusActive;
                db.ViTriLuuTrus.Add(e);
                db.SaveChanges();
            });
        }

        /// <summary>
        /// Cập nhật vị trí
        /// </summary>
        public static void Update(ViTriLuuTru e)
        {
            if (e == null || string.IsNullOrWhiteSpace(e.MaViTri))
                throw new ArgumentException("Mã vị trí không hợp lệ");

            DbConfig.Use(db =>
            {
                var ex = db.ViTriLuuTrus.FirstOrDefault(x => x.MaViTri == e.MaViTri)
                    ?? throw new InvalidOperationException("Không tìm thấy vị trí lưu trữ");
                ex.TenViTri = e.TenViTri;
                ex.MoTa = e.MoTa;
                ex.TrangThai = e.TrangThai;
                db.SaveChanges();
            });
        }

        /// <summary>
        /// Xóa vị trí
        /// </summary>
        public static void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã vị trí không hợp lệ");

            DbConfig.Use(db =>
            {
                var e = db.ViTriLuuTrus.FirstOrDefault(x => x.MaViTri == id)
                    ?? throw new InvalidOperationException("Không tìm thấy vị trí lưu trữ");
                
                // Kiểm tra xem có ký gửi nào đang sử dụng vị trí này không
                bool hasKyGui = db.KyGuiRuous.Any(x => x.ViTriLuuTru == id);
                if (hasKyGui)
                {
                    e.TrangThai = Res.StatusInactive;
                    db.SaveChanges();
                    throw new InvalidOperationException("Vị trí đang được sử dụng, đã chuyển sang trạng thái ngừng hoạt động");
                }
                
                db.ViTriLuuTrus.Remove(e);
                db.SaveChanges();
            });
        }
    }
}
