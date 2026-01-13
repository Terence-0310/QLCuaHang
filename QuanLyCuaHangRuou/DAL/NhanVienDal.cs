using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Data Access Layer cho Nhân Viên
    /// Chỉ CRUD đơn giản
    /// </summary>
    public static class NhanVienDal
    {
        public sealed class NhanVienGridRow
        {
            public string MaNV { get; set; }
            public string TenNV { get; set; }
            public string SoDienThoai { get; set; }
            public string DiaChi { get; set; }
            public string Username { get; set; }
            public string Role { get; set; }
            public string MaVaiTro { get; set; }
            public string TrangThai { get; set; }
            public string HinhPath { get; set; }
            public string MaTK { get; set; }
        }

        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        public static List<NhanVienGridRow> GetAllForGrid() => DbConfig.Use(db =>
            db.NhanViens.Select(x => new NhanVienGridRow
            {
                MaNV = x.MaNV,
                TenNV = x.TenNV,
                SoDienThoai = x.SoDienThoai ?? "",
                DiaChi = x.DiaChi ?? "",
                Username = x.TaiKhoan != null ? x.TaiKhoan.Username : "",
                Role = x.TaiKhoan != null && x.TaiKhoan.VaiTro != null ? x.TaiKhoan.VaiTro.TenVaiTro : "",
                MaVaiTro = x.TaiKhoan != null ? x.TaiKhoan.MaVaiTro : "",
                TrangThai = x.TrangThai,
                HinhPath = x.HinhPath,
                MaTK = x.MaTK
            }).ToList());

        /// <summary>
        /// Tìm kiếm nhân viên
        /// </summary>
        public static List<NhanVienGridRow> SearchForGrid(string keyword) => DbConfig.Use(db =>
        {
            keyword = (keyword ?? "").Trim();
            var query = db.NhanViens.AsQueryable();
            
            if (keyword.Length > 0)
            {
                query = query.Where(x => 
                    x.MaNV.Contains(keyword) || 
                    x.TenNV.Contains(keyword) ||
                    x.SoDienThoai.Contains(keyword) || 
                    x.DiaChi.Contains(keyword) ||
                    (x.TaiKhoan != null && x.TaiKhoan.Username.Contains(keyword)));
            }
            
            return query.Select(x => new NhanVienGridRow
            {
                MaNV = x.MaNV,
                TenNV = x.TenNV,
                SoDienThoai = x.SoDienThoai ?? "",
                DiaChi = x.DiaChi ?? "",
                Username = x.TaiKhoan != null ? x.TaiKhoan.Username : "",
                Role = x.TaiKhoan != null && x.TaiKhoan.VaiTro != null ? x.TaiKhoan.VaiTro.TenVaiTro : "",
                MaVaiTro = x.TaiKhoan != null ? x.TaiKhoan.MaVaiTro : "",
                TrangThai = x.TrangThai,
                HinhPath = x.HinhPath,
                MaTK = x.MaTK
            }).ToList();
        });

        /// <summary>
        /// Kiểm tra mã nhân viên tồn tại
        /// </summary>
        public static bool ExistsMaNV(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return false;

            return DbConfig.Use(db => db.NhanViens.Any(x => x.MaNV == maNV));
        }

        /// <summary>
        /// Lấy nhân viên theo mã
        /// </summary>
        public static NhanVien GetById(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return null;

            return DbConfig.Use(db =>
                db.NhanViens
                    .Include(n => n.TaiKhoan)
                    .Include(n => n.TaiKhoan.VaiTro)
                    .FirstOrDefault(x => x.MaNV == maNV));
        }

        /// <summary>
        /// Lấy nhân viên theo username
        /// </summary>
        public static NhanVien GetByUsername(string username)
        {
            username = (username ?? "").Trim();
            if (username.Length == 0)
                return null;

            return DbConfig.Use(db =>
                db.NhanViens
                    .Include(n => n.TaiKhoan)
                    .FirstOrDefault(x => x.TaiKhoan != null && x.TaiKhoan.Username == username));
        }

        /// <summary>
        /// Kiểm tra có hóa đơn liên quan không
        /// </summary>
        public static bool HasInvoices(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return false;

            return DbConfig.Use(db => db.HoaDons.Any(x => x.MaNV == maNV));
        }

        /// <summary>
        /// Thêm nhân viên cùng tài khoản
        /// </summary>
        public static void AddWithAccount(NhanVien nhanVien, TaiKhoan taiKhoan)
        {
            if (nhanVien == null || taiKhoan == null)
                throw new ArgumentNullException("Thông tin nhân viên/tài khoản không hợp lệ");

            using (var db = DbConfig.Create())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    db.TaiKhoans.Add(taiKhoan);
                    nhanVien.MaTK = taiKhoan.MaTK;
                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Cập nhật nhân viên và vai trò
        /// </summary>
        public static void UpdateWithRoleAndStatus(string maNV, string tenNV, string sdt, string diaChi, string trangThai, string vaiTro, string maTK)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("Mã NV không hợp lệ");

            DbConfig.Use(db =>
            {
                var nhanVien = db.NhanViens.Include(x => x.TaiKhoan).FirstOrDefault(x => x.MaNV == maNV);
                if (nhanVien == null)
                    throw new InvalidOperationException("Không tìm thấy nhân viên");

                nhanVien.TenNV = tenNV;
                nhanVien.SoDienThoai = sdt;
                nhanVien.DiaChi = diaChi;
                nhanVien.TrangThai = trangThai;

                if (nhanVien.TaiKhoan != null)
                {
                    nhanVien.TaiKhoan.TrangThai = (trangThai == Res.StatusWorking);
                    
                    if (!string.IsNullOrWhiteSpace(vaiTro))
                        nhanVien.TaiKhoan.MaVaiTro = vaiTro;
                }

                db.SaveChanges();
            });
        }

        /// <summary>
        /// Soft delete - chỉ đổi trạng thái
        /// </summary>
        public static void SoftDelete(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("Mã NV không hợp lệ");

            DbConfig.Use(db =>
            {
                var nhanVien = db.NhanViens.Include(x => x.TaiKhoan).FirstOrDefault(x => x.MaNV == maNV);
                if (nhanVien == null)
                    throw new InvalidOperationException("Không tìm thấy nhân viên");

                nhanVien.TrangThai = Res.StatusQuit;
                if (nhanVien.TaiKhoan != null)
                    nhanVien.TaiKhoan.TrangThai = false;

                db.SaveChanges();
            });
        }

        /// <summary>
        /// Hard delete - xóa hoàn toàn
        /// </summary>
        public static void HardDelete(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("Mã NV không hợp lệ");

            using (var db = DbConfig.Create())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var nhanVien = db.NhanViens.Include(x => x.TaiKhoan).FirstOrDefault(x => x.MaNV == maNV);
                    if (nhanVien == null)
                        throw new InvalidOperationException("Không tìm thấy nhân viên");

                    // Gỡ liên kết hóa đơn
                    foreach (var hd in db.HoaDons.Where(x => x.MaNV == maNV))
                        hd.MaNV = null;

                    var taiKhoan = nhanVien.TaiKhoan;
                    db.NhanViens.Remove(nhanVien);
                    
                    if (taiKhoan != null)
                        db.TaiKhoans.Remove(taiKhoan);

                    db.SaveChanges();
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Xóa nhân viên (backward compatibility)
        /// BLL nên sử dụng SoftDelete hoặc HardDelete
        /// </summary>
        public static void Delete(string maNV)
        {
            if (HasInvoices(maNV))
            {
                SoftDelete(maNV);
                throw new InvalidOperationException(Res.SoftDeleteEmployee);
            }
            else
            {
                HardDelete(maNV);
            }
        }
    }
}
