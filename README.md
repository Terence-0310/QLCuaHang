# 🍷 Quản Lý Cửa Hàng Rượu  
**Wine Store Management System – Windows Forms (.NET Framework)**

<div align="center">

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple?style=for-the-badge&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6.x-blue?style=for-the-badge)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-App-green?style=for-the-badge&logo=windows)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-red?style=for-the-badge&logo=microsoftsqlserver)
![License](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)

**Ứng dụng quản lý cửa hàng rượu toàn diện với giao diện Windows Forms**

[Tính năng](#-tính-năng) •
[Cài đặt](#-cài-đặt) •
[Kiến trúc](#-kiến-trúc) •
[Hướng dẫn sử dụng](#-hướng-dẫn-sử-dụng) •
[Đóng góp](#-đóng-góp)

</div>

---

## 📌 Giới thiệu

**Quản Lý Cửa Hàng Rượu** là ứng dụng desktop được phát triển bằng **C# WinForms (.NET Framework 4.7.2)**, phục vụ cho việc quản lý toàn bộ hoạt động kinh doanh của một cửa hàng rượu, bao gồm:

- Quản lý danh mục đồ uống  
- Quản lý khách hàng và nhân viên  
- Phân quyền người dùng  
- Bán hàng – xuất hóa đơn  
- Dịch vụ ký gửi rượu  
- Báo cáo doanh thu & tồn kho  

👉 Phù hợp cho **đồ án WinForms**, **môn Lập trình Windows**, hoặc **hệ thống quản lý bán hàng quy mô nhỏ**.

---

## ✨ Tính năng

### 🔐 Xác thực & phân quyền

| Vai trò | Mô tả | Quyền hạn |
|------|------|---------|
| ADMIN | Quản trị hệ thống | Toàn quyền |
| MANAGER | Quản lý | Danh mục, nhân viên, báo cáo |
| STAFF | Nhân viên bán hàng | Bán hàng, khách hàng |
| WAREHOUSE | Nhân viên kho | Quản lý tồn kho |

### 📂 Quản lý danh mục
- Đồ uống: thêm / sửa / xóa / tìm kiếm  
- Khách hàng: lưu thông tin, khách thân thiết  
- Nhân viên: quản lý tài khoản & vai trò  

### 💼 Nghiệp vụ kinh doanh
- Bán hàng với giỏ hàng trực quan  
- Xuất hóa đơn (HTML / Excel)  
- Dịch vụ ký gửi rượu  

### 📊 Báo cáo – thống kê
- Doanh thu theo thời gian  
- Tồn kho sản phẩm  
- Xuất báo cáo Excel  

---

## ⚙️ Cài đặt

### Yêu cầu hệ thống
- Windows 7 SP1 trở lên  
- .NET Framework 4.7.2  
- SQL Server 2014+  
- Visual Studio 2019 / 2022  

### Các bước cài đặt

#### 1. Clone repository
```bash
git clone https://github.com/Terence-0310/QLCuaHang.git
cd QLCuaHang
```

#### 2. Cấu hình Database
Cập nhật `App.config`:
```xml
<connectionStrings>
  <add name="Model1"
       connectionString="data source=YOUR_SERVER;
       initial catalog=QuanLyCuaHangRuou;
       integrated security=True;
       MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

#### 3. Build & chạy
- Mở `QuanLyCuaHangRuou.sln`
- Restore NuGet packages  
- Build (Ctrl + Shift + B)  
- Run (F5)  

### Tài khoản mặc định
```
Username: admin
Password: admin123
```

---

## 🧱 Kiến trúc

### Mô hình 3-Layer
```
GUI → BUS → BLL → DAL → SQL Server
```

### Cấu trúc thư mục
```
QuanLyCuaHangRuou/
├─ GUI/
├─ BUS/
├─ BLL/
├─ DAL/
├─ Models/
├─ Common/
├─ App.config
├─ Program.cs
└─ README.md
```

### BusResult Pattern
```csharp
BusResult.Ok("Thêm thành công");
BusResult.Fail("Lỗi dữ liệu");

BusResult<List<DoUong>>.Ok(data);
BusResult<DoUong>.Fail("Không tìm thấy");
```

---

## 📘 Hướng dẫn sử dụng

### Đăng nhập
- Nhập username & password  
- Nhấn Đăng nhập  

### Bán hàng
1. Chọn khách hàng  
2. Thêm sản phẩm vào giỏ  
3. Thanh toán  
4. In / xuất hóa đơn  

### Báo cáo
- Chọn thời gian  
- Xem báo cáo  
- Xuất Excel  

---

## 🗄️ Cơ sở dữ liệu

| Bảng | Mô tả |
|----|------|
| VaiTro | Vai trò |
| TaiKhoan | Tài khoản |
| NhanVien | Nhân viên |
| LoaiDoUong | Loại đồ uống |
| DoUong | Sản phẩm |
| KhachHang | Khách hàng |
| HoaDon | Hóa đơn |
| ChiTietHoaDon | Chi tiết hóa đơn |
| KyGuiRuou | Ký gửi rượu |

---

## 🤝 Đóng góp
1. Fork repository  
2. Tạo branch mới  
3. Commit thay đổi  
4. Push & tạo Pull Request  

---

## 📄 License
MIT License

---

## 👤 Tác giả
**Terence**  
GitHub: https://github.com/Terence-0310

---

⭐ Nếu thấy dự án hữu ích, hãy cho một star ⭐  
Made with ❤️ in Vietnam
