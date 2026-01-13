using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Hóa ??n (Facade cho GUI)
    /// Ch? ??c/tìm ki?m - không c?n BLL ph?c t?p
    /// </summary>
    public static class HoaDonBus
    {
        /// <summary>
        /// Tìm ki?m hóa ??n
        /// </summary>
        public static BusResult<List<HoaDonDal.HoaDonGridRow>> Search(string keyword, DateTime? from = null, DateTime? to = null)
        {
            try
            {
                var data = HoaDonDal.Search(keyword, from, to);
                return BusResult<List<HoaDonDal.HoaDonGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<HoaDonDal.HoaDonGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        /// <summary>
        /// L?y hóa ??n ?? in
        /// </summary>
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
