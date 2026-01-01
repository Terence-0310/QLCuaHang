using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmBaoCaoDoanhThu : Form
    {
        private decimal _total;

        public FrmBaoCaoDoanhThu() { InitializeComponent(); }

        private void FrmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvDoanhThu);
                WinFormsExtensions.AttachDataErrorHandler(dgvDoanhThu);
                dtpTu.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpDen.Value = DateTime.Now;
                LoadData();
            }
            catch (Exception ex) { ShowError("Lỗi khởi tạo: " + ex.Message); }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            btnXem.Enabled = false;
            Application.DoEvents();
            try
            {
                LoadData();
            }
            finally { btnXem.Enabled = true; }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            btnXuatExcel.Enabled = false;
            Application.DoEvents();
            try
            {
                ExcelExporter.ExportDoanhThuReport(dgvDoanhThu, dtpTu.Value, dtpDen.Value, _total);
            }
            catch (Exception ex) { ShowError("Lỗi xuất Excel: " + ex.Message); }
            finally { btnXuatExcel.Enabled = true; }
        }

        private void LoadData()
        {
            var result = ReportBus.GetDoanhThu(dtpTu.Value, dtpDen.Value);

            if (result.Success)
            {
                dgvDoanhThu.DataSource = result.Data;
                _total = ReportBus.CalculateTotalRevenue(result.Data);
                lblTongDoanhThu.Text = Res.TotalAmount(_total);

                if (dgvDoanhThu.Columns.Contains("Ngay")) dgvDoanhThu.Columns["Ngay"].HeaderText = "Ngày";
                if (dgvDoanhThu.Columns.Contains("SoHoaDon")) dgvDoanhThu.Columns["SoHoaDon"].HeaderText = "Số hóa đơn";
                if (dgvDoanhThu.Columns.Contains("TongTien")) dgvDoanhThu.Columns["TongTien"].HeaderText = "Tổng tiền";
            }
            else
            {
                ShowError(result.Message);
            }
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
