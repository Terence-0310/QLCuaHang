using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quản lý nhân viên
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

        public static List<NhanVienGridRow> SearchForGrid(string kw) => DbConfig.Use(db =>
        {
            kw = (kw ?? "").Trim();
            var q = db.NhanViens.AsQueryable();
            if (kw.Length > 0)
                q = q.Where(x => x.MaNV.Contains(kw) || x.TenNV.Contains(kw) ||
                                x.SoDienThoai.Contains(kw) || x.DiaChi.Contains(kw) ||
                                (x.TaiKhoan != null && x.TaiKhoan.Username.Contains(kw)));
            return q.Select(x => new NhanVienGridRow
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

        public static bool ExistsMaNV(string id) =>
            !string.IsNullOrWhiteSpace(id) && DbConfig.Use(db => db.NhanViens.Any(x => x.MaNV == id));

        public static NhanVien GetById(string id) =>
            string.IsNullOrWhiteSpace(id) ? null : DbConfig.Use(db =>
                db.NhanViens.Include(n => n.TaiKhoan).Include(n => n.TaiKhoan.VaiTro).FirstOrDefault(x => x.MaNV == id));

        public static NhanVien GetByUsername(string username)
        {
            username = (username ?? "").Trim();
            return username.Length == 0 ? null : DbConfig.Use(db =>
                db.NhanViens.Include(n => n.TaiKhoan).FirstOrDefault(x => x.TaiKhoan != null && x.TaiKhoan.Username == username));
        }

        public static void AddWithAccount(NhanVien nv, TaiKhoan tk)
        {
            if (nv == null || tk == null || string.IsNullOrWhiteSpace(nv.MaNV) || string.IsNullOrWhiteSpace(nv.TenNV))
                throw new ArgumentException("Thông tin nhân viên không hợp lệ");

            if (!AppSession.IsAdmin && (tk.MaVaiTro == PermissionKeys.RoleAdmin || tk.MaVaiTro == PermissionKeys.RoleManager))
                throw new InvalidOperationException(Res.CannotCreateAdmin);

            using (var db = DbConfig.Create())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(nv.TrangThai)) nv.TrangThai = Res.StatusWorking;
                    db.TaiKhoans.Add(tk);
                    nv.MaTK = tk.MaTK;
                    db.NhanViens.Add(nv);
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

        public static void UpdateWithRoleAndStatus(string maNv, string tenNv, string sdt, string diaChi, string trangThai, string vaiTro, string maTK)
        {
            if (string.IsNullOrWhiteSpace(maNv)) throw new ArgumentException("Mã NV không hợp lệ");

            DbConfig.Use(db =>
            {
                var nv = db.NhanViens.Include(x => x.TaiKhoan).FirstOrDefault(x => x.MaNV == maNv)
                    ?? throw new InvalidOperationException("Không tìm thấy nhân viên");

                nv.TenNV = tenNv;
                nv.SoDienThoai = sdt;
                nv.DiaChi = diaChi;
                nv.TrangThai = trangThai;

                if (nv.TaiKhoan != null)
                {
                    nv.TaiKhoan.TrangThai = (trangThai == Res.StatusWorking);

                    if (AppSession.IsAdmin && !string.IsNullOrWhiteSpace(vaiTro))
                    {
                        if (nv.TaiKhoan.Username?.ToLower() == "admin" && vaiTro != PermissionKeys.RoleAdmin)
                            throw new InvalidOperationException(Res.CannotChangeAdminRole);
                        nv.TaiKhoan.MaVaiTro = vaiTro;
                    }
                }
                db.SaveChanges();
            });
        }

        public static void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã NV không hợp lệ");

            using (var db = DbConfig.Create())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var nv = db.NhanViens.Include(x => x.TaiKhoan).FirstOrDefault(x => x.MaNV == id)
                        ?? throw new InvalidOperationException("Không tìm thấy nhân viên");

                    var username = nv.TaiKhoan?.Username ?? "";
                    var role = nv.TaiKhoan?.MaVaiTro ?? "";

                    if (!AppSession.CanDeleteEmployeeWithRole(role, username))
                    {
                        if (string.Equals(AppSession.CurrentUser, username, StringComparison.OrdinalIgnoreCase))
                            throw new InvalidOperationException(Res.CannotDeleteSelf);
                        if (role.Equals(PermissionKeys.RoleAdmin, StringComparison.OrdinalIgnoreCase) &&
                            username.Equals("admin", StringComparison.OrdinalIgnoreCase))
                            throw new InvalidOperationException(Res.CannotDeleteAdmin);
                        throw new InvalidOperationException(Res.NoPermissionDelete);
                    }

                    bool hasHD = db.HoaDons.Any(x => x.MaNV == id);

                    if (hasHD)
                    {
                        nv.TrangThai = Res.StatusQuit;
                        if (nv.TaiKhoan != null) nv.TaiKhoan.TrangThai = false;
                        db.SaveChanges();
                        tx.Commit();
                        throw new InvalidOperationException(Res.SoftDeleteEmployee);
                    }

                    foreach (var hd in db.HoaDons.Where(x => x.MaNV == id)) hd.MaNV = null;
                    var tk = nv.TaiKhoan;
                    db.NhanViens.Remove(nv);
                    if (tk != null) db.TaiKhoans.Remove(tk);
                    db.SaveChanges();
                    tx.Commit();
                }
                catch (InvalidOperationException) { throw; }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("Lỗi khi xóa nhân viên: " + DbConfig.GetInnerMsg(ex), ex);
                }
            }
        }
    }
}
