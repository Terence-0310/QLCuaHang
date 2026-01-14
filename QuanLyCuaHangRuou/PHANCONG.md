# PHÂN CÔNG CÔNG VIỆC CHI TIẾT DỰ ÁN QUẢN LÝ CỬA HÀNG RƯỢU

**Môn học:** Lập trình trên môi trường Windows  
**Trường:** HUTECH  
**Thời gian:** Học kỳ 2024-2025

---

## 📋 DANH SÁCH THÀNH VIÊN

| STT | Họ và tên | MSSV | Vai trò | Tỷ lệ đóng góp |
|-----|-----------|------|---------|----------------|
| 1 | **Nguyễn Đức Anh Tài** | 2280602799 | Trưởng nhóm | **40%** |
| 2 | **Trần Hồng Đức** | 2380600546 | Thành viên | **20%** |
| 3 | **Lê Tấn Tài** | 2380601944 | Thành viên | **20%** |
| 4 | **Trần Anh Trung** | 2380602377 | Thành viên | **20%** |

---

## 🎯 TỔNG QUAN PHÂN CÔNG

Dự án được chia thành **4 Module chính** và **3 Layer** (GUI - BUS - BLL - DAL), mỗi thành viên sẽ phụ trách các phần công việc cụ thể theo tỷ lệ đóng góp.

---

## 👤 1. NGUYỄN ĐỨC ANH TÀI - TRƯỞNG NHÓM (40%)

### 🎯 Vai trò tổng thể
- **Quản lý dự án:** Phân công, theo dõi tiến độ, đảm bảo chất lượng
- **Kiến trúc hệ thống:** Thiết kế tổng thể, cấu trúc dự án
- **Core Infrastructure:** Xây dựng nền tảng cho toàn bộ hệ thống
- **Tích hợp & Testing:** Đảm bảo các module hoạt động đồng bộ

---

### 📦 MODULE 1: CƠ SỞ HẠ TẦNG & DATABASE (100% - Trưởng nhóm)

#### 1.1. Thiết kế Database Schema
- ✅ **File:** `Database/QuanLyCuaHangRuou.sql`
- ✅ **Nhiệm vụ:**
  - Thiết kế ERD (Entity Relationship Diagram)
  - Tạo các bảng: VaiTro, TaiKhoan, NhanVien, KhachHang, DoUong, LoaiDoUong, HoaDon, ChiTietHoaDon, KyGuiRuou, ViTriLuuTru
  - Định nghĩa Primary Keys, Foreign Keys
  - Thiết kế các View: vw_DoanhThu, vw_TonKho
  - Tạo các Stored Procedures (nếu có)
  - Thiết kế Indexes để tối ưu hiệu năng

#### 1.2. Entity Framework Models
- ✅ **Files:** `Models/Model1.cs`, `Models/*.cs` (tất cả entity models)
- ✅ **Nhiệm vụ:**
  - Tạo DbContext (Model1.cs)
  - Định nghĩa tất cả Entity Models (DoUong, KhachHang, NhanVien, HoaDon, ChiTietHoaDon, KyGuiRuou, TaiKhoan, VaiTro, LoaiDoUong, ViTriLuuTru)
  - Cấu hình quan hệ (Relationships) trong `OnModelCreating`
  - Định nghĩa Data Annotations ([Key], [Required], [StringLength], etc.)
  - Cấu hình Precision cho các trường Decimal

#### 1.3. Database Configuration
- ✅ **File:** `DAL/DbConfig.cs`
- ✅ **Nhiệm vụ:**
  - Tạo helper class DbConfig
  - Implement pattern `Use<T>()` và `Use(Action<Model1>)`
  - Cấu hình LazyLoadingEnabled = false
  - Cấu hình ProxyCreationEnabled = false
  - Implement `TestConnection()` để kiểm tra kết nối
  - Xử lý Exception và GetInnerMsg()

#### 1.4. App.config Configuration
- ✅ **File:** `App.config`
- ✅ **Nhiệm vụ:**
  - Cấu hình Connection String
  - Cấu hình Entity Framework Provider
  - Cấu hình .NET Framework version

---

### 📦 MODULE 2: HỆ THỐNG XÁC THỰC & PHÂN QUYỀN (100% - Trưởng nhóm)

#### 2.1. Authentication System
- ✅ **Files:** 
  - `DAL/AuthDal.cs`
  - `BLL/AuthBll.cs`
  - `BUS/AuthBus.cs`
  - `GUI/FrmLogin.cs`
- ✅ **Nhiệm vụ:**
  - Implement `AuthDal.Login()` - Xác thực người dùng
  - Implement `AuthBll.Login()` - Business logic đăng nhập
  - Implement `AuthBus.Login()` - Facade pattern
  - Thiết kế Form đăng nhập (FrmLogin.cs)
  - Xử lý validation username/password
  - Kiểm tra kết nối database trước khi đăng nhập
  - Xử lý exception và hiển thị thông báo lỗi

