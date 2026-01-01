using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Logic cho Nhân Viên
    /// </summary>
    public static class NhanVienBus
    {
        public static BusResult<List<NhanVienDal.NhanVienGridRow>> GetAll()
        {
            try
            {
                if (!AppSession.CanViewEmployees)
                    return BusResult<List<NhanVienDal.NhanVienGridRow>>.Fail(Res.NoPermissionEdit);

                return BusResult<List<NhanVienDal.NhanVienGridRow>>.Ok(NhanVienDal.GetAllForGrid());
            }
            catch (Exception ex)
            {
                return BusResult<List<NhanVienDal.NhanVienGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }

        public static BusResult<List<NhanVienDal.NhanVienGridRow>> Search(string keyword)
        {
            try
            {
                if (!AppSession.CanViewEmployees)
                    return BusResult<List<NhanVienDal.NhanVienGridRow>>.Fail(Res.NoPermissionEdit);

                return BusResult<List<NhanVienDal.NhanVienGridRow>>.Ok(NhanVienDal.SearchForGrid(keyword));
            }
            catch (Exception ex)
            {
                return BusResult<List<NhanVienDal.NhanVienGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        public static BusResult Add(NhanVien nv, string username, string password, string vaiTro)
        {
            try
            {
                if (!AppSession.CanEditEmployees)
                    return BusResult.Fail(Res.NoPermissionAdd);

                var err = Validate(nv);
                if (err != null) return BusResult.Fail(err);

                if (NhanVienDal.ExistsMaNV(nv.MaNV))
                    return BusResult.Fail(Res.CodeExists);

                if (TaiKhoanDal.ExistsUsername(username))
                    return BusResult.Fail("Tên ??ng nh?p ?ã t?n t?i!");

                if (!AppSession.IsAdmin && (vaiTro == PermissionKeys.RoleAdmin || vaiTro == PermissionKeys.RoleManager))
                    return BusResult.Fail(Res.CannotCreateAdmin);

                Normalize(nv);
                var tk = new TaiKhoan
                {
                    MaTK = TaiKhoanDal.GenerateMaTK(),
                    Username = username?.Trim(),
                    Password = password,
                    MaVaiTro = vaiTro,
                    TrangThai = true
                };

                NhanVienDal.AddWithAccount(nv, tk);
                return BusResult.Ok(Res.AddSuccess);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i thêm: " + ex.Message);
            }
        }

        public static BusResult Update(string maNV, string tenNV, string sdt, string diaChi, string trangThai, string vaiTro, string maTK)
        {
            try
            {
                if (!AppSession.CanEditEmployees)
                    return BusResult.Fail(Res.NoPermissionEdit);

                if (string.IsNullOrWhiteSpace(maNV)) return BusResult.Fail(Res.EnterCode);
                if (string.IsNullOrWhiteSpace(tenNV)) return BusResult.Fail(Res.EnterName);

                NhanVienDal.UpdateWithRoleAndStatus(maNV, tenNV.Trim(), sdt?.Trim(), diaChi?.Trim(), trangThai, vaiTro, maTK);
                return BusResult.Ok(Res.UpdateSuccess);
            }
            catch (InvalidOperationException ex)
            {
                return BusResult.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return BusResult.Fail("L?i c?p nh?t: " + ex.Message);
            }
        }

        public static BusResult Delete(string maNV)
        {
            try
            {
                if (!AppSession.CanDeleteEmployees)
                    return BusResult.Fail(Res.NoPermissionDelete);

                if (string.IsNullOrWhiteSpace(maNV))
                    return BusResult.Fail(Res.EnterCode);

                NhanVienDal.Delete(maNV);
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

        private static string Validate(NhanVien nv)
        {
            if (nv == null) return "D? li?u không h?p l?!";
            if (string.IsNullOrWhiteSpace(nv.MaNV)) return Res.EnterCode;
            if (string.IsNullOrWhiteSpace(nv.TenNV)) return Res.EnterName;
            return null;
        }

        private static void Normalize(NhanVien nv)
        {
            nv.MaNV = nv.MaNV?.Trim();
            nv.TenNV = nv.TenNV?.Trim();
            nv.SoDienThoai = nv.SoDienThoai?.Trim();
            nv.DiaChi = nv.DiaChi?.Trim();
            if (string.IsNullOrWhiteSpace(nv.TrangThai)) nv.TrangThai = Res.StatusWorking;
        }
    }
}
