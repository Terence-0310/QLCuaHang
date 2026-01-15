## PHẦN VIỆC CỦA TRƯỞNG NHÓM – NGUYỄN ĐỨC ANH TÀI

**MSSV**: 2280602799  
**Vai trò**: Trưởng nhóm (40%)  
**Mô tả ngắn**: Phụ trách nền tảng kỹ thuật của dự án, hệ thống đăng nhập–phân quyền, nghiệp vụ lõi bán hàng, tích hợp các module và hoàn thiện tài liệu.

Đoạn mô tả tổng quan:
> Em phụ trách phần nền tảng dự án gồm thiết kế database/ERD, xây dựng EF models & DbContext, chuẩn hóa DbConfig cho DAL. Em triển khai hệ thống đăng nhập–phân quyền (Auth + AppSession + ApplyPermissions) và đảm nhiệm nghiệp vụ lõi bán hàng với transaction đảm bảo dữ liệu nhất quán (hóa đơn, chi tiết, trừ kho). Ngoài ra em tích hợp các module của thành viên, kiểm thử end-to-end theo vai trò và hoàn thiện tài liệu/README để dự án chạy ổn định và trình bày mạch lạc.

---

## 1. NỀN TẢNG DỰ ÁN: DATABASE, EF MODELS & DBCONTEXT

### 1.1. Thiết kế Database / ERD

- **File SQL & thiết kế ERD**:
  - `Database/QuanLyCuaHangRuou.sql`
- Nội dung công việc:
  - Thiết kế sơ đồ ERD đầy đủ cho các thực thể:
    - `VaiTro`, `TaiKhoan`, `NhanVien`, `KhachHang`, `LoaiDoUong`, `DoUong`, `HoaDon`, `ChiTietHoaDon`, `KyGuiRuou`, `ViTriLuuTru`.
  - Định nghĩa **Primary Key**, **Foreign Key**, ràng buộc quan hệ 1–nhiều.
  - Tạo **view** báo cáo: `vw_DoanhThu`, `vw_TonKho`.
  - Tạo dữ liệu mẫu cho vai trò, tài khoản admin, v.v.

### 1.2. Entity Framework Models & DbContext

- **DbContext**:
  - `Models/Model1.cs`
- **Các Entity Model chính** (phụ trách định nghĩa & chỉnh sửa):
  - `Models/DoUong.cs`
  - `Models/LoaiDoUong.cs`
  - `Models/KhachHang.cs`
  - `Models/NhanVien.cs`
  - `Models/TaiKhoan.cs`
  - `Models/VaiTro.cs`
  - `Models/HoaDon.cs`
  - `Models/ChiTietHoaDon.cs`
  - `Models/KyGuiRuou.cs`
  - `Models/ViTriLuuTru.cs`
  - `Models/vw_DoanhThu.cs`
  - `Models/vw_TonKho.cs`
- Nội dung công việc:
  - Cấu hình `DbSet<>` trong `Model1` để map đầy đủ các bảng/view.
  - Thiết lập quan hệ trong `OnModelCreating`:
    - `DoUong` – `ChiTietHoaDon`, `HoaDon` – `ChiTietHoaDon`, `KhachHang` – `KyGuiRuou`, `LoaiDoUong` – `DoUong`, `VaiTro` – `TaiKhoan`.
  - Sử dụng DataAnnotations: `[Table]`, `[Key]`, `[Required]`, `[StringLength]`, `[Column(TypeName = "date")]`, cấu hình precision cho các trường `decimal`.

### 1.3. Chuẩn hóa DbConfig cho toàn bộ DAL

- **File phụ trách**:
  - `DAL/DbConfig.cs`
  - `QuanLyCuaHangRuou/App.config` (phần connection string & Entity Framework section)
- Nội dung công việc:
  - Định nghĩa `DbConfig.Create()` để tạo `Model1` với:
    - `LazyLoadingEnabled = false`
    - `ProxyCreationEnabled = false`  
    → giúp tối ưu hiệu năng và tránh Lazy Loading ngoài ý muốn.
  - Cung cấp pattern dùng chung cho DAL:
    - `DbConfig.Use<T>(Func<Model1, T> func)`
    - `DbConfig.Use(Action<Model1> action)`  
    → đảm bảo DbContext luôn được `Dispose` đúng cách.
  - `TestConnection()` để kiểm tra kết nối SQL Server và báo lỗi rõ ràng cho người dùng.
  - Cấu hình connection string `Model1` trong `App.config` để EF kết nối đúng tới database `QuanLyCuaHangRuou`.

