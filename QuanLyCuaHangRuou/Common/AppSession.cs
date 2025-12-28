namespace QuanLyCuaHangRuou.Common
{
    /// <summary>
    /// Session nguoi dung hien tai va phan quyen
    /// - ADMIN: Quyen cao nhat, xoa tat ca
    /// - QUAN_LY: Quan ly, xoa duoc nhan vien thuong
    /// - NHAN_VIEN: Chi xem va ban hang
    /// </summary>
    public static class AppSession
    {
        // === CURRENT USER ===
        public static string CurrentUser { get; set; }
        public static string CurrentRole { get; set; }

        // === ROLE CHECKS ===
        public static bool IsAdmin => Eq(CurrentRole, PermissionKeys.RoleAdmin);
        public static bool IsManager => Eq(CurrentRole, PermissionKeys.RoleManager);
        public static bool IsStaff => Eq(CurrentRole, PermissionKeys.RoleStaff);

        // === PERMISSIONS ===
        // Danh muc (DoUong, KhachHang)
        public static bool CanEditCatalog => IsAdmin || IsManager;
        public static bool CanDeleteCatalog => IsAdmin;

        // Nhan vien
        public static bool CanViewEmployees => IsAdmin || IsManager;
        public static bool CanEditEmployees => IsAdmin || IsManager;
        public static bool CanDeleteEmployees => IsAdmin || IsManager;

        // Khach hang
        public static bool CanDeleteCustomer => IsAdmin;

        // Do uong
        public static bool CanDeleteDrink => IsAdmin;

        // Ky gui
        public static bool CanEditConsignment => IsAdmin || IsManager;
        public static bool CanDeleteConsignment => IsAdmin;

        // Bao cao
        public static bool CanViewStatistics => IsAdmin || IsManager;

        // === METHODS ===
        public static void Clear()
        {
            CurrentUser = null;
            CurrentRole = null;
        }

        private static bool Eq(string a, string b) =>
            string.Equals(a, b, System.StringComparison.OrdinalIgnoreCase);
    }
}
