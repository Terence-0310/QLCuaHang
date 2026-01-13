using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho V? Trí L?u Tr? (Facade cho GUI)
    /// Ch? ??c d? li?u - không c?n BLL
    /// </summary>
    public static class ViTriLuuTruBus
    {
        /// <summary>
        /// L?y danh sách v? trí l?u tr? cho ComboBox
        /// </summary>
        public static BusResult<List<ViTriLuuTruDal.ViTriGridRow>> GetAllForCombo()
        {
            try
            {
                var data = ViTriLuuTruDal.GetAllForCombo();
                return BusResult<List<ViTriLuuTruDal.ViTriGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<ViTriLuuTruDal.ViTriGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }
    }
}
