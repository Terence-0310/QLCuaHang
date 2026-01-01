-- =============================================
-- Script them du lieu doanh thu mau va cap nhat du lieu day du
-- Chay sau khi da co database
-- =============================================

USE QuanLyCuaHangRuou
GO

-- =============================================
-- 1. CAP NHAT VAI TRO (khop voi code C#)
-- =============================================
-- Xoa vai tro cu va them moi
DELETE FROM VaiTro WHERE MaVaiTro NOT IN ('ADMIN')
GO

-- Them vai tro moi neu chua co
IF NOT EXISTS (SELECT 1 FROM VaiTro WHERE MaVaiTro = 'ADMIN')
    INSERT INTO VaiTro (MaVaiTro, TenVaiTro) VALUES ('ADMIN', N'Qu?n tr? viên')
IF NOT EXISTS (SELECT 1 FROM VaiTro WHERE MaVaiTro = 'MANAGER')
    INSERT INTO VaiTro (MaVaiTro, TenVaiTro) VALUES ('MANAGER', N'Qu?n lý')
IF NOT EXISTS (SELECT 1 FROM VaiTro WHERE MaVaiTro = 'STAFF')
    INSERT INTO VaiTro (MaVaiTro, TenVaiTro) VALUES ('STAFF', N'Nhân viên bán hàng')
IF NOT EXISTS (SELECT 1 FROM VaiTro WHERE MaVaiTro = 'WAREHOUSE')
    INSERT INTO VaiTro (MaVaiTro, TenVaiTro) VALUES ('WAREHOUSE', N'Nhân viên kho')
GO

-- Cap nhat tai khoan su dung vai tro moi
UPDATE TaiKhoan SET MaVaiTro = 'ADMIN' WHERE MaVaiTro = 'ADMIN'
UPDATE TaiKhoan SET MaVaiTro = 'MANAGER' WHERE MaVaiTro = 'QUAN_LY'
UPDATE TaiKhoan SET MaVaiTro = 'STAFF' WHERE MaVaiTro = 'NHAN_VIEN'
GO

-- Xoa vai tro cu khong dung
DELETE FROM VaiTro WHERE MaVaiTro IN ('QUAN_LY', 'NHAN_VIEN')
GO

-- =============================================
-- 2. CAP NHAT HAN SU DUNG CHO TAT CA DO UONG
-- =============================================
-- Cap nhat han su dung cho tat ca do uong chua co
UPDATE DoUong SET HanSuDung = DATEADD(YEAR, 5, GETDATE()) WHERE HanSuDung IS NULL AND MaLoai = 'RUOU_VANG'
UPDATE DoUong SET HanSuDung = DATEADD(YEAR, 10, GETDATE()) WHERE HanSuDung IS NULL AND MaLoai = 'WHISKY'
UPDATE DoUong SET HanSuDung = DATEADD(YEAR, 2, GETDATE()) WHERE HanSuDung IS NULL AND MaLoai = 'SAKE'
UPDATE DoUong SET HanSuDung = DATEADD(YEAR, 7, GETDATE()) WHERE HanSuDung IS NULL AND MaLoai = 'VODKA'
UPDATE DoUong SET HanSuDung = DATEADD(YEAR, 3, GETDATE()) WHERE HanSuDung IS NULL -- Default 3 nam
GO

-- =============================================
-- 3. THEM KHACH HANG MOI VOI DU LIEU DAY DU
-- =============================================
IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKH = 'KH004')
    INSERT INTO KhachHang (MaKH, TenKH, SoDienThoai, DiaChi, TrangThai) VALUES
    ('KH004', N'Công ty TNHH ABC', '0281234567', N'100 Nguy?n V?n Linh, Q.7, TP.HCM', N'Ho?t ??ng')
IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKH = 'KH005')
    INSERT INTO KhachHang (MaKH, TenKH, SoDienThoai, DiaChi, TrangThai) VALUES
    ('KH005', N'Nhà hàng H??ng Vi?t', '0282345678', N'200 Lê V?n S?, Q.Tân Bình, TP.HCM', N'Ho?t ??ng')
IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKH = 'KH006')
    INSERT INTO KhachHang (MaKH, TenKH, SoDienThoai, DiaChi, TrangThai) VALUES
    ('KH006', N'Bar & Lounge Galaxy', '0284567890', N'400 ??ng Kh?i, Q.1, TP.HCM', N'Ho?t ??ng')
IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKH = 'KH007')
    INSERT INTO KhachHang (MaKH, TenKH, SoDienThoai, DiaChi, TrangThai) VALUES
    ('KH007', N'Lê Th? Thanh H??ng', '0936789012', N'70 Nam K? Kh?i Ngh?a, Q.1, TP.HCM', N'Ho?t ??ng')
IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKH = 'KH008')
    INSERT INTO KhachHang (MaKH, TenKH, SoDienThoai, DiaChi, TrangThai) VALUES
    ('KH008', N'Ph?m ??c Anh', '0947890123', N'80 ?inh Tiên Hoàng, Q.Bình Th?nh, TP.HCM', N'Ho?t ??ng')
IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKH = 'KH009')
    INSERT INTO KhachHang (MaKH, TenKH, SoDienThoai, DiaChi, TrangThai) VALUES
    ('KH009', N'Công ty XYZ Trading', '0285678901', N'500 Tr??ng S?n, Q.Tân Bình, TP.HCM', N'Ho?t ??ng')
IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKH = 'KH010')
    INSERT INTO KhachHang (MaKH, TenKH, SoDienThoai, DiaChi, TrangThai) VALUES
    ('KH010', N'Nhà hàng Sài Gòn X?a', '0286789012', N'600 Nguy?n Th? Ngh?a, Q.1, TP.HCM', N'Ho?t ??ng')
GO

-- =============================================
-- 4. THEM DO UONG MOI VOI DU LIEU DAY DU
-- =============================================
-- Ruou vang
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU005')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, HanSuDung, TrangThai, GhiChu) VALUES
    ('DU005', N'Penfolds Grange 2017', 'RUOU_VANG', 12000000, 10, N'Chai', 750, '2040-12-31', N'Còn hàng', N'R??u vang ?? Úc cao c?p')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU006')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, HanSuDung, TrangThai, GhiChu) VALUES
    ('DU006', N'Opus One 2018', 'RUOU_VANG', 9500000, 12, N'Chai', 750, '2038-12-31', N'Còn hàng', N'R??u vang ?? California')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU007')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, HanSuDung, TrangThai, GhiChu) VALUES
    ('DU007', N'Cloudy Bay Sauvignon Blanc', 'RUOU_VANG', 850000, 22, N'Chai', 750, '2026-12-31', N'Còn hàng', N'R??u vang tr?ng New Zealand')

-- Whisky
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU008')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU008', N'Macallan 18 Year Old', 'WHISKY', 8500000, 9, N'Chai', 700, N'Còn hàng', N'Single malt Scotch whisky')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU009')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU009', N'Johnnie Walker Blue Label', 'WHISKY', 5200000, 18, N'Chai', 750, N'Còn hàng', N'Blended Scotch whisky cao c?p')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU010')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU010', N'Yamazaki 12 Year Old', 'WHISKY', 3800000, 7, N'Chai', 700, N'Còn hàng', N'Japanese single malt whisky')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU011')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU011', N'Glenfiddich 21 Year Old', 'WHISKY', 6500000, 6, N'Chai', 700, N'Còn hàng', N'Single malt Scotch whisky')

-- Cognac & Brandy
IF NOT EXISTS (SELECT 1 FROM LoaiDoUong WHERE MaLoai = 'COGNAC')
    INSERT INTO LoaiDoUong (MaLoai, TenLoai, MoTa) VALUES ('COGNAC', N'Cognac & Brandy', N'R??u Cognac và Brandy Pháp')

IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU012')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU012', N'Hennessy XO', 'COGNAC', 4800000, 18, N'Chai', 700, N'Còn hàng', N'Cognac XO Pháp')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU013')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU013', N'Rémy Martin Louis XIII', 'COGNAC', 85000000, 2, N'Chai', 700, N'Còn hàng', N'Cognac huy?n tho?i')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU014')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU014', N'Martell Cordon Bleu', 'COGNAC', 3200000, 20, N'Chai', 700, N'Còn hàng', N'Cognac truy?n th?ng')

