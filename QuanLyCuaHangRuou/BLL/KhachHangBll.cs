using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BLL
{
    /// <summary>
    /// Business Logic Layer cho Khách Hàng
    /// </summary>
    public static class KhachHangBll
    {
        #region Validation

        /// <summary>
        /// Validate d? li?u khách hàng
        /// </summary>
        public static string Validate(KhachHang entity)
        {
            if (entity == null)
                return "D? li?u không h?p l?!";

            if (string.IsNullOrWhiteSpace(entity.MaKH))
                return Res.EnterCode;

            if (string.IsNullOrWhiteSpace(entity.TenKH))
                return Res.EnterName;

            if (entity.MaKH.Length < 3)
                return "Mã khách hàng ph?i có ít nh?t 3 ký t?!";

            if (!string.IsNullOrWhiteSpace(entity.SoDienThoai))
            {
                var phone = entity.SoDienThoai.Trim();
                if (phone.Length < 10 || phone.Length > 11 || !phone.All(char.IsDigit))
                    return "S? ?i?n tho?i không h?p l?!";
            }

            return null;
        }

        /// <summary>
        /// Chu?n hóa d? li?u
        /// </summary>
        public static void Normalize(KhachHang entity)
        {
            if (entity == null) return;

            entity.MaKH = entity.MaKH?.Trim().ToUpper();
            entity.TenKH = entity.TenKH?.Trim();
            entity.SoDienThoai = entity.SoDienThoai?.Trim();
            entity.DiaChi = entity.DiaChi?.Trim();

            if (string.IsNullOrWhiteSpace(entity.TrangThai))
                entity.TrangThai = Res.StatusActive;
        }

        #endregion

        #region Business Rules

        /// <summary>
        /// Ki?m tra mã ?ã t?n t?i
        /// </summary>
        public static bool IsCodeExists(string maKH) =>
            !string.IsNullOrWhiteSpace(maKH) && KhachHangDal.GetById(maKH) != null;

        /// <summary>
        /// Ki?m tra có th? xóa không
        /// </summary>
        public static (bool canDelete, string reason) CanDelete(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return (false, "Mã khách hàng không h?p l?!");

            var relations = KhachHangDal.GetRelationships(maKH);
            if (!relations.hasRelations)
                return (true, null);

            if (AppSession.IsAdmin)
                return (true, null);

            var reasons = new List<string>();
            if (relations.hasConsignments) reasons.Add(Res.RelatedConsignment);
            if (relations.hasInvoices) reasons.Add(Res.RelatedInvoice);

            return (false, string.Join(", ", reasons));
        }

        #endregion

        #region Business Operations

        /// <summary>
        /// Tìm ki?m khách hàng
        /// </summary>
        public static List<KhachHangDal.KhachHangGridRow> Search(string keyword) =>
            KhachHangDal.SearchForGrid(keyword);

        /// <summary>
        /// L?y khách hàng ?ang ho?t ??ng
        /// </summary>
        public static List<KhachHangDal.KhachHangGridRow> GetActiveCustomers() =>
            KhachHangDal.GetAllForGrid().Where(x => x.TrangThai == Res.StatusActive).ToList();

        /// <summary>
        /// Thêm khách hàng m?i
        /// </summary>
        public static (bool success, string message) Add(KhachHang entity)
        {
            try
            {
                if (!AppSession.CanEditCatalog)
                    return (false, Res.NoPermissionAdd);

                var error = Validate(entity);
                if (error != null)
                    return (false, error);

                if (IsCodeExists(entity.MaKH))
                    return (false, Res.CodeExists);

                Normalize(entity);
                KhachHangDal.Add(entity);

                return (true, Res.AddSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i thêm khách hàng: " + ex.Message);
            }
        }

        /// <summary>
        /// C?p nh?t khách hàng
        /// </summary>
        public static (bool success, string message) Update(KhachHang entity)
        {
            try
            {
                if (!AppSession.CanEditCatalog)
                    return (false, Res.NoPermissionEdit);

                var error = Validate(entity);
                if (error != null)
                    return (false, error);

                if (!IsCodeExists(entity.MaKH))
                    return (false, "Không tìm th?y khách hàng!");

                Normalize(entity);
                KhachHangDal.Update(entity);

                return (true, Res.UpdateSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i c?p nh?t: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        public static (bool success, string message, bool isSoftDelete) Delete(string maKH)
        {
            try
            {
                if (!AppSession.CanDeleteCustomer)
                    return (false, Res.NoPermissionDelete, false);

                if (string.IsNullOrWhiteSpace(maKH))
                    return (false, Res.EnterCode, false);

                var (canDelete, reason) = CanDelete(maKH);

                if (AppSession.IsAdmin)
                {
                    KhachHangDal.HardDelete(maKH);
                    return (true, Res.DeleteSuccess, false);
                }

                if (!canDelete)
                {
                    KhachHangDal.SoftDelete(maKH);
                    return (true, Res.SoftDeleteCustomer(reason), true);
                }

                KhachHangDal.HardDelete(maKH);
                return (true, Res.DeleteSuccess, false);
            }
            catch (Exception ex)
            {
                return (false, "L?i xóa: " + ex.Message, false);
            }
        }

        #endregion
    }
}
