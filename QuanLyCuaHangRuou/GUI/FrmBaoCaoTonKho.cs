using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmBaoCaoTonKho : Form
    {
        private decimal _total;

        public FrmBaoCaoTonKho() { InitializeComponent(); }

        private void FrmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvTonKho);
                WinFormsExtensions.AttachDataErrorHandler(dgvTonKho);
                LoadData();
            }
            catch (Exception ex) { ShowError("L\u1ED7i kh\u1EDFi t\u1EA1o: " + DbConfig.GetInnerMsg(ex)); }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                btnTim.Enabled = false;
                Application.DoEvents();
                LoadData(txtTim.Text.Trim());
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
            finally { btnTim.Enabled = true; }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try { txtTim.Clear(); LoadData(); }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                btnXuatExcel.Enabled = false;
                Application.DoEvents();
                ExcelExporter.ExportTonKhoReport(dgvTonKho, _total);
            }
            catch (Exception ex) { ShowError("L\u1ED7i xu\u1EA5t Excel: " + DbConfig.GetInnerMsg(ex)); }
            finally { btnXuatExcel.Enabled = true; }
        }

        private void LoadData(string kw = null)
        {
            try
            {
                var data = string.IsNullOrWhiteSpace(kw) ? ReportDal.GetTonKho() : ReportDal.SearchTonKho(kw);
                dgvTonKho.DataSource = data;
                WinFormsExtensions.HideIfExists(dgvTonKho, "HinhPath");
                _total = data.Sum(x => x.SoLuongTon);
                lblTongTonKho.Text = Res.TotalProducts((int)_total);

                if (dgvTonKho.Columns.Contains("MaDoUong")) dgvTonKho.Columns["MaDoUong"].HeaderText = "M\u00E3 \u0111\u1ED3 u\u1ED1ng";
                if (dgvTonKho.Columns.Contains("TenDoUong")) dgvTonKho.Columns["TenDoUong"].HeaderText = "T\u00EAn \u0111\u1ED3 u\u1ED1ng";
                if (dgvTonKho.Columns.Contains("TenLoai")) dgvTonKho.Columns["TenLoai"].HeaderText = "Lo\u1EA1i";
                if (dgvTonKho.Columns.Contains("SoLuongTon")) dgvTonKho.Columns["SoLuongTon"].HeaderText = "S\u1ED1 l\u01B0\u1EE3ng t\u1ED3n";
                if (dgvTonKho.Columns.Contains("DonViTinh")) dgvTonKho.Columns["DonViTinh"].HeaderText = "\u0110\u01A1n v\u1ECB t\u00EDnh";
                if (dgvTonKho.Columns.Contains("DonGia")) dgvTonKho.Columns["DonGia"].HeaderText = "\u0110\u01A1n gi\u00E1";
            }
            catch (Exception ex) { throw new Exception("L\u1ED7i t\u1EA3i d\u1EEF li\u1EC7u: " + DbConfig.GetInnerMsg(ex), ex); }
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
