using System;
using System.IO;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
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
                
                // Set labels
                lblTim.Text = Res.HeaderTimKiem;
                this.Text = Res.FrmKhachHangTitle;
                
                LoadTrangThaiCombo();
                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError(Res.Error + ": " + ex.Message); }
        }

        private void LoadTrangThaiCombo()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add(Res.StatusActive);
            cboTrangThai.Items.Add(Res.StatusInactive);
            cboTrangThai.SelectedIndex = 0;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_mode != UiMode.View) return;
            var row = dgvKhachHang.CurrentRow?.DataBoundItem as KhachHangDal.KhachHangGridRow;
            if (row != null) DisplayRow(row);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInputs();
            SetMode(UiMode.Add);
            txtMaKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var row = dgvKhachHang.CurrentRow?.DataBoundItem as KhachHangDal.KhachHangGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }
            DisplayRow(row);
            SetMode(UiMode.Edit);
            txtTenKH.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var row = dgvKhachHang.CurrentRow?.DataBoundItem as KhachHangDal.KhachHangGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToDelete); return; }
            if (Confirm(Res.ConfirmDelete) != DialogResult.Yes) return;

            btnXoa.Enabled = false;
            Application.DoEvents();

            try
            {
                var result = KhachHangBus.Delete(row.MaKH);
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
                var entity = new KhachHang
                {
                    MaKH = txtMaKH.Text.Trim(),
                    TenKH = txtTenKH.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() ?? Res.StatusActive,
                    HinhPath = (picKhachHang.Tag as string) ?? ""
                };

                BusResult result;
                if (_mode == UiMode.Add)
                    result = KhachHangBus.Add(entity);
                else
                    result = KhachHangBus.Update(entity);

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
                if (ofd.ShowDialog() == DialogResult.OK) { SetImage(ofd.FileName); picKhachHang.Tag = ofd.FileName; }
        }

        private void btnXoaHinh_Click(object sender, EventArgs e)
        {
            ClearImage();
            picKhachHang.Tag = "";
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        // === HELPERS ===
        private void LoadData(string kw = null)
        {
            var result = string.IsNullOrWhiteSpace(kw) 
                ? KhachHangBus.GetAll() 
                : KhachHangBus.Search(kw);
            
            if (result.Success)
            {
                dgvKhachHang.DataSource = result.Data;
                WinFormsExtensions.HideIfExists(dgvKhachHang, "HinhPath");
            }
            else
            {
                ShowError(result.Message);
            }
        }

        private void DisplayRow(KhachHangDal.KhachHangGridRow row)
        {
            txtMaKH.Text = row.MaKH;
            txtTenKH.Text = row.TenKH;
            txtSDT.Text = row.SoDienThoai;
            txtDiaChi.Text = row.DiaChi;

            int idx = cboTrangThai.FindStringExact(row.TrangThai ?? "");
            cboTrangThai.SelectedIndex = idx >= 0 ? idx : 0;

            SetImage(row.HinhPath);
        }

        private void SetMode(UiMode mode)
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
            cboTrangThai.Enabled = !isView;
            btnChonHinh.Enabled = !isView;
            btnXoaHinh.Enabled = !isView;
        }

        private void ClearInputs()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            cboTrangThai.SelectedIndex = 0;
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
                    picKhachHang.Image = System.Drawing.Image.FromStream(fs);
                    picKhachHang.Tag = path;
                }
            }
            catch { }
        }

        private void ClearImage()
        {
            picKhachHang.Image?.Dispose();
            picKhachHang.Image = null;
            picKhachHang.Tag = null;
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
