USE QuanLyCuaHangRuou;
GO

-- =============================================
-- 1) DROP TABLES (đúng thứ tự khóa ngoại)
-- =============================================
IF OBJECT_ID(N'dbo.ChiTietHoaDon', N'U') IS NOT NULL DROP TABLE dbo.ChiTietHoaDon;
IF OBJECT_ID(N'dbo.HoaDon',        N'U') IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID(N'dbo.KyGuiRuou',     N'U') IS NOT NULL DROP TABLE dbo.KyGuiRuou;
IF OBJECT_ID(N'dbo.DoUong',        N'U') IS NOT NULL DROP TABLE dbo.DoUong;
IF OBJECT_ID(N'dbo.LoaiDoUong',    N'U') IS NOT NULL DROP TABLE dbo.LoaiDoUong;
IF OBJECT_ID(N'dbo.KhachHang',     N'U') IS NOT NULL DROP TABLE dbo.KhachHang;
IF OBJECT_ID(N'dbo.NhanVien',      N'U') IS NOT NULL DROP TABLE dbo.NhanVien;
IF OBJECT_ID(N'dbo.TaiKhoan',      N'U') IS NOT NULL DROP TABLE dbo.TaiKhoan;
IF OBJECT_ID(N'dbo.VaiTro',        N'U') IS NOT NULL DROP TABLE dbo.VaiTro;
GO

-- =============================================
-- 2) TẠO BẢNG (KHỚP VỚI EF MODEL)
-- =============================================

-- Bảng VaiTro (phân quyền)
CREATE TABLE dbo.VaiTro
(
    MaVaiTro    NVARCHAR(20)   NOT NULL CONSTRAINT PK_VaiTro PRIMARY KEY,
    TenVaiTro   NVARCHAR(50)   NOT NULL
);
GO

-- Bảng TaiKhoan (liên kết với VaiTro)
CREATE TABLE dbo.TaiKhoan
(
    MaTK        NVARCHAR(20)   NOT NULL CONSTRAINT PK_TaiKhoan PRIMARY KEY,
    Username    NVARCHAR(50)   NOT NULL CONSTRAINT UQ_TaiKhoan_Username UNIQUE,
    Password    NVARCHAR(200)  NOT NULL,
    MaVaiTro    NVARCHAR(20)   NOT NULL,
    TrangThai   BIT            NOT NULL CONSTRAINT DF_TaiKhoan_TrangThai DEFAULT(1),
    HinhPath    NVARCHAR(500)  NULL,

    CONSTRAINT FK_TaiKhoan_VaiTro FOREIGN KEY (MaVaiTro) REFERENCES dbo.VaiTro(MaVaiTro)
);
GO

-- Bảng NhanVien (liên kết với TaiKhoan)
CREATE TABLE dbo.NhanVien
(
    MaNV        NVARCHAR(20)   NOT NULL CONSTRAINT PK_NhanVien PRIMARY KEY,
    TenNV       NVARCHAR(100)  NOT NULL,
    SoDienThoai NVARCHAR(20)   NULL,
    DiaChi      NVARCHAR(200)  NULL,
    TrangThai   NVARCHAR(50)   NULL,
    HinhPath    NVARCHAR(500)  NULL,
    MaTK        NVARCHAR(20)   NULL,

    CONSTRAINT FK_NhanVien_TaiKhoan FOREIGN KEY (MaTK) REFERENCES dbo.TaiKhoan(MaTK)
);
GO

-- Bảng KhachHang
CREATE TABLE dbo.KhachHang
(
    MaKH        NVARCHAR(20)   NOT NULL CONSTRAINT PK_KhachHang PRIMARY KEY,
    TenKH       NVARCHAR(100)  NOT NULL,
    SoDienThoai NVARCHAR(20)   NULL,
    DiaChi      NVARCHAR(200)  NULL,
    TrangThai   NVARCHAR(50)   NULL,
    HinhPath    NVARCHAR(500)  NULL
);
GO

-- Bảng LoaiDoUong
CREATE TABLE dbo.LoaiDoUong
(
    MaLoai      NVARCHAR(20)   NOT NULL CONSTRAINT PK_LoaiDoUong PRIMARY KEY,
    TenLoai     NVARCHAR(100)  NOT NULL,
    MoTa        NVARCHAR(500)  NULL
);
GO