#### 2.2. Session Management
- ✅ **File:** `Common/AppSession.cs`
- ✅ **Nhiệm vụ:**
  - Quản lý session người dùng hiện tại
  - Lưu trữ: CurrentUser, CurrentRole, CurrentMaNV
  - Implement các property kiểm tra vai trò: IsAdmin, IsManager, IsStaff, IsWarehouse
  - Implement các property kiểm tra quyền: CanEditCatalog, CanDeleteCatalog, CanViewEmployees, CanSell, CanViewStatistics
  - Method `Clear()` để đăng xuất
  - Method `CanDeleteEmployeeWithRole()` để kiểm tra quyền xóa nhân viên

#### 2.3. Permission System
- ✅ **File:** `Common/PermissionKeys.cs`
- ✅ **Nhiệm vụ:**
  - Định nghĩa các hằng số vai trò: RoleAdmin, RoleManager, RoleStaff, RoleWarehouse
  - Đảm bảo các giá trị khớp với database

#### 2.4. Main Form & Menu System
- ✅ **Files:**
  - `GUI/FrmMain.cs`
  - `GUI/FrmMain.Designer.cs`
- ✅ **Nhiệm vụ:**
  - Thiết kế Form chính (MDI Parent)
  - Implement menu system với phân quyền
  - Hiển thị thông tin người dùng và vai trò
  - Xử lý đăng nhập/đăng xuất
  - Quản lý MDI children forms
  - Apply permissions để ẩn/hiện menu theo vai trò

---

### 📦 MODULE 3: BUSINESS LOGIC CORE (100% - Trưởng nhóm)

#### 3.1. BusResult Pattern
- ✅ **File:** `BUS/BusResult.cs`
- ✅ **Nhiệm vụ:**
  - Thiết kế pattern BusResult<T> để chuẩn hóa kết quả trả về
  - Implement Success/Message pattern
  - Generic BusResult<T> cho kết quả có data

#### 3.2. Common Utilities
- ✅ **Files:**
  - `Common/Res.cs` - Resource strings
  - `Common/UIConstants.cs` - UI constants
  - `Common/WinFormsExtensions.cs` - Extension methods
- ✅ **Nhiệm vụ:**
  - Định nghĩa tất cả message strings
  - Định nghĩa constants cho UI
  - Implement extension methods cho WinForms controls

#### 3.3. Program Entry Point
- ✅ **File:** `Program.cs`
- ✅ **Nhiệm vụ:**
  - Xử lý Application startup
  - Global exception handlers
  - Thread exception handlers
  - Khởi tạo FrmLogin và FrmMain

---

### 📦 MODULE 4: BÁN HÀNG - BUSINESS LOGIC (70% - Trưởng nhóm)

#### 4.1. Business Logic Layer
- ✅ **File:** `BLL/BanHangBll.cs`
- ✅ **Nhiệm vụ:**
  - Validate đơn hàng (`ValidateOrder()`)
  - Kiểm tra tồn kho (`CheckStockAvailability()`)
  - Logic thêm vào giỏ hàng (`AddToCart()`)
  - Tính tổng tiền (`CalculateTotal()`)
  - Sinh mã hóa đơn (`GenerateInvoiceCode()`)
  - Xử lý thanh toán (`ProcessPayment()`)
  - Kiểm tra quyền bán hàng

#### 4.2. Data Access Layer
- ✅ **File:** `DAL/BanHangDal.cs`
- ✅ **Nhiệm vụ:**
  - Implement `ThanhToan()` với transaction
  - Validate input trước khi truy cập DB
  - Kiểm tra mã hóa đơn trùng lặp
  - Validate tồn kho (nhóm theo MaDoUong)
  - Tạo hóa đơn và chi tiết hóa đơn
  - Trừ tồn kho (atomic operation)
  - Rollback transaction khi có lỗi
  - Dispose resources đúng cách

#### 4.3. Business Service Layer
- ✅ **File:** `BUS/BanHangBus.cs`
- ✅ **Nhiệm vụ:**
  - Facade pattern cho GUI
  - `ThanhToan()` - Gọi BLL
  - `AddToCart()` - Validate giỏ hàng
  - `CalculateTotal()` - Tính tổng tiền
  - `GenerateMaHD()` - Sinh mã hóa đơn

---

### 📦 MODULE 5: BÁO CÁO - BUSINESS LOGIC (100% - Trưởng nhóm)

#### 5.1. Report Business Logic
- ✅ **File:** `BLL/ReportBll.cs`
- ✅ **Nhiệm vụ:**
  - Định nghĩa nghiệp vụ báo cáo doanh thu
  - Định nghĩa nghiệp vụ báo cáo tồn kho
  - Validate tham số báo cáo (ngày bắt đầu, ngày kết thúc)
  - Xử lý logic tính toán doanh thu

#### 5.2. Report Data Access
- ✅ **File:** `DAL/ReportDal.cs`
- ✅ **Nhiệm vụ:**
  - Truy vấn dữ liệu từ View vw_DoanhThu
  - Truy vấn dữ liệu từ View vw_TonKho
  - Filter theo khoảng thời gian
  - Aggregate dữ liệu

