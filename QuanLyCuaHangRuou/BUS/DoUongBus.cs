using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho ?? U?ng
    /// </summary>
    public static class DoUongBus
    {
        public static BusResult<List<DoUongDal.DoUongGridRow>> GetAll()
        {
            try
            {
                return BusResult<List<DoUongDal.DoUongGridRow>>.Ok(DoUongDal.GetAllForGrid());
            }
            catch (Exception ex)
            {
                return BusResult<List<DoUongDal.DoUongGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }

        public static BusResult<List<DoUongDal.DoUongGridRow>> Search(string keyword)
        {
            try
            {
                return BusResult<List<DoUongDal.DoUongGridRow>>.Ok(DoUongDal.SearchForGrid(keyword));
            }
            catch (Exception ex)
            {
                return BusResult<List<DoUongDal.DoUongGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        public static BusResult Add(DoUong entity)
        {
            try
            {
                if (!AppSession.CanEditCatalog)
                    return BusResult.Fail(Res.NoPermissionAdd);

                var err = Validate(entity);
                if (err != null) return BusResult.Fail(err);

                if (DoUongDal.GetById(entity.MaDoUong) != null)
                    return BusResult.Fail(Res.CodeExists);

                Normalize(entity);
                DoUongDal.Add(entity);
                return BusResult.Ok(Res.AddSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i thêm: " + ex.Message);
            }
        }

        public static BusResult Update(DoUong entity)
        {
            try
            {
                if (!AppSession.CanEditCatalog)
                    return BusResult.Fail(Res.NoPermissionEdit);

                var err = Validate(entity);
                if (err != null) return BusResult.Fail(err);

                Normalize(entity);
                DoUongDal.Update(entity);
                return BusResult.Ok(Res.UpdateSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i c?p nh?t: " + ex.Message);
            }
        }

        public static BusResult Delete(string maDoUong)
        {
            try
            {
                if (!AppSession.CanDeleteDrink)
                    return BusResult.Fail(Res.NoPermissionDelete);

                if (string.IsNullOrWhiteSpace(maDoUong))
                    return BusResult.Fail(Res.EnterCode);

                DoUongDal.Delete(maDoUong);
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

        /// <summary>
        /// Ki?m tra ?? u?ng có th? bán ???c không
        /// </summary>
        public static BusResult<DoUong> CheckAvailableForSale(string maDoUong, int quantity)
        {
            try
            {
                var doUong = DoUongDal.GetById(maDoUong);
                if (doUong == null)
                    return BusResult<DoUong>.Fail("Không tìm th?y ?? u?ng!");

                if (doUong.TrangThai == Res.StatusOutOfStock)
                    return BusResult<DoUong>.Fail($"'{doUong.TenDoUong}' ?ã ng?ng kinh doanh!");

                if (doUong.SoLuongTon < quantity)
                    return BusResult<DoUong>.Fail($"T?n kho không ??! Còn: {doUong.SoLuongTon}");

                if (doUong.HanSuDung.HasValue && doUong.HanSuDung.Value < DateTime.Today)
                    return BusResult<DoUong>.Fail($"'{doUong.TenDoUong}' ?ã h?t h?n s? d?ng!");

                return BusResult<DoUong>.Ok(doUong);
            }
            catch (Exception ex)
            {
                return BusResult<DoUong>.Fail("L?i: " + ex.Message);
            }
        }

        private static string Validate(DoUong e)
        {
            if (e == null) return "D? li?u không h?p l?!";
            if (string.IsNullOrWhiteSpace(e.MaDoUong)) return Res.EnterCode;
            if (string.IsNullOrWhiteSpace(e.TenDoUong)) return Res.EnterName;
            if (e.DonGia < 0) return Res.InvalidPrice;
            if (e.SoLuongTon < 0) return Res.InvalidQuantity;
            return null;
        }

        private static void Normalize(DoUong e)
        {
            e.MaDoUong = e.MaDoUong?.Trim();
            e.TenDoUong = e.TenDoUong?.Trim();
            e.DonViTinh = string.IsNullOrWhiteSpace(e.DonViTinh) ? "Chai" : e.DonViTinh.Trim();
            e.GhiChu = e.GhiChu?.Trim();
            if (string.IsNullOrWhiteSpace(e.TrangThai)) e.TrangThai = Res.StatusInStock;
        }
    }
}
