using System;
using System.IO;
using System.Windows.Forms;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmDoUong : Form
    {
        private UiMode _mode = UiMode.View;
        private string _currentMaLoai;

        public FrmDoUong() { InitializeComponent(); }

        private void FrmDoUong_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvDoUong);
                WinFormsExtensions.AttachDataErrorHandler(dgvDoUong);
                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError("L\u1ED7i kh\u1EDFi t\u1EA1o: " + DbConfig.GetInnerMsg(ex)); }
        }

        private void dgvDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_mode != UiMode.View) return;
                var row = dgvDoUong.CurrentRow?.DataBoundItem as DoUongDal.DoUongGridRow;
                if (row != null) DisplayRow(row);
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanEditCatalog) { ShowWarn(Res.NoPermissionDelete); return; }
                ClearInputs();
                _currentMaLoai = null;
                SetMode(UiMode.Add);
                txtMaDoUong.Focus();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanEditCatalog) { ShowWarn(Res.NoPermissionDelete); return; }
                var row = dgvDoUong.CurrentRow?.DataBoundItem as DoUongDal.DoUongGridRow;
                if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }
                DisplayRow(row);
                SetMode(UiMode.Edit);
                txtTenDoUong.Focus();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanDeleteDrink) { ShowWarn(Res.NoPermissionDelete); return; }
                var row = dgvDoUong.CurrentRow?.DataBoundItem as DoUongDal.DoUongGridRow;
                if (row == null) { ShowWarn(Res.SelectRowToDelete); return; }
                if (Confirm(Res.ConfirmDelete) != DialogResult.Yes) return;

                btnXoa.Enabled = false;
                Application.DoEvents();

                DoUongDal.Delete(row.MaDoUong);
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
                if (!ValidateInputs()) return;

                btnLuu.Enabled = false;
                Application.DoEvents();

                var entity = new DoUong
                {
                    MaDoUong = txtMaDoUong.Text.Trim(),
                    TenDoUong = txtTenDoUong.Text.Trim(),
                    DonGia = decimal.Parse(txtDonGia.Text.Trim()),
                    SoLuongTon = decimal.Parse(txtSoLuongTon.Text.Trim()),
                    GhiChu = txtGhiChu.Text.Trim(),
                    HinhPath = (picDoUong.Tag as string) ?? ""
                };

                if (_mode == UiMode.Add)
                {
                    if (DoUongDal.GetById(entity.MaDoUong) != null) { ShowWarn(Res.CodeExists); return; }
                    DoUongDal.Add(entity);
                    ShowInfo(Res.AddSuccess);
                }
                else
                {
                    DoUongDal.Update(entity);
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

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog { Filter = "Image|*.jpg;*.png;*.bmp" })
                    if (ofd.ShowDialog() == DialogResult.OK) { SetImage(ofd.FileName); picDoUong.Tag = ofd.FileName; }
            }
            catch { }
        }

        private void btnXoaHinh_Click(object sender, EventArgs e)
        {
            try { ClearImage(); picDoUong.Tag = ""; } catch { }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',') e.Handled = true;
        }

        // === HELPERS ===
        private void LoadData(string kw = null)
        {
            try
            {
                dgvDoUong.DataSource = string.IsNullOrWhiteSpace(kw) ? DoUongDal.GetAllForGrid() : DoUongDal.SearchForGrid(kw);
                WinFormsExtensions.HideIfExists(dgvDoUong, "HinhPath", "MaLoai");
            }
            catch (Exception ex) { throw new Exception("L\u1ED7i t\u1EA3i d\u1EEF li\u1EC7u: " + DbConfig.GetInnerMsg(ex), ex); }
        }

        private void DisplayRow(DoUongDal.DoUongGridRow row)
        {
            try
            {
                txtMaDoUong.Text = row.MaDoUong;
                txtTenDoUong.Text = row.TenDoUong;
                txtDonGia.Text = row.DonGia.ToString("0");
                txtSoLuongTon.Text = row.SoLuongTon.ToString("0.##");
                txtGhiChu.Text = row.GhiChu ?? "";
                _currentMaLoai = row.MaLoai;
                SetImage(row.HinhPath);
            }
            catch { }
        }

        private void SetMode(UiMode mode)
        {
            try
            {
                _mode = mode;
                bool canEdit = AppSession.CanEditCatalog;
                bool canDel = AppSession.CanDeleteDrink;
                bool isView = mode == UiMode.View;

                btnThem.Enabled = isView && canEdit;
                btnSua.Enabled = isView && canEdit;
                btnXoa.Enabled = isView && canDel;
                btnLuu.Enabled = !isView;
                btnHuy.Enabled = !isView;

                txtMaDoUong.ReadOnly = isView || mode == UiMode.Edit;
                txtTenDoUong.ReadOnly = isView;
                txtDonGia.ReadOnly = isView;
                txtSoLuongTon.ReadOnly = isView;
                txtGhiChu.ReadOnly = isView;
                btnChonHinh.Enabled = !isView;
                btnXoaHinh.Enabled = !isView;
            }
            catch { }
        }

        private void ClearInputs()
        {
            try
            {
                txtMaDoUong.Clear(); txtTenDoUong.Clear(); txtDonGia.Clear();
                txtSoLuongTon.Clear(); txtGhiChu.Clear(); _currentMaLoai = null; ClearImage();
            }
            catch { }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaDoUong.Text)) { ShowWarn(Res.EnterCode); return false; }
            if (string.IsNullOrWhiteSpace(txtTenDoUong.Text)) { ShowWarn(Res.EnterName); return false; }
            if (!decimal.TryParse(txtDonGia.Text, out var price) || price < 0) { ShowWarn(Res.InvalidPrice); return false; }
            if (!decimal.TryParse(txtSoLuongTon.Text, out var qty) || qty < 0) { ShowWarn(Res.InvalidQuantity); return false; }
            return true;
        }

        private void SetImage(string path)
        {
            ClearImage();
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return;
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    picDoUong.Image = System.Drawing.Image.FromStream(fs);
                    picDoUong.Tag = path;
                }
            }
            catch { }
        }

        private void ClearImage()
        {
            try { picDoUong.Image?.Dispose(); picDoUong.Image = null; picDoUong.Tag = null; } catch { }
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
