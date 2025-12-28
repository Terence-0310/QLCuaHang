using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmKyGuiRuou : Form
    {
        private UiMode _mode = UiMode.View;

        public FrmKyGuiRuou() { InitializeComponent(); }

        private void FrmKyGuiRuou_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvKyGui);
                WinFormsExtensions.AttachDataErrorHandler(dgvKyGui);

                cboKhachHang.DisplayMember = "TenKH";
                cboKhachHang.ValueMember = "MaKH";
                cboKhachHang.DataSource = KhachHangDal.GetAllForGrid();

                cboTrangThai.Items.Clear();
                cboTrangThai.Items.AddRange(new object[] { Res.StatusConsigning, Res.StatusSold, Res.StatusReturned });

                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError("L?i kh?i t?o: " + DbConfig.GetInnerMsg(ex)); }
        }

        private void dgvKyGui_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_mode != UiMode.View) return;
                var row = dgvKyGui.CurrentRow?.DataBoundItem as KyGuiRuouDal.KyGuiGridRow;
                if (row != null) DisplayRow(row);
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanEditConsignment) { ShowWarn(Res.NoPermissionDelete); return; }
                ClearInputs();
                txtMaKyGui.Text = KyGuiRuouDal.GenerateMaKyGui();
                SetMode(UiMode.Add);
                txtTenRuou.Focus();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanEditConsignment) { ShowWarn(Res.NoPermissionDelete); return; }
                var row = dgvKyGui.CurrentRow?.DataBoundItem as KyGuiRuouDal.KyGuiGridRow;
                if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }
                DisplayRow(row);
                SetMode(UiMode.Edit);
                txtTenRuou.Focus();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanDeleteConsignment) { ShowWarn(Res.NoPermissionDelete); return; }
                var row = dgvKyGui.CurrentRow?.DataBoundItem as KyGuiRuouDal.KyGuiGridRow;
                if (row == null) { ShowWarn(Res.SelectRowToDelete); return; }
                if (Confirm(Res.ConfirmDelete) != DialogResult.Yes) return;

                btnXoa.Enabled = false;
                Application.DoEvents();

                KyGuiRuouDal.Delete(row.MaKyGui);
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
                if (string.IsNullOrWhiteSpace(txtTenRuou.Text)) { ShowWarn(Res.EnterName); return; }
                if (cboKhachHang.SelectedValue == null) { ShowWarn(Res.EnterRequired); return; }

                btnLuu.Enabled = false;
                Application.DoEvents();

                var entity = new KyGuiRuou
                {
                    MaKyGui = txtMaKyGui.Text.Trim(),
                    MaKH = cboKhachHang.SelectedValue?.ToString(),
                    TenRuou = txtTenRuou.Text.Trim(),
                    DungTichConLai = nudSoLuong.Value,
                    DonViTinh = "ml",
                    NgayKyGui = dtpNgayKyGui.Value.Date,
                    HanKyGui = dtpNgayKyGui.Value.Date.AddMonths(6),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() ?? Res.StatusConsigning
                };

                if (_mode == UiMode.Add)
                {
                    if (KyGuiRuouDal.GetById(entity.MaKyGui) != null) { ShowWarn(Res.CodeExists); return; }
                    KyGuiRuouDal.Add(entity);
                    ShowInfo(Res.AddSuccess);
                }
                else
                {
                    KyGuiRuouDal.Update(entity);
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
                dgvKyGui.DataSource = string.IsNullOrWhiteSpace(kw) ? KyGuiRuouDal.GetAllForGrid() : KyGuiRuouDal.SearchForGrid(kw);
                WinFormsExtensions.HideIfExists(dgvKyGui, "HinhPath", "MaKH");
            }
            catch (Exception ex) { throw new Exception("L?i t?i d? li?u: " + DbConfig.GetInnerMsg(ex), ex); }
        }

        private void DisplayRow(KyGuiRuouDal.KyGuiGridRow row)
        {
            try
            {
                txtMaKyGui.Text = row.MaKyGui;
                txtTenRuou.Text = row.TenRuou;
                nudSoLuong.Value = row.DungTichConLai;
                dtpNgayKyGui.Value = row.NgayKyGui;

                for (int i = 0; i < cboKhachHang.Items.Count; i++)
                {
                    var item = cboKhachHang.Items[i] as KhachHangDal.KhachHangGridRow;
                    if (item != null && item.MaKH == row.MaKH) { cboKhachHang.SelectedIndex = i; break; }
                }

                int idx = cboTrangThai.Items.IndexOf(row.TrangThai);
                cboTrangThai.SelectedIndex = idx >= 0 ? idx : 0;
            }
            catch { }
        }

        private void SetMode(UiMode mode)
        {
            try
            {
                _mode = mode;
                bool canEdit = AppSession.CanEditConsignment;
                bool canDel = AppSession.CanDeleteConsignment;
                bool isView = mode == UiMode.View;

                btnThem.Enabled = isView && canEdit;
                btnSua.Enabled = isView && canEdit;
                btnXoa.Enabled = isView && canDel;
                btnLuu.Enabled = !isView;
                btnHuy.Enabled = !isView;

                txtMaKyGui.ReadOnly = true;
                txtTenRuou.ReadOnly = isView;
                cboKhachHang.Enabled = !isView && mode == UiMode.Add;
                cboTrangThai.Enabled = !isView;
                dtpNgayKyGui.Enabled = !isView && mode == UiMode.Add;
                nudSoLuong.Enabled = !isView;
            }
            catch { }
        }

        private void ClearInputs()
        {
            try
            {
                txtMaKyGui.Clear(); txtTenRuou.Clear();
                cboKhachHang.SelectedIndex = cboKhachHang.Items.Count > 0 ? 0 : -1;
                dtpNgayKyGui.Value = DateTime.Now;
                nudSoLuong.Value = 1;
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
