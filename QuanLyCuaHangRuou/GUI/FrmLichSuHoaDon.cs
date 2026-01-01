using System;
using System.Windows.Forms;
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

                // Default: 1 thang gan day
                dtpTu.Value = DateTime.Now.AddMonths(-1);
                dtpDen.Value = DateTime.Now;

                LoadData();
            }
            catch (Exception ex)
            {
                ShowError("L\u1ED7i kh\u1EDFi t\u1EA1o: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void LoadData()
        {
            try
            {
                var keyword = txtTimKiem.Text.Trim();
                var data = HoaDonDal.Search(keyword, dtpTu.Value, dtpDen.Value);
                dgvHoaDon.DataSource = data;

                // Format columns
                if (dgvHoaDon.Columns.Contains("MaHD"))
                {
                    dgvHoaDon.Columns["MaHD"].HeaderText = "M\u00E3 H\u0110";
                    dgvHoaDon.Columns["MaHD"].Width = 120;
                }
                if (dgvHoaDon.Columns.Contains("NgayHoaDon"))
                {
                    dgvHoaDon.Columns["NgayHoaDon"].HeaderText = "Ng\u00E0y h\u00F3a \u0111\u01A1n";
                    dgvHoaDon.Columns["NgayHoaDon"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHoaDon.Columns["NgayHoaDon"].Width = 140;
                }
                if (dgvHoaDon.Columns.Contains("TenKH"))
                {
                    dgvHoaDon.Columns["TenKH"].HeaderText = "Kh\u00E1ch h\u00E0ng";
                    dgvHoaDon.Columns["TenKH"].Width = 180;
                }
                if (dgvHoaDon.Columns.Contains("TenNV"))
                {
                    dgvHoaDon.Columns["TenNV"].HeaderText = "Nh\u00E2n vi\u00EAn";
                    dgvHoaDon.Columns["TenNV"].Width = 150;
                }
                if (dgvHoaDon.Columns.Contains("TongTien"))
                {
                    dgvHoaDon.Columns["TongTien"].HeaderText = "T\u1ED5ng ti\u1EC1n";
                    dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvHoaDon.Columns["TongTien"].Width = 120;
                }
                if (dgvHoaDon.Columns.Contains("GhiChu"))
                {
                    dgvHoaDon.Columns["GhiChu"].HeaderText = "Ghi ch\u00FA";
                    dgvHoaDon.Columns["GhiChu"].Width = 150;
                }

                // Hide unnecessary columns
                WinFormsExtensions.HideIfExists(dgvHoaDon, "MaKH", "MaNV");

                // Update label
                lblTongHD.Text = $"T\u1ED5ng: {data.Count} h\u00F3a \u0111\u01A1n";
            }
            catch (Exception ex)
            {
                ShowError("L\u1ED7i t\u1EA3i d\u1EEF li\u1EC7u: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dtpTu.Value = DateTime.Now.AddMonths(-1);
            dtpDen.Value = DateTime.Now;
            LoadData();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dgvHoaDon.CurrentRow?.DataBoundItem as HoaDonDal.HoaDonGridRow;
                if (row == null)
                {
                    ShowWarn("Vui l\u00F2ng ch\u1ECDn h\u00F3a \u0111\u01A1n \u0111\u1EC3 xem!");
                    return;
                }

                using (var frm = new FrmXemHoaDon(row.MaHD))
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                ShowError("L\u1ED7i: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnXemChiTiet_Click(sender, e);
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, "L\u1ED7i", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarn(string msg) => MessageBox.Show(this, msg, "C\u1EA3nh b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
