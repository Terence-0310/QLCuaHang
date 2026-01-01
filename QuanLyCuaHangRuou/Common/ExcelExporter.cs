using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangRuou.Common
{
    /// <summary>
    /// Helper class để xuất dữ liệu ra file Excel (CSV format hoặc HTML table)
    /// Không cần thư viện bên ngoài
    /// </summary>
    public static class ExcelExporter
    {
        /// <summary>
        /// Xuất hóa đơn bán hàng
        /// </summary>
        public static bool ExportHoaDon(string maHD, DateTime ngayHD, string tenKhachHang, 
            string tenNhanVien, DataGridView dgvGioHang, decimal tongTien, bool showSaveDialog = true)
        {
            if (dgvGioHang == null || dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm trong giỏ hàng!", Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string filePath;
            
            if (showSaveDialog)
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xls)|*.xls|PDF Files (*.html)|*.html";
                    sfd.FileName = "HoaDon_" + maHD;
                    sfd.Title = "Xuất hóa đơn";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return false;
                    
                    filePath = sfd.FileName;
                }
            }
            else
            {
                // Lưu vào thư mục HoaDon
                string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HoaDon");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                filePath = Path.Combine(folder, "HoaDon_" + maHD + ".html");
            }

            try
            {
                var sb = new StringBuilder();
                
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLine("<html>");
                sb.AppendLine("<head>");
                sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
                sb.AppendLine("<title>Hóa đơn " + maHD + "</title>");
                sb.AppendLine("<style>");
                sb.AppendLine("@media print { body { margin: 0; } }");
                sb.AppendLine("body { font-family: Arial, sans-serif; max-width: 800px; margin: 0 auto; padding: 20px; }");
                sb.AppendLine(".header { text-align: center; border-bottom: 2px solid #333; padding-bottom: 10px; margin-bottom: 20px; }");
                sb.AppendLine(".shop-name { font-size: 24px; font-weight: bold; color: #8B0000; margin-bottom: 5px; }");
                sb.AppendLine(".shop-info { font-size: 12px; color: #666; }");
                sb.AppendLine(".invoice-title { font-size: 28px; font-weight: bold; text-align: center; margin: 20px 0; color: #333; }");
                sb.AppendLine(".info-row { margin-bottom: 8px; }");
                sb.AppendLine(".info-label { font-weight: bold; display: inline-block; width: 120px; }");
                sb.AppendLine("table { width: 100%; border-collapse: collapse; margin: 20px 0; }");
                sb.AppendLine("th { background-color: #8B0000; color: white; padding: 12px 8px; text-align: center; border: 1px solid #ddd; }");
                sb.AppendLine("td { padding: 10px 8px; border: 1px solid #ddd; }");
                sb.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
                sb.AppendLine(".text-center { text-align: center; }");
                sb.AppendLine(".text-right { text-align: right; }");
                sb.AppendLine(".total-section { margin-top: 20px; text-align: right; }");
                sb.AppendLine(".total-row { font-size: 14px; margin-bottom: 5px; }");
                sb.AppendLine(".grand-total { font-size: 22px; font-weight: bold; color: #8B0000; border-top: 2px solid #333; padding-top: 10px; margin-top: 10px; }");
                sb.AppendLine(".signature-section { display: flex; justify-content: space-between; margin-top: 50px; }");
                sb.AppendLine(".signature-box { width: 45%; text-align: center; }");
                sb.AppendLine(".signature-title { font-weight: bold; margin-bottom: 60px; }");
                sb.AppendLine(".signature-line { border-top: 1px solid #333; padding-top: 5px; }");
                sb.AppendLine(".thank-you { text-align: center; margin-top: 30px; font-style: italic; color: #666; }");
                sb.AppendLine(".print-btn { background-color: #8B0000; color: white; padding: 10px 30px; border: none; cursor: pointer; font-size: 16px; margin-top: 20px; }");
                sb.AppendLine(".print-btn:hover { background-color: #660000; }");
                sb.AppendLine("@media print { .no-print { display: none; } }");
                sb.AppendLine("</style>");
                sb.AppendLine("</head>");
                sb.AppendLine("<body>");
                
                // Header - Tên cửa hàng
                sb.AppendLine("<div class=\"header\">");
                sb.AppendLine("<div class=\"shop-name\">CỬA HÀNG RƯỢU CAO CẤP</div>");
                sb.AppendLine("<div class=\"shop-info\">Địa chỉ: 123 Nguyễn Văn Linh, Quận 7, TP.HCM</div>");
                sb.AppendLine("<div class=\"shop-info\">Điện thoại: 0123 456 789 | Email: contact@cuahangr.vn</div>");
                sb.AppendLine("</div>");
                
                // Tiêu đề hóa đơn
                sb.AppendLine("<div class=\"invoice-title\">HÓA ĐƠN BÁN HÀNG</div>");
                
                // Thông tin hóa đơn
                sb.AppendLine("<table style=\"border: none; margin-bottom: 20px;\">");
                sb.AppendLine("<tr style=\"border: none;\">");
                sb.AppendLine("<td style=\"border: none; width: 50%; vertical-align: top;\">");
                sb.AppendLine("<div class=\"info-row\"><span class=\"info-label\">Số hóa đơn:</span> <strong>" + HtmlEncode(maHD) + "</strong></div>");
                sb.AppendLine("<div class=\"info-row\"><span class=\"info-label\">Ngày lập:</span> " + ngayHD.ToString("dd/MM/yyyy HH:mm") + "</div>");
                sb.AppendLine("</td>");
                sb.AppendLine("<td style=\"border: none; width: 50%; vertical-align: top;\">");
                sb.AppendLine("<div class=\"info-row\"><span class=\"info-label\">Khách hàng:</span> " + HtmlEncode(tenKhachHang ?? "Khách lẻ") + "</div>");
                sb.AppendLine("<div class=\"info-row\"><span class=\"info-label\">Nhân viên:</span> " + HtmlEncode(tenNhanVien ?? "") + "</div>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</table>");
                
                // Bảng chi tiết sản phẩm
                sb.AppendLine("<table>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style=\"width: 50px;\">STT</th>");
                sb.AppendLine("<th>Tên sản phẩm</th>");
                sb.AppendLine("<th style=\"width: 120px;\">Đơn giá</th>");
                sb.AppendLine("<th style=\"width: 80px;\">SL</th>");
                sb.AppendLine("<th style=\"width: 140px;\">Thành tiền</th>");
                sb.AppendLine("</tr>");

                int stt = 0;
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (row.Cells[0].Value == null) continue;
                    stt++;
                    
                    string tenSP = row.Cells[1].Value?.ToString() ?? "";
                    decimal donGia = Convert.ToDecimal(row.Cells[2].Value ?? 0);
                    decimal soLuong = Convert.ToDecimal(row.Cells[3].Value ?? 0);
                    decimal thanhTien = Convert.ToDecimal(row.Cells[4].Value ?? 0);
                    
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td class=\"text-center\">" + stt + "</td>");
                    sb.AppendLine("<td>" + HtmlEncode(tenSP) + "</td>");
                    sb.AppendLine("<td class=\"text-right\">" + donGia.ToString("N0") + "</td>");
                    sb.AppendLine("<td class=\"text-center\"" + soLuong.ToString("N0") + "</td>");
                    sb.AppendLine("<td class=\"text-right\">" + thanhTien.ToString("N0") + "</td>");
                    sb.AppendLine("</tr>");
                }
                
                sb.AppendLine("</table>");
                
                // Tổng tiền
                sb.AppendLine("<div class=\"total-section\">");
                sb.AppendLine("<div class=\"total-row\">Tạm tính: " + tongTien.ToString("N0") + " VNĐ</div>");
                sb.AppendLine("<div class=\"total-row\">Thuế VAT (0%): 0 VNĐ</div>");
                sb.AppendLine("<div class=\"grand-total\">TỔNG CỘNG: " + tongTien.ToString("N0") + " VNĐ</div>");
                sb.AppendLine("</div>");
                
                // Chữ ký
                sb.AppendLine("<div class=\"signature-section\">");
                sb.AppendLine("<div class=\"signature-box\">");
                sb.AppendLine("<div class=\"signature-title\">Khách hàng</div>");
                sb.AppendLine("<div class=\"signature-line\">(Ký, ghi rõ họ tên)</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("<div class=\"signature-box\">");
                sb.AppendLine("<div class=\"signature-title\">Người bán hàng</div>");
                sb.AppendLine("<div class=\"signature-line\">(Ký, ghi rõ họ tên)</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                
                // Lời cảm ơn
                sb.AppendLine("<div class=\"thank-you\">");
                sb.AppendLine("<p>Cảm ơn Quý khách đã mua hàng!</p>");
                sb.AppendLine("<p>Hẹn gặp lại Quý khách!</p>");
                sb.AppendLine("</div>");
                
                // Nút in (chỉ hiển thị khi mở file)
                sb.AppendLine("<div class=\"no-print\" style=\"text-align: center;\">");
                sb.AppendLine("<button class=\"print-btn\" onclick=\"window.print()\">IN HÓA ĐƠN</button>");
                sb.AppendLine("</div>");
                
                sb.AppendLine("</body>");
                sb.AppendLine("</html>");

                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                
                if (showSaveDialog)
                {
                    MessageBox.Show("Xuất hóa đơn thành công!\n" + filePath, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                // Mở file sau khi xuất
                System.Diagnostics.Process.Start(filePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Xuất DataGridView ra file Excel (CSV format)
        /// </summary>
        public static bool ExportToExcel(DataGridView dgv, string title, string fileName = null)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.csv";
                sfd.FileName = fileName ?? title + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                sfd.Title = "Xuất báo cáo";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return false;

                try
                {
                    string ext = Path.GetExtension(sfd.FileName).ToLower();
                    
                    if (ext == ".csv")
                    {
                        ExportToCsv(dgv, sfd.FileName, title);
                    }
                    else
                    {
                        ExportToHtmlExcel(dgv, sfd.FileName, title);
                    }

                    MessageBox.Show("Xuất file thành công!\n" + sfd.FileName, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Mở file sau khi xuất
                    System.Diagnostics.Process.Start(sfd.FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// Xuất ra file CSV
        /// </summary>
        private static void ExportToCsv(DataGridView dgv, string filePath, string title)
        {
            var sb = new StringBuilder();
            
            // Tiêu đề
            sb.AppendLine(title);
            sb.AppendLine("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine();

            // Header
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (!dgv.Columns[i].Visible) continue;
                sb.Append(EscapeCsv(dgv.Columns[i].HeaderText));
                if (i < dgv.Columns.Count - 1) sb.Append(",");
            }
            sb.AppendLine();

            // Data rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (!dgv.Columns[i].Visible) continue;
                    var value = row.Cells[i].Value?.ToString() ?? "";
                    sb.Append(EscapeCsv(value));
                    if (i < dgv.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Xuất ra file Excel dạng HTML table (Excel có thể mở được)
        /// </summary>
        private static void ExportToHtmlExcel(DataGridView dgv, string filePath, string title)
        {
            var sb = new StringBuilder();
            
            // HTML header
            sb.AppendLine("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            sb.AppendLine("<style>");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; }");
            sb.AppendLine("th { background-color: #4472C4; color: white; font-weight: bold; padding: 10px; border: 1px solid #ddd; text-align: center; }");
            sb.AppendLine("td { padding: 8px; border: 1px solid #ddd; }");
            sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
            sb.AppendLine(".title { font-size: 18px; font-weight: bold; margin-bottom: 10px; }");
            sb.AppendLine(".date { font-size: 12px; color: #666; margin-bottom: 20px; }");
            sb.AppendLine(".number { text-align: right; }");
            sb.AppendLine(".total { font-weight: bold; background-color: #d9e2f3; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            
            // Tiêu đề
            sb.AppendLine("<p class=\"title\">" + HtmlEncode(title) + "</p>");
            sb.AppendLine("<p class=\"date\">Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "</p>");
            
            // Table
            sb.AppendLine("<table>");
            
            // Header
            sb.AppendLine("<tr>");
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (!dgv.Columns[i].Visible) continue;
                sb.AppendLine("<th>" + HtmlEncode(dgv.Columns[i].HeaderText) + "</th>");
            }
            sb.AppendLine("</tr>");

            // Data rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine("<tr>");
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (!dgv.Columns[i].Visible) continue;
                    var value = row.Cells[i].Value;
                    string cellValue = value?.ToString() ?? "";
                    string cssClass = "";
                    
                    // Format số
                    if (value is decimal || value is double || value is int || value is long)
                    {
                        cssClass = " class=\"number\"";
                        if (value is decimal d)
                            cellValue = d.ToString("N0");
                    }
                    else if (value is DateTime dt)
                    {
                        cellValue = dt.ToString("dd/MM/yyyy");
                    }
                    
                    sb.AppendLine("<td" + cssClass + ">" + HtmlEncode(cellValue) + "</td>");
                }
                sb.AppendLine("</tr>");
            }
            
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Xuất báo cáo doanh thu với tổng hợp
        /// </summary>
        public static bool ExportDoanhThuReport(DataGridView dgv, DateTime tuNgay, DateTime denNgay, decimal tongDoanhThu)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xls)|*.xls";
                sfd.FileName = "BaoCaoDoanhThu_" + tuNgay.ToString("yyyyMMdd") + "_" + denNgay.ToString("yyyyMMdd");
                sfd.Title = "Xuất báo cáo doanh thu";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return false;

                try
                {
                    var sb = new StringBuilder();
                    
                    // HTML header
                    sb.AppendLine("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                    sb.AppendLine("<head>");
                    sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
                    sb.AppendLine("<style>");
                    sb.AppendLine("table { border-collapse: collapse; width: 100%; }");
                    sb.AppendLine("th { background-color: #4472C4; color: white; font-weight: bold; padding: 10px; border: 1px solid #ddd; text-align: center; }");
                    sb.AppendLine("td { padding: 8px; border: 1px solid #ddd; }");
                    sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
                    sb.AppendLine(".title { font-size: 20px; font-weight: bold; text-align: center; margin-bottom: 5px; }");
                    sb.AppendLine(".subtitle { font-size: 14px; text-align: center; margin-bottom: 5px; }");
                    sb.AppendLine(".date { font-size: 12px; color: #666; text-align: center; margin-bottom: 20px; }");
                    sb.AppendLine(".number { text-align: right; }");
                    sb.AppendLine(".total-row { font-weight: bold; background-color: #d9e2f3 !important; }");
                    sb.AppendLine(".total-label { text-align: right; }");
                    sb.AppendLine(".total-value { text-align: right; color: #c00000; font-size: 14px; }");
                    sb.AppendLine("</style>");
                    sb.AppendLine("</head>");
                    sb.AppendLine("<body>");
                    
                    // Tiêu đề
                    sb.AppendLine("<p class=\"title\">BÁO CÁO DOANH THU</p>");
                    sb.AppendLine("<p class=\"subtitle\">Từ ngày: " + tuNgay.ToString("dd/MM/yyyy") + " - Đến ngày: " + denNgay.ToString("dd/MM/yyyy") + "</p>");
                    sb.AppendLine("<p class=\"date\">Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "</p>");
                    
                    // Table
                    sb.AppendLine("<table>");
                    
                    // Header
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<th>STT</th>");
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (!dgv.Columns[i].Visible) continue;
                        string header = dgv.Columns[i].HeaderText;
                        // Đổi tên cột cho đẹp hơn
                        if (dgv.Columns[i].Name == "Ngay") header = "Ngày";
                        else if (dgv.Columns[i].Name == "SoHoaDon") header = "Số hóa đơn";
                        else if (dgv.Columns[i].Name == "TongTien") header = "Tổng tiền (VNĐ)";
                        sb.AppendLine("<th>" + header + "</th>");
                    }
                    sb.AppendLine("</tr>");

                    // Data rows
                    int stt = 0;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;
                        stt++;
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td class=\"number\">" + stt + "</td>");
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (!dgv.Columns[i].Visible) continue;
                            var value = row.Cells[i].Value;
                            string cellValue = value?.ToString() ?? "";
                            string cssClass = "";
                            
                            if (value is decimal d)
                            {
                                cssClass = " class=\"number\"";
                                cellValue = d.ToString("N0");
                            }
                            else if (value is int n)
                            {
                                cssClass = " class=\"number\"";
                                cellValue = n.ToString("N0");
                            }
                            else if (value is DateTime dt)
                            {
                                cellValue = dt.ToString("dd/MM/yyyy");
                            }
                            
                            sb.AppendLine("<td" + cssClass + ">" + HtmlEncode(cellValue) + "</td>");
                        }
                        sb.AppendLine("</tr>");
                    }
                    
                    // Tổng cộng
                    int colCount = 1; // STT
                    foreach (DataGridViewColumn col in dgv.Columns)
                        if (col.Visible) colCount++;
                    
                    sb.AppendLine("<tr class=\"total-row\">");
                    sb.AppendLine("<td colspan=\"" + (colCount - 1) + "\" class=\"total-label\">TỔNG CỘNG:</td>");
                    sb.AppendLine("<td class=\"total-value\">" + tongDoanhThu.ToString("N0") + " VNĐ</td>");
                    sb.AppendLine("</tr>");
                    
                    sb.AppendLine("</table>");
                    
                    // Footer
                    sb.AppendLine("<br/><br/>");
                    sb.AppendLine("<table style=\"width: 100%; border: none;\">");
                    sb.AppendLine("<tr style=\"border: none;\">");
                    sb.AppendLine("<td style=\"border: none; width: 50%;\"></td>");
                    sb.AppendLine("<td style=\"border: none; text-align: center;\">");
                    sb.AppendLine("<p><i>Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + "</i></p>");
                    sb.AppendLine("<p><b>Người lập báo cáo</b></p>");
                    sb.AppendLine("<br/><br/><br/>");
                    sb.AppendLine("<p>____________________</p>");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");
                    sb.AppendLine("</table>");
                    
                    sb.AppendLine("</body>");
                    sb.AppendLine("</html>");

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    
                    MessageBox.Show("Xuất file thành công!\n" + sfd.FileName, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Mở file sau khi xuất
                    System.Diagnostics.Process.Start(sfd.FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// Xuất báo cáo tồn kho
        /// </summary>
        public static bool ExportTonKhoReport(DataGridView dgv, decimal tongSoLuong)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", Res.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xls)|*.xls";
                sfd.FileName = "BaoCaoTonKho_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                sfd.Title = "Xuất báo cáo tồn kho";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return false;

                try
                {
                    var sb = new StringBuilder();
                    
                    sb.AppendLine("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                    sb.AppendLine("<head>");
                    sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
                    sb.AppendLine("<style>");
                    sb.AppendLine("table { border-collapse: collapse; width: 100%; }");
                    sb.AppendLine("th { background-color: #70AD47; color: white; font-weight: bold; padding: 10px; border: 1px solid #ddd; text-align: center; }");
                    sb.AppendLine("td { padding: 8px; border: 1px solid #ddd; }");
                    sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
                    sb.AppendLine(".title { font-size: 20px; font-weight: bold; text-align: center; margin-bottom: 5px; }");
                    sb.AppendLine(".date { font-size: 12px; color: #666; text-align: center; margin-bottom: 20px; }");
                    sb.AppendLine(".number { text-align: right; }");
                    sb.AppendLine(".total-row { font-weight: bold; background-color: #c6e0b4 !important; }");
                    sb.AppendLine(".total-label { text-align: right; }");
                    sb.AppendLine(".total-value { text-align: right; color: #375623; font-size: 14px; }");
                    sb.AppendLine("</style>");
                    sb.AppendLine("</head>");
                    sb.AppendLine("<body>");
                    
                    sb.AppendLine("<p class=\"title\">BÁO CÁO TỒN KHO</p>");
                    sb.AppendLine("<p class=\"date\">Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "</p>");
                    
                    sb.AppendLine("<table>");
                    
                    // Header
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<th>STT</th>");
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (!dgv.Columns[i].Visible) continue;
                        sb.AppendLine("<th>" + HtmlEncode(dgv.Columns[i].HeaderText) + "</th>");
                    }
                    sb.AppendLine("</tr>");

                    // Data rows
                    int stt = 0;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;
                        stt++;
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td class=\"number\">" + stt + "</td>");
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (!dgv.Columns[i].Visible) continue;
                            var value = row.Cells[i].Value;
                            string cellValue = value?.ToString() ?? "";
                            string cssClass = "";
                            
                            if (value is decimal d)
                            {
                                cssClass = " class=\"number\"";
                                cellValue = d.ToString("N2");
                            }
                            else if (value is int n)
                            {
                                cssClass = " class=\"number\"";
                                cellValue = n.ToString("N0");
                            }
                            
                            sb.AppendLine("<td" + cssClass + ">" + HtmlEncode(cellValue) + "</td>");
                        }
                        sb.AppendLine("</tr>");
                    }
                    
                    // Tổng cộng
                    int colCount = 1;
                    foreach (DataGridViewColumn col in dgv.Columns)
                        if (col.Visible) colCount++;
                    
                    sb.AppendLine("<tr class=\"total-row\">");
                    sb.AppendLine("<td colspan=\"" + (colCount - 1) + "\" class=\"total-label\">TỔNG CỘNG:</td>");
                    sb.AppendLine("<td class=\"total-value\">" + tongSoLuong.ToString("N0") + " sản phẩm</td>");
                    sb.AppendLine("</tr>");
                    
                    sb.AppendLine("</table>");
                    sb.AppendLine("</body>");
                    sb.AppendLine("</html>");

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    
                    MessageBox.Show("Xuất file thành công!\n" + sfd.FileName, Res.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(sfd.FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, Res.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private static string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private static string HtmlEncode(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
        }
    }
}
