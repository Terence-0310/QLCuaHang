namespace QuanLyCuaHangRuou.Common
{
    /// <summary>
    /// T?t c? resource strings c?a ?ng d?ng
    /// </summary>
    public static class Res
    {
        // === APP ===
        public const string AppTitle = "Qu?n Lý C?a Hàng R??u";

        // === DIALOG TITLES ===
        public const string Warning = "C?nh báo";
        public const string Error = "L?i";
        public const string Info = "Thông báo";
        public const string Confirm = "Xác nh?n";

        // === FORM TITLES ===
        public const string FrmDoUongTitle = "Qu?n lý ?? u?ng";
        public const string FrmKhachHangTitle = "Qu?n lý khách hàng";
        public const string FrmNhanVienTitle = "Qu?n lý nhân viên";
        public const string FrmBanHangTitle = "Bán hàng";
        public const string FrmKyGuiRuouTitle = "Ký g?i r??u";
        public const string FrmBaoCaoDoanhThuTitle = "Báo cáo doanh thu";
        public const string FrmBaoCaoTonKhoTitle = "Báo cáo t?n kho";

        // === MENU ===
        public const string MenuSystem = "H? th?ng";
        public const string MenuLogout = "??ng xu?t";
        public const string MenuEmployee = "Qu?n lý nhân viên";
        public const string MenuExit = "Thoát";
        public const string MenuCatalog = "Danh m?c";
        public const string MenuDrink = "?? u?ng";
        public const string MenuCustomer = "Khách hàng";
        public const string MenuBusiness = "Nghi?p v?";
        public const string MenuSales = "Bán hàng";
        public const string MenuConsignment = "Ký g?i r??u";
        public const string MenuReport = "Báo cáo";
        public const string MenuRevenue = "Doanh thu";
        public const string MenuInventory = "T?n kho";

        // === ROLES ===
        public const string RoleAdmin = "Qu?n tr? viên";
        public const string RoleManager = "Qu?n lý";
        public const string RoleStaff = "Nhân viên bán hàng";
        public const string RoleWarehouse = "Nhân viên kho";

        // === STATUS VALUES ===
        public const string StatusActive = "Ho?t ??ng";
        public const string StatusInactive = "Ng?ng ho?t ??ng";
        public const string StatusWorking = "?ang làm vi?c";
        public const string StatusQuit = "Ngh? vi?c";
        public const string StatusInStock = "Còn hàng";
        public const string StatusOutOfStock = "Ng?ng kinh doanh";
        public const string StatusConsigning = "?ang ký g?i";
        public const string StatusSold = "?ã bán";
        public const string StatusReturned = "?ã tr?";

        // === LOGIN ===
        public const string LoginTitle = "??NG NH?P H? TH?NG";
        public const string LoginFailed = "Sai tài kho?n ho?c m?t kh?u.";
        public const string EnterUsername = "Vui lòng nh?p tài kho?n!";
        public const string EnterPassword = "Vui lòng nh?p m?t kh?u!";
        public const string NotLoggedIn = "Ch?a ??ng nh?p";
        public const string DbConnectionError = "L?i k?t n?i Database";

        // === VALIDATION MESSAGES ===
        public const string ConfirmDelete = "B?n có ch?c mu?n xóa?";
        public const string SelectRowToEdit = "Vui lòng ch?n dòng ?? s?a!";
        public const string SelectRowToDelete = "Vui lòng ch?n dòng ?? xóa!";
        public const string EnterRequired = "Vui lòng nh?p ??y ?? thông tin b?t bu?c!";
        public const string EnterCodeAndName = "Vui lòng nh?p mã và tên!";
        public const string EnterCode = "Vui lòng nh?p mã!";
        public const string EnterName = "Vui lòng nh?p tên!";
        public const string InvalidPrice = "??n giá không h?p l?!";
        public const string InvalidQuantity = "S? l??ng không h?p l?!";
        public const string CodeExists = "Mã này ?ã t?n t?i!";
        public const string SelectCustomer = "Vui lòng ch?n khách hàng!";
        public const string SelectDrink = "Vui lòng ch?n ?? u?ng!";
        public const string NotEnoughStock = "S? l??ng t?n kho không ??!";
        public const string QtyMustBePositive = "S? l??ng ph?i l?n h?n 0!";
        public const string CartEmpty = "Gi? hàng ?ang tr?ng!";
        public const string ConfirmPayment = "Xác nh?n thanh toán ??n hàng này?";
        public const string ExitConfirm = "B?n có mu?n thoát ch??ng trình?";

        // === SUCCESS MESSAGES ===
        public const string AddSuccess = "Thêm m?i thành công!";
        public const string UpdateSuccess = "C?p nh?t thành công!";
        public const string DeleteSuccess = "Xóa thành công!";
        public const string PaymentSuccess = "Thanh toán thành công!";
        public const string ExportSuccess = "Xu?t file thành công!";

        // === PERMISSION MESSAGES ===
        public const string NoPermissionDelete = "B?n không có quy?n th?c hi?n thao tác này!";
        public const string NoPermissionEdit = "B?n không có quy?n ch?nh s?a!";
        public const string NoPermissionAdd = "B?n không có quy?n thêm m?i!";
        public const string CannotDeleteAdmin = "Không th? xóa tài kho?n qu?n tr? viên g?c!";
        public const string CannotDeleteSelf = "Không th? xóa tài kho?n ?ang ??ng nh?p!";
        public const string CannotDeleteManager = "Ch? Admin m?i có quy?n xóa tài kho?n Qu?n lý!";
        public const string CannotCreateAdmin = "B?n không có quy?n t?o tài kho?n Admin ho?c Qu?n lý!";
        public const string CannotChangeAdminRole = "Không th? thay ??i vai trò c?a tài kho?n admin g?c!";

        // === RELATED DATA ===
        public const string RelatedInvoice = "hóa ??n";
        public const string RelatedConsignment = "ký g?i r??u";
        public const string SoftDeleteEmployee = "Nhân viên ?ang có hóa ??n liên quan.\n?ã chuy?n tr?ng thái sang 'Ngh? vi?c' và khóa tài kho?n.";

        // === METHODS ===
        public static string SoftDeleteCustomer(string reason) =>
            $"Khách hàng ?ang có {reason} liên quan.\n?ã chuy?n tr?ng thái sang 'Ng?ng ho?t ??ng'.";

        public static string SoftDeleteDrink(string reason) =>
            $"?? u?ng ?ang có {reason} liên quan.\n?ã chuy?n tr?ng thái sang 'Ng?ng kinh doanh'.";

        public static string TotalAmount(decimal amount) => $"{amount:N0} VN?";
    }
}
