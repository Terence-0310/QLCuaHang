using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.BLL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Bán Hàng (Facade cho GUI)
    /// </summary>
    public static class BanHangBus
    {
        /// <summary>
        /// Thanh toán hóa ??n
        /// </summary>
        public static BusResult ThanhToan(string maHD, DateTime ngay, string maKH, string maNV, string ghiChu, List<DAL.BanHangDal.GioHangItem> items)
        {
            var (success, message) = BanHangBll.ProcessPayment(maHD, ngay, maKH, maNV, ghiChu, items);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// Thêm s?n ph?m vào gi? hàng
        /// </summary>
        public static BusResult AddToCart(string maDoUong, int quantity, List<DAL.BanHangDal.GioHangItem> currentCart)
        {
            var (success, message) = BanHangBll.AddToCart(maDoUong, quantity, currentCart);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// Tính t?ng ti?n gi? hàng
        /// </summary>
        public static decimal CalculateTotal(List<DAL.BanHangDal.GioHangItem> items) =>
            BanHangBll.CalculateTotal(items);

        /// <summary>
        /// T?o mã hóa ??n m?i
        /// </summary>
        public static string GenerateMaHD() =>
            BanHangBll.GenerateInvoiceCode();
    }
}
