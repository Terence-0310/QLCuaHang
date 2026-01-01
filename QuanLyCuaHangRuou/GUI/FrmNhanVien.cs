using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmNhanVien : Form
    {
        private UiMode _mode = UiMode.View;
        private string _currentMaTK;
        private string _currentMaVaiTro;
        private string _currentUsername;

        public FrmNhanVien() { InitializeComponent(); }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvNhanVien);
                WinFormsExtensions.AttachDataErrorHandler(dgvNhanVien);
                LoadComboBoxes();
                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError("Lỗi khởi tạo: " + DbConfig.GetInnerMsg(ex)); }
        }

        private void LoadComboBoxes()
        {
            try
            {
                cboVaiTro.Items.Clear();
                try 
                { 
                    foreach (var vt in VaiTroDal.GetAll()) 
                        cboVaiTro.Items.Add(vt.MaVaiTro); 
                }
                catch 
                { 
                    cboVaiTro.Items.AddRange(new[] { 
                        PermissionKeys.RoleAdmin, 
                        PermissionKeys.RoleManager, 
                        PermissionKeys.RoleStaff,
                        PermissionKeys.RoleWarehouse 
                    }); 
                }

                cboTrangThai.Items.Clear();
                cboTrangThai.Items.Add(Res.StatusWorking);
                cboTrangThai.Items.Add(Res.StatusQuit);
                cboTrangThai.SelectedIndex = 0;
            }
            catch { }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_mode != UiMode.View) return;
                var row = dgvNhanVien.CurrentRow?.DataBoundItem as NhanVienDal.NhanVienGridRow;
                if (row != null) DisplayRow(row);
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanEditEmployees) { ShowWarn(Res.NoPermissionAdd); return; }
                ClearInputs();
                SetMode(UiMode.Add);
                txtMaNV.Focus();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanEditEmployees) { ShowWarn(Res.NoPermissionEdit); return; }
                var row = dgvNhanVien.CurrentRow?.DataBoundItem as NhanVienDal.NhanVienGridRow;
                if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }
                DisplayRow(row);
                SetMode(UiMode.Edit);
                txtTenNV.Focus();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanDeleteEmployees) { ShowWarn(Res.NoPermissionDelete); return; }
                var row = dgvNhanVien.CurrentRow?.DataBoundItem as NhanVienDal.NhanVienGridRow;
                if (row == null) { ShowWarn(Res.SelectRowToDelete); return; }

                // Kiểm tra quyền xóa trước khi hỏi xác nhận
                if (!AppSession.CanDeleteEmployeeWithRole(row.MaVaiTro, row.Username))
                {
                    if (string.Equals(AppSession.CurrentUser, row.Username, StringComparison.OrdinalIgnoreCase))
                    {
                        ShowWarn(Res.CannotDeleteSelf);
                        return;
                    }
                    if (row.MaVaiTro == PermissionKeys.RoleAdmin)
                    {
                        ShowWarn(Res.CannotDeleteAdmin);
                        return;
                    }
                    if (row.MaVaiTro == PermissionKeys.RoleManager && !AppSession.IsAdmin)
                    {
                        ShowWarn(Res.CannotDeleteManager);
                        return;
                    }
                    ShowWarn(Res.NoPermissionDelete);
                    return;
                }

                if (Confirm(Res.ConfirmDelete) != DialogResult.Yes) return;

                btnXoa.Enabled = false;
                Application.DoEvents();

                NhanVienDal.Delete(row.MaNV);
                LoadData(); ClearInputs();
                ShowInfo(Res.DeleteSuccess);
            }
            catch (InvalidOperationException ex) { LoadData(); ClearInputs(); ShowInfo(ex.Message); }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
            finally { btnXoa.Enabled = true; }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNV.Text)) { ShowWarn(Res.EnterCode); return; }
                if (string.IsNullOrWhiteSpace(txtTenNV.Text)) { ShowWarn(Res.EnterName); return; }
                if (_mode == UiMode.Add && cboVaiTro.SelectedIndex < 0) { ShowWarn(Res.EnterRequired); return; }

                btnLuu.Enabled = false;
                Application.DoEvents();

                string maNV = txtMaNV.Text.Trim();
                string tenNV = txtTenNV.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string vaiTro = cboVaiTro.SelectedItem?.ToString() ?? PermissionKeys.RoleStaff;
                string trangThai = cboTrangThai.SelectedItem?.ToString() ?? Res.StatusWorking;

                if (_mode == UiMode.Add)
                {
                    if (NhanVienDal.ExistsMaNV(maNV)) { ShowWarn(Res.CodeExists); return; }
                    
                    // Manager không được tạo Admin hoặc Manager
                    if (!AppSession.IsAdmin && (vaiTro == PermissionKeys.RoleAdmin || vaiTro == PermissionKeys.RoleManager))
                    {
                        ShowWarn(Res.CannotCreateAdmin);
                        return;
                    }

                    var tk = new TaiKhoan { MaTK = TaiKhoanDal.GenerateMaTK(), Username = maNV, Password = "123456", MaVaiTro = vaiTro, TrangThai = true };
                    var nv = new NhanVien { MaNV = maNV, TenNV = tenNV, SoDienThoai = sdt, DiaChi = diaChi, TrangThai = trangThai };
                    NhanVienDal.AddWithAccount(nv, tk);
                    ShowInfo(Res.AddSuccess);
                }
                else
                {
                    NhanVienDal.UpdateWithRoleAndStatus(maNV, tenNV, sdt, diaChi, trangThai, vaiTro, _currentMaTK);
                    ShowInfo(Res.UpdateSuccess);
                }
                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
            finally { btnLuu.Enabled = true; }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try { ClearInputs(); SetMode(UiMode.View); } catch { }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try { LoadData(txtTim.Text.Trim()); }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try { txtTim.Clear(); LoadData(); ClearInputs(); SetMode(UiMode.View); }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        // === HELPERS ===
        private void LoadData(string kw = null)
        {
            try
            {
                dgvNhanVien.DataSource = string.IsNullOrWhiteSpace(kw) ? NhanVienDal.GetAllForGrid() : NhanVienDal.SearchForGrid(kw);
                WinFormsExtensions.HideIfExists(dgvNhanVien, "HinhPath", "MaTK", "MaVaiTro");
            }
            catch (Exception ex) { throw new Exception("Lỗi tải dữ liệu: " + DbConfig.GetInnerMsg(ex), ex); }
        }

        private void DisplayRow(NhanVienDal.NhanVienGridRow row)
        {
            try
            {
                txtMaNV.Text = row.MaNV;
                txtTenNV.Text = row.TenNV;
                txtSDT.Text = row.SoDienThoai ?? "";
                txtDiaChi.Text = row.DiaChi ?? "";
                _currentMaTK = row.MaTK;
                _currentMaVaiTro = row.MaVaiTro;
                _currentUsername = row.Username;

                // Chọn vai trò trong combo
                if (!string.IsNullOrEmpty(row.MaVaiTro))
                {
                    int idx = cboVaiTro.Items.IndexOf(row.MaVaiTro);
                    cboVaiTro.SelectedIndex = idx >= 0 ? idx : -1;
                }
                else
                {
                    cboVaiTro.SelectedIndex = -1;
                }

                // Chọn trạng thái
                if (!string.IsNullOrEmpty(row.TrangThai))
                {
                    int idx = cboTrangThai.Items.IndexOf(row.TrangThai);
                    cboTrangThai.SelectedIndex = idx >= 0 ? idx : 0;
                }
            }
            catch { }
        }

        private void SetMode(UiMode mode)
        {
            try
            {
                _mode = mode;
                bool canEdit = AppSession.CanEditEmployees;
                bool canDel = AppSession.CanDeleteEmployees;
                bool isView = mode == UiMode.View;

                btnThem.Enabled = isView && canEdit;
                btnSua.Enabled = isView && canEdit;
                btnXoa.Enabled = isView && canDel;
                btnLuu.Enabled = !isView;
                btnHuy.Enabled = !isView;

                txtMaNV.ReadOnly = isView || mode == UiMode.Edit;
                txtTenNV.ReadOnly = isView;
                txtSDT.ReadOnly = isView;
                txtDiaChi.ReadOnly = isView;
                
                // Chỉ Admin mới được thay đổi vai trò
                cboVaiTro.Enabled = !isView && AppSession.IsAdmin;
                cboTrangThai.Enabled = !isView;

                // Nếu là Manager thì chỉ hiển thị vai trò STAFF và WAREHOUSE khi thêm mới
                if (!isView && mode == UiMode.Add && !AppSession.IsAdmin)
                {
                    FilterVaiTroForManager();
                }
            }
            catch { }
        }

        private void FilterVaiTroForManager()
        {
            try
            {
                cboVaiTro.Items.Clear();
                cboVaiTro.Items.Add(PermissionKeys.RoleStaff);
                cboVaiTro.Items.Add(PermissionKeys.RoleWarehouse);
                cboVaiTro.SelectedIndex = 0;
                cboVaiTro.Enabled = true;
            }
            catch { }
        }

        private void ClearInputs()
        {
            try
            {
                txtMaNV.Clear(); txtTenNV.Clear(); txtSDT.Clear(); txtDiaChi.Clear(); 
                _currentMaTK = null;
                _currentMaVaiTro = null;
                _currentUsername = null;
                
                // Reload combo vai trò
                LoadComboBoxes();
                cboVaiTro.SelectedIndex = cboVaiTro.Items.Count > 0 ? cboVaiTro.Items.Count - 1 : -1;
                cboTrangThai.SelectedIndex = 0;
            }
            catch { }
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
