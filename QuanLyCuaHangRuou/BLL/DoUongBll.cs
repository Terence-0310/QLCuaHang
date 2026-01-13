using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BLL
{
    /// <summary>
    /// Business Logic Layer cho ?? U?ng
    /// </summary>
    public static class DoUongBll
    {
        #region Validation

        /// <summary>
        /// Validate d? li?u ?? u?ng
        /// </summary>
        public static string Validate(DoUong entity)
        {
            if (entity == null)
                return "D? li?u không h?p l?!";

            if (string.IsNullOrWhiteSpace(entity.MaDoUong))
                return Res.EnterCode;

            if (string.IsNullOrWhiteSpace(entity.TenDoUong))
                return Res.EnterName;

            if (entity.DonGia < 0)
                return Res.InvalidPrice;

            if (entity.SoLuongTon < 0)
                return Res.InvalidQuantity;

            if (entity.DungTich.HasValue && entity.DungTich.Value <= 0)
                return "Dung tích ph?i l?n h?n 0!";

            if (entity.HanSuDung.HasValue && entity.HanSuDung.Value < DateTime.Today)
                return "H?n s? d?ng không h?p l?!";

            return null;
        }

        /// <summary>
        /// Chu?n hóa d? li?u
        /// </summary>
        public static void Normalize(DoUong entity)
        {
            if (entity == null) return;

            entity.MaDoUong = entity.MaDoUong?.Trim().ToUpper();
            entity.TenDoUong = entity.TenDoUong?.Trim();
            entity.DonViTinh = string.IsNullOrWhiteSpace(entity.DonViTinh) ? "Chai" : entity.DonViTinh.Trim();
            entity.GhiChu = entity.GhiChu?.Trim();

            // T? ??ng c?p nh?t tr?ng thái
            if (entity.SoLuongTon <= 0)
                entity.TrangThai = Res.StatusOutOfStock;
            else if (entity.SoLuongTon < 10)
                entity.TrangThai = "S?p h?t";
            else if (string.IsNullOrWhiteSpace(entity.TrangThai) || entity.TrangThai == Res.StatusOutOfStock)
                entity.TrangThai = Res.StatusInStock;
        }

        #endregion

        #region Business Rules

        /// <summary>
        /// Ki?m tra mã ?ã t?n t?i
        /// </summary>
        public static bool IsCodeExists(string maDoUong) =>
            !string.IsNullOrWhiteSpace(maDoUong) && DoUongDal.GetById(maDoUong) != null;

        /// <summary>
        /// Ki?m tra có th? xóa không
        /// </summary>
        public static (bool canDelete, string reason) CanDelete(string maDoUong)
        {
            if (string.IsNullOrWhiteSpace(maDoUong))
                return (false, "Mã ?? u?ng không h?p l?!");

            var relations = DoUongDal.GetRelationships(maDoUong);
            if (!relations.hasRelations)
                return (true, null);

            if (AppSession.IsAdmin)
                return (true, null);

            var reasons = new List<string>();
            if (relations.hasInvoiceDetails) reasons.Add(Res.RelatedInvoice);
            if (relations.hasConsignments) reasons.Add(Res.RelatedConsignment);

            return (false, string.Join(", ", reasons));
        }

        /// <summary>
        /// Ki?m tra có th? bán không
        /// </summary>
        public static (bool canSell, string reason) CanSell(string maDoUong, int quantity)
        {
            var doUong = DoUongDal.GetById(maDoUong);
            if (doUong == null)
                return (false, "Không tìm th?y ?? u?ng!");

            if (doUong.TrangThai == Res.StatusOutOfStock)
                return (false, $"'{doUong.TenDoUong}' ?ã ng?ng kinh doanh!");

            if (doUong.SoLuongTon < quantity)
                return (false, $"T?n kho không ??! Còn: {doUong.SoLuongTon}");

            if (doUong.HanSuDung.HasValue && doUong.HanSuDung.Value < DateTime.Today)
                return (false, $"'{doUong.TenDoUong}' ?ã h?t h?n s? d?ng!");

            return (true, null);
        }

        #endregion

        #region Business Operations

        /// <summary>
        /// Tìm ki?m ?? u?ng
        /// </summary>
        public static List<DoUongDal.DoUongGridRow> Search(string keyword) =>
            DoUongDal.SearchForGrid(keyword);

        /// <summary>
        /// L?y ?? u?ng còn hàng
        /// </summary>
        public static List<DoUongDal.DoUongGridRow> GetAvailableDrinks() =>
            DoUongDal.GetAllForGrid().Where(x => x.TrangThai == Res.StatusInStock && x.SoLuongTon > 0).ToList();

        /// <summary>
        /// L?y ?? u?ng s?p h?t hàng
        /// </summary>
        public static List<DoUongDal.DoUongGridRow> GetLowStockDrinks(int threshold = 10) =>
            DoUongDal.GetAllForGrid().Where(x => x.SoLuongTon > 0 && x.SoLuongTon < threshold).OrderBy(x => x.SoLuongTon).ToList();

        /// <summary>
        /// Thêm ?? u?ng m?i
        /// </summary>
        public static (bool success, string message) Add(DoUong entity)
        {
            try
            {
                if (!AppSession.CanEditCatalog)
                    return (false, Res.NoPermissionAdd);

                var error = Validate(entity);
                if (error != null)
                    return (false, error);

                if (IsCodeExists(entity.MaDoUong))
                    return (false, Res.CodeExists);

                Normalize(entity);

                if (string.IsNullOrWhiteSpace(entity.MaLoai))
                    entity.MaLoai = LoaiDoUongDal.GetDefaultCategoryCode();

                DoUongDal.Add(entity);

                return (true, Res.AddSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i thêm ?? u?ng: " + ex.Message);
            }
        }

        /// <summary>
        /// C?p nh?t ?? u?ng
        /// </summary>
        public static (bool success, string message) Update(DoUong entity)
        {
            try
            {
                if (!AppSession.CanEditCatalog)
                    return (false, Res.NoPermissionEdit);

                var error = Validate(entity);
                if (error != null)
                    return (false, error);

                if (!IsCodeExists(entity.MaDoUong))
                    return (false, "Không tìm th?y ?? u?ng!");

                Normalize(entity);
                DoUongDal.Update(entity);

                return (true, Res.UpdateSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i c?p nh?t: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa ?? u?ng
        /// </summary>
        public static (bool success, string message, bool isSoftDelete) Delete(string maDoUong)
        {
            try
            {
                if (!AppSession.CanDeleteDrink)
                    return (false, Res.NoPermissionDelete, false);

                if (string.IsNullOrWhiteSpace(maDoUong))
                    return (false, Res.EnterCode, false);

                var (canDelete, reason) = CanDelete(maDoUong);

                if (AppSession.IsAdmin)
                {
                    DoUongDal.HardDelete(maDoUong);
                    return (true, Res.DeleteSuccess, false);
                }

                if (!canDelete)
                {
                    DoUongDal.SoftDelete(maDoUong);
                    return (true, Res.SoftDeleteDrink(reason), true);
                }

                DoUongDal.HardDelete(maDoUong);
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