---

## 2. HỆ THỐNG ĐĂNG NHẬP – PHÂN QUYỀN (AUTH + APPSESSION + APPLYPERMISSIONS)

### 2.1. Lớp truy cập dữ liệu đăng nhập (Auth DAL)

- **File phụ trách**:
  - `DAL/AuthDal.cs`
- Nội dung công việc:
  - Hàm `Login(username, password)`:
    - Kiểm tra đầu vào, gọi `DbConfig.TestConnection()`.
    - Sử dụng `TaiKhoanDal.GetByUsername()` để lấy tài khoản.
    - Kiểm tra trạng thái tài khoản, khớp mật khẩu.
    - Xác định role (ADMIN / MANAGER / STAFF / WAREHOUSE) để dùng cho phân quyền.

### 2.2. Lớp nghiệp vụ đăng nhập (Auth BLL) & Facade (Auth BUS)

- **Files phụ trách**:
  - `BLL/AuthBll.cs`
  - `BUS/AuthBus.cs`
- Nội dung công việc:
  - `AuthBll.ValidateLogin()` – kiểm tra dữ liệu đầu vào (trống username/password).
  - `AuthBll.Login()` – gọi `AuthDal`, set `AppSession.CurrentUser`, `CurrentRole`, `CurrentMaNV`.
  - `AuthBus.Login()` – đóng gói kết quả dưới dạng `BusResult<string>` để GUI dùng đơn giản.
  - `AuthBll.Logout()` & `AuthBus.Logout()` – xử lý đăng xuất, xóa session.

### 2.3. Quản lý session & phân quyền (AppSession + PermissionKeys)

- **Files phụ trách**:
  - `Common/AppSession.cs`
  - `Common/PermissionKeys.cs`
- Nội dung công việc:
  - `PermissionKeys` – định nghĩa các hằng số vai trò: `ADMIN`, `MANAGER`, `STAFF`, `WAREHOUSE` (khớp với `MaVaiTro` trong DB).
  - `AppSession` – lưu thông tin người dùng đang đăng nhập:
    - `CurrentUser`, `CurrentRole`, `CurrentMaNV`.
  - Các property quyền:
    - `IsAdmin`, `IsManager`, `IsStaff`, `IsWarehouse`.
    - `CanEditCatalog`, `CanDeleteCatalog`, `CanViewEmployees`, `CanEditEmployees`, `CanDeleteEmployees`, `CanDeleteCustomer`, `CanDeleteDrink`, `CanEditConsignment`, `CanDeleteConsignment`, `CanViewStatistics`, `CanSell`.
  - Hàm `Clear()` – xóa session khi đăng xuất.
  - Hàm `CanDeleteEmployeeWithRole()` – logic chi tiết kiểm tra quyền xóa nhân viên tùy vai trò.

### 2.4. Áp dụng phân quyền lên giao diện (ApplyPermissions)

- **Files liên quan**:
  - `GUI/FrmMain.cs` (trưởng nhóm thiết kế và áp dụng logic)
  - `Program.cs` (quy trình chạy: Login → Main)
- Nội dung công việc:
  - Sau khi đăng nhập thành công, `Program.Main()` khởi tạo `FrmMain` với user/role hiện tại.
  - `FrmMain`:
    - `UpdateUserDisplay()` – hiển thị tên đăng nhập và vai trò.
    - `ApplyPermissions()` – ẩn/hiện các menu (Quản lý nhân viên, Báo cáo, v.v.) dựa trên `AppSession`.
  - Đảm bảo mỗi vai trò chỉ thấy và dùng được các chức năng phù hợp.

---

## 3. NGHIỆP VỤ LÕI BÁN HÀNG VỚI TRANSACTION (HÓA ĐƠN, CHI TIẾT, TRỪ KHO)

### 3.1. Business Logic bán hàng (BanHangBll)

- **File phụ trách**:
  - `BLL/BanHangBll.cs`
- Nội dung công việc:
  - `ValidateOrder()` – kiểm tra mã hóa đơn, giỏ hàng, số lượng, đơn giá.
  - `CheckStockAvailability()` – kiểm tra tồn kho trước khi thanh toán (gọi `DoUongBll.CanSell()`).
  - `AddToCart()` – logic thêm vào giỏ hàng, kiểm tra tồn kho, trạng thái, hạn sử dụng.
  - `CalculateTotal()` – tính tổng tiền giỏ hàng.
  - `GenerateInvoiceCode()` – sinh mã hóa đơn dạng `HDyyyyMMddHHmmss`.
  - `ProcessPayment()` – xử lý thanh toán:
    - Kiểm tra quyền bán hàng (`AppSession.CanSell`).
    - Gọi `ValidateOrder()`, kiểm tra mã hóa đơn trùng (`HoaDonDal.GetById()`).
    - Gọi `CheckStockAvailability()` để đảm bảo tồn kho.
    - Gọi `BanHangDal.ThanhToan()` – nơi thực hiện transaction với DB.

