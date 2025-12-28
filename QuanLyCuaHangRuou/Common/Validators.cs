using System.Text.RegularExpressions;

namespace QuanLyCuaHangRuou.Common
{
    /// <summary>
    /// Helper validate input
    /// </summary>
    public static class Validators
    {
        private static readonly Regex UsernameRgx = new Regex(@"^[a-zA-Z0-9_\.]{4,50}$", RegexOptions.Compiled);

        public static bool Username(string s) => !string.IsNullOrWhiteSpace(s) && UsernameRgx.IsMatch(s.Trim());
        public static bool Password(string s) => s != null && s.Length >= 4 && s.Length <= 200;
        public static bool Phone(string s) => string.IsNullOrWhiteSpace(s) || (s.Trim().Length >= 8 && s.Trim().Length <= 15);
        public static bool NotEmpty(string s) => !string.IsNullOrWhiteSpace(s);
        public static bool PositiveNumber(decimal n) => n > 0;
    }
}
