using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BLL
{
    /// <summary>
    /// Business Logic Layer cho Bán Hàng
    /// </summary>
    public static class BanHangBll
    {
        #region Validation

        /// <summary>
        /// Validate ??n hàng
        /// </summary>
        public static string ValidateOrder(string maHD, List<BanHangDal.GioHangItem> items)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                return "Mã hóa ??n không h?p l?!";

            if (items == null || items.Count == 0)
                return Res.CartEmpty;

            foreach (var item in items)
            {
                if (string.IsNullOrWhiteSpace(item.MaDoUong))
                    return "Mã ?? u?ng không h?p l?!";
                if (item.SoLuong <= 0)
                    return "S? l??ng ph?i l?n h?n 0!";
                if (item.DonGia < 0)
                    return "??n giá không h?p l?!";
            }

            return null;
        }

        /// <summary>
        /// Ki?m tra t?n kho
        /// </summary>
        public static (bool success, string message) CheckStockAvailability(List<BanHangDal.GioHangItem> items)
        {
            foreach (var item in items)
            {
                var (canSell, reason) = DoUongBll.CanSell(item.MaDoUong, item.SoLuong);
                if (!canSell)
                    return (false, reason);
            }
            return (true, null);
        }

        #endregion

        #region Cart Operations

        /// <summary>
        /// Thêm vào gi? hàng
        /// </summary>
        public static (bool success, string message) AddToCart(string maDoUong, int quantity, List<BanHangDal.GioHangItem> currentCart)
        {
            if (quantity <= 0)
                return (false, Res.QtyMustBePositive);

            var doUong = DoUongDal.GetById(maDoUong);
            if (doUong == null)
                return (false, "Không tìm th?y ?? u?ng!");

            if (doUong.TrangThai == Res.StatusOutOfStock)
                return (false, $"'{doUong.TenDoUong}' ?ã ng?ng kinh doanh!");

            if (doUong.HanSuDung.HasValue && doUong.HanSuDung.Value < DateTime.Today)
                return (false, $"'{doUong.TenDoUong}' ?ã h?t h?n!");

            int existingQty = currentCart?.FirstOrDefault(x => x.MaDoUong == maDoUong)?.SoLuong ?? 0;
            if (doUong.SoLuongTon < existingQty + quantity)
                return (false, $"T?n kho không ??! Còn: {doUong.SoLuongTon}");

            return (true, null);
        }

        #endregion

        #region Calculations

        /// <summary>
        /// Tính t?ng ti?n
        /// </summary>
        public static decimal CalculateTotal(List<BanHangDal.GioHangItem> items) =>
            items?.Sum(x => x.DonGia * x.SoLuong) ?? 0;

        /// <summary>
        /// Sinh mã hóa ??n
        /// </summary>
        public static string GenerateInvoiceCode() =>
            "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

        #endregion

        #region Payment

        /// <summary>
        /// X? lý thanh toán
        /// </summary>
        public static (bool success, string message) ProcessPayment(
            string maHD, DateTime ngayHD, string maKH, string maNV, string ghiChu,
            List<BanHangDal.GioHangItem> items)
        {
            try
            {
                if (!AppSession.CanSell)
                    return (false, "B?n không có quy?n th?c hi?n bán hàng!");

                var error = ValidateOrder(maHD, items);
                if (error != null)
                    return (false, error);

                if (HoaDonDal.GetById(maHD) != null)
                    return (false, "Mã hóa ??n ?ã t?n t?i!");

                var (stockOk, stockMessage) = CheckStockAvailability(items);
                if (!stockOk)
                    return (false, stockMessage);

                BanHangDal.ThanhToan(maHD, ngayHD, maKH, maNV, ghiChu, items);

                return (true, Res.PaymentSuccess);
            }
            catch (Exception ex)
            {
                return (false, "L?i thanh toán: " + ex.Message);
            }
        }

        #endregion
    }
}
