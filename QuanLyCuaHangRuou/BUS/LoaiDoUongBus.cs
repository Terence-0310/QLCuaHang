using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Lo?i ?? U?ng (Facade cho GUI)
    /// Ch? ??c d? li?u - không c?n BLL
    /// </summary>
    public static class LoaiDoUongBus
    {
        /// <summary>
        /// L?y t?t c? lo?i ?? u?ng
        /// </summary>
        public static BusResult<List<LoaiDoUong>> GetAll()
        {
            try
            {
                var data = LoaiDoUongDal.GetAll();
                return BusResult<List<LoaiDoUong>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<LoaiDoUong>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }
    }
}