#### 5.3. Report Business Service
- ✅ **File:** `BUS/ReportBus.cs`
- ✅ **Nhiệm vụ:**
  - Facade cho GUI báo cáo
  - GetDoanhThu() - Lấy báo cáo doanh thu
  - GetTonKho() - Lấy báo cáo tồn kho

---

### 📦 MODULE 6: TÍCH HỢP & TESTING (100% - Trưởng nhóm)

#### 6.1. Integration
- ✅ **Nhiệm vụ:**
  - Tích hợp tất cả các module
  - Đảm bảo các layer hoạt động đồng bộ
  - Xử lý dependencies giữa các module
  - Kiểm tra flow dữ liệu qua các layer

#### 6.2. Testing & Bug Fixing
- ✅ **Nhiệm vụ:**
  - Unit testing các business logic
  - Integration testing
  - Fix bugs phát sinh
  - Tối ưu hiệu năng
  - Code review cho các thành viên

#### 6.3. Documentation
- ✅ **Nhiệm vụ:**
  - Viết README.md
  - Tài liệu hướng dẫn sử dụng
  - Tài liệu kỹ thuật
  - Báo cáo đồ án

---

## 👤 2. TRẦN HỒNG ĐỨC (20%)

### 🎯 Vai trò tổng thể
- **Chuyên về:** Quản lý đồ uống, Giao diện người dùng, Báo cáo tồn kho
- **Kỹ năng:** WinForms UI/UX, Data Binding, Grid Controls

---

### 📦 MODULE 1: QUẢN LÝ ĐỒ UỐNG (100% - Trần Hồng Đức)

#### 1.1. Data Access Layer
- ✅ **File:** `DAL/DoUongDal.cs`
- ✅ **Nhiệm vụ:**
  - `GetAllForGrid()` - Lấy tất cả đồ uống cho grid
  - `SearchForGrid()` - Tìm kiếm đồ uống
  - `GetById()` - Lấy đồ uống theo mã
  - `GetRelationships()` - Kiểm tra quan hệ (có hóa đơn/ky gửi không)
  - `Add()` - Thêm đồ uống mới
  - `Update()` - Cập nhật đồ uống
  - `UpdateQuantity()` - Cập nhật số lượng tồn kho
  - `SoftDelete()` - Xóa mềm (đổi trạng thái)
  - `HardDelete()` - Xóa cứng (có transaction)

#### 1.2. Business Logic Layer
- ✅ **File:** `BLL/DoUongBll.cs`
- ✅ **Nhiệm vụ:**
  - `Validate()` - Validate dữ liệu đồ uống
  - `Normalize()` - Chuẩn hóa dữ liệu (trim, uppercase mã)
  - `IsCodeExists()` - Kiểm tra mã trùng
  - `CanDelete()` - Kiểm tra có thể xóa không
  - `CanSell()` - Kiểm tra có thể bán không (tồn kho, hạn sử dụng)
  - `Search()` - Tìm kiếm
  - `GetAvailableDrinks()` - Lấy đồ uống còn hàng
  - `GetLowStockDrinks()` - Lấy đồ uống sắp hết
  - `Add()`, `Update()`, `Delete()` - CRUD operations

#### 1.3. Business Service Layer
- ✅ **File:** `BUS/DoUongBus.cs`
- ✅ **Nhiệm vụ:**
  - `GetAll()` - Lấy tất cả
  - `Search()` - Tìm kiếm
  - `Add()`, `Update()`, `Delete()` - CRUD
  - `CheckAvailableForSale()` - Kiểm tra có thể bán
  - `GetAvailableDrinks()` - Đồ uống còn hàng
  - `GetLowStockDrinks()` - Đồ uống sắp hết

#### 1.4. GUI Layer
- ✅ **Files:**
  - `GUI/FrmDoUong.cs`
  - `GUI/FrmDoUong.Designer.cs`
  - `GUI/FrmDoUong.resx`
- ✅ **Nhiệm vụ:**
  - Thiết kế form quản lý đồ uống
  - DataGridView hiển thị danh sách
  - TextBox/ComboBox cho nhập liệu
  - Buttons: Thêm, Sửa, Xóa, Tìm kiếm, Làm mới
  - Validation input
  - Binding dữ liệu
  - Xử lý sự kiện click buttons
  - Hiển thị thông báo lỗi/thành công
  - Kiểm tra quyền (CanEditCatalog, CanDeleteDrink)

#### 1.5. Loại Đồ Uống
- ✅ **Files:**
  - `DAL/LoaiDoUongDal.cs`
  - `BUS/LoaiDoUongBus.cs`
- ✅ **Nhiệm vụ:**
  - CRUD loại đồ uống
  - Lấy danh sách loại cho ComboBox
  - `GetDefaultCategoryCode()` - Lấy mã loại mặc định

---

### 📦 MODULE 2: BÁN HÀNG - GIAO DIỆN (30% - Trần Hồng Đức)

