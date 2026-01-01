using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Ký G?i R??u
    /// </summary>
    public static class KyGuiRuouBus
    {
        public static BusResult<List<KyGuiRuouDal.KyGuiGridRow>> GetAll()
        {
            try
            {
                return BusResult<List<KyGuiRuouDal.KyGuiGridRow>>.Ok(KyGuiRuouDal.GetAllForGrid());
            }
            catch (Exception ex)
            {
                return BusResult<List<KyGuiRuouDal.KyGuiGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }

        public static BusResult<List<KyGuiRuouDal.KyGuiGridRow>> Search(string keyword)
        {
            try
            {
                return BusResult<List<KyGuiRuouDal.KyGuiGridRow>>.Ok(KyGuiRuouDal.SearchForGrid(keyword));
            }
            catch (Exception ex)
            {
                return BusResult<List<KyGuiRuouDal.KyGuiGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        public static BusResult Add(KyGuiRuou entity)
        {
            try
            {
                if (!AppSession.CanEditConsignment)
                    return BusResult.Fail(Res.NoPermissionAdd);

                var err = Validate(entity, isAdd: true);
                if (err != null) return BusResult.Fail(err);

                if (KyGuiRuouDal.GetById(entity.MaKyGui) != null)
                    return BusResult.Fail(Res.CodeExists);

                if (string.IsNullOrWhiteSpace(entity.MaKH))
                    return BusResult.Fail(Res.SelectCustomer);

                Normalize(entity);
                KyGuiRuouDal.Add(entity);
                return BusResult.Ok(Res.AddSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i thêm: " + ex.Message);
            }
        }

        public static BusResult Update(KyGuiRuou entity)
        {
            try
            {
                if (!AppSession.CanEditConsignment)
                    return BusResult.Fail(Res.NoPermissionEdit);

                var err = Validate(entity, isAdd: false);
                if (err != null) return BusResult.Fail(err);

                var existing = KyGuiRuouDal.GetById(entity.MaKyGui);
                if (existing == null)
                    return BusResult.Fail("Không tìm th?y ký g?i!");

                if (existing.TrangThai == Res.StatusSold || existing.TrangThai == Res.StatusReturned)
                    return BusResult.Fail("Không th? ch?nh s?a ký g?i ?ã hoàn t?t!");

                Normalize(entity);
                KyGuiRuouDal.Update(entity);
                return BusResult.Ok(Res.UpdateSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i c?p nh?t: " + ex.Message);
            }
        }

        public static BusResult Delete(string maKyGui)
        {
            try
            {
                if (!AppSession.CanDeleteConsignment)
                    return BusResult.Fail(Res.NoPermissionDelete);

                if (string.IsNullOrWhiteSpace(maKyGui))
                    return BusResult.Fail(Res.EnterCode);

                var existing = KyGuiRuouDal.GetById(maKyGui);
                if (existing?.TrangThai == Res.StatusSold)
                    return BusResult.Fail("Không th? xóa ký g?i ?ã bán!");

                KyGuiRuouDal.Delete(maKyGui);
                return BusResult.Ok(Res.DeleteSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i xóa: " + ex.Message);
            }
        }

        public static string GenerateMaKyGui() => KyGuiRuouDal.GenerateMaKyGui();

        private static string Validate(KyGuiRuou e, bool isAdd)
        {
            if (e == null) return "D? li?u không h?p l?!";
            if (string.IsNullOrWhiteSpace(e.TenRuou)) return Res.EnterName;
            if (e.DungTichConLai < 0) return Res.InvalidQuantity;
            if (e.HanKyGui <= e.NgayKyGui) return "H?n ký g?i ph?i sau ngày ký g?i!";
            return null;
        }

        private static void Normalize(KyGuiRuou e)
        {
            e.MaKyGui = e.MaKyGui?.Trim();
            e.TenRuou = e.TenRuou?.Trim();
            e.DonViTinh = string.IsNullOrWhiteSpace(e.DonViTinh) ? "ml" : e.DonViTinh.Trim();
            e.ViTriLuuTru = e.ViTriLuuTru?.Trim();
            if (string.IsNullOrWhiteSpace(e.TrangThai)) e.TrangThai = Res.StatusConsigning;
        }
    }
}
