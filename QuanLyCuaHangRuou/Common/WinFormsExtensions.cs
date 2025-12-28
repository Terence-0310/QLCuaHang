using System.Windows.Forms;

namespace QuanLyCuaHangRuou.Common
{
    /// <summary>
    /// Helper WinForms
    /// </summary>
    public static class WinFormsExtensions
    {
        /// <summary>
        /// Bat DoubleBuffered cho DataGridView de giam nhap nhay
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
        /// An cac cot theo ten
        /// </summary>
        public static void HideIfExists(DataGridView dgv, params string[] cols)
        {
            if (dgv == null || cols == null) return;
            foreach (var col in cols)
                if (!string.IsNullOrWhiteSpace(col) && dgv.Columns.Contains(col))
                    dgv.Columns[col].Visible = false;
        }

        /// <summary>
        /// Xu ly loi DataError de tranh crash
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
    }
}
