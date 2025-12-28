using System;

namespace QuanLyCuaHangRuou.Common
{
    /// <summary>
    /// Helper format du lieu
    /// </summary>
    public static class Formatters
    {
        public static string Money(decimal value) => string.Format("{0:N0} VN\u0110", value);
        public static string Date(DateTime date) => date.ToString("dd/MM/yyyy");
        public static string DateTime(DateTime dt) => dt.ToString("dd/MM/yyyy HH:mm");
        public static string Quantity(decimal value) => string.Format("{0:N0}", value);

        public static bool TryParseMoney(string text, out decimal result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(text)) return false;
            var raw = text.Trim().Replace(",", "").Replace(".", "").Replace(" ", "")
                         .Replace("VN\u0110", "").Replace("VND", "").Replace("\u20AB", "");
            return decimal.TryParse(raw, out result);
        }
    }
}
