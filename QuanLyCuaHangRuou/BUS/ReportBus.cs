using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.BLL;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Báo Cáo (Facade cho GUI)
    /// </summary>
    public static class ReportBus
    {
        /// <summary>
        /// L?y báo cáo doanh thu theo kho?ng th?i gian
        /// </summary>
        public static BusResult<List<ReportDal.DoanhThuRow>> GetDoanhThu(DateTime from, DateTime to)
        {
            var (success, message, data) = ReportBll.GetDoanhThu(from, to);
            return success 
                ? BusResult<List<ReportDal.DoanhThuRow>>.Ok(data) 
                : BusResult<List<ReportDal.DoanhThuRow>>.Fail(message);
        }

        /// <summary>
        /// L?y báo cáo t?n kho
        /// </summary>
        public static BusResult<List<vw_TonKho>> GetTonKho()
        {
            var (success, message, data) = ReportBll.GetTonKho();
            return success 
                ? BusResult<List<vw_TonKho>>.Ok(data) 
                : BusResult<List<vw_TonKho>>.Fail(message);
        }

        /// <summary>
        /// Tìm ki?m t?n kho
        /// </summary>
        public static BusResult<List<vw_TonKho>> SearchTonKho(string keyword)
        {
            var (success, message, data) = ReportBll.SearchTonKho(keyword);
            return success 
                ? BusResult<List<vw_TonKho>>.Ok(data) 
                : BusResult<List<vw_TonKho>>.Fail(message);
        }

        /// <summary>
        /// Tính t?ng doanh thu
        /// </summary>
        public static decimal CalculateTotalRevenue(List<ReportDal.DoanhThuRow> data) =>
            ReportBll.CalculateTotalRevenue(data);

        /// <summary>
        /// Tính t?ng s? l??ng t?n kho
        /// </summary>
        public static decimal CalculateTotalStock(List<vw_TonKho> data) =>
            ReportBll.CalculateTotalStock(data);
    }
}