#### 2.1. GUI Giỏ Hàng
- ✅ **File:** `GUI/FrmBanHang.cs` (phần giao diện giỏ hàng)
- ✅ **Nhiệm vụ:**
  - Thiết kế DataGridView giỏ hàng
  - Hiển thị: Mã đồ uống, Tên, Đơn giá, Số lượng, Thành tiền
  - Buttons: Thêm vào giỏ, Xóa dòng, Xóa hết
  - Label hiển thị tổng tiền
  - ComboBox chọn đồ uống và khách hàng
  - NumericUpDown cho số lượng
  - Xử lý sự kiện SelectedIndexChanged cho ComboBox
  - Cập nhật tổng tiền khi thay đổi giỏ hàng

---

### 📦 MODULE 3: BÁO CÁO TỒN KHO (100% - Trần Hồng Đức)

#### 3.1. Data Access Layer
- ✅ **File:** `DAL/ReportDal.cs` (phần tồn kho)
- ✅ **Nhiệm vụ:**
  - Truy vấn View `vw_TonKho`
  - Filter theo điều kiện
  - Aggregate dữ liệu tồn kho

#### 3.2. GUI Báo Cáo Tồn Kho
- ✅ **Files:**
  - `GUI/FrmBaoCaoTonKho.cs`
  - `GUI/FrmBaoCaoTonKho.Designer.cs`
- ✅ **Nhiệm vụ:**
  - Thiết kế form báo cáo tồn kho
  - DataGridView hiển thị báo cáo
  - TextBox tìm kiếm
  - Button "Xem báo cáo", "Xuất Excel"
  - Hiển thị tổng số sản phẩm
  - Export Excel sử dụng ExcelExporter

---

### 📦 MODULE 4: PHÂN QUYỀN - GIAO DIỆN (30% - Trần Hồng Đức)

#### 4.1. Kiểm Tra Quyền Giao Diện
- ✅ **Nhiệm vụ:**
  - Ẩn/hiện controls theo quyền trong FrmDoUong
  - Disable buttons khi không có quyền
  - Hiển thị thông báo khi không có quyền

---

## 👤 3. LÊ TẤN TÀI (20%)

### 🎯 Vai trò tổng thể
- **Chuyên về:** Quản lý Khách hàng, Quản lý Nhân viên, Báo cáo Doanh thu, Xử lý Hóa đơn
- **Kỹ năng:** CRUD Operations, Data Processing, Business Logic

---

### 📦 MODULE 1: QUẢN LÝ KHÁCH HÀNG (100% - Lê Tấn Tài)

#### 1.1. Data Access Layer
- ✅ **File:** `DAL/KhachHangDal.cs`
- ✅ **Nhiệm vụ:**
  - `GetAllForGrid()` - Lấy tất cả khách hàng
  - `SearchForGrid()` - Tìm kiếm khách hàng
  - `GetById()` - Lấy khách hàng theo mã
  - `GetRelationships()` - Kiểm tra quan hệ (có hóa đơn/ky gửi không)
  - `Add()` - Thêm khách hàng mới
  - `Update()` - Cập nhật khách hàng
  - `SoftDelete()` - Xóa mềm (đổi trạng thái)
  - `HardDelete()` - Xóa cứng (có transaction, xóa ky gửi, gỡ liên kết hóa đơn)

#### 1.2. Business Logic Layer
- ✅ **File:** `BLL/KhachHangBll.cs`
- ✅ **Nhiệm vụ:**
  - `Validate()` - Validate dữ liệu (mã, tên, số điện thoại)
  - `Normalize()` - Chuẩn hóa dữ liệu
  - `IsCodeExists()` - Kiểm tra mã trùng
  - `CanDelete()` - Kiểm tra có thể xóa không
  - `Search()` - Tìm kiếm
  - `GetActiveCustomers()` - Lấy khách hàng đang hoạt động
  - `Add()`, `Update()`, `Delete()` - CRUD operations

#### 1.3. Business Service Layer
- ✅ **File:** `BUS/KhachHangBus.cs`
- ✅ **Nhiệm vụ:**
  - `GetAll()` - Lấy tất cả
  - `Search()` - Tìm kiếm
  - `Add()`, `Update()`, `Delete()` - CRUD
  - `GetActiveCustomers()` - Khách hàng đang hoạt động

#### 1.4. GUI Layer
- ✅ **Files:**
  - `GUI/FrmKhachHang.cs`
  - `GUI/FrmKhachHang.Designer.cs`
  - `GUI/FrmKhachHang.resx`
- ✅ **Nhiệm vụ:**
  - Thiết kế form quản lý khách hàng
  - DataGridView hiển thị danh sách
  - Form nhập liệu: Mã KH, Tên KH, SĐT, Địa chỉ, Trạng thái
  - Buttons: Thêm, Sửa, Xóa, Tìm kiếm, Làm mới
  - Validation input (số điện thoại 10-11 số)
  - Binding dữ liệu
  - Xử lý sự kiện
  - Kiểm tra quyền (CanEditCatalog, CanDeleteCustomer)

---

### 📦 MODULE 2: QUẢN LÝ NHÂN VIÊN (100% - Lê Tấn Tài)