-- Vodka
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU015')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU015', N'Beluga Noble Russian', 'VODKA', 1500000, 31, N'Chai', 700, N'Còn hàng', N'Vodka Nga cao c?p')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU016')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU016', N'Grey Goose', 'VODKA', 950000, 40, N'Chai', 750, N'Còn hàng', N'Vodka Pháp')

-- Champagne & Sparkling
IF NOT EXISTS (SELECT 1 FROM LoaiDoUong WHERE MaLoai = 'CHAMPAGNE')
    INSERT INTO LoaiDoUong (MaLoai, TenLoai, MoTa) VALUES ('CHAMPAGNE', N'Champagne & Sparkling', N'R??u sâm panh và vang s?i')

IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU017')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, HanSuDung, TrangThai, GhiChu) VALUES
    ('DU017', N'Dom Pérignon 2012', 'CHAMPAGNE', 7500000, 10, N'Chai', 750, '2035-12-31', N'Còn hàng', N'Champagne huy?n tho?i')
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU018')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, HanSuDung, TrangThai, GhiChu) VALUES
    ('DU018', N'Moët & Chandon Impérial', 'CHAMPAGNE', 1200000, 16, N'Chai', 750, '2028-12-31', N'Còn hàng', N'Champagne ph? bi?n')

-- Tequila
IF NOT EXISTS (SELECT 1 FROM LoaiDoUong WHERE MaLoai = 'TEQUILA')
    INSERT INTO LoaiDoUong (MaLoai, TenLoai, MoTa) VALUES ('TEQUILA', N'Tequila', N'R??u Tequila Mexico')

IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU019')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU019', N'Patrón Silver Tequila', 'TEQUILA', 1800000, 25, N'Chai', 750, N'Còn hàng', N'Tequila Mexico cao c?p')

-- Gin
IF NOT EXISTS (SELECT 1 FROM LoaiDoUong WHERE MaLoai = 'GIN')
    INSERT INTO LoaiDoUong (MaLoai, TenLoai, MoTa) VALUES ('GIN', N'Gin', N'R??u Gin các lo?i')

IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU020')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU020', N'Hendrick''s Gin', 'GIN', 1100000, 25, N'Chai', 700, N'Còn hàng', N'Gin Scotland')

-- Rum
IF NOT EXISTS (SELECT 1 FROM LoaiDoUong WHERE MaLoai = 'RUM')
    INSERT INTO LoaiDoUong (MaLoai, TenLoai, MoTa) VALUES ('RUM', N'Rum', N'R??u Rum các lo?i')

IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU021')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, TrangThai, GhiChu) VALUES
    ('DU021', N'Bacardi 8 Años', 'RUM', 850000, 30, N'Chai', 700, N'Còn hàng', N'Rum Cuba')

-- Sake
IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU022')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, HanSuDung, TrangThai, GhiChu) VALUES
    ('DU022', N'Dassai 23 Junmai Daiginjo', 'SAKE', 2500000, 18, N'Chai', 720, '2025-12-31', N'Còn hàng', N'Sake Nh?t B?n cao c?p')

-- Liqueur
IF NOT EXISTS (SELECT 1 FROM LoaiDoUong WHERE MaLoai = 'LIQUEUR')
    INSERT INTO LoaiDoUong (MaLoai, TenLoai, MoTa) VALUES ('LIQUEUR', N'Liqueur', N'R??u mùi các lo?i')

IF NOT EXISTS (SELECT 1 FROM DoUong WHERE MaDoUong = 'DU023')
    INSERT INTO DoUong (MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DonViTinh, DungTich, HanSuDung, TrangThai, GhiChu) VALUES
    ('DU023', N'Baileys Original', 'LIQUEUR', 650000, 39, N'Chai', 700, '2026-06-30', N'Còn hàng', N'Liqueur kem Ai-len')
GO

