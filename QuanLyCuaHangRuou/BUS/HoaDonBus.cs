using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Hóa ??n
    /// </summary>
    public static class HoaDonBus
    {
        public static BusResult<List<HoaDonDal.HoaDonGridRow>> Search(string keyword, DateTime? from = null, DateTime? to = null)
        {
            try
            {
                return BusResult<List<HoaDonDal.HoaDonGridRow>>.Ok(HoaDonDal.Search(keyword, from, to));
            }
            catch (Exception ex)
            {
                return BusResult<List<HoaDonDal.HoaDonGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        public static BusResult<HoaDonDal.HoaDonPrintDto> GetForPrint(string maHD)
        {
            try
            {
                var data = HoaDonDal.GetForPrint(maHD);
                return data != null 
                    ? BusResult<HoaDonDal.HoaDonPrintDto>.Ok(data) 
                    : BusResult<HoaDonDal.HoaDonPrintDto>.Fail("Không tìm th?y hóa ??n!");
            }
            catch (Exception ex)
            {
                return BusResult<HoaDonDal.HoaDonPrintDto>.Fail("L?i: " + ex.Message);
            }
        }
    }
}
