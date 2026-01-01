using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Bán Hàng
    /// </summary>
    public static class BanHangBus
    {
        public static BusResult ThanhToan(string maHD, DateTime ngay, string maKH, string maNV, string ghiChu, List<BanHangDal.GioHangItem> items)
        {
            try
            {
                if (!AppSession.CanSell)
                    return BusResult.Fail("B?n không có quy?n th?c hi?n bán hàng!");

                if (items == null || items.Count == 0)
                    return BusResult.Fail(Res.CartEmpty);

                // Ki?m tra t?n kho t?ng s?n ph?m
                foreach (var item in items)
                {
                    var check = DoUongBus.CheckAvailableForSale(item.MaDoUong, item.SoLuong);
                    if (!check.Success)
                        return BusResult.Fail(check.Message);
                }

                BanHangDal.ThanhToan(maHD, ngay, maKH, maNV, ghiChu, items);
                return BusResult.Ok(Res.PaymentSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i thanh toán: " + ex.Message);
            }
        }

        public static BusResult AddToCart(string maDoUong, int quantity, List<BanHangDal.GioHangItem> currentCart)
        {
            try
            {
                if (quantity <= 0)
                    return BusResult.Fail(Res.QtyMustBePositive);

                var doUong = DoUongDal.GetById(maDoUong);
                if (doUong == null)
                    return BusResult.Fail("Không tìm th?y ?? u?ng!");

                if (doUong.TrangThai == Res.StatusOutOfStock)
                    return BusResult.Fail($"'{doUong.TenDoUong}' ?ã ng?ng kinh doanh!");

                if (doUong.HanSuDung.HasValue && doUong.HanSuDung.Value < DateTime.Today)
                    return BusResult.Fail($"'{doUong.TenDoUong}' ?ã h?t h?n!");

                int existingQty = currentCart?.FirstOrDefault(x => x.MaDoUong == maDoUong)?.SoLuong ?? 0;
                if (doUong.SoLuongTon < existingQty + quantity)
                    return BusResult.Fail($"T?n kho không ??! Còn: {doUong.SoLuongTon}");

                return BusResult.Ok();
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i: " + ex.Message);
            }
        }

        public static decimal CalculateTotal(List<BanHangDal.GioHangItem> items) =>
            items?.Sum(x => x.DonGia * x.SoLuong) ?? 0;

        public static string GenerateMaHD() =>
            "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