#### 2.1. Data Access Layer
- ✅ **File:** `DAL/NhanVienDal.cs`
- ✅ **Nhiệm vụ:**
  - `GetAllForGrid()` - Lấy tất cả nhân viên (join với TaiKhoan, VaiTro)
  - `SearchForGrid()` - Tìm kiếm nhân viên
  - `ExistsMaNV()` - Kiểm tra mã NV trùng
  - `GetById()` - Lấy nhân viên theo mã (Include TaiKhoan, VaiTro)
  - `GetByUsername()` - Lấy nhân viên theo username
  - `HasInvoices()` - Kiểm tra có hóa đơn không
  - `AddWithAccount()` - Thêm nhân viên cùng tài khoản (transaction)
  - `UpdateWithRoleAndStatus()` - Cập nhật nhân viên và vai trò
  - `SoftDelete()` - Xóa mềm (đổi trạng thái, khóa tài khoản)
  - `HardDelete()` - Xóa cứng (gỡ liên kết hóa đơn, xóa tài khoản)

#### 2.2. Business Logic Layer
- ✅ **File:** `BLL/NhanVienBll.cs`
- ✅ **Nhiệm vụ:**
  - `Validate()` - Validate dữ liệu nhân viên
  - `Normalize()` - Chuẩn hóa dữ liệu
  - `IsCodeExists()` - Kiểm tra mã trùng
  - `CanDelete()` - Kiểm tra có thể xóa không (có hóa đơn không)
  - `CanDeleteEmployeeWithRole()` - Kiểm tra quyền xóa theo vai trò
  - `Search()` - Tìm kiếm
  - `Add()`, `Update()`, `Delete()` - CRUD operations
  - Xử lý logic tạo tài khoản cùng lúc

#### 2.3. Business Service Layer
- ✅ **File:** `BUS/NhanVienBus.cs`
- ✅ **Nhiệm vụ:**
  - `GetAll()` - Lấy tất cả
  - `Search()` - Tìm kiếm
  - `Add()`, `Update()`, `Delete()` - CRUD
  - `GetById()` - Lấy theo mã
  - `GetByUsername()` - Lấy theo username

#### 2.4. GUI Layer
- ✅ **Files:**
  - `GUI/FrmNhanVien.cs`
  - `GUI/FrmNhanVien.Designer.cs`
  - `GUI/FrmNhanVien.resx`
- ✅ **Nhiệm vụ:**
  - Thiết kế form quản lý nhân viên
  - DataGridView hiển thị: Mã NV, Tên NV, SĐT, Địa chỉ, Username, Vai trò, Trạng thái
  - Form nhập liệu với ComboBox chọn vai trò
  - Buttons: Thêm, Sửa, Xóa, Tìm kiếm, Làm mới
  - Validation input
  - Xử lý tạo tài khoản khi thêm nhân viên
  - Kiểm tra quyền (CanViewEmployees, CanEditEmployees, CanDeleteEmployees)
  - Kiểm tra không được xóa chính mình

#### 2.5. Tài Khoản DAL
- ✅ **File:** `DAL/TaiKhoanDal.cs`
- ✅ **Nhiệm vụ:**
  - `GetByUsername()` - Lấy tài khoản theo username (Include VaiTro)
  - `ExistsUsername()` - Kiểm tra username trùng
  - `Add()`, `Update()` - CRUD
  - `GenerateMaTK()` - Sinh mã tài khoản

#### 2.6. Vai Trò DAL/BUS
- ✅ **Files:**
  - `DAL/VaiTroDal.cs`
  - `BUS/VaiTroBus.cs`
- ✅ **Nhiệm vụ:**
  - Lấy danh sách vai trò cho ComboBox
  - CRUD vai trò (nếu cần)

---

### 📦 MODULE 3: BÁN HÀNG - XỬ LÝ HÓA ĐƠN (30% - Lê Tấn Tài)

#### 3.1. Hóa Đơn DAL
- ✅ **File:** `DAL/HoaDonDal.cs`
- ✅ **Nhiệm vụ:**
  - `GetById()` - Lấy hóa đơn theo mã
  - `GetAll()` - Lấy tất cả hóa đơn
  - `GetByDateRange()` - Lấy hóa đơn theo khoảng thời gian
  - `GetByKhachHang()` - Lấy hóa đơn theo khách hàng
  - `GetByNhanVien()` - Lấy hóa đơn theo nhân viên

#### 3.2. Hóa Đơn BUS
- ✅ **File:** `BUS/HoaDonBus.cs`
- ✅ **Nhiệm vụ:**
  - Facade cho GUI
  - `GetById()`, `GetAll()`, `GetByDateRange()` - Các phương thức lấy dữ liệu

#### 3.3. Lịch Sử Hóa Đơn GUI
- ✅ **Files:**
  - `GUI/FrmLichSuHoaDon.cs`
  - `GUI/FrmLichSuHoaDon.Designer.cs`
- ✅ **Nhiệm vụ:**
  - Thiết kế form lịch sử hóa đơn
  - DataGridView hiển thị: Mã HD, Ngày, Khách hàng, Nhân viên, Tổng tiền
  - Filter theo ngày, khách hàng, nhân viên
  - Double-click để xem chi tiết
  - Button "Xem chi tiết"

#### 3.4. Xem Hóa Đơn GUI
- ✅ **Files:**
  - `GUI/FrmXemHoaDon.cs`
  - `GUI/FrmXemHoaDon.Designer.cs`
