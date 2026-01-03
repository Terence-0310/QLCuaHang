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

Ứng dụng được thiết kế theo mô hình **3 Layer (GUI – BUS – DAL)**, đảm bảo dễ mở rộng, dễ bảo trì và phù hợp với yêu cầu đồ án môn học.

---

## Tính năng chính

### 1. Quản lý danh mục
- Quản lý đồ uống (thêm, sửa, xóa, tìm kiếm)
- Quản lý khách hàng
- Quản lý nhân viên
- Quản lý ký gửi rượu

### 2. Bán hàng
- Tạo hóa đơn bán hàng
- Giỏ hàng hỗ trợ nhiều sản phẩm
- Tự động trừ tồn kho sau khi thanh toán
- Xuất hóa đơn HTML

### 3. Báo cáo – Thống kê
- Báo cáo doanh thu theo ngày
- Báo cáo tồn kho
- Xuất báo cáo Excel

### 4. Phân quyền người dùng
- Phân quyền theo vai trò: ADMIN / QUẢN LÝ / NHÂN VIÊN
- Kiểm soát chức năng theo quyền đăng nhập

---

## Danh sách thành viên nhóm

| STT | Họ và tên | MSSV | Vai trò | Tỷ lệ |
|----|----------|------|--------|------|
| 1 | Nguyễn Đức Anh Tài | 2280602799 | Trưởng nhóm | 40% |
| 2 | Trần Hồng Đức  | 2380600546 | Thành viên | 20% |
| 3 | Lê Tấn Tài | 2380601944 | Thành viên | 20% |
| 4 | Trần Anh Trung | 2380602377 | Thành viên | 20% |

---

## Phân chia công việc theo Module

### Module 1: Danh mục (Đồ uống – Khách hàng – Nhân viên – Ký gửi)

| Thành viên | Công việc |
|-----------|----------|
| Nguyễn Đức Anh Tài | Thiết kế cơ sở dữ liệu, định nghĩa Model, kiểm tra nghiệp vụ |
| Trần Hồng Đức | CRUD đồ uống, xử lý BUS & DAL đồ uống |
| Lê Tấn Tài | CRUD khách hàng và nhân viên |
| Trần Anh Trung | CRUD ký gửi rượu |

---

### Module 2: Bán hàng

| Thành viên | Công việc |
|-----------|----------|
| Nguyễn Đức Anh Tài | Thiết kế luồng bán hàng, kiểm tra tồn kho |
| Trần Hồng Đức | Giao diện giỏ hàng |
| Lê Tấn Tài | Xử lý hóa đơn và lưu dữ liệu |
| Trần Anh Trung | Xuất hóa đơn HTML |

---

### Module 3: Báo cáo – Thống kê

| Thành viên | Công việc |
|-----------|----------|
| Nguyễn Đức Anh Tài | Định nghĩa nghiệp vụ báo cáo |
| Trần Hồng Đức | Truy vấn dữ liệu tồn kho |
| Lê Tấn Tài | Báo cáo doanh thu |
| Trần Anh Trung | Xuất Excel, kiểm tra dữ liệu |

---

### Module 4: Hệ thống – Phân quyền

| Thành viên | Công việc |
|-----------|----------|
| Nguyễn Đức Anh Tài | Đăng nhập, phân quyền, quản lý session |
| Trần Hồng Đức | Kiểm tra quyền giao diện |
| Lê Tấn Tài | Hỗ trợ test phân quyền |
| Trần Anh Trung | Kiểm thử toàn hệ thống |

---

## Đánh giá đóng góp từng thành viên

### Nguyễn Đức Anh Tài – Trưởng nhóm (40%)
- Phân tích yêu cầu và thiết kế tổng thể hệ thống  
- Xây dựng cấu trúc dự án theo mô hình 3 Layer  
- Quản lý cơ sở dữ liệu và nghiệp vụ chính  
- Tích hợp hệ thống, kiểm thử và sửa lỗi  
- Hoàn thiện tài liệu và báo cáo đồ án  

### Trần Hồng Đức (20%)
- Thực hiện chức năng quản lý đồ uống  
- Thiết kế giao diện rõ ràng, dễ sử dụng  
- Hoàn thành công việc đúng tiến độ  

### Lê Tấn Tài (20%)
- Xây dựng chức năng quản lý khách hàng và nhân viên  
- Hỗ trợ xử lý nghiệp vụ và kiểm tra dữ liệu  
- Phối hợp tốt với các thành viên trong nhóm  

### Trần Anh Trung (20%)
- Xây dựng chức năng ký gửi rượu và báo cáo  
- Hỗ trợ xuất dữ liệu và kiểm thử  
- Có tinh thần trách nhiệm và hỗ trợ nhóm  

---

## Kết luận

Dự án **Quản Lý Cửa Hàng Rượu** đáp ứng đầy đủ yêu cầu của đồ án môn **Lập trình Windows Forms**, áp dụng kiến thức về C#, WinForms, SQL Server và mô hình 3 Layer.  
Quá trình thực hiện giúp nhóm rèn luyện kỹ năng làm việc nhóm và xây dựng phần mềm thực tế.
