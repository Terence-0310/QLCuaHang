using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmLichSuHoaDon : Form
    {
        public FrmLichSuHoaDon()
        {
            InitializeComponent();
        }

        private void FrmLichSuHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvHoaDon);
                WinFormsExtensions.AttachDataErrorHandler(dgvHoaDon);

                // Set labels with proper Vietnamese
                lblTu.Text = Res.HeaderTuNgay;
                lblDen.Text = Res.HeaderDenNgay;
                lblTimKiem.Text = Res.HeaderTimKiem;
                this.Text = Res.FrmLichSuHoaDonTitle;

                dtpTu.Value = DateTime.Now.AddMonths(-1);
                dtpDen.Value = DateTime.Now;

                LoadData();
            }
            catch (Exception ex)
            {
                ShowError(Res.Error + ": " + ex.Message);
            }
        }

        private void LoadData()
        {
            var keyword = txtTimKiem.Text.Trim();
            var result = HoaDonBus.Search(keyword, dtpTu.Value, dtpDen.Value);

            if (result.Success)
            {
                dgvHoaDon.DataSource = result.Data;
                FormatGrid();
                lblTongHD.Text = Res.TotalHoaDon(result.Data.Count);
            }
            else
            {
                ShowError(result.Message);
            }
        }

        private void FormatGrid()
        {
            if (dgvHoaDon.Columns.Contains("MaHD"))
            {
                dgvHoaDon.Columns["MaHD"].HeaderText = Res.HeaderMaHD;
                dgvHoaDon.Columns["MaHD"].Width = 140;
            }
            if (dgvHoaDon.Columns.Contains("NgayHoaDon"))
            {
                dgvHoaDon.Columns["NgayHoaDon"].HeaderText = Res.HeaderNgayHoaDon;
                dgvHoaDon.Columns["NgayHoaDon"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvHoaDon.Columns["NgayHoaDon"].Width = 150;
            }
            if (dgvHoaDon.Columns.Contains("TenKH"))
            {
                dgvHoaDon.Columns["TenKH"].HeaderText = Res.HeaderKhachHang;
            }
            if (dgvHoaDon.Columns.Contains("TenNV"))
            {
                dgvHoaDon.Columns["TenNV"].HeaderText = Res.HeaderNhanVien;
            }
            if (dgvHoaDon.Columns.Contains("TongTien"))
            {
                dgvHoaDon.Columns["TongTien"].HeaderText = Res.HeaderTongTien;
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvHoaDon.Columns.Contains("GhiChu"))
            {
                dgvHoaDon.Columns["GhiChu"].HeaderText = Res.HeaderGhiChu;
            }
            WinFormsExtensions.HideIfExists(dgvHoaDon, "MaKH", "MaNV");
        }

        private void btnTim_Click(object sender, EventArgs e) => LoadData();

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dtpTu.Value = DateTime.Now.AddMonths(-1);
            dtpDen.Value = DateTime.Now;
            LoadData();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            var row = dgvHoaDon.CurrentRow?.DataBoundItem as HoaDonDal.HoaDonGridRow;
            if (row == null) { ShowWarn(Res.SelectRowToEdit); return; }

            using (var frm = new FrmXemHoaDon(row.MaHD))
                frm.ShowDialog(this);
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnXemChiTiet_Click(sender, e);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnTim_Click(sender, e); e.Handled = e.SuppressKeyPress = true; }
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