-- =============================================
-- 5. THEM NHAN VIEN MOI (neu chua co)
-- =============================================
IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = 'NV003')
BEGIN
    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaTK = 'TK004')
        INSERT INTO TaiKhoan (MaTK, Username, Password, MaVaiTro, TrangThai) VALUES ('TK004', 'nhanvien1', '123456', 'STAFF', 1)
    INSERT INTO NhanVien (MaNV, TenNV, SoDienThoai, DiaChi, TrangThai, MaTK) VALUES
    ('NV003', N'Lê V?n Hùng', '0923456789', N'789 Hai Bà Tr?ng, Q.1, TP.HCM', N'?ang làm vi?c', 'TK004')
END
GO

-- =============================================
-- 6. THEM HOA DON DOANH THU (6 thang gan day)
-- =============================================
DECLARE @MaNV NVARCHAR(20) = (SELECT TOP 1 MaNV FROM NhanVien WHERE TrangThai LIKE N'%?ang%' OR TrangThai LIKE N'%ho?t ??ng%')
IF @MaNV IS NULL SET @MaNV = (SELECT TOP 1 MaNV FROM NhanVien)

DECLARE @MaKH1 NVARCHAR(20) = (SELECT TOP 1 MaKH FROM KhachHang)
DECLARE @MaKH2 NVARCHAR(20) = (SELECT TOP 1 MaKH FROM KhachHang WHERE MaKH <> @MaKH1)
IF @MaKH2 IS NULL SET @MaKH2 = @MaKH1

DECLARE @MaDU1 NVARCHAR(20) = (SELECT TOP 1 MaDoUong FROM DoUong)
DECLARE @MaDU2 NVARCHAR(20) = (SELECT TOP 1 MaDoUong FROM DoUong WHERE MaDoUong <> @MaDU1)
IF @MaDU2 IS NULL SET @MaDU2 = @MaDU1

DECLARE @DonGia1 DECIMAL(18,2) = (SELECT DonGia FROM DoUong WHERE MaDoUong = @MaDU1)
DECLARE @DonGia2 DECIMAL(18,2) = (SELECT DonGia FROM DoUong WHERE MaDoUong = @MaDU2)

-- THANG HIEN TAI
IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202501001')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202501001', DATEADD(DAY, -1, GETDATE()), @MaKH1, @MaNV, N'Khách quen tháng 1', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202501001', @MaDU1, @DonGia1, 2)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202501002')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202501002', DATEADD(DAY, -2, GETDATE()), @MaKH2, @MaNV, N'??n hàng nhà hàng', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202501002', @MaDU2, @DonGia2, 3)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202501003')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202501003', DATEADD(DAY, -3, GETDATE()), @MaKH1, @MaNV, N'Khách l?', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202501003', @MaDU1, @DonGia1, 1)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202501003', @MaDU2, @DonGia2, 2)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202501004')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202501004', DATEADD(DAY, -5, GETDATE()), @MaKH2, @MaNV, N'??n hàng bar', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202501004', @MaDU1, @DonGia1, 5)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202501005')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202501005', DATEADD(DAY, -7, GETDATE()), @MaKH1, @MaNV, N'??n hàng công ty', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202501005', @MaDU2, @DonGia2, 4)
END

-- THANG TRUOC
IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202412001')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202412001', DATEADD(MONTH, -1, DATEADD(DAY, -5, GETDATE())), @MaKH1, @MaNV, N'??n tháng 12', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202412001', @MaDU1, @DonGia1, 3)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202412002')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202412002', DATEADD(MONTH, -1, DATEADD(DAY, -10, GETDATE())), @MaKH2, @MaNV, N'Ti?c cu?i n?m', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202412002', @MaDU1, @DonGia1, 10)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202412002', @MaDU2, @DonGia2, 8)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202412003')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202412003', DATEADD(MONTH, -1, DATEADD(DAY, -15, GETDATE())), @MaKH1, @MaNV, N'??n Noel', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202412003', @MaDU2, @DonGia2, 5)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202412004')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202412004', DATEADD(MONTH, -1, DATEADD(DAY, -20, GETDATE())), @MaKH2, @MaNV, N'??n hàng l?n', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202412004', @MaDU1, @DonGia1, 6)
END

