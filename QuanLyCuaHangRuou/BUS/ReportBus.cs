using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Báo Cáo
    /// </summary>
    public static class ReportBus
    {
        public static BusResult<List<ReportDal.DoanhThuRow>> GetDoanhThu(DateTime from, DateTime to)
        {
            try
            {
                if (!AppSession.CanViewStatistics)
                    return BusResult<List<ReportDal.DoanhThuRow>>.Fail("B?n không có quy?n xem báo cáo!");

                // Validate kho?ng ngày
                if (from > to)
                    return BusResult<List<ReportDal.DoanhThuRow>>.Fail("Ngày b?t ??u ph?i nh? h?n ho?c b?ng ngày k?t thúc!");

                // Validate kho?ng th?i gian không quá xa (t?i ?a 1 n?m)
                if ((to - from).TotalDays > 365)
                    return BusResult<List<ReportDal.DoanhThuRow>>.Fail("Kho?ng th?i gian báo cáo không ???c v??t quá 1 n?m!");

                return BusResult<List<ReportDal.DoanhThuRow>>.Ok(ReportDal.GetDoanhThuByDateRange(from, to));
            }
            catch (Exception ex)
            {
                return BusResult<List<ReportDal.DoanhThuRow>>.Fail("L?i t?i báo cáo: " + ex.Message);
            }
        }

        public static BusResult<List<vw_TonKho>> GetTonKho()
        {
            try
            {
                if (!AppSession.CanViewStatistics)
                    return BusResult<List<vw_TonKho>>.Fail("B?n không có quy?n xem báo cáo!");

                return BusResult<List<vw_TonKho>>.Ok(ReportDal.GetTonKho());
            }
            catch (Exception ex)
            {
                return BusResult<List<vw_TonKho>>.Fail("L?i t?i báo cáo: " + ex.Message);
            }
        }

        public static BusResult<List<vw_TonKho>> SearchTonKho(string keyword)
        {
            try
            {
                if (!AppSession.CanViewStatistics)
                    return BusResult<List<vw_TonKho>>.Fail("B?n không có quy?n xem báo cáo!");

                return BusResult<List<vw_TonKho>>.Ok(ReportDal.SearchTonKho(keyword));
            }
            catch (Exception ex)
            {
                return BusResult<List<vw_TonKho>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        public static decimal CalculateTotalRevenue(List<ReportDal.DoanhThuRow> data) =>
            data?.Sum(x => x.TongTien) ?? 0;

        public static decimal CalculateTotalStock(List<vw_TonKho> data) =>
            data?.Sum(x => x.SoLuongTon) ?? 0;
    }
}