- ✅ **Nhiệm vụ:**
  - Hiển thị thông tin hóa đơn: Mã HD, Ngày, Khách hàng, Nhân viên
  - DataGridView chi tiết: Đồ uống, Đơn giá, Số lượng, Thành tiền
  - Label tổng tiền
  - Button "In hóa đơn", "Xuất Excel"

---

### 📦 MODULE 4: BÁO CÁO DOANH THU (100% - Lê Tấn Tài)

#### 4.1. Data Access Layer
- ✅ **File:** `DAL/ReportDal.cs` (phần doanh thu)
- ✅ **Nhiệm vụ:**
  - Truy vấn View `vw_DoanhThu`
  - Filter theo khoảng thời gian
  - Aggregate dữ liệu doanh thu

#### 4.2. GUI Báo Cáo Doanh Thu
- ✅ **Files:**
  - `GUI/FrmBaoCaoDoanhThu.cs`
  - `GUI/FrmBaoCaoDoanhThu.Designer.cs`
- ✅ **Nhiệm vụ:**
  - Thiết kế form báo cáo doanh thu
  - DateTimePicker chọn khoảng thời gian (Từ ngày - Đến ngày)
  - DataGridView hiển thị báo cáo: Ngày, Số hóa đơn, Tổng doanh thu
  - Label tổng doanh thu
  - Button "Xem báo cáo", "Xuất Excel"
  - Validation ngày (từ ngày <= đến ngày)

---

### 📦 MODULE 5: PHÂN QUYỀN - TESTING (30% - Lê Tấn Tài)

#### 5.1. Testing Phân Quyền
- ✅ **Nhiệm vụ:**
  - Test đăng nhập với các vai trò khác nhau
  - Test quyền truy cập các chức năng
  - Test quyền xóa/chỉnh sửa
  - Báo cáo bugs về phân quyền

---

## 👤 4. TRẦN ANH TRUNG (20%)

### 🎯 Vai trò tổng thể
- **Chuyên về:** Ký gửi rượu, Xuất Excel/HTML, Kiểm thử hệ thống
- **Kỹ năng:** Export Data, File Processing, Testing

---

### 📦 MODULE 1: QUẢN LÝ KÝ GỬI RƯỢU (100% - Trần Anh Trung)

#### 1.1. Data Access Layer
- ✅ **File:** `DAL/KyGuiRuouDal.cs`
- ✅ **Nhiệm vụ:**
  - `GetAllForGrid()` - Lấy tất cả ký gửi
  - `SearchForGrid()` - Tìm kiếm ký gửi
  - `GetById()` - Lấy ký gửi theo mã
  - `GetByKhachHang()` - Lấy ký gửi theo khách hàng
  - `GetByTrangThai()` - Lấy ký gửi theo trạng thái
  - `Add()` - Thêm ký gửi mới
  - `Update()` - Cập nhật ký gửi
  - `UpdateTrangThai()` - Cập nhật trạng thái
  - `Delete()` - Xóa ký gửi

#### 1.2. Business Logic Layer
- ✅ **File:** `BLL/KyGuiRuouBll.cs`
- ✅ **Nhiệm vụ:**
  - `Validate()` - Validate dữ liệu ký gửi
  - `Normalize()` - Chuẩn hóa dữ liệu
  - `IsCodeExists()` - Kiểm tra mã trùng
  - `CanDelete()` - Kiểm tra có thể xóa không
  - `CheckHanKyGui()` - Kiểm tra hạn ký gửi
  - `Search()` - Tìm kiếm
  - `Add()`, `Update()`, `Delete()` - CRUD operations

#### 1.3. Business Service Layer
- ✅ **File:** `BUS/KyGuiRuouBus.cs`
- ✅ **Nhiệm vụ:**
  - `GetAll()` - Lấy tất cả
  - `Search()` - Tìm kiếm
  - `Add()`, `Update()`, `Delete()` - CRUD
  - `GetByKhachHang()` - Lấy theo khách hàng
  - `GetByTrangThai()` - Lấy theo trạng thái

#### 1.4. GUI Layer
- ✅ **Files:**
  - `GUI/FrmKyGuiRuou.cs`
  - `GUI/FrmKyGuiRuou.Designer.cs`
  - `GUI/FrmKyGuiRuou.resx`
- ✅ **Nhiệm vụ:**
  - Thiết kế form quản lý ký gửi rượu
  - DataGridView hiển thị: Mã ký gửi, Khách hàng, Tên rượu, Ngày ký gửi, Hạn ký gửi, Trạng thái
  - Form nhập liệu: Chọn khách hàng, Tên rượu, Dung tích, Đơn vị tính, Ngày ký gửi, Hạn ký gửi, Vị trí lưu trữ
  - Buttons: Thêm, Sửa, Xóa, Tìm kiếm, Làm mới
  - Validation input (hạn ký gửi >= ngày ký gửi)
  - Kiểm tra quyền (CanEditConsignment, CanDeleteConsignment)