-- 2 THANG TRUOC
IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202411001')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202411001', DATEADD(MONTH, -2, DATEADD(DAY, -5, GETDATE())), @MaKH1, @MaNV, N'??n tháng 11', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202411001', @MaDU1, @DonGia1, 4)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202411002')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202411002', DATEADD(MONTH, -2, DATEADD(DAY, -12, GETDATE())), @MaKH2, @MaNV, N'Ti?c sinh nh?t', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202411002', @MaDU2, @DonGia2, 7)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202411003')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202411003', DATEADD(MONTH, -2, DATEADD(DAY, -18, GETDATE())), @MaKH1, @MaNV, N'Khách quen', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202411003', @MaDU1, @DonGia1, 2)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202411003', @MaDU2, @DonGia2, 3)
END

-- 3 THANG TRUOC
IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202410001')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202410001', DATEADD(MONTH, -3, DATEADD(DAY, -8, GETDATE())), @MaKH1, @MaNV, N'??n tháng 10', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202410001', @MaDU1, @DonGia1, 3)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202410002')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202410002', DATEADD(MONTH, -3, DATEADD(DAY, -15, GETDATE())), @MaKH2, @MaNV, N'??n hàng bar', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202410002', @MaDU2, @DonGia2, 6)
END

-- 4-6 THANG TRUOC
IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202409001')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202409001', DATEADD(MONTH, -4, DATEADD(DAY, -10, GETDATE())), @MaKH1, @MaNV, N'??n tháng 9', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202409001', @MaDU1, @DonGia1, 5)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202408001')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202408001', DATEADD(MONTH, -5, DATEADD(DAY, -5, GETDATE())), @MaKH2, @MaNV, N'??n tháng 8', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202408001', @MaDU2, @DonGia2, 4)
END

IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = 'HD202407001')
BEGIN
    INSERT INTO HoaDon (MaHD, NgayHoaDon, MaKH, MaNV, GhiChu, TongTien) VALUES
    ('HD202407001', DATEADD(MONTH, -6, DATEADD(DAY, -10, GETDATE())), @MaKH1, @MaNV, N'??n tháng 7', 0)
    INSERT INTO ChiTietHoaDon (MaHD, MaDoUong, DonGia, SoLuong) VALUES ('HD202407001', @MaDU1, @DonGia1, 3)
END

GO

-- =============================================
-- 7. CAP NHAT TONG TIEN CHO TAT CA HOA DON
-- =============================================
UPDATE h
SET h.TongTien = ISNULL(x.SumThanhTien, 0)
FROM dbo.HoaDon h
LEFT JOIN (
    SELECT MaHD, SUM(DonGia * SoLuong) AS SumThanhTien
    FROM dbo.ChiTietHoaDon
    GROUP BY MaHD
) x ON x.MaHD = h.MaHD
WHERE h.TongTien = 0 OR h.TongTien IS NULL OR h.TongTien <> ISNULL(x.SumThanhTien, 0)
GO

-- =============================================
-- 8. KIEM TRA KET QUA
-- =============================================
PRINT N'=== LOAI DO UONG ==='
SELECT * FROM LoaiDoUong

PRINT N''
PRINT N'=== DO UONG VOI HAN SU DUNG ==='
SELECT MaDoUong, TenDoUong, MaLoai, DonGia, SoLuongTon, DungTich, HanSuDung, TrangThai 
FROM DoUong 
ORDER BY MaLoai, MaDoUong

PRINT N''
PRINT N'=== KHACH HANG ==='
SELECT * FROM KhachHang

PRINT N''
PRINT N'=== DANH SACH HOA DON ==='
SELECT MaHD, NgayHoaDon, MaKH, MaNV, TongTien, GhiChu 
FROM HoaDon 
ORDER BY NgayHoaDon DESC

PRINT N''
PRINT N'=== DOANH THU THEO THANG ==='
SELECT 
    YEAR(NgayHoaDon) AS Nam,
    MONTH(NgayHoaDon) AS Thang,
    COUNT(*) AS SoHoaDon,
    SUM(TongTien) AS TongDoanhThu
FROM HoaDon
GROUP BY YEAR(NgayHoaDon), MONTH(NgayHoaDon)
ORDER BY Nam DESC, Thang DESC

GO