-- Bảng DoUong (liên kết với LoaiDoUong)
CREATE TABLE dbo.DoUong
(
    MaDoUong    NVARCHAR(20)   NOT NULL CONSTRAINT PK_DoUong PRIMARY KEY,
    TenDoUong   NVARCHAR(200)  NOT NULL,
    MaLoai      NVARCHAR(20)   NOT NULL,
    DonGia      DECIMAL(18,2)  NOT NULL CONSTRAINT DF_DoUong_DonGia DEFAULT(0),
    SoLuongTon  INT            NOT NULL CONSTRAINT DF_DoUong_SoLuongTon DEFAULT(0),
    TrangThai   NVARCHAR(50)   NULL,
    GhiChu      NVARCHAR(500)  NULL,
    HinhPath    NVARCHAR(500)  NULL,

    CONSTRAINT FK_DoUong_LoaiDoUong FOREIGN KEY (MaLoai) REFERENCES dbo.LoaiDoUong(MaLoai)
);
GO

-- Bảng KyGuiRuou
CREATE TABLE dbo.KyGuiRuou
(
    MaKyGui         NVARCHAR(20)   NOT NULL CONSTRAINT PK_KyGuiRuou PRIMARY KEY,
    MaKH            NVARCHAR(20)   NOT NULL,
    MaDoUong        NVARCHAR(20)   NULL,
    TenRuou         NVARCHAR(200)  NOT NULL,
    DungTichConLai  DECIMAL(18,2)  NOT NULL CONSTRAINT DF_KyGui_DungTich DEFAULT(0),
    DonViTinh       NVARCHAR(10)   NOT NULL,
    NgayKyGui       DATE           NOT NULL,
    HanKyGui        DATE           NOT NULL,
    ViTriLuuTru     NVARCHAR(100)  NULL,
    TrangThai       NVARCHAR(50)   NULL,
    HinhPath        NVARCHAR(500)  NULL,

    CONSTRAINT FK_KyGui_KhachHang FOREIGN KEY (MaKH) REFERENCES dbo.KhachHang(MaKH),
    CONSTRAINT FK_KyGui_DoUong FOREIGN KEY (MaDoUong) REFERENCES dbo.DoUong(MaDoUong)
);
GO

-- Bảng HoaDon
CREATE TABLE dbo.HoaDon
(
    MaHD        NVARCHAR(30)   NOT NULL CONSTRAINT PK_HoaDon PRIMARY KEY,
    NgayHoaDon  DATETIME       NOT NULL,
    MaKH        NVARCHAR(20)   NULL,
    MaNV        NVARCHAR(20)   NULL,
    GhiChu      NVARCHAR(500)  NULL,
    TongTien    DECIMAL(18,2)  NOT NULL CONSTRAINT DF_HoaDon_TongTien DEFAULT(0),

    CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (MaKH) REFERENCES dbo.KhachHang(MaKH),
    CONSTRAINT FK_HoaDon_NhanVien  FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
);
GO

-- Bảng ChiTietHoaDon
CREATE TABLE dbo.ChiTietHoaDon
(
    MaHD        NVARCHAR(30)   NOT NULL,
    MaDoUong    NVARCHAR(20)   NOT NULL,
    DonGia      DECIMAL(18,2)  NOT NULL,
    SoLuong     INT            NOT NULL,
    ThanhTien   AS (DonGia * SoLuong) PERSISTED,

    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHD, MaDoUong),
    CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (MaHD)     REFERENCES dbo.HoaDon(MaHD),
    CONSTRAINT FK_CTHD_DoUong FOREIGN KEY (MaDoUong) REFERENCES dbo.DoUong(MaDoUong)
);
GO

-- =============================================
-- 3) TẠO VIEW
-- =============================================
CREATE OR ALTER VIEW dbo.vw_TonKho
AS
SELECT MaDoUong, TenDoUong, DonGia, SoLuongTon
FROM dbo.DoUong;
GO

CREATE OR ALTER VIEW dbo.vw_DoanhThu
AS
SELECT h.MaHD, h.NgayHoaDon, h.MaKH, h.MaNV, h.TongTien
FROM dbo.HoaDon h;
GO

-- =============================================
-- 4) SEED DATA
-- =============================================
BEGIN TRAN;

