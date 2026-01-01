using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
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
            catch (Exception ex) { ShowError("Lỗi khởi tạo: " + ex.Message); }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            btnTim.Enabled = false;
            Application.DoEvents();
            try
            {
                LoadData(txtTim.Text.Trim());
            }
            finally { btnTim.Enabled = true; }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            LoadData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            btnXuatExcel.Enabled = false;
            Application.DoEvents();
            try
            {
                ExcelExporter.ExportTonKhoReport(dgvTonKho, _total);
            }
            catch (Exception ex) { ShowError("Lỗi xuất Excel: " + ex.Message); }
            finally { btnXuatExcel.Enabled = true; }
        }

        private void LoadData(string kw = null)
        {
            var result = string.IsNullOrWhiteSpace(kw)
                ? ReportBus.GetTonKho()
                : ReportBus.SearchTonKho(kw);

            if (result.Success)
            {
                dgvTonKho.DataSource = result.Data;
                WinFormsExtensions.HideIfExists(dgvTonKho, "HinhPath");
                _total = ReportBus.CalculateTotalStock(result.Data);
                lblTongTonKho.Text = Res.TotalProducts((int)_total);

                if (dgvTonKho.Columns.Contains("MaDoUong")) dgvTonKho.Columns["MaDoUong"].HeaderText = "Mã đồ uống";
                if (dgvTonKho.Columns.Contains("TenDoUong")) dgvTonKho.Columns["TenDoUong"].HeaderText = "Tên đồ uống";
                if (dgvTonKho.Columns.Contains("TenLoai")) dgvTonKho.Columns["TenLoai"].HeaderText = "Loại";
                if (dgvTonKho.Columns.Contains("SoLuongTon")) dgvTonKho.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
                if (dgvTonKho.Columns.Contains("DonViTinh")) dgvTonKho.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
                if (dgvTonKho.Columns.Contains("DonGia")) dgvTonKho.Columns["DonGia"].HeaderText = "Đơn giá";
            }
            else
            {
                ShowError(result.Message);
            }
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
