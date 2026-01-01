using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
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

                // Load danh sách khách hàng
                LoadKhachHang();

                // Load danh sách trạng thái
                cboTrangThai.Items.Clear();
                cboTrangThai.Items.AddRange(new object[] { Res.StatusConsigning, Res.StatusSold, Res.StatusReturned });

                // Load danh sách vị trí lưu trữ
                LoadViTriLuuTru();

                dtpHanKyGui.Value = DateTime.Now.AddMonths(6);

                LoadData();
                SetMode(UiMode.View);
            }
            catch (Exception ex) { ShowError("Lỗi khởi tạo: " + ex.Message); }
        }

        private void LoadKhachHang()
        {
            var result = KhachHangBus.GetAll();
            if (result.Success)
            {
                cboKhachHang.DisplayMember = "TenKH";
                cboKhachHang.ValueMember = "MaKH";
                cboKhachHang.DataSource = result.Data;
            }
        }

        private void LoadViTriLuuTru()
        {
            var result = ViTriLuuTruBus.GetAllForCombo();
            if (result.Success && result.Data != null && result.Data.Count > 0)
            {
                cboViTriLuuTru.DisplayMember = "TenViTri";
                cboViTriLuuTru.ValueMember = "MaViTri";
                cboViTriLuuTru.DataSource = result.Data;
            }
            else
            {
                cboViTriLuuTru.Items.Clear();
                cboViTriLuuTru.Items.Add("Chưa xác định");
            }
        }

        private void dgvKyGui_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_mode != UiMode.View) return;
            var row = dgvKyGui.CurrentRow?.DataBoundItem as KyGuiRuouDal.KyGuiGridRow;
            if (row != null) DisplayRow(row);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtMaKyGui.Text = KyGuiRuouBus.GenerateMaKyGui();
            SetMode(UiMode.Add);
            txtTenRuou.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var row = dgvKyGui.CurrentRow?.DataBoundItem as KyGuiRuouDal.KyGuiGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }
            DisplayRow(row);
            SetMode(UiMode.Edit);
            txtTenRuou.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var row = dgvKyGui.CurrentRow?.DataBoundItem as KyGuiRuouDal.KyGuiGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToDelete); return; }
            if (Confirm(Res.ConfirmDelete) != DialogResult.Yes) return;

            btnXoa.Enabled = false;
            Application.DoEvents();

            try
            {
                var result = KyGuiRuouBus.Delete(row.MaKyGui);
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
                var entity = new KyGuiRuou
                {
                    MaKyGui = txtMaKyGui.Text.Trim(),
                    MaKH = cboKhachHang.SelectedValue?.ToString(),
                    TenRuou = txtTenRuou.Text.Trim(),
                    DungTichConLai = nudSoLuong.Value,
                    DonViTinh = "ml",
                    NgayKyGui = dtpNgayKyGui.Value.Date,
                    HanKyGui = dtpHanKyGui.Value.Date,
                    ViTriLuuTru = cboViTriLuuTru.SelectedValue?.ToString() ?? "",
                    TrangThai = cboTrangThai.SelectedItem?.ToString() ?? Res.StatusConsigning
                };

                BusResult result;
                if (_mode == UiMode.Add)
                    result = KyGuiRuouBus.Add(entity);
                else
                    result = KyGuiRuouBus.Update(entity);

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
                ? KyGuiRuouBus.GetAll()
                : KyGuiRuouBus.Search(kw);

            if (result.Success)
            {
                dgvKyGui.DataSource = result.Data;
                WinFormsExtensions.HideIfExists(dgvKyGui, "HinhPath", "MaKH");
            }
            else
            {
                ShowError(result.Message);
            }
        }

        private void DisplayRow(KyGuiRuouDal.KyGuiGridRow row)
        {
            txtMaKyGui.Text = row.MaKyGui;
            txtTenRuou.Text = row.TenRuou;
            nudSoLuong.Value = row.DungTichConLai;
            dtpNgayKyGui.Value = row.NgayKyGui;
            dtpHanKyGui.Value = row.HanKyGui;

            // Chọn vị trí lưu trữ
            if (!string.IsNullOrEmpty(row.ViTriLuuTru))
            {
                for (int i = 0; i < cboViTriLuuTru.Items.Count; i++)
                {
                    var item = cboViTriLuuTru.Items[i] as ViTriLuuTruDal.ViTriGridRow;
                    if (item != null && item.MaViTri == row.ViTriLuuTru)
                    {
                        cboViTriLuuTru.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cboViTriLuuTru.SelectedIndex = cboViTriLuuTru.Items.Count > 0 ? 0 : -1;
            }

            // Chọn khách hàng
            for (int i = 0; i < cboKhachHang.Items.Count; i++)
            {
                var item = cboKhachHang.Items[i] as KhachHangDal.KhachHangGridRow;
                if (item != null && item.MaKH == row.MaKH) { cboKhachHang.SelectedIndex = i; break; }
            }

            int idx = cboTrangThai.Items.IndexOf(row.TrangThai);
            cboTrangThai.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private void SetMode(UiMode mode)
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
            dtpHanKyGui.Enabled = !isView;
            nudSoLuong.Enabled = !isView;
            cboViTriLuuTru.Enabled = !isView;
        }

        private void ClearInputs()
        {
            txtMaKyGui.Clear();
            txtTenRuou.Clear();
            cboKhachHang.SelectedIndex = cboKhachHang.Items.Count > 0 ? 0 : -1;
            dtpNgayKyGui.Value = DateTime.Now;
            dtpHanKyGui.Value = DateTime.Now.AddMonths(6);
            nudSoLuong.Value = 750;
            cboTrangThai.SelectedIndex = 0;
            cboViTriLuuTru.SelectedIndex = cboViTriLuuTru.Items.Count > 0 ? 0 : -1;
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