-- 4.1 VaiTro (Phân quyền) - QUAN TRỌNG!
INSERT INTO dbo.VaiTro (MaVaiTro, TenVaiTro) VALUES
(N'ADMIN',     N'Quản trị viên'),
(N'QUAN_LY',   N'Quản lý'),
(N'NHAN_VIEN', N'Nhân viên');

-- 4.2 TaiKhoan (liên kết VaiTro)
INSERT INTO dbo.TaiKhoan (MaTK, Username, Password, MaVaiTro, TrangThai, HinhPath) VALUES
(N'TK001', N'admin',      N'123456', N'ADMIN',     1, NULL),
(N'TK002', N'an.nguyen',  N'123456', N'ADMIN',     1, NULL),
(N'TK003', N'binh.tran',  N'1234',   N'QUAN_LY',   1, NULL),
(N'TK004', N'cuong.le',   N'123',    N'NHAN_VIEN', 1, NULL);

-- 4.3 NhanVien (liên kết TaiKhoan)
INSERT INTO dbo.NhanVien (MaNV, TenNV, SoDienThoai, DiaChi, TrangThai, HinhPath, MaTK) VALUES
(N'NV000', N'Admin Hệ Thống', N'0900000000', N'Hệ thống',           N'Đang hoạt động', NULL, N'TK001'),
(N'NV001', N'Nguyễn Văn An',  N'0901111111', N'Quận 1, TP.HCM',     N'Đang hoạt động', NULL, N'TK002'),
(N'NV002', N'Trần Thị Bình',  N'0902222222', N'Quận 3, TP.HCM',     N'Đang hoạt động', NULL, N'TK003'),
(N'NV003', N'Lê Văn Cường',   N'0903333333', N'TP. Thủ Đức, TP.HCM',N'Đang hoạt động', NULL, N'TK004');

-- 4.4 KhachHang
INSERT INTO dbo.KhachHang (MaKH, TenKH, SoDienThoai, DiaChi, TrangThai, HinhPath) VALUES
(N'KH001', N'Phạm Minh Khang', N'0901234567', N'Quận 1, TP.HCM',      N'Hoạt động', NULL),
(N'KH002', N'Nguyễn Thảo My',  N'0912345678', N'Quận 3, TP.HCM',      N'Hoạt động', NULL),
(N'KH003', N'Võ Quốc Huy',     N'0987654321', N'TP. Thủ Đức, TP.HCM', N'Hoạt động', NULL);

-- 4.5 LoaiDoUong
INSERT INTO dbo.LoaiDoUong (MaLoai, TenLoai, MoTa) VALUES
(N'RUOU_VANG', N'Rượu vang',  N'Rượu vang đỏ, trắng, hồng'),
(N'WHISKY',    N'Whisky',     N'Whisky các loại'),
(N'SAKE',      N'Sake',       N'Rượu Sake Nhật Bản'),
(N'VODKA',     N'Vodka',      N'Vodka các loại');

-- 4.6 DoUong (liên kết LoaiDoUong)
INSERT INTO dbo.DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, TrangThai, GhiChu, HinhPath) VALUES
(N'DU001', N'Rượu vang đỏ Pháp',   N'RUOU_VANG',  350000, 20, N'Còn hàng', N'Chai 750ml',           NULL),
(N'DU002', N'Whisky Chivas 12',    N'WHISKY',    1200000, 10, N'Còn hàng', N'Chivas Regal 12 năm',  NULL),
(N'DU003', N'Sake Junmai',         N'SAKE',       420000, 15, N'Còn hàng', N'Junmai 720ml',         NULL),
(N'DU004', N'Vodka Absolut',       N'VODKA',      280000, 25, N'Còn hàng', N'40% vol - chai 750ml', NULL);

-- 4.7 KyGuiRuou (liên kết KhachHang)
INSERT INTO dbo.KyGuiRuou (MaKyGui, MaKH, MaDoUong, TenRuou, DungTichConLai, DonViTinh, NgayKyGui, HanKyGui, ViTriLuuTru, TrangThai, HinhPath) VALUES
(N'KG001', N'KH001', NULL, N'Macallan 12',  500, N'ml', CAST(DATEADD(DAY,-5,GETDATE())  AS DATE), CAST(DATEADD(MONTH,1,GETDATE()) AS DATE), N'Kệ A1', N'Đang ký gửi', NULL),
(N'KG002', N'KH002', NULL, N'Chivas 18',   1000, N'ml', CAST(DATEADD(DAY,-20,GETDATE()) AS DATE), CAST(DATEADD(DAY,10,GETDATE())  AS DATE), N'Kệ B2', N'Đang ký gửi', NULL);

