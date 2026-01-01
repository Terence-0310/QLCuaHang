using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Lo?i ?? U?ng
    /// </summary>
    public static class LoaiDoUongBus
    {
        public static BusResult<List<LoaiDoUong>> GetAll()
        {
            try
            {
                return BusResult<List<LoaiDoUong>>.Ok(LoaiDoUongDal.GetAll());
            }
            catch (Exception ex)
            {
                return BusResult<List<LoaiDoUong>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }
    }
}
