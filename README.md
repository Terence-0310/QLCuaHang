# Quản Lý Cửa Hàng Rượu

Ứng dụng **Windows Forms** quản lý cửa hàng rượu, phát triển trên **.NET Framework 4.7.2**.  
Phần mềm hỗ trợ quản lý bán hàng, kho, khách hàng, nhân viên và ký gửi rượu, phục vụ cho đồ án môn **Lập trình Windows Forms** tại **HUTECH**.

---

## Giới thiệu

Phần mềm **Quản Lý Cửa Hàng Rượu** được xây dựng nhằm hỗ trợ các hoạt động kinh doanh tại cửa hàng rượu như:
- Bán hàng
- Quản lý kho
- Quản lý khách hàng
- Quản lý nhân viên
- Quản lý ký gửi rượu

Ứng dụng phù hợp cho đồ án môn **Lập trình Windows Forms**.

---

## Tính năng

### 1. Quản lý danh mục
- Quản lý **đồ uống** (thêm, sửa, xóa, tìm kiếm)
- Quản lý **khách hàng**
- Quản lý **nhân viên**
- Quản lý **ký gửi rượu**

### 2. Bán hàng
- Tạo **hóa đơn bán hàng**
- **Giỏ hàng** hỗ trợ nhiều sản phẩm
- **Tự động trừ tồn kho** sau khi thanh toán
- Xuất **hóa đơn HTML**

### 3. Báo cáo – Thống kê
- Báo cáo **doanh thu theo ngày**
- Báo cáo **tồn kho**
- Xuất báo cáo ra **Excel**

### 4. Phân quyền người dùng

| Vai trò | Quyền hạn |
|-------|----------|
| **ADMIN** | Toàn quyền hệ thống, bao gồm xóa dữ liệu |
| **QUẢN LÝ** | Quản lý danh mục, xem báo cáo, xóa nhân viên thường |
| **NHÂN VIÊN** | Bán hàng, xem danh mục |

---

## Bảng phân quyền chi tiết

| Chức năng | ADMIN | QUẢN LÝ | NHÂN VIÊN |
|---------|:-----:|:------:|:--------:|
| Nhân viên – Xem | ✔ | ✔ | ✖ |
| Nhân viên – Thêm / Sửa | ✔ | ✔ | ✖ |
| Nhân viên – Xóa | ✔ | ✔ (chỉ NV thường) | ✖ |
| Khách hàng – Thêm / Sửa | ✔ | ✔ | ✖ |
| Khách hàng – Xóa | ✔ | ✖ | ✖ |
| Đồ uống – Thêm / Sửa | ✔ | ✔ | ✖ |
| Đồ uống – Xóa | ✔ | ✖ | ✖ |
| Ký gửi – Thêm / Sửa | ✔ | ✔ | ✖ |
| Ký gửi – Xóa | ✔ | ✖ | ✖ |
| Thống kê / Báo cáo | ✔ | ✔ | ✖ |
| Bán hàng | ✔ | ✔ | ✔ |
| Đổi vai trò nhân viên | ✔ | ✖ | ✖ |

---

## Cấu trúc Project

