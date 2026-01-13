using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.BLL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho ?? U?ng (Facade cho GUI)
    /// </summary>
    public static class DoUongBus
    {
        /// <summary>
        /// L?y t?t c? ?? u?ng
        /// </summary>
        public static BusResult<List<DAL.DoUongDal.DoUongGridRow>> GetAll()
        {
            try
            {
                var data = DAL.DoUongDal.GetAllForGrid();
                return BusResult<List<DAL.DoUongDal.DoUongGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<DAL.DoUongDal.DoUongGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }

        /// <summary>
        /// Tìm ki?m ?? u?ng
        /// </summary>
        public static BusResult<List<DAL.DoUongDal.DoUongGridRow>> Search(string keyword)
        {
            try
            {
                var data = DoUongBll.Search(keyword);
                return BusResult<List<DAL.DoUongDal.DoUongGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<DAL.DoUongDal.DoUongGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm ?? u?ng m?i
        /// </summary>
        public static BusResult Add(DoUong entity)
        {
            var (success, message) = DoUongBll.Add(entity);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// C?p nh?t ?? u?ng
        /// </summary>
        public static BusResult Update(DoUong entity)
        {
            var (success, message) = DoUongBll.Update(entity);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// Xóa ?? u?ng
        /// </summary>
        public static BusResult Delete(string maDoUong)
        {
            var (success, message, isSoftDelete) = DoUongBll.Delete(maDoUong);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// Ki?m tra ?? u?ng có th? bán ???c không
        /// </summary>
        public static BusResult<DoUong> CheckAvailableForSale(string maDoUong, int quantity)
        {
            try
            {
                var (canSell, reason) = DoUongBll.CanSell(maDoUong, quantity);
                if (!canSell)
                    return BusResult<DoUong>.Fail(reason);

                var doUong = DAL.DoUongDal.GetById(maDoUong);
                return BusResult<DoUong>.Ok(doUong);
            }
            catch (Exception ex)
            {
                return BusResult<DoUong>.Fail("L?i: " + ex.Message);
            }
        }

        /// <summary>
        /// L?y danh sách ?? u?ng còn hàng
        /// </summary>
        public static BusResult<List<DAL.DoUongDal.DoUongGridRow>> GetAvailableDrinks()
        {
            try
            {
                var data = DoUongBll.GetAvailableDrinks();
                return BusResult<List<DAL.DoUongDal.DoUongGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<DAL.DoUongDal.DoUongGridRow>>.Fail("L?i: " + ex.Message);
            }
        }

        /// <summary>
        /// L?y danh sách ?? u?ng s?p h?t hàng
        /// </summary>
        public static BusResult<List<DAL.DoUongDal.DoUongGridRow>> GetLowStockDrinks()
        {
            try
            {
                var data = DoUongBll.GetLowStockDrinks();
                return BusResult<List<DAL.DoUongDal.DoUongGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<DAL.DoUongDal.DoUongGridRow>>.Fail("L?i: " + ex.Message);
            }
        }
    }
}
