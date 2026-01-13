using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.BLL;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Ký G?i R??u (Facade cho GUI)
    /// </summary>
    public static class KyGuiRuouBus
    {
        /// <summary>
        /// L?y t?t c? ký g?i
        /// </summary>
        public static BusResult<List<KyGuiRuouDal.KyGuiGridRow>> GetAll()
        {
            try
            {
                var data = KyGuiRuouBll.GetAll();
                return BusResult<List<KyGuiRuouDal.KyGuiGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<KyGuiRuouDal.KyGuiGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }

        /// <summary>
        /// Tìm ki?m ký g?i
        /// </summary>
        public static BusResult<List<KyGuiRuouDal.KyGuiGridRow>> Search(string keyword)
        {
            try
            {
                var data = KyGuiRuouBll.Search(keyword);
                return BusResult<List<KyGuiRuouDal.KyGuiGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<KyGuiRuouDal.KyGuiGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm ký g?i m?i
        /// </summary>
        public static BusResult Add(KyGuiRuou entity)
        {
            var (success, message) = KyGuiRuouBll.Add(entity);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// C?p nh?t ký g?i
        /// </summary>
        public static BusResult Update(KyGuiRuou entity)
        {
            var (success, message) = KyGuiRuouBll.Update(entity);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// Xóa ký g?i
        /// </summary>
        public static BusResult Delete(string maKyGui)
        {
            var (success, message) = KyGuiRuouBll.Delete(maKyGui);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// T?o mã ký g?i m?i
        /// </summary>
        public static string GenerateMaKyGui() => KyGuiRuouBll.GenerateCode();
    }
}
