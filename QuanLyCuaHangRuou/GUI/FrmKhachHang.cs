using System;
using System.IO;
using System.Windows.Forms;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmKhachHang : Form
    {
        private UiMode _mode = UiMode.View;

        public FrmKhachHang() { InitializeComponent(); }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvKhachHang);
                WinFormsExtensions.AttachDataErrorHandler(dgvKhachHang);
                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError("L\u1ED7i kh\u1EDFi t\u1EA1o: " + DbConfig.GetInnerMsg(ex)); }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_mode != UiMode.View) return;
                var row = dgvKhachHang.CurrentRow?.DataBoundItem as KhachHangDal.KhachHangGridRow;
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
                SetMode(UiMode.Add);
                txtMaKH.Focus();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanEditCatalog) { ShowWarn(Res.NoPermissionDelete); return; }
                var row = dgvKhachHang.CurrentRow?.DataBoundItem as KhachHangDal.KhachHangGridRow;
                if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }
                DisplayRow(row);
                SetMode(UiMode.Edit);
                txtTenKH.Focus();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppSession.CanDeleteCustomer) { ShowWarn(Res.NoPermissionDelete); return; }
                var row = dgvKhachHang.CurrentRow?.DataBoundItem as KhachHangDal.KhachHangGridRow;
                if (row == null) { ShowWarn(Res.SelectRowToDelete); return; }
                if (Confirm(Res.ConfirmDelete) != DialogResult.Yes) return;

                btnXoa.Enabled = false;
                Application.DoEvents();

                KhachHangDal.Delete(row.MaKH);
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
                if (string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtTenKH.Text))
                { ShowWarn(Res.EnterCodeAndName); return; }

                btnLuu.Enabled = false;
                Application.DoEvents();

                var entity = new KhachHang
                {
                    MaKH = txtMaKH.Text.Trim(),
                    TenKH = txtTenKH.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    HinhPath = (picKhachHang.Tag as string) ?? ""
                };

                if (_mode == UiMode.Add)
                {
                    if (KhachHangDal.GetById(entity.MaKH) != null) { ShowWarn(Res.CodeExists); return; }
                    entity.TrangThai = Res.StatusActive;
                    KhachHangDal.Add(entity);
                    ShowInfo(Res.AddSuccess);
                }
                else
                {
                    KhachHangDal.Update(entity);
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
                    if (ofd.ShowDialog() == DialogResult.OK) { SetImage(ofd.FileName); picKhachHang.Tag = ofd.FileName; }
            }
            catch { }
        }

        private void btnXoaHinh_Click(object sender, EventArgs e)
        {
            try { ClearImage(); picKhachHang.Tag = ""; } catch { }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        // === HELPERS ===
        private void LoadData(string kw = null)
        {
            try
            {
                dgvKhachHang.DataSource = string.IsNullOrWhiteSpace(kw) ? KhachHangDal.GetAllForGrid() : KhachHangDal.SearchForGrid(kw);
                WinFormsExtensions.HideIfExists(dgvKhachHang, "HinhPath");
            }
            catch (Exception ex) { throw new Exception("L\u1ED7i t\u1EA3i d\u1EEF li\u1EC7u: " + DbConfig.GetInnerMsg(ex), ex); }
        }

        private void DisplayRow(KhachHangDal.KhachHangGridRow row)
        {
            try
            {
                txtMaKH.Text = row.MaKH;
                txtTenKH.Text = row.TenKH;
                txtSDT.Text = row.SoDienThoai;
                txtDiaChi.Text = row.DiaChi;
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
                bool canDel = AppSession.CanDeleteCustomer;
                bool isView = mode == UiMode.View;

                btnThem.Enabled = isView && canEdit;
                btnSua.Enabled = isView && canEdit;
                btnXoa.Enabled = isView && canDel;
                btnLuu.Enabled = !isView;
                btnHuy.Enabled = !isView;

                txtMaKH.ReadOnly = isView || mode == UiMode.Edit;
                txtTenKH.ReadOnly = isView;
                txtSDT.ReadOnly = isView;
                txtDiaChi.ReadOnly = isView;
                btnChonHinh.Enabled = !isView;
                btnXoaHinh.Enabled = !isView;
            }
            catch { }
        }

        private void ClearInputs()
        {
            try { txtMaKH.Clear(); txtTenKH.Clear(); txtSDT.Clear(); txtDiaChi.Clear(); ClearImage(); } catch { }
        }

        private void SetImage(string path)
        {
            ClearImage();
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return;
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    picKhachHang.Image = System.Drawing.Image.FromStream(fs);
                    picKhachHang.Tag = path;
                }
            }
            catch { }
        }

        private void ClearImage()
        {
            try { picKhachHang.Image?.Dispose(); picKhachHang.Image = null; picKhachHang.Tag = null; } catch { }
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