-- 4.8 HoaDon (liên kết KhachHang, NhanVien)
INSERT INTO dbo.HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
(N'HD0001', DATEADD(HOUR,-2,GETDATE()), N'KH001', N'NV003', N'Khách quen', 0),
(N'HD0002', DATEADD(DAY,-1,GETDATE()),  N'KH002', N'NV002', NULL,          0);

-- 4.9 ChiTietHoaDon (liên kết HoaDon, DoUong)
INSERT INTO dbo.ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES
(N'HD0001', N'DU001', 350000, 2),
(N'HD0001', N'DU004', 280000, 1),
(N'HD0002', N'DU002', 1200000, 1),
(N'HD0002', N'DU003', 420000,  2);

-- 4.10 Cập nhật TongTien từ ChiTietHoaDon
UPDATE h
SET h.TongTien = x.SumThanhTien
FROM dbo.HoaDon h
JOIN (
    SELECT MaHD, SUM(ThanhTien) AS SumThanhTien
    FROM dbo.ChiTietHoaDon
    GROUP BY MaHD
) x ON x.MaHD = h.MaHD;

COMMIT TRAN;
GO

-- =============================================
-- 5) KIỂM TRA DỮ LIỆU VÀ PHÂN QUYỀN
-- =============================================
SELECT * FROM dbo.VaiTro;
SELECT 
    tk.MaTK, 
    tk.Username, 
    tk.Password,
    tk.MaVaiTro,
    vt.TenVaiTro,
    CASE WHEN tk.TrangThai = 1 THEN N'Hoạt động' ELSE N'Khóa' END AS TrangThai
FROM dbo.TaiKhoan tk
JOIN dbo.VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro;
SELECT 
    nv.MaNV, 
    nv.TenNV, 
    tk.Username, 
    vt.TenVaiTro AS [Role], 
    nv.TrangThai,
    nv.SoDienThoai
FROM dbo.NhanVien nv
LEFT JOIN dbo.TaiKhoan tk ON nv.MaTK = tk.MaTK
LEFT JOIN dbo.VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro;

-- Cap nhat so dien thoai cho nhan vien
UPDATE NhanVien SET SoDienThoai = N'0900000000' WHERE MaNV = N'NV000';
UPDATE NhanVien SET SoDienThoai = N'0901111111' WHERE MaNV = N'NV001';
UPDATE NhanVien SET SoDienThoai = N'0902222222' WHERE MaNV = N'NV002';
UPDATE NhanVien SET SoDienThoai = N'0903333333' WHERE MaNV = N'NV003';

-- Kiem tra ket qua
SELECT MaNV, TenNV, SoDienThoai, TrangThai FROM NhanVien;
GO

-- Cap nhat dia chi cho nhan vien
UPDATE NhanVien SET DiaChi = N'He thong' WHERE MaNV = N'NV000';
UPDATE NhanVien SET DiaChi = N'Quan 1, TP.HCM' WHERE MaNV = N'NV001';
UPDATE NhanVien SET DiaChi = N'Quan 3, TP.HCM' WHERE MaNV = N'NV002';
UPDATE NhanVien SET DiaChi = N'TP. Thu Duc, TP.HCM' WHERE MaNV = N'NV003';
UPDATE NhanVien SET DiaChi = N'TP. Thu Duc, TP.HCM' WHERE MaNV = N'NV005';

-- Kiem tra ket qua
SELECT MaNV, TenNV, SoDienThoai, DiaChi, TrangThai FROM NhanVien;
GO

--cd "D:\Hutech\Lập trình trên môi trường Win\QLCuaHang-main\QLCuaHang-main"
--git add .
--git commit -m "Mo ta thay doi"
--git push


SELECT * FROM VaiTro
SELECT * FROM dbo.NhanVien;
SELECT * FROM dbo.KhachHang;
SELECT * FROM dbo.DoUong;
SELECT * FROM dbo.KyGuiRuou;
SELECT * FROM dbo.HoaDon;
SELECT * FROM dbo.ChiTietHoaDon;
GO