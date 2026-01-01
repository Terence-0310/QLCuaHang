using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyCuaHangRuou.Common
{
    /// <summary>
    /// Helper WinForms, Validators và Formatters
    /// </summary>
    public static class WinFormsExtensions
    {
        #region DataGridView Helpers
        
        /// <summary>
        /// Bật DoubleBuffered cho DataGridView để giảm nhấp nháy
        /// </summary>
        public static void SetDoubleBuffered(DataGridView dgv)
        {
            if (dgv == null) return;
            try
            {
                var pi = typeof(DataGridView).GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                pi?.SetValue(dgv, true, null);
            }
            catch { }
        }

        /// <summary>
        /// Ẩn các cột theo tên
        /// </summary>
        public static void HideIfExists(DataGridView dgv, params string[] cols)
        {
            if (dgv == null || cols == null) return;
            foreach (var col in cols)
                if (!string.IsNullOrWhiteSpace(col) && dgv.Columns.Contains(col))
                    dgv.Columns[col].Visible = false;
        }

        /// <summary>
        /// Xử lý lỗi DataError để tránh crash
        /// </summary>
        public static void AttachDataErrorHandler(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.DataError -= OnDataError;
            dgv.DataError += OnDataError;
        }

        private static void OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }
        
        #endregion

        #region Formatters
        
        public static string Money(decimal value) => string.Format("{0:N0} VNĐ", value);
        public static string Date(DateTime date) => date.ToString("dd/MM/yyyy");
        public static string DateTime(DateTime dt) => dt.ToString("dd/MM/yyyy HH:mm");
        public static string Quantity(decimal value) => string.Format("{0:N0}", value);

        public static bool TryParseMoney(string text, out decimal result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;
            var raw = text.Trim().Replace(",", "").Replace(".", "").Replace(" ", "")
                         .Replace("VNĐ", "").Replace("VND", "").Replace("₫", "");
            return decimal.TryParse(raw, out result);
        }
        
        #endregion

        #region Validators
        
        private static readonly Regex UsernameRgx = new Regex(@"^[a-zA-Z0-9_\.]{4,50}$", RegexOptions.Compiled);

        public static bool ValidUsername(string s) => !string.IsNullOrWhiteSpace(s) && UsernameRgx.IsMatch(s.Trim());
        public static bool ValidPassword(string s) => s != null && s.Length >= 4 && s.Length <= 200;
        public static bool ValidPhone(string s) => string.IsNullOrWhiteSpace(s) || (s.Trim().Length >= 8 && s.Trim().Length <= 15);
        public static bool NotEmpty(string s) => !string.IsNullOrWhiteSpace(s);
        public static bool PositiveNumber(decimal n) => n > 0;
        
        #endregion
    }
}
