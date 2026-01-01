namespace QuanLyCuaHangRuou.Common
{
    /// <summary>
    /// Session người dùng hiện tại và phân quyền
    /// </summary>
    public static class AppSession
    {
        // === CURRENT USER ===
        public static string CurrentUser { get; set; }
        public static string CurrentRole { get; set; }
        public static string CurrentMaNV { get; set; }

        // === ROLE CHECKS ===
        public static bool IsAdmin => Eq(CurrentRole, PermissionKeys.RoleAdmin);
        public static bool IsManager => Eq(CurrentRole, PermissionKeys.RoleManager);
        public static bool IsStaff => Eq(CurrentRole, PermissionKeys.RoleStaff);
        public static bool IsWarehouse => Eq(CurrentRole, PermissionKeys.RoleWarehouse);

        // === PERMISSIONS ===
        public static bool CanEditCatalog => IsAdmin || IsManager;
        public static bool CanDeleteCatalog => IsAdmin;
        public static bool CanViewEmployees => IsAdmin || IsManager;
        public static bool CanEditEmployees => IsAdmin || IsManager;
        public static bool CanDeleteEmployees => IsAdmin || IsManager;
        public static bool CanDeleteCustomer => IsAdmin;
        public static bool CanDeleteDrink => IsAdmin;
        public static bool CanEditConsignment => IsAdmin || IsManager;
        public static bool CanDeleteConsignment => IsAdmin;
        public static bool CanViewStatistics => IsAdmin || IsManager;
        public static bool CanSell => IsAdmin || IsManager || IsStaff;

        // === METHODS ===
        public static void Clear()
        {
            CurrentUser = null;
            CurrentRole = null;
            CurrentMaNV = null;
        }

        /// <summary>
        /// Kiểm tra quyền xóa nhân viên với vai trò cụ thể
        /// </summary>
        public static bool CanDeleteEmployeeWithRole(string targetRole, string targetUsername)
        {
            if (Eq(targetUsername, CurrentUser)) return false;
            if (IsAdmin)
            {
                if (Eq(targetRole, PermissionKeys.RoleAdmin) && Eq(targetUsername, "admin"))
                    return false;
                return true;
            }
            if (IsManager)
                return Eq(targetRole, PermissionKeys.RoleStaff) || Eq(targetRole, PermissionKeys.RoleWarehouse);
            return false;
        }

        private static bool Eq(string a, string b) =>
            string.Equals(a?.Trim(), b?.Trim(), System.StringComparison.OrdinalIgnoreCase);
    }
}
