using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangRuou.DAL;
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
            catch (Exception ex) { ShowError("L\u1ED7i kh\u1EDFi t\u1EA1o: " + DbConfig.GetInnerMsg(ex)); }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                btnXem.Enabled = false;
                Application.DoEvents();
                LoadData();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
            finally { btnXem.Enabled = true; }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                btnXuatExcel.Enabled = false;
                Application.DoEvents();
                ExcelExporter.ExportDoanhThuReport(dgvDoanhThu, dtpTu.Value, dtpDen.Value, _total);
            }
            catch (Exception ex) { ShowError("L\u1ED7i xu\u1EA5t Excel: " + DbConfig.GetInnerMsg(ex)); }
            finally { btnXuatExcel.Enabled = true; }
        }

        private void LoadData()
        {
            try
            {
                var data = ReportDal.GetDoanhThuByDateRange(dtpTu.Value, dtpDen.Value);
                dgvDoanhThu.DataSource = data;
                _total = data.Sum(x => x.TongTien);
                lblTongDoanhThu.Text = Res.TotalAmount(_total);

                if (dgvDoanhThu.Columns.Contains("Ngay")) dgvDoanhThu.Columns["Ngay"].HeaderText = "Ng\u00E0y";
                if (dgvDoanhThu.Columns.Contains("SoHoaDon")) dgvDoanhThu.Columns["SoHoaDon"].HeaderText = "S\u1ED1 h\u00F3a \u0111\u01A1n";
                if (dgvDoanhThu.Columns.Contains("TongTien")) dgvDoanhThu.Columns["TongTien"].HeaderText = "T\u1ED5ng ti\u1EC1n";
            }
            catch (Exception ex) { throw new Exception("L\u1ED7i t\u1EA3i d\u1EEF li\u1EC7u: " + DbConfig.GetInnerMsg(ex), ex); }
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
