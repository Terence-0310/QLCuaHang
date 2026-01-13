using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Vai Trò (Facade cho GUI)
    /// Ch? ??c d? li?u - không c?n BLL
    /// </summary>
    public static class VaiTroBus
    {
        /// <summary>
        /// L?y t?t c? vai trò
        /// </summary>
        public static BusResult<List<VaiTro>> GetAll()
        {
            try
            {
                var data = VaiTroDal.GetAll();
                return BusResult<List<VaiTro>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<VaiTro>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }
    }
}