### 3.2. Data Access bán hàng & transaction (BanHangDal)

- **File phụ trách**:
  - `DAL/BanHangDal.cs`
- Nội dung công việc:
  - `ThanhToan()` – xử lý nhiều bước trong một **transaction** EF:
    - Mở `DbContext` và `DbContextTransaction` bằng `DbConfig.Create()`.
    - Kiểm tra mã hóa đơn đã tồn tại chưa (`Any(x => x.MaHD == maHd)`).
    - Lấy danh sách đồ uống trong giỏ (`DoUongs.Where(...)`).
    - Nhóm giỏ hàng theo `MaDoUong`, cộng số lượng để kiểm tra tồn kho tổng cho mỗi sản phẩm.
    - Nếu thiếu tồn kho thì ném exception (rollback toàn bộ).
    - Tạo bản ghi `HoaDon` với tổng tiền.
    - Thêm các bản ghi `ChiTietHoaDon` tương ứng.
    - Trừ tồn kho `DoUong.SoLuongTon` theo tổng số lượng đã bán.
    - `SaveChanges()` và `Commit()`, rollback nếu bất kỳ bước nào lỗi.

### 3.3. Facade bán hàng cho GUI (BanHangBus)

- **File phụ trách**:
  - `BUS/BanHangBus.cs`
- Nội dung công việc:
  - Cung cấp các hàm để Form bán hàng (`FrmBanHang`) sử dụng:
    - `GenerateMaHD()` – sinh mã hóa đơn mới.
    - `AddToCart()` – kiểm tra logic trước khi thêm vào giỏ.
    - `CalculateTotal()` – tính tổng tiền từ danh sách `GioHangItem`.
    - `ThanhToan()` – gọi `BanHangBll.ProcessPayment()` và trả về `BusResult` cho GUI hiển thị.

---

## 4. TÍCH HỢP MODULE, KIỂM THỬ END-TO-END & TÀI LIỆU

### 4.1. Tích hợp các module

- Kết nối các phần do thành viên khác thực hiện (Đồ uống, Khách hàng, Nhân viên, Ký gửi, Báo cáo) với phần nền tảng do trưởng nhóm chịu trách nhiệm.
- Đảm bảo flow dữ liệu:
  - GUI → BUS → BLL → DAL → Database → quay lại GUI
  - Hoạt động mượt mà cho các luồng:
    - Đăng nhập → Mở form → Thao tác CRUD → Kiểm tra phân quyền.
    - Bán hàng → Tạo hóa đơn → Trừ tồn kho → Báo cáo.

### 4.2. Kiểm thử end-to-end theo vai trò

- Test các vai trò: `ADMIN`, `MANAGER`, `STAFF`, `WAREHOUSE`:
  - Quyền truy cập form.
  - Quyền thêm/sửa/xóa dữ liệu.
  - Quyền xem báo cáo.
- Test luồng bán hàng thực tế:
  - Chọn khách hàng, thêm sản phẩm vào giỏ, kiểm tra tồn kho, thanh toán, xuất hóa đơn.
  - Kiểm tra dữ liệu hóa đơn & chi tiết cập nhật đúng trong DB.

### 4.3. Hoàn thiện tài liệu / README

- Góp phần chính trong việc viết và chỉnh sửa:
  - `README.md` ở gốc dự án (giới thiệu, tính năng, cài đặt, kiến trúc).
  - Các đoạn mô tả module, phân công, đánh giá đóng góp.
  - Diễn giải rõ ràng cách kết nối DB, cách chạy dự án, và các luồng nghiệp vụ chính.

---

## 5. TÓM TẮT

Trưởng nhóm phụ trách toàn bộ **nền tảng kỹ thuật** (database, EF, DbContext, DbConfig), xây dựng **hệ thống đăng nhập – phân quyền** (Auth, AppSession, ApplyPermissions), triển khai **nghiệp vụ bán hàng lõi** với transaction đảm bảo tính nhất quán dữ liệu, đồng thời **tích hợp, kiểm thử end-to-end** và **hoàn thiện tài liệu/README** để dự án chạy ổn định, dễ bảo trì và trình bày mạch lạc.

