using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyCuaHangRuou.Common;
using QuanLyCuaHangRuou.DAL;

namespace QuanLyCuaHangRuou.GUI
{
    public partial class FrmXemHoaDon : Form
    {
        private HoaDonDal.HoaDonPrintDto _hoaDon;
        private string _maHD;

        public FrmXemHoaDon()
        {
            InitializeComponent();
        }

        public FrmXemHoaDon(string maHD) : this()
        {
            _maHD = maHD;
        }

        private void FrmXemHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_maHD))
                {
                    ShowError("Kh\u00F4ng c\u00F3 m\u00E3 h\u00F3a \u0111\u01A1n!");
                    Close();
                    return;
                }

                _hoaDon = HoaDonDal.GetForPrint(_maHD);
                if (_hoaDon == null)
                {
                    ShowError("Kh\u00F4ng t\u00ECm th\u1EA5y h\u00F3a \u0111\u01A1n!");
                    Close();
                    return;
                }

                DisplayInvoice();
            }
            catch (Exception ex)
            {
                ShowError("L\u1ED7i t\u1EA3i h\u00F3a \u0111\u01A1n: " + DbConfig.GetInnerMsg(ex));
                Close();
            }
        }

        private void DisplayInvoice()
        {
            var sb = new StringBuilder();
            sb.AppendLine("================================================================================");
            sb.AppendLine("                         H\u00D3A \u0110\u01A0N B\u00C1N H\u00C0NG");
            sb.AppendLine("                      C\u1EECA H\u00C0NG R\u01AF\u1EE2U CAO C\u1EA4P");
            sb.AppendLine("================================================================================");
            sb.AppendLine();
            sb.AppendLine($"  M\u00E3 H\u0110:        {_hoaDon.MaHD}");
            sb.AppendLine($"  Ng\u00E0y:         {_hoaDon.NgayHoaDon:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"  Kh\u00E1ch h\u00E0ng:   {_hoaDon.TenKH}");
            if (!string.IsNullOrEmpty(_hoaDon.SdtKH))
                sb.AppendLine($"  S\u0110T:          {_hoaDon.SdtKH}");
            if (!string.IsNullOrEmpty(_hoaDon.DiaChiKH))
                sb.AppendLine($"  \u0110\u1ECBa ch\u1EC9:     {_hoaDon.DiaChiKH}");
            sb.AppendLine($"  Nh\u00E2n vi\u00EAn:    {_hoaDon.TenNV}");
            sb.AppendLine();
            sb.AppendLine("--------------------------------------------------------------------------------");
            sb.AppendLine("  STT  | T\u00EAn \u0111\u1ED3 u\u1ED1ng                    | \u0110\u01A1n gi\u00E1      | SL  | Th\u00E0nh ti\u1EC1n");
            sb.AppendLine("--------------------------------------------------------------------------------");

            foreach (var item in _hoaDon.Items)
            {
                string tenDU = item.TenDoUong.Length > 28 ? item.TenDoUong.Substring(0, 25) + "..." : item.TenDoUong;
                sb.AppendLine($"  {item.STT,3}  | {tenDU,-28} | {item.DonGia,10:N0} | {item.SoLuong,3} | {item.ThanhTien,11:N0}");
            }

            sb.AppendLine("--------------------------------------------------------------------------------");
            sb.AppendLine($"                                          T\u1ED4NG C\u1ED8NG: {_hoaDon.TongTien,15:N0} VN\u0110");
            sb.AppendLine("================================================================================");
            
            if (!string.IsNullOrEmpty(_hoaDon.GhiChu))
            {
                sb.AppendLine($"  Ghi ch\u00FA: {_hoaDon.GhiChu}");
                sb.AppendLine();
            }
            
            sb.AppendLine();
            sb.AppendLine("                      C\u1EA3m \u01A1n qu\u00FD kh\u00E1ch \u0111\u00E3 mua h\u00E0ng!");
            sb.AppendLine("                         H\u1EB9n g\u1EB7p l\u1EA1i qu\u00FD kh\u00E1ch!");
            sb.AppendLine();

            txtPreview.Text = sb.ToString();
            txtPreview.SelectionStart = 0;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                var printDoc = new PrintDocument();
                printDoc.PrintPage += PrintDoc_PrintPage;

                var printDialog = new PrintDialog
                {
                    Document = printDoc,
                    UseEXDialog = true
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    ShowInfo("In h\u00F3a \u0111\u01A1n th\u00E0nh c\u00F4ng!");
                }
            }
            catch (Exception ex)
            {
                ShowError("L\u1ED7i in: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var font = new Font("Consolas", 10);
            var fontBold = new Font("Consolas", 12, FontStyle.Bold);
            var brush = Brushes.Black;
            float x = 50, y = 50;
            float lineHeight = font.GetHeight(e.Graphics) + 2;

            // Header
            e.Graphics.DrawString("H\u00D3A \u0110\u01A0N B\u00C1N H\u00C0NG", fontBold, brush, x + 150, y);
            y += lineHeight * 2;

            e.Graphics.DrawString($"M\u00E3 H\u0110: {_hoaDon.MaHD}", font, brush, x, y); y += lineHeight;
            e.Graphics.DrawString($"Ng\u00E0y: {_hoaDon.NgayHoaDon:dd/MM/yyyy HH:mm}", font, brush, x, y); y += lineHeight;
            e.Graphics.DrawString($"Kh\u00E1ch h\u00E0ng: {_hoaDon.TenKH}", font, brush, x, y); y += lineHeight;
            e.Graphics.DrawString($"Nh\u00E2n vi\u00EAn: {_hoaDon.TenNV}", font, brush, x, y); y += lineHeight * 2;

            // Table header
            e.Graphics.DrawString("STT", font, brush, x, y);
            e.Graphics.DrawString("T\u00EAn \u0111\u1ED3 u\u1ED1ng", font, brush, x + 40, y);
            e.Graphics.DrawString("\u0110\u01A1n gi\u00E1", font, brush, x + 250, y);
            e.Graphics.DrawString("SL", font, brush, x + 350, y);
            e.Graphics.DrawString("Th\u00E0nh ti\u1EC1n", font, brush, x + 400, y);
            y += lineHeight;
            e.Graphics.DrawLine(Pens.Black, x, y, x + 500, y);
            y += 5;

            // Items
            foreach (var item in _hoaDon.Items)
            {
                string tenDU = item.TenDoUong.Length > 25 ? item.TenDoUong.Substring(0, 22) + "..." : item.TenDoUong;
                e.Graphics.DrawString(item.STT.ToString(), font, brush, x, y);
                e.Graphics.DrawString(tenDU, font, brush, x + 40, y);
                e.Graphics.DrawString(item.DonGia.ToString("N0"), font, brush, x + 250, y);
                e.Graphics.DrawString(item.SoLuong.ToString(), font, brush, x + 350, y);
                e.Graphics.DrawString(item.ThanhTien.ToString("N0"), font, brush, x + 400, y);
                y += lineHeight;
            }

            // Total
            y += 10;
            e.Graphics.DrawLine(Pens.Black, x, y, x + 500, y);
            y += 10;
            e.Graphics.DrawString($"T\u1ED4NG C\u1ED8NG: {_hoaDon.TongTien:N0} VN\u0110", fontBold, brush, x + 250, y);

            e.HasMorePages = false;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                var sfd = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    FileName = $"HoaDon_{_hoaDon.MaHD}_{_hoaDon.NgayHoaDon:yyyyMMdd}.txt",
                    Title = "Xu\u1EA5t h\u00F3a \u0111\u01A1n"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, txtPreview.Text, Encoding.UTF8);
                    ShowInfo("Xu\u1EA5t file th\u00E0nh c\u00F4ng!\n" + sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                ShowError("L\u1ED7i xu\u1EA5t file: " + DbConfig.GetInnerMsg(ex));
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowError(string msg) => MessageBox.Show(this, msg, "L\u1ED7i", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) => MessageBox.Show(this, msg, "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