#### 1.5. Vị Trí Lưu Trữ
- ✅ **Files:**
  - `DAL/ViTriLuuTruDal.cs`
  - `BUS/ViTriLuuTruBus.cs`
- ✅ **Nhiệm vụ:**
  - CRUD vị trí lưu trữ
  - Lấy danh sách vị trí cho ComboBox

---

### 📦 MODULE 2: XUẤT EXCEL/HTML (100% - Trần Anh Trung)

#### 2.1. Excel Exporter
- ✅ **File:** `Common/ExcelExporter.cs`
- ✅ **Nhiệm vụ:**
  - `ExportHoaDon()` - Xuất hóa đơn ra HTML/Excel
  - `ExportBaoCaoDoanhThu()` - Xuất báo cáo doanh thu ra Excel
  - `ExportBaoCaoTonKho()` - Xuất báo cáo tồn kho ra Excel
  - Format HTML cho hóa đơn (table, styling)
  - Sử dụng thư viện Excel (EPPlus hoặc ClosedXML)
  - Tạo file và mở file sau khi xuất

#### 2.2. Tích Hợp Xuất File
- ✅ **Nhiệm vụ:**
  - Tích hợp ExportHoaDon vào FrmBanHang
  - Tích hợp ExportBaoCaoDoanhThu vào FrmBaoCaoDoanhThu
  - Tích hợp ExportBaoCaoTonKho vào FrmBaoCaoTonKho
  - Xử lý SaveFileDialog để chọn nơi lưu
  - Hiển thị thông báo thành công/lỗi

---

### 📦 MODULE 3: BÁN HÀNG - XUẤT HÓA ĐƠN (30% - Trần Anh Trung)

#### 3.1. Xuất Hóa Đơn HTML
- ✅ **File:** `GUI/FrmBanHang.cs` (phần ExportInvoice)
- ✅ **Nhiệm vụ:**
  - Implement `ExportInvoice()` trong FrmBanHang
  - Gọi ExcelExporter.ExportHoaDon()
  - Xử lý sau khi thanh toán thành công (hỏi có muốn xuất hóa đơn không)
  - Button "In hóa đơn" trong form bán hàng

---

### 📦 MODULE 4: KIỂM THỬ HỆ THỐNG (100% - Trần Anh Trung)

#### 4.1. Testing Toàn Hệ Thống
- ✅ **Nhiệm vụ:**
  - Test tất cả các chức năng CRUD
  - Test luồng bán hàng end-to-end
  - Test xuất file Excel/HTML
  - Test phân quyền với các vai trò khác nhau
  - Test validation và error handling
  - Test với dữ liệu lớn
  - Test transaction và rollback
  - Báo cáo bugs và đề xuất cải thiện

#### 4.2. Kiểm Tra Dữ Liệu
- ✅ **Nhiệm vụ:**
  - Kiểm tra tính nhất quán dữ liệu
  - Kiểm tra foreign key constraints
  - Kiểm tra business rules
  - Kiểm tra tính toàn vẹn dữ liệu

---

## 📊 TỔNG KẾT PHÂN CÔNG THEO LAYER

### DAL (Data Access Layer)
- **Nguyễn Đức Anh Tài (40%):** DbConfig.cs, BanHangDal.cs, ReportDal.cs, AuthDal.cs
- **Trần Hồng Đức (20%):** DoUongDal.cs, LoaiDoUongDal.cs
- **Lê Tấn Tài (20%):** KhachHangDal.cs, NhanVienDal.cs, TaiKhoanDal.cs, VaiTroDal.cs, HoaDonDal.cs
- **Trần Anh Trung (20%):** KyGuiRuouDal.cs, ViTriLuuTruDal.cs

### BLL (Business Logic Layer)
- **Nguyễn Đức Anh Tài (40%):** AuthBll.cs, BanHangBll.cs, ReportBll.cs
- **Trần Hồng Đức (20%):** DoUongBll.cs
- **Lê Tấn Tài (20%):** KhachHangBll.cs, NhanVienBll.cs
- **Trần Anh Trung (20%):** KyGuiRuouBll.cs

### BUS (Business Service Layer)
- **Nguyễn Đức Anh Tài (40%):** AuthBus.cs, BanHangBus.cs, ReportBus.cs, BusResult.cs
- **Trần Hồng Đức (20%):** DoUongBus.cs, LoaiDoUongBus.cs
- **Lê Tấn Tài (20%):** KhachHangBus.cs, NhanVienBus.cs, HoaDonBus.cs, VaiTroBus.cs
- **Trần Anh Trung (20%):** KyGuiRuouBus.cs, ViTriLuuTruBus.cs

### GUI (Presentation Layer)
- **Nguyễn Đức Anh Tài (40%):** FrmLogin.cs, FrmMain.cs, Program.cs
- **Trần Hồng Đức (20%):** FrmDoUong.cs, FrmBaoCaoTonKho.cs, FrmBanHang.cs (phần giỏ hàng)
- **Lê Tấn Tài (20%):** FrmKhachHang.cs, FrmNhanVien.cs, FrmLichSuHoaDon.cs, FrmXemHoaDon.cs, FrmBaoCaoDoanhThu.cs
- **Trần Anh Trung (20%):** FrmKyGuiRuou.cs, FrmBanHang.cs (phần xuất hóa đơn)

