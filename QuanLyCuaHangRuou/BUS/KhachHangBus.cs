using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Khách Hàng
    /// </summary>
    public static class KhachHangBus
    {
        public static BusResult<List<KhachHangDal.KhachHangGridRow>> GetAll()
        {
            try
            {
                return BusResult<List<KhachHangDal.KhachHangGridRow>>.Ok(KhachHangDal.GetAllForGrid());
            }
            catch (Exception ex)
            {
                return BusResult<List<KhachHangDal.KhachHangGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }

        public static BusResult<List<KhachHangDal.KhachHangGridRow>> Search(string keyword)
        {
            try
            {
                return BusResult<List<KhachHangDal.KhachHangGridRow>>.Ok(KhachHangDal.SearchForGrid(keyword));
            }
            catch (Exception ex)
            {
                return BusResult<List<KhachHangDal.KhachHangGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        public static BusResult Add(KhachHang entity)
        {
            try
            {
                if (!AppSession.CanEditCatalog)
                    return BusResult.Fail(Res.NoPermissionAdd);

                var err = Validate(entity);
                if (err != null) return BusResult.Fail(err);

                if (KhachHangDal.GetById(entity.MaKH) != null)
                    return BusResult.Fail(Res.CodeExists);

                Normalize(entity);
                KhachHangDal.Add(entity);
                return BusResult.Ok(Res.AddSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i thêm: " + ex.Message);
            }
        }

        public static BusResult Update(KhachHang entity)
        {
            try
            {
                if (!AppSession.CanEditCatalog)
                    return BusResult.Fail(Res.NoPermissionEdit);

                var err = Validate(entity);
                if (err != null) return BusResult.Fail(err);

                Normalize(entity);
                KhachHangDal.Update(entity);
                return BusResult.Ok(Res.UpdateSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i c?p nh?t: " + ex.Message);
            }
        }

        public static BusResult Delete(string maKH)
        {
            try
            {
                if (!AppSession.CanDeleteCustomer)
                    return BusResult.Fail(Res.NoPermissionDelete);

                if (string.IsNullOrWhiteSpace(maKH))
                    return BusResult.Fail(Res.EnterCode);

                KhachHangDal.Delete(maKH);
                return BusResult.Ok(Res.DeleteSuccess);
            }
            catch (InvalidOperationException ex)
            {
                return BusResult.Ok(ex.Message); // Soft delete
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i xóa: " + ex.Message);
            }
        }

        private static string Validate(KhachHang e)
        {
            if (e == null) return "D? li?u không h?p l?!";
            if (string.IsNullOrWhiteSpace(e.MaKH)) return Res.EnterCode;
            if (string.IsNullOrWhiteSpace(e.TenKH)) return Res.EnterName;
            return null;
        }

        private static void Normalize(KhachHang e)
        {
            e.MaKH = e.MaKH?.Trim();
            e.TenKH = e.TenKH?.Trim();
            e.SoDienThoai = e.SoDienThoai?.Trim();
            e.DiaChi = e.DiaChi?.Trim();
            if (string.IsNullOrWhiteSpace(e.TrangThai)) e.TrangThai = Res.StatusActive;
        }
    }
}
