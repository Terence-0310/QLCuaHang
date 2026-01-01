using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
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
                
                // Đặt tiêu đề và nhãn cho form
                lblTim.Text = Res.HeaderTimKiem;
                this.Text = Res.FrmNhanVienTitle;
                
                LoadComboBoxes();
                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError(Res.Error + ": " + ex.Message); }
        }

        private void LoadComboBoxes()
        {
            cboVaiTro.Items.Clear();
            var vaiTroResult = VaiTroBus.GetAll();
            if (vaiTroResult.Success && vaiTroResult.Data != null)
            {
                foreach (var vt in vaiTroResult.Data)
                    cboVaiTro.Items.Add(vt.MaVaiTro);
            }
            else
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_mode != UiMode.View) return;
            var row = dgvNhanVien.CurrentRow?.DataBoundItem as NhanVienDal.NhanVienGridRow;
            if (row != null) DisplayRow(row);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInputs();
            SetMode(UiMode.Add);
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var row = dgvNhanVien.CurrentRow?.DataBoundItem as NhanVienDal.NhanVienGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }
            DisplayRow(row);
            SetMode(UiMode.Edit);
            txtTenNV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var row = dgvNhanVien.CurrentRow?.DataBoundItem as NhanVienDal.NhanVienGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToDelete); return; }
            if (Confirm(Res.ConfirmDelete) != DialogResult.Yes) return;

            btnXoa.Enabled = false;
            Application.DoEvents();

            try
            {
                var result = NhanVienBus.Delete(row.MaNV);
                LoadData();
                ClearInputs();

                if (result.Success)
                    ShowInfo(result.Message ?? Res.DeleteSuccess);
                else
                    ShowWarn(result.Message);
            }
            finally { btnXoa.Enabled = true; }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            Application.DoEvents();

            try
            {
                string maNV = txtMaNV.Text.Trim();
                string tenNV = txtTenNV.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string vaiTro = cboVaiTro.SelectedItem?.ToString() ?? PermissionKeys.RoleStaff;
                string trangThai = cboTrangThai.SelectedItem?.ToString() ?? Res.StatusWorking;

                BusResult result;
                if (_mode == UiMode.Add)
                {
                    var nv = new NhanVien
                    {
                        MaNV = maNV,
                        TenNV = tenNV,
                        SoDienThoai = sdt,
                        DiaChi = diaChi,
                        TrangThai = trangThai
                    };
                    // Tạo mới nhân viên, tên đăng nhập = Mã NV, mật khẩu mặc định = "123456"
                    result = NhanVienBus.Add(nv, maNV, "123456", vaiTro);
                }
                else
                {
                    result = NhanVienBus.Update(maNV, tenNV, sdt, diaChi, trangThai, vaiTro, _currentMaTK);
                }

                if (result.Success)
                {
                    ShowInfo(result.Message);
                    LoadData();
                    SetMode(UiMode.View);
                }
                else
                {
                    ShowWarn(result.Message);
                }
            }
            finally { btnLuu.Enabled = true; }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInputs();
            SetMode(UiMode.View);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData(txtTim.Text.Trim());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            LoadData();
            ClearInputs();
            SetMode(UiMode.View);
        }

        // === HELPERS ===
        private void LoadData(string kw = null)
        {
            var result = string.IsNullOrWhiteSpace(kw)
                ? NhanVienBus.GetAll()
                : NhanVienBus.Search(kw);

            if (result.Success)
            {
                dgvNhanVien.DataSource = result.Data;
                WinFormsExtensions.HideIfExists(dgvNhanVien, "HinhPath", "MaTK", "MaVaiTro");
            }
            else
            {
                ShowError(result.Message);
            }
        }

        private void DisplayRow(NhanVienDal.NhanVienGridRow row)
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

        private void SetMode(UiMode mode)
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

        private void FilterVaiTroForManager()
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add(PermissionKeys.RoleStaff);
            cboVaiTro.Items.Add(PermissionKeys.RoleWarehouse);
            cboVaiTro.SelectedIndex = 0;
            cboVaiTro.Enabled = true;
        }

        private void ClearInputs()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            _currentMaTK = null;
            _currentMaVaiTro = null;
            _currentUsername = null;

            // Reload combo vai trò
            LoadComboBoxes();
            cboVaiTro.SelectedIndex = cboVaiTro.Items.Count > 0 ? cboVaiTro.Items.Count - 1 : -1;
            cboTrangThai.SelectedIndex = 0;
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
