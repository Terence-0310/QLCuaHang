using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Vai Trò
    /// </summary>
    public static class VaiTroBus
    {
        public static BusResult<List<VaiTro>> GetAll()
        {
            try
            {
                return BusResult<List<VaiTro>>.Ok(VaiTroDal.GetAll());
            }
            catch (Exception ex)
            {
                return BusResult<List<VaiTro>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }
    }
}
