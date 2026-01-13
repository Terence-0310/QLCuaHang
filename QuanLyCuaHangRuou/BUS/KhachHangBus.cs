using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.BLL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Khách Hàng (Facade cho GUI)
    /// Chuy?n ti?p các request t? GUI sang BLL
    /// </summary>
    public static class KhachHangBus
    {
        /// <summary>
        /// L?y t?t c? khách hàng
        /// </summary>
        public static BusResult<List<DAL.KhachHangDal.KhachHangGridRow>> GetAll()
        {
            try
            {
                var data = DAL.KhachHangDal.GetAllForGrid();
                return BusResult<List<DAL.KhachHangDal.KhachHangGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<DAL.KhachHangDal.KhachHangGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }

        /// <summary>
        /// Tìm ki?m khách hàng
        /// </summary>
        public static BusResult<List<DAL.KhachHangDal.KhachHangGridRow>> Search(string keyword)
        {
            try
            {
                var data = KhachHangBll.Search(keyword);
                return BusResult<List<DAL.KhachHangDal.KhachHangGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<DAL.KhachHangDal.KhachHangGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm khách hàng m?i
        /// </summary>
        public static BusResult Add(KhachHang entity)
        {
            var (success, message) = KhachHangBll.Add(entity);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// C?p nh?t khách hàng
        /// </summary>
        public static BusResult Update(KhachHang entity)
        {
            var (success, message) = KhachHangBll.Update(entity);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        public static BusResult Delete(string maKH)
        {
            var (success, message, isSoftDelete) = KhachHangBll.Delete(maKH);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// L?y danh sách khách hàng ?ang ho?t ??ng
        /// </summary>
        public static BusResult<List<DAL.KhachHangDal.KhachHangGridRow>> GetActiveCustomers()
        {
            try
            {
                var data = KhachHangBll.GetActiveCustomers();
                return BusResult<List<DAL.KhachHangDal.KhachHangGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<DAL.KhachHangDal.KhachHangGridRow>>.Fail("L?i: " + ex.Message);
            }
        }
    }
}
