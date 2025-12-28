# Quan Ly Cua Hang Ruou

Ung dung Windows Forms quan ly cua hang ruou, phat trien tren .NET Framework 4.7.2

## Tinh nang

### Quan ly Danh muc
- Quan ly Do uong (them, sua, xoa, tim kiem)
- Quan ly Khach hang
- Quan ly Nhan vien
- Quan ly Ky gui ruou

### Ban hang
- Tao hoa don ban hang
- Gio hang voi nhieu san pham
- Tu dong tru ton kho
- Xuat hoa don HTML

### Bao cao
- Bao cao doanh thu theo ngay
- Bao cao ton kho
- Xuat Excel

### Phan quyen

| Vai tro | Quyen han |
|---------|-----------|
| ADMIN | Toan quyen, xoa cung du lieu |
| QUAN_LY | Quan ly danh muc, xem bao cao, xoa nhan vien thuong |
| NHAN_VIEN | Ban hang, xem danh muc |

### Bang phan quyen chi tiet

| Chuc nang | ADMIN | QUAN LY | NHAN VIEN |
|-----------|:-----:|:-------:|:---------:|
| Nhan vien - Xem | Yes | Yes | No |
| Nhan vien - Them/Sua | Yes | Yes | No |
| Nhan vien - Xoa | Yes | Yes (chi NV) | No |
| Khach hang - Them/Sua | Yes | Yes | No |
| Khach hang - Xoa | Yes | No | No |
| Do uong - Them/Sua | Yes | Yes | No |
| Do uong - Xoa | Yes | No | No |
| Ky gui - Them/Sua | Yes | Yes | No |
| Ky gui - Xoa | Yes | No | No |
| Thong ke/Bao cao | Yes | Yes | No |
| Ban hang | Yes | Yes | Yes |
| Doi vai tro NV | Yes | No | No |

## Cau truc Project

```
QuanLyCuaHangRuou/
+-- Common/          # Helpers, Constants, Utilities
|   +-- AppSession.cs     # Quan ly phien dang nhap
|   +-- PermissionKeys.cs # Hang so phan quyen
|   +-- Res.cs            # Chuoi thong bao
+-- DAL/             # Data Access Layer
|   +-- AuthDal.cs        # Xu ly dang nhap
|   +-- DbConfig.cs       # Cau hinh database
|   +-- NhanVienDal.cs    # Quan ly nhan vien
|   +-- KhachHangDal.cs   # Quan ly khach hang
|   +-- DoUongDal.cs      # Quan ly do uong
+-- GUI/             # Windows Forms
|   +-- FrmLogin.cs       # Form dang nhap
|   +-- FrmMain.cs        # Form chinh
|   +-- FrmNhanVien.cs    # Form nhan vien
+-- Models/          # Entity Framework Models
|   +-- Model1.cs         # DbContext
|   +-- NhanVien.cs
|   +-- TaiKhoan.cs
|   +-- VaiTro.cs
+-- Properties/      # Assembly Info
```

## So do co so du lieu

```
VaiTro (1) --< TaiKhoan (1) --< NhanVien (1) --< HoaDon
                                                   |
LoaiDoUong (1) --< DoUong (1) --< ChiTietHoaDon >--+
                      |
                      +--< KyGuiRuou >-- KhachHang (1) --< HoaDon
```

## Cong nghe su dung

- .NET Framework 4.7.2
- Windows Forms
- Entity Framework 6
- SQL Server

## Cai dat

1. Clone repository
2. Mo file .sln bang Visual Studio 2019/2022
3. Cau hinh connection string trong App.config
4. Restore NuGet packages
5. Tao database va chay script SQL
6. Build va chay (F5)

## Tai khoan mac dinh

| Username | Password | Vai tro |
|----------|----------|---------|
| admin | 123456 | Quan tri vien (ADMIN) |
| an.nguyen | 123456 | Quan tri vien (ADMIN) |
| binh.tran | 1234 | Quan ly (QUAN_LY) |
| cuong.le | 123 | Nhan vien (NHAN_VIEN) |

## Tac gia

**HUTECH** - Do an Lap trinh tren moi truong Windows

---

(c) 2024 - Dai hoc Cong nghe TP.HCM (HUTECH)
