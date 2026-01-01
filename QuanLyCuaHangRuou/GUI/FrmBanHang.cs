using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyCuaHangRuou.BUS;
using QuanLyCuaHangRuou.DAL;
using QuanLyCuaHangRuou.Common;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmBanHang : Form
    {
        private List<BanHangDal.GioHangItem> _cartItems = new List<BanHangDal.GioHangItem>();

        public FrmBanHang() { InitializeComponent(); }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            try
            {
                WinFormsExtensions.SetDoubleBuffered(dgvGioHang);
                WinFormsExtensions.AttachDataErrorHandler(dgvGioHang);

                LoadKhachHang();
                LoadDoUong();

                dgvGioHang.AutoGenerateColumns = false;
                ResetHoaDon();
                lblNhanVien.Text = AppSession.CurrentUser ?? "NV";
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

        private void LoadDoUong()
        {
            var result = DoUongBus.GetAll();
            if (result.Success)
            {
                cboDoUong.DisplayMember = "TenDoUong";
                cboDoUong.ValueMember = "MaDoUong";
                cboDoUong.DataSource = result.Data;
            }
        }

        private void ResetHoaDon()
        {
            txtMaHD.Text = BanHangBus.GenerateMaHD();
            dtpNgay.Value = DateTime.Now;
            nudSoLuong.Value = 1;
            dgvGioHang.Rows.Clear();
            _cartItems.Clear();
            UpdateTotal();
        }

        private void cboDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDoUong.SelectedItem is DoUongDal.DoUongGridRow row)
                txtDonGia.Text = row.DonGia.ToString("N0");
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            if (!(cboDoUong.SelectedItem is DoUongDal.DoUongGridRow du)) return;
            int sl = (int)nudSoLuong.Value;

            // Gọi BUS để validate
            var result = BanHangBus.AddToCart(du.MaDoUong, sl, _cartItems);
            if (!result.Success)
            {
                ShowWarn(result.Message);
                return;
            }

            // Kiểm tra sản phẩm đã có trong giỏ chưa
            foreach (DataGridViewRow r in dgvGioHang.Rows)
            {
                if (r.Cells[0].Value?.ToString() == du.MaDoUong)
                {
                    int oldQty = Convert.ToInt32(r.Cells[3].Value);
                    int newQty = oldQty + sl;
                    r.Cells[3].Value = newQty;
                    r.Cells[4].Value = du.DonGia * newQty;

                    // Cập nhật _cartItems
                    var item = _cartItems.Find(x => x.MaDoUong == du.MaDoUong);
                    if (item != null) item.SoLuong = newQty;

                    UpdateTotal();
                    return;
                }
            }

            // Thêm mới vào giỏ
            dgvGioHang.Rows.Add(du.MaDoUong, du.TenDoUong, du.DonGia, sl, du.DonGia * sl);
            _cartItems.Add(new BanHangDal.GioHangItem
            {
                MaDoUong = du.MaDoUong,
                DonGia = du.DonGia,
                SoLuong = sl
            });
            UpdateTotal();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0) { ShowWarn(Res.CartEmpty); return; }
            if (Confirm(Res.ConfirmPayment) != DialogResult.Yes) return;

            btnThanhToan.Enabled = false;
            Application.DoEvents();

            try
            {
                // Lấy mã NV từ session
                string maNv = AppSession.CurrentMaNV;

                var result = BanHangBus.ThanhToan(
                    txtMaHD.Text.Trim(),
                    dtpNgay.Value,
                    cboKhachHang.SelectedValue?.ToString(),
                    maNv,
                    null,
                    _cartItems
                );

                if (result.Success)
                {
                    ShowInfo(result.Message ?? Res.PaymentSuccess);

                    if (Confirm("Bạn có muốn xuất hóa đơn?") == DialogResult.Yes)
                        ExportInvoice();

                    LoadDoUong();
                    ResetHoaDon();
                }
                else
                {
                    ShowError(result.Message);
                }
            }
            finally { btnThanhToan.Enabled = true; }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                var maDoUong = dgvGioHang.CurrentRow.Cells[0].Value?.ToString();
                _cartItems.RemoveAll(x => x.MaDoUong == maDoUong);
                dgvGioHang.Rows.Remove(dgvGioHang.CurrentRow);
                UpdateTotal();
            }
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            dgvGioHang.Rows.Clear();
            _cartItems.Clear();
            UpdateTotal();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0) { ShowWarn(Res.CartEmpty); return; }
            ExportInvoice();
        }

        // === HELPERS ===
        private void UpdateTotal()
        {
            decimal sum = BanHangBus.CalculateTotal(_cartItems);
            lblTongTienValue.Text = Res.TotalAmount(sum);
        }

        private decimal GetTotal()
        {
            return BanHangBus.CalculateTotal(_cartItems);
        }

        private void ExportInvoice()
        {
            try
            {
                string tenKH = "Khách lẻ";
                if (cboKhachHang.SelectedItem is KhachHangDal.KhachHangGridRow kh) tenKH = kh.TenKH;
                ExcelExporter.ExportHoaDon(txtMaHD.Text.Trim(), dtpNgay.Value, tenKH, AppSession.CurrentUser ?? "", dgvGioHang, GetTotal(), true);
            }
            catch (Exception ex) { ShowError("Lỗi xuất hóa đơn: " + ex.Message); }
        }

        private void ShowWarn(string msg) => MessageBox.Show(this, msg, Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(this, msg, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private DialogResult Confirm(string msg) => MessageBox.Show(this, msg, Res.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}
