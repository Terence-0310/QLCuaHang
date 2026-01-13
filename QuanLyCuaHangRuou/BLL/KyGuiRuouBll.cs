using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BLL
{
    /// <summary>
    /// Business Logic Layer cho Ký G?i R??u
    /// </summary>
    public static class KyGuiRuouBll
    {
        #region Validation

        /// <summary>
        /// Validate ký g?i
        /// </summary>
        public static string Validate(KyGuiRuou entity, bool isAdd = true)
        {
            if (entity == null)
                return "D? li?u không h?p l?!";

            if (isAdd && string.IsNullOrWhiteSpace(entity.MaKyGui))
                return Res.EnterCode;

            if (string.IsNullOrWhiteSpace(entity.TenRuou))
                return Res.EnterName;

            if (string.IsNullOrWhiteSpace(entity.MaKH))
                return Res.SelectCustomer;

            if (entity.DungTichConLai < 0)
                return Res.InvalidQuantity;

            if (entity.HanKyGui <= entity.NgayKyGui)
                return "H?n ký g?i ph?i sau ngày ký g?i!";

            return null;
        }

        #endregion

        #region Business Rules

        /// <summary>
        /// Chu?n hóa d? li?u
        /// </summary>
        public static void Normalize(KyGuiRuou entity)
        {
            if (entity == null) return;

            entity.MaKyGui = entity.MaKyGui?.Trim().ToUpper();
            entity.TenRuou = entity.TenRuou?.Trim();
            entity.DonViTinh = string.IsNullOrWhiteSpace(entity.DonViTinh) ? "ml" : entity.DonViTinh.Trim();
            entity.ViTriLuuTru = entity.ViTriLuuTru?.Trim();

            if (string.IsNullOrWhiteSpace(entity.TrangThai))
                entity.TrangThai = Res.StatusConsigning;
        }

        /// <summary>
        /// Ki?m tra có th? ch?nh s?a ký g?i không
        /// </summary>
        public static (bool canEdit, string reason) CanEdit(string maKyGui)
        {
            var existing = KyGuiRuouDal.GetById(maKyGui);
            if (existing == null)
                return (false, "Không tìm th?y ký g?i!");

            if (existing.TrangThai == Res.StatusSold || existing.TrangThai == Res.StatusReturned)
                return (false, "Không th? ch?nh s?a ký g?i ?ã hoàn t?t!");

            return (true, null);
        }

        /// <summary>
        /// Ki?m tra có th? xóa không
        /// </summary>
        public static (bool canDelete, string reason) CanDelete(string maKyGui)
        {
            var existing = KyGuiRuouDal.GetById(maKyGui);
            if (existing == null)
                return (false, "Không tìm th?y ký g?i!");

            if (existing.TrangThai == Res.StatusSold)
                return (false, "Không th? xóa ký g?i ?ã bán!");

            return (true, null);
        }

        /// <summary>
        /// Sinh mã ký g?i t? ??ng
        /// </summary>
        public static string GenerateCode()
        {
            return "KG" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        #endregion

        #region Business Operations

        /// <summary>
        /// L?y t?t c? ký g?i
        /// </summary>
        public static List<KyGuiRuouDal.KyGuiGridRow> GetAll()
        {
            return KyGuiRuouDal.GetAllForGrid();
        }

        /// <summary>
        /// Tìm ki?m
        /// </summary>
        public static List<KyGuiRuouDal.KyGuiGridRow> Search(string keyword)
        {
            return KyGuiRuouDal.SearchForGrid(keyword);
        }

        /// <summary>
        /// Thêm ký g?i m?i
        /// </summary>
        public static (bool success, string message) Add(KyGuiRuou entity)
        {
            try
            {
                // Ki?m tra quy?n
                if (!AppSession.CanEditConsignment)
                    return (false, Res.NoPermissionAdd);

                // Validate
                var error = Validate(entity, isAdd: true);
                if (error != null)
                    return (false, error);

                // Ki?m tra trùng mã
                if (KyGuiRuouDal.GetById(entity.MaKyGui) != null)
                    return (false, Res.CodeExists);

                // Chu?n hóa
                Normalize(entity);

                // L?u
                KyGuiRuouDal.Add(entity);

                return (true, Res.AddSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i thêm: " + ex.Message);
            }
        }

        /// <summary>
        /// C?p nh?t ký g?i
        /// </summary>
        public static (bool success, string message) Update(KyGuiRuou entity)
        {
            try
            {
                // Ki?m tra quy?n
                if (!AppSession.CanEditConsignment)
                    return (false, Res.NoPermissionEdit);

                // Validate
                var error = Validate(entity, isAdd: false);
                if (error != null)
                    return (false, error);

                // Ki?m tra có th? s?a không
                var (canEdit, reason) = CanEdit(entity.MaKyGui);
                if (!canEdit)
                    return (false, reason);

                // Chu?n hóa
                Normalize(entity);

                // C?p nh?t
                KyGuiRuouDal.Update(entity);

                return (true, Res.UpdateSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i c?p nh?t: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa ký g?i
        /// </summary>
        public static (bool success, string message) Delete(string maKyGui)
        {
            try
            {
                // Ki?m tra quy?n
                if (!AppSession.CanDeleteConsignment)
                    return (false, Res.NoPermissionDelete);

                if (string.IsNullOrWhiteSpace(maKyGui))
                    return (false, Res.EnterCode);

                // Ki?m tra có th? xóa không
                var (canDelete, reason) = CanDelete(maKyGui);
                if (!canDelete)
                    return (false, reason);

                // Xóa
                KyGuiRuouDal.Delete(maKyGui);

                return (true, Res.DeleteSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i xóa: " + ex.Message);
            }
        }

        #endregion
    }
}
