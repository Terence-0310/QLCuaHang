using System;
using System.IO;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
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
                
                // Set title
                this.Text = Res.FrmDoUongTitle;
                lblTim.Text = Res.HeaderTimKiem;
                
                dtpHanSuDung.Value = DateTime.Now.AddYears(1);
                chkHanSuDung.Checked = false;
                dtpHanSuDung.Enabled = false;
                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError(Res.Error + ": " + ex.Message); }
        }

        private void dgvDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_mode != UiMode.View) return;
            var row = dgvDoUong.CurrentRow?.DataBoundItem as DoUongDal.DoUongGridRow;
            if (row != null) DisplayRow(row);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInputs();
            _currentMaLoai = null;
            SetMode(UiMode.Add);
            txtMaDoUong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var row = dgvDoUong.CurrentRow?.DataBoundItem as DoUongDal.DoUongGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }
            DisplayRow(row);
            SetMode(UiMode.Edit);
            txtTenDoUong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var row = dgvDoUong.CurrentRow?.DataBoundItem as DoUongDal.DoUongGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToDelete); return; }
            if (Confirm(Res.ConfirmDelete) != DialogResult.Yes) return;

            btnXoa.Enabled = false;
            Application.DoEvents();

            try
            {
                var result = DoUongBus.Delete(row.MaDoUong);
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
                // Parse dữ liệu từ UI
                decimal donGia = 0;
                int soLuongTon = 0;
                decimal? dungTich = null;

                if (!string.IsNullOrWhiteSpace(txtDonGia.Text))
                    decimal.TryParse(txtDonGia.Text.Trim(), out donGia);

                if (!string.IsNullOrWhiteSpace(txtSoLuongTon.Text))
                    int.TryParse(txtSoLuongTon.Text.Trim(), out soLuongTon);

                if (!string.IsNullOrWhiteSpace(txtDungTich.Text))
                {
                    if (decimal.TryParse(txtDungTich.Text.Trim(), out var dt))
                        dungTich = dt;
                }

                var entity = new DoUong
                {
                    MaDoUong = txtMaDoUong.Text.Trim(),
                    TenDoUong = txtTenDoUong.Text.Trim(),
                    MaLoai = _currentMaLoai,
                    DonGia = donGia,
                    SoLuongTon = soLuongTon,
                    DungTich = dungTich,
                    HanSuDung = chkHanSuDung.Checked ? dtpHanSuDung.Value.Date : (DateTime?)null,
                    GhiChu = txtGhiChu.Text.Trim(),
                    HinhPath = (picDoUong.Tag as string) ?? ""
                };

                BusResult result;
                if (_mode == UiMode.Add)
                    result = DoUongBus.Add(entity);
                else
                    result = DoUongBus.Update(entity);

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

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Image|*.jpg;*.png;*.bmp" })
                if (ofd.ShowDialog() == DialogResult.OK) { SetImage(ofd.FileName); picDoUong.Tag = ofd.FileName; }
        }

        private void btnXoaHinh_Click(object sender, EventArgs e)
        {
            ClearImage();
            picDoUong.Tag = "";
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtDungTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',') e.Handled = true;
        }

        private void chkHanSuDung_CheckedChanged(object sender, EventArgs e)
        {
            dtpHanSuDung.Enabled = chkHanSuDung.Checked && _mode != UiMode.View;
        }

        // === HELPERS ===
        private void LoadData(string kw = null)
        {
            var result = string.IsNullOrWhiteSpace(kw)
                ? DoUongBus.GetAll()
                : DoUongBus.Search(kw);

            if (result.Success)
            {
                dgvDoUong.DataSource = result.Data;
                WinFormsExtensions.HideIfExists(dgvDoUong, "HinhPath", "MaLoai");
            }
            else
            {
                ShowError(result.Message);
            }
        }

        private void DisplayRow(DoUongDal.DoUongGridRow row)
        {
            txtMaDoUong.Text = row.MaDoUong;
            txtTenDoUong.Text = row.TenDoUong;
            txtDonGia.Text = row.DonGia.ToString("0");
            txtSoLuongTon.Text = row.SoLuongTon.ToString();
            txtDungTich.Text = row.DungTich?.ToString("0") ?? "";

            if (row.HanSuDung.HasValue)
            {
                chkHanSuDung.Checked = true;
                dtpHanSuDung.Value = row.HanSuDung.Value;
            }
            else
            {
                chkHanSuDung.Checked = false;
                dtpHanSuDung.Value = DateTime.Now.AddYears(1);
            }

            txtGhiChu.Text = row.GhiChu ?? "";
            _currentMaLoai = row.MaLoai;
            SetImage(row.HinhPath);
        }

        private void SetMode(UiMode mode)
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
            txtDungTich.ReadOnly = isView;
            dtpHanSuDung.Enabled = !isView && chkHanSuDung.Checked;
            chkHanSuDung.Enabled = !isView;
            txtGhiChu.ReadOnly = isView;
            btnChonHinh.Enabled = !isView;
            btnXoaHinh.Enabled = !isView;
        }

        private void ClearInputs()
        {
            txtMaDoUong.Clear();
            txtTenDoUong.Clear();
            txtDonGia.Clear();
            txtSoLuongTon.Clear();
            txtDungTich.Clear();
            txtGhiChu.Clear();
            chkHanSuDung.Checked = false;
            dtpHanSuDung.Value = DateTime.Now.AddYears(1);
            _currentMaLoai = null;
            ClearImage();
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
            picDoUong.Image?.Dispose();
            picDoUong.Image = null;
            picDoUong.Tag = null;
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        private void grpHinh_Enter(object sender, EventArgs e)
        {

        }
    }
}
