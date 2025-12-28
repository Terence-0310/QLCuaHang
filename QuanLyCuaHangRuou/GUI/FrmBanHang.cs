using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmBanHang : Form
    {
        public FrmBanHang() { InitializeComponent(); }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvGioHang);
                WinFormsExtensions.AttachDataErrorHandler(dgvGioHang);

                cboKhachHang.DisplayMember = "TenKH";
                cboKhachHang.ValueMember = "MaKH";
                cboKhachHang.DataSource = KhachHangDal.GetAllForGrid();

                cboDoUong.DisplayMember = "TenDoUong";
                cboDoUong.ValueMember = "MaDoUong";
                cboDoUong.DataSource = DoUongDal.GetAllForGrid();

                dgvGioHang.AutoGenerateColumns = false;
                ResetHoaDon();
                lblNhanVien.Text = AppSession.CurrentUser ?? "NV";
            }
            catch (Exception ex) { ShowError("L\u1ED7i kh\u1EDFi t\u1EA1o: " + DbConfig.GetInnerMsg(ex)); }
        }

        private void ResetHoaDon()
        {
            try
            {
                txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
                dtpNgay.Value = DateTime.Now;
                nudSoLuong.Value = 1;
                dgvGioHang.Rows.Clear();
                UpdateTotal();
            }
            catch { }
        }

        private void cboDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDoUong.SelectedItem is DoUongDal.DoUongGridRow row)
                    txtDonGia.Text = row.DonGia.ToString("N0");
            }
            catch { }
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cboDoUong.SelectedItem is DoUongDal.DoUongGridRow du)) return;
                int sl = (int)nudSoLuong.Value;
                if (sl <= 0) { ShowWarn(Res.QtyMustBePositive); return; }

                // Kiem tra ton kho
                var duDb = DoUongDal.GetById(du.MaDoUong);
                if (duDb != null && duDb.SoLuongTon < sl)
                {
                    ShowWarn($"T\u1ED3n kho kh\u00F4ng \u0111\u1EE7. C\u00F2n: {duDb.SoLuongTon}");
                    return;
                }

                foreach (DataGridViewRow r in dgvGioHang.Rows)
                {
                    if (r.Cells[0].Value?.ToString() == du.MaDoUong)
                    {
                        int oldQty = Convert.ToInt32(r.Cells[3].Value);
                        r.Cells[3].Value = oldQty + sl;
                        r.Cells[4].Value = du.DonGia * (oldQty + sl);
                        UpdateTotal();
                        return;
                    }
                }
                dgvGioHang.Rows.Add(du.MaDoUong, du.TenDoUong, du.DonGia, sl, du.DonGia * sl);
                UpdateTotal();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGioHang.Rows.Count == 0) { ShowWarn(Res.CartEmpty); return; }
                if (Confirm(Res.ConfirmPayment) != DialogResult.Yes) return;

                btnThanhToan.Enabled = false;
                Application.DoEvents();

                var items = new List<BanHangDal.GioHangItem>();
                foreach (DataGridViewRow r in dgvGioHang.Rows)
                    if (r.Cells[0].Value != null)
                        items.Add(new BanHangDal.GioHangItem
                        {
                            MaDoUong = r.Cells[0].Value.ToString(),
                            DonGia = Convert.ToDecimal(r.Cells[2].Value),
                            SoLuong = Convert.ToInt32(r.Cells[3].Value)
                        });

                string maNv = null;
                try { maNv = NhanVienDal.GetByUsername(AppSession.CurrentUser)?.MaNV; } catch { }

                string maHD = txtMaHD.Text.Trim();
                BanHangDal.ThanhToan(maHD, dtpNgay.Value, cboKhachHang.SelectedValue?.ToString(), maNv, null, items);

                ShowInfo(Res.PaymentSuccess);

                if (Confirm("Ban co muon xuat hoa don?") == DialogResult.Yes)
                    ExportInvoice();

                // Reload do uong va reset form
                try { cboDoUong.DataSource = DoUongDal.GetAllForGrid(); } catch { }
                ResetHoaDon();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
            finally { btnThanhToan.Enabled = true; }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGioHang.CurrentRow != null) { dgvGioHang.Rows.Remove(dgvGioHang.CurrentRow); UpdateTotal(); }
            }
            catch { }
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            try { dgvGioHang.Rows.Clear(); UpdateTotal(); } catch { }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGioHang.Rows.Count == 0) { ShowWarn(Res.CartEmpty); return; }
                ExportInvoice();
            }
            catch (Exception ex) { ShowError(DbConfig.GetInnerMsg(ex)); }
        }

        // === HELPERS ===
        private void UpdateTotal()
        {
            try
            {
                decimal sum = 0;
                foreach (DataGridViewRow r in dgvGioHang.Rows)
                    if (r.Cells[4].Value != null) sum += Convert.ToDecimal(r.Cells[4].Value);
                lblTongTienValue.Text = Res.TotalAmount(sum);
            }
            catch { lblTongTienValue.Text = "0 VN\u0110"; }
        }

        private decimal GetTotal()
        {
            try
            {
                decimal sum = 0;
                foreach (DataGridViewRow r in dgvGioHang.Rows)
                    if (r.Cells[4].Value != null) sum += Convert.ToDecimal(r.Cells[4].Value);
                return sum;
            }
            catch { return 0; }
        }

        private void ExportInvoice()
        {
            try
            {
                string tenKH = "Kh\u00E1ch l\u1EBB";
                if (cboKhachHang.SelectedItem is KhachHangDal.KhachHangGridRow kh) tenKH = kh.TenKH;
                ExcelExporter.ExportHoaDon(txtMaHD.Text.Trim(), dtpNgay.Value, tenKH, AppSession.CurrentUser ?? "", dgvGioHang, GetTotal(), true);
            }
            catch (Exception ex) { ShowError("L\u1ED7i xu\u1EA5t h\u00F3a \u0111\u01A1n: " + DbConfig.GetInnerMsg(ex)); }
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