### Common (Shared Utilities)
- **Nguyễn Đức Anh Tài (40%):** AppSession.cs, PermissionKeys.cs, Res.cs, UIConstants.cs, WinFormsExtensions.cs
- **Trần Anh Trung (20%):** ExcelExporter.cs

### Models (Entity Models)
- **Nguyễn Đức Anh Tài (40%):** Model1.cs (DbContext), Tất cả Entity Models

---

## 📈 ĐÁNH GIÁ ĐÓNG GÓP CHI TIẾT

### Nguyễn Đức Anh Tài (40%)
**Tổng số file phụ trách:** ~25-30 files
- ✅ **Infrastructure & Core:** Database, Models, DbConfig, AppSession, PermissionKeys
- ✅ **Authentication & Authorization:** Toàn bộ hệ thống đăng nhập và phân quyền
- ✅ **Business Logic Core:** BanHangBll, ReportBll, AuthBll
- ✅ **Integration & Testing:** Tích hợp và kiểm thử toàn hệ thống
- ✅ **Documentation:** README, tài liệu kỹ thuật

### Trần Hồng Đức (20%)
**Tổng số file phụ trách:** ~10-12 files
- ✅ **Quản lý Đồ uống:** Toàn bộ module (DAL, BLL, BUS, GUI)
- ✅ **Báo cáo Tồn kho:** DAL, GUI
- ✅ **Giao diện Giỏ hàng:** Phần UI trong FrmBanHang
- ✅ **Loại Đồ uống:** DAL, BUS

### Lê Tấn Tài (20%)
**Tổng số file phụ trách:** ~15-18 files
- ✅ **Quản lý Khách hàng:** Toàn bộ module (DAL, BLL, BUS, GUI)
- ✅ **Quản lý Nhân viên:** Toàn bộ module (DAL, BLL, BUS, GUI)
- ✅ **Hóa đơn:** DAL, BUS, GUI (Lịch sử, Xem chi tiết)
- ✅ **Báo cáo Doanh thu:** DAL, GUI
- ✅ **Tài khoản & Vai trò:** DAL, BUS

### Trần Anh Trung (20%)
**Tổng số file phụ trách:** ~8-10 files
- ✅ **Ký gửi Rượu:** Toàn bộ module (DAL, BLL, BUS, GUI)
- ✅ **Xuất Excel/HTML:** ExcelExporter.cs, tích hợp vào các form
- ✅ **Vị trí Lưu trữ:** DAL, BUS
- ✅ **Testing:** Kiểm thử toàn hệ thống

---

## ✅ CHECKLIST HOÀN THÀNH

### Nguyễn Đức Anh Tài
- [ ] Database Schema & Scripts
- [ ] Entity Framework Models & DbContext
- [ ] DbConfig & Connection Management
- [ ] Authentication System (DAL, BLL, BUS, GUI)
- [ ] Session Management & Permissions
- [ ] BanHang Business Logic & DAL
- [ ] Report Business Logic & DAL
- [ ] Integration & Testing
- [ ] Documentation

### Trần Hồng Đức
- [ ] DoUong DAL, BLL, BUS, GUI
- [ ] LoaiDoUong DAL, BUS
- [ ] FrmBaoCaoTonKho GUI
- [ ] Giỏ hàng UI trong FrmBanHang
- [ ] Report DAL (phần tồn kho)

### Lê Tấn Tài
- [ ] KhachHang DAL, BLL, BUS, GUI
- [ ] NhanVien DAL, BLL, BUS, GUI
- [ ] TaiKhoan DAL
- [ ] VaiTro DAL, BUS
- [ ] HoaDon DAL, BUS
- [ ] FrmLichSuHoaDon GUI
- [ ] FrmXemHoaDon GUI
- [ ] FrmBaoCaoDoanhThu GUI
- [ ] Report DAL (phần doanh thu)

### Trần Anh Trung
- [ ] KyGuiRuou DAL, BLL, BUS, GUI
- [ ] ViTriLuuTru DAL, BUS
- [ ] ExcelExporter.cs
- [ ] Tích hợp xuất file vào các form
- [ ] Testing toàn hệ thống

---

## 📝 GHI CHÚ QUAN TRỌNG

1. **Code Review:** Tất cả code phải được Trưởng nhóm (Nguyễn Đức Anh Tài) review trước khi commit
2. **Naming Convention:** Tuân thủ naming convention đã thống nhất
3. **Error Handling:** Tất cả methods phải có try-catch và xử lý exception
4. **Comments:** Code phải có comments bằng tiếng Việt
5. **Testing:** Mỗi thành viên tự test module của mình trước khi tích hợp
6. **Git Workflow:** Sử dụng feature branches, không commit trực tiếp lên main
7. **Meeting:** Họp nhóm hàng tuần để báo cáo tiến độ

---

**Ngày tạo:** [Ngày hiện tại]  
**Cập nhật lần cuối:** [Ngày hiện tại]  
**Phiên bản:** 1.0
