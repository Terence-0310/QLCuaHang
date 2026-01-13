using System;
using System.Collections.Generic;
using QuanLyCuaHangRuou.BLL;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.BUS
{
    /// <summary>
    /// Business Service cho Nhân Viên (Facade cho GUI)
    /// Ch? chuy?n ti?p request t? GUI sang BLL
    /// </summary>
    public static class NhanVienBus
    {
        /// <summary>
        /// L?y t?t c? nhân viên
        /// </summary>
        public static BusResult<List<NhanVienDal.NhanVienGridRow>> GetAll()
        {
            try
            {
                var data = NhanVienBll.GetAll();
                return BusResult<List<NhanVienDal.NhanVienGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<NhanVienDal.NhanVienGridRow>>.Fail("L?i t?i d? li?u: " + ex.Message);
            }
        }

        /// <summary>
        /// Tìm ki?m nhân viên
        /// </summary>
        public static BusResult<List<NhanVienDal.NhanVienGridRow>> Search(string keyword)
        {
            try
            {
                var data = NhanVienBll.Search(keyword);
                return BusResult<List<NhanVienDal.NhanVienGridRow>>.Ok(data);
            }
            catch (Exception ex)
            {
                return BusResult<List<NhanVienDal.NhanVienGridRow>>.Fail("L?i tìm ki?m: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm nhân viên m?i v?i tài kho?n
        /// </summary>
        public static BusResult Add(NhanVien nv, string username, string password, string vaiTro)
        {
            var tk = new TaiKhoan
            {
                MaTK = NhanVienBll.GenerateAccountCode(),
                Username = username,
                Password = password,
                MaVaiTro = vaiTro,
                TrangThai = true
            };

            var (success, message) = NhanVienBll.AddEmployeeWithAccount(nv, tk);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// C?p nh?t thông tin nhân viên
        /// </summary>
        public static BusResult Update(string maNV, string tenNV, string sdt, string diaChi, string trangThai, string vaiTro, string maTK)
        {
            var (success, message) = NhanVienBll.UpdateEmployee(maNV, tenNV, sdt, diaChi, trangThai, vaiTro, maTK);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        public static BusResult Delete(string maNV)
        {
            var (success, message, isSoftDelete) = NhanVienBll.DeleteEmployee(maNV);
            return success ? BusResult.Ok(message) : BusResult.Fail(message);
        }
    }
}
