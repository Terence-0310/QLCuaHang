using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho V? Trí L?u Tr?
    /// </summary>
    public static class ViTriLuuTruBus
    {
        /// <summary>
        /// L?y t?t c? v? trí l?u tr? ?ang ho?t ??ng cho ComboBox
        /// </summary>
        public static BusResult<List<ViTriLuuTruDal.ViTriGridRow>> GetAllForCombo()
        {
            try
            {
                return BusResult<List<ViTriLuuTruDal.ViTriGridRow>>.Ok(ViTriLuuTruDal.GetAllForCombo());
            }
            catch (Exception ex)
            {
                return BusResult<List<ViTriLuuTruDal.ViTriGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }
    }
}
