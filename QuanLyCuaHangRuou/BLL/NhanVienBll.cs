using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BLL
{
    /// <summary>
    /// Business Logic Layer cho Nhân Viên
    /// </summary>
    public static class NhanVienBll
    {
        #region Validation

        /// <summary>
        /// Validate nhân viên
        /// </summary>
        public static string ValidateEmployee(NhanVien entity)
        {
            if (entity == null)
                return "D? li?u không h?p l?!";

            if (string.IsNullOrWhiteSpace(entity.MaNV))
                return Res.EnterCode;

            if (string.IsNullOrWhiteSpace(entity.TenNV))
                return Res.EnterName;

            if (!string.IsNullOrWhiteSpace(entity.SoDienThoai))
            {
                var phone = entity.SoDienThoai.Trim();
                if (phone.Length < 10 || phone.Length > 11 || !phone.All(char.IsDigit))
                    return "S? ?i?n tho?i không h?p l?!";
            }

            return null;
        }

        /// <summary>
        /// Validate tài kho?n
        /// </summary>
        public static string ValidateAccount(TaiKhoan account)
        {
            if (account == null)
                return "Thông tin tài kho?n không h?p l?!";

            if (string.IsNullOrWhiteSpace(account.Username))
                return Res.EnterUsername;

            if (string.IsNullOrWhiteSpace(account.Password))
                return Res.EnterPassword;

            if (account.Username.Trim().Length < 4)
                return "Tên ??ng nh?p ph?i có ít nh?t 4 ký t?!";

            if (account.Password.Length < 6)
                return "M?t kh?u ph?i có ít nh?t 6 ký t?!";

            if (string.IsNullOrWhiteSpace(account.MaVaiTro))
                return "Vui lòng ch?n vai trò!";

            return null;
        }

        #endregion

        #region Business Rules

        /// <summary>
        /// Chu?n hóa nhân viên
        /// </summary>
        public static void NormalizeEmployee(NhanVien entity)
        {
            if (entity == null) return;

            entity.MaNV = entity.MaNV?.Trim().ToUpper();
            entity.TenNV = entity.TenNV?.Trim();
            entity.SoDienThoai = entity.SoDienThoai?.Trim();
            entity.DiaChi = entity.DiaChi?.Trim();

            if (string.IsNullOrWhiteSpace(entity.TrangThai))
                entity.TrangThai = Res.StatusWorking;
        }

        /// <summary>
        /// Chu?n hóa tài kho?n
        /// </summary>
        public static void NormalizeAccount(TaiKhoan account)
        {
            if (account == null) return;
            account.Username = account.Username?.Trim().ToLower();
            account.TrangThai = true;
        }

        /// <summary>
        /// Ki?m tra quy?n t?o vai trò
        /// </summary>
        public static (bool canCreate, string reason) CanCreateAccountWithRole(string maVaiTro)
        {
            if (AppSession.IsAdmin)
                return (true, null);

            if (AppSession.IsManager)
            {
                if (maVaiTro == PermissionKeys.RoleAdmin || maVaiTro == PermissionKeys.RoleManager)
                    return (false, Res.CannotCreateAdmin);
                return (true, null);
            }

            return (false, "B?n không có quy?n t?o tài kho?n!");
        }

        /// <summary>
        /// Ki?m tra có th? xóa không
        /// </summary>
        public static (bool canDelete, string reason) CanDeleteEmployee(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return (false, "Mã nhân viên không h?p l?!");

            var nhanVien = NhanVienDal.GetById(maNV);
            if (nhanVien == null)
                return (false, "Không tìm th?y nhân viên!");

            var username = nhanVien.TaiKhoan?.Username ?? "";
            var role = nhanVien.TaiKhoan?.MaVaiTro ?? "";

            if (string.Equals(AppSession.CurrentUser, username, StringComparison.OrdinalIgnoreCase))
                return (false, Res.CannotDeleteSelf);

            if (role.Equals(PermissionKeys.RoleAdmin, StringComparison.OrdinalIgnoreCase) &&
                username.Equals("admin", StringComparison.OrdinalIgnoreCase))
                return (false, Res.CannotDeleteAdmin);

            if (!AppSession.CanDeleteEmployeeWithRole(role, username))
                return (false, Res.NoPermissionDelete);

            return (true, null);
        }

        /// <summary>
        /// Sinh mã tài kho?n
        /// </summary>
        public static string GenerateAccountCode() =>
            "TK" + DateTime.Now.ToString("yyyyMMddHHmmss");

        #endregion

        #region Business Operations

        /// <summary>
        /// L?y t?t c? nhân viên
        /// </summary>
        public static List<NhanVienDal.NhanVienGridRow> GetAll() =>
            AppSession.CanViewEmployees ? NhanVienDal.GetAllForGrid() : new List<NhanVienDal.NhanVienGridRow>();

        /// <summary>
        /// Tìm ki?m nhân viên
        /// </summary>
        public static List<NhanVienDal.NhanVienGridRow> Search(string keyword) =>
            AppSession.CanViewEmployees ? NhanVienDal.SearchForGrid(keyword) : new List<NhanVienDal.NhanVienGridRow>();

        /// <summary>
        /// Thêm nhân viên cùng tài kho?n
        /// </summary>
        public static (bool success, string message) AddEmployeeWithAccount(NhanVien employee, TaiKhoan account)
        {
            try
            {
                if (!AppSession.CanEditEmployees)
                    return (false, Res.NoPermissionAdd);

                var employeeError = ValidateEmployee(employee);
                if (employeeError != null)
                    return (false, employeeError);

                var accountError = ValidateAccount(account);
                if (accountError != null)
                    return (false, accountError);

                var (canCreate, roleReason) = CanCreateAccountWithRole(account.MaVaiTro);
                if (!canCreate)
                    return (false, roleReason);

                if (NhanVienDal.ExistsMaNV(employee.MaNV))
                    return (false, Res.CodeExists);

                if (TaiKhoanDal.ExistsUsername(account.Username))
                    return (false, "Tên ??ng nh?p ?ã t?n t?i!");

                NormalizeEmployee(employee);
                NormalizeAccount(account);
                NhanVienDal.AddWithAccount(employee, account);

                return (true, Res.AddSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i thêm nhân viên: " + ex.Message);
            }
        }

        /// <summary>
        /// C?p nh?t nhân viên
        /// </summary>
        public static (bool success, string message) UpdateEmployee(
            string maNV, string tenNV, string soDienThoai, string diaChi,
            string trangThai, string maVaiTro, string maTK)
        {
            try
            {
                if (!AppSession.CanEditEmployees)
                    return (false, Res.NoPermissionEdit);

                if (string.IsNullOrWhiteSpace(maNV))
                    return (false, Res.EnterCode);

                if (string.IsNullOrWhiteSpace(tenNV))
                    return (false, Res.EnterName);

                var existing = NhanVienDal.GetById(maNV);
                if (existing == null)
                    return (false, "Không tìm th?y nhân viên!");

                if (!string.IsNullOrWhiteSpace(maVaiTro) && existing.TaiKhoan?.MaVaiTro != maVaiTro)
                {
                    var (canCreate, reason) = CanCreateAccountWithRole(maVaiTro);
                    if (!canCreate)
                        return (false, reason);
                }

                NhanVienDal.UpdateWithRoleAndStatus(maNV, tenNV.Trim(), soDienThoai?.Trim(), diaChi?.Trim(), trangThai, maVaiTro, maTK);

                return (true, Res.UpdateSuccess);
            }
            catch (InvalidOperationException ex)
            {
                return (false, ex.Message);
            }
            catch (Exception ex)
            {
                return (false, "L?i c?p nh?t: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        public static (bool success, string message, bool isSoftDelete) DeleteEmployee(string maNV)
        {
            try
            {
                if (!AppSession.CanDeleteEmployees)
                    return (false, Res.NoPermissionDelete, false);

                if (string.IsNullOrWhiteSpace(maNV))
                    return (false, Res.EnterCode, false);

                var (canDelete, reason) = CanDeleteEmployee(maNV);
                if (!canDelete)
                    return (false, reason, false);

                try
                {
                    NhanVienDal.Delete(maNV);
                    return (true, Res.DeleteSuccess, false);
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message.Contains("Ngh?") || ex.Message.Contains("tr?ng thái"))
                        return (true, ex.Message, true);
                    throw;
                }
            }
            catch (Exception ex)
            {
                return (false, "L?i xóa: " + ex.Message, false);
            }
        }

        #endregion
    }
}
