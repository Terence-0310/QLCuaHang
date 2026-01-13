using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BLL
{
    /// <summary>
    /// Business Logic Layer cho Báo Cáo
    /// </summary>
    public static class ReportBll
    {
        #region Validation

        /// <summary>
        /// Validate kho?ng th?i gian báo cáo
        /// </summary>
        public static string ValidateDateRange(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
                return "Ngày b?t ??u ph?i nh? h?n ho?c b?ng ngày k?t thúc!";

            if ((toDate - fromDate).TotalDays > 365)
                return "Kho?ng th?i gian báo cáo không ???c v??t quá 1 n?m!";

            return null;
        }

        #endregion

        #region Business Operations

        /// <summary>
        /// L?y báo cáo doanh thu
        /// </summary>
        public static (bool success, string message, List<ReportDal.DoanhThuRow> data) GetDoanhThu(DateTime fromDate, DateTime toDate)
        {
            try
            {
                // Ki?m tra quy?n
                if (!AppSession.CanViewStatistics)
                    return (false, "B?n không có quy?n xem báo cáo!", null);

                // Validate
                var error = ValidateDateRange(fromDate, toDate);
                if (error != null)
                    return (false, error, null);

                // L?y d? li?u
                var data = ReportDal.GetDoanhThuByDateRange(fromDate, toDate);
                return (true, null, data);
            }
            catch (Exception ex)
            {
                return (false, "L?i t?i báo cáo: " + ex.Message, null);
            }
        }

        /// <summary>
        /// L?y báo cáo t?n kho
        /// </summary>
        public static (bool success, string message, List<vw_TonKho> data) GetTonKho()
        {
            try
            {
                // Ki?m tra quy?n
                if (!AppSession.CanViewStatistics)
                    return (false, "B?n không có quy?n xem báo cáo!", null);

                // L?y d? li?u
                var data = ReportDal.GetTonKho();
                return (true, null, data);
            }
            catch (Exception ex)
            {
                return (false, "L?i t?i báo cáo: " + ex.Message, null);
            }
        }

        /// <summary>
        /// Tìm ki?m t?n kho
        /// </summary>
        public static (bool success, string message, List<vw_TonKho> data) SearchTonKho(string keyword)
        {
            try
            {
                // Ki?m tra quy?n
                if (!AppSession.CanViewStatistics)
                    return (false, "B?n không có quy?n xem báo cáo!", null);

                // L?y d? li?u
                var data = ReportDal.SearchTonKho(keyword);
                return (true, null, data);
            }
            catch (Exception ex)
            {
                return (false, "L?i tìm ki?m: " + ex.Message, null);
            }
        }

        /// <summary>
        /// Tính t?ng doanh thu
        /// </summary>
        public static decimal CalculateTotalRevenue(List<ReportDal.DoanhThuRow> data)
        {
            return data?.Sum(x => x.TongTien) ?? 0;
        }

        /// <summary>
        /// Tính t?ng t?n kho
        /// </summary>
        public static decimal CalculateTotalStock(List<vw_TonKho> data)
        {
            return data?.Sum(x => x.SoLuongTon) ?? 0;
        }

        #endregion
    }
}
