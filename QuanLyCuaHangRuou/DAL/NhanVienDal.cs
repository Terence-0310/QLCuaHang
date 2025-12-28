using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.DAL
{
    /// <summary>
    /// Quan ly nhan vien - co try-catch day du
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
            public string TrangThai { get; set; }
            public string HinhPath { get; set; }
            public string MaTK { get; set; }
        }

        public static List<NhanVienGridRow> GetAllForGrid()
        {
            try
            {
                return DbConfig.Use(db =>
                    db.NhanViens.Select(x => new NhanVienGridRow
                    {
                        MaNV = x.MaNV, 
                        TenNV = x.TenNV,
                        SoDienThoai = x.SoDienThoai ?? "",
                        DiaChi = x.DiaChi ?? "",
                        Username = x.TaiKhoan != null ? x.TaiKhoan.Username : "",
                        Role = x.TaiKhoan != null && x.TaiKhoan.VaiTro != null ? x.TaiKhoan.VaiTro.TenVaiTro : "",
                        TrangThai = x.TrangThai, 
                        HinhPath = x.HinhPath, 
                        MaTK = x.MaTK
                    }).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi tai danh sach nhan vien: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static List<NhanVienGridRow> SearchForGrid(string kw)
        {
            try
            {
                return DbConfig.Use(db =>
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
                        TrangThai = x.TrangThai, 
                        HinhPath = x.HinhPath, 
                        MaTK = x.MaTK
                    }).ToList();
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi tim kiem nhan vien: " + DbConfig.GetInnerMsg(ex), ex);
            }
        }

        public static bool ExistsMaNV(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return false;
                return DbConfig.Use(db => db.NhanViens.Any(x => x.MaNV == id));
            }
            catch { return false; }
        }

        public static NhanVien GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return null;
                return DbConfig.Use(db =>
                    db.NhanViens.Include(n => n.TaiKhoan).Include(n => n.TaiKhoan.VaiTro).FirstOrDefault(x => x.MaNV == id));
            }
            catch { return null; }
        }

        public static NhanVien GetByUsername(string username)
        {
            try
            {
                username = (username ?? "").Trim();
                if (username.Length == 0) return null;
                return DbConfig.Use(db =>
                    db.NhanViens.Include(n => n.TaiKhoan).FirstOrDefault(x => x.TaiKhoan != null && x.TaiKhoan.Username == username));
            }
            catch { return null; }
        }

        public static void AddWithAccount(NhanVien nv, TaiKhoan tk)
        {
            if (nv == null) throw new ArgumentNullException(nameof(nv));
            if (tk == null) throw new ArgumentNullException(nameof(tk));
            if (string.IsNullOrWhiteSpace(nv.MaNV)) throw new ArgumentException("Ma NV khong hop le");
            if (string.IsNullOrWhiteSpace(nv.TenNV)) throw new ArgumentException("Ten NV khong hop le");

            Model1 db = null;
            System.Data.Entity.DbContextTransaction tx = null;
            try
            {
                db = DbConfig.Create();
                tx = db.Database.BeginTransaction();

                if (string.IsNullOrWhiteSpace(nv.TrangThai)) nv.TrangThai = Res.StatusWorking;
                db.TaiKhoans.Add(tk);
                nv.MaTK = tk.MaTK;
                db.NhanViens.Add(nv);
                db.SaveChanges();

                tx.Commit();
            }
            catch (Exception)
            {
                try { tx?.Rollback(); } catch { }
                throw;
            }
            finally
            {
                try { tx?.Dispose(); } catch { }
                try { db?.Dispose(); } catch { }
            }
        }

        public static void UpdateWithRoleAndStatus(string maNv, string tenNv, string sdt, string diaChi, string trangThai, string vaiTro, string maTK)
        {
            if (string.IsNullOrWhiteSpace(maNv)) throw new ArgumentException("Ma NV khong hop le");

            DbConfig.Use(db =>
            {
                var nv = db.NhanViens.Include(x => x.TaiKhoan).FirstOrDefault(x => x.MaNV == maNv);
                if (nv == null) throw new InvalidOperationException("Khong tim thay nhan vien");

                nv.TenNV = tenNv;
                nv.SoDienThoai = sdt;
                nv.DiaChi = diaChi;
                nv.TrangThai = trangThai;

                if (nv.TaiKhoan != null)
                {
                    nv.TaiKhoan.TrangThai = (trangThai == Res.StatusWorking);
                    if (AppSession.IsAdmin && !string.IsNullOrWhiteSpace(vaiTro))
                        nv.TaiKhoan.MaVaiTro = vaiTro;
                }

                db.SaveChanges();
            });
        }

        public static void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Ma NV khong hop le");

            Model1 db = null;
            System.Data.Entity.DbContextTransaction tx = null;
            try
            {
                db = DbConfig.Create();
                tx = db.Database.BeginTransaction();

                var nv = db.NhanViens.Include(x => x.TaiKhoan).FirstOrDefault(x => x.MaNV == id);
                if (nv == null) throw new InvalidOperationException("Khong tim thay nhan vien");

                var username = nv.TaiKhoan?.Username;
                var role = nv.TaiKhoan?.MaVaiTro ?? "";

                // Khong xoa chinh minh
                if (!string.IsNullOrWhiteSpace(AppSession.CurrentUser) &&
                    string.Equals(AppSession.CurrentUser, username, StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException(Res.CannotDeleteSelf);

                bool hasHD = db.HoaDons.Any(x => x.MaNV == id);

                if (AppSession.IsAdmin)
                {
                    // Khong xoa admin goc
                    if (role.Equals("ADMIN", StringComparison.OrdinalIgnoreCase) &&
                        "admin".Equals(username, StringComparison.OrdinalIgnoreCase))
                        throw new InvalidOperationException(Res.CannotDeleteAdmin);

                    // Set null cho hoa don lien quan
                    foreach (var hd in db.HoaDons.Where(x => x.MaNV == id)) hd.MaNV = null;

                    var tk = nv.TaiKhoan;
                    db.NhanViens.Remove(nv);
                    if (tk != null) db.TaiKhoans.Remove(tk);
                    db.SaveChanges();
                    tx.Commit();
                    return;
                }

                if (!AppSession.IsManager)
                    throw new InvalidOperationException(Res.NoPermissionDelete);

                // Manager chi xoa nhan vien thuong
                if (!role.Equals("NHAN_VIEN", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException(Res.NoPermissionDelete);

                // Soft delete neu co hoa don
                if (hasHD)
                {
                    nv.TrangThai = Res.StatusQuit;
                    if (nv.TaiKhoan != null) nv.TaiKhoan.TrangThai = false;
                    db.SaveChanges();
                    tx.Commit();
                    throw new InvalidOperationException(Res.SoftDeleteEmployee);
                }

                var tkDel = nv.TaiKhoan;
                db.NhanViens.Remove(nv);
                if (tkDel != null) db.TaiKhoans.Remove(tkDel);
                db.SaveChanges();
                tx.Commit();
            }
            catch (InvalidOperationException)
            {
                throw; // Re-throw business exceptions
            }
            catch (Exception ex)
            {
                try { tx?.Rollback(); } catch { }
                throw new Exception("Loi khi xoa nhan vien: " + DbConfig.GetInnerMsg(ex), ex);
            }
            finally
            {
                try { tx?.Dispose(); } catch { }
                try { db?.Dispose(); } catch { }
            }
        }
    }
}
