-- =============================================
-- Script t?o b?ng và thêm d? li?u V? trí l?u tr?
-- Ch?y sau khi ?ã có database QuanLyCuaHangRuou
-- =============================================

USE QuanLyCuaHangRuou
GO

-- =============================================
-- 1. T?O B?NG V? TRÍ L?U TR? (n?u ch?a có)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ViTriLuuTru')
BEGIN
    CREATE TABLE dbo.ViTriLuuTru
    (
        MaViTri     NVARCHAR(20)   NOT NULL CONSTRAINT PK_ViTriLuuTru PRIMARY KEY,
        TenViTri    NVARCHAR(100)  NOT NULL,
        MoTa        NVARCHAR(500)  NULL,
        TrangThai   NVARCHAR(50)   NOT NULL DEFAULT N'Ho?t ??ng'
    );
    PRINT N'?ã t?o b?ng ViTriLuuTru'
END
ELSE
BEGIN
    PRINT N'B?ng ViTriLuuTru ?ã t?n t?i'
END
GO

-- =============================================
-- 2. THÊM D? LI?U M?U V? TRÍ L?U TR?
-- =============================================

-- Khu v?c VIP - R??u cao c?p
IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'VIP01')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'VIP01', N'K? VIP 01', N'Khu v?c r??u cao c?p - T?ng 1, có ?i?u hòa 18°C', N'Ho?t ??ng')

IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'VIP02')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'VIP02', N'K? VIP 02', N'Khu v?c r??u cao c?p - T?ng 1, có ?i?u hòa 18°C', N'Ho?t ??ng')

IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'VIP03')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'VIP03', N'K? VIP 03', N'Khu v?c r??u cao c?p - T?ng 1, có ?i?u hòa 18°C', N'Ho?t ??ng')

-- H?m r??u
IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'HAM01')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'HAM01', N'H?m R??u 01', N'H?m r??u ng?m - Nhi?t ?? 14-16°C, ?? ?m 70%', N'Ho?t ??ng')

IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'HAM02')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'HAM02', N'H?m R??u 02', N'H?m r??u ng?m - Nhi?t ?? 14-16°C, ?? ?m 70%', N'Ho?t ??ng')

-- T? l?nh chuyên d?ng
IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'TU01')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'TU01', N'T? L?nh 01', N'T? l?nh chuyên d?ng - Nhi?t ?? 4-8°C, cho Champagne', N'Ho?t ??ng')

IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'TU02')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'TU02', N'T? L?nh 02', N'T? l?nh chuyên d?ng - Nhi?t ?? 4-8°C, cho Champagne', N'Ho?t ??ng')

-- K? th??ng
IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'KE01')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'KE01', N'K? A01', N'K? tr?ng bày t?ng tr?t - Whisky & Cognac', N'Ho?t ??ng')

IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'KE02')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'KE02', N'K? A02', N'K? tr?ng bày t?ng tr?t - Vodka & Gin', N'Ho?t ??ng')

IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'KE03')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'KE03', N'K? B01', N'K? tr?ng bày t?ng 1 - R??u vang', N'Ho?t ??ng')

IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'KE04')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'KE04', N'K? B02', N'K? tr?ng bày t?ng 1 - Sake & Liqueur', N'Ho?t ??ng')

-- Kho l?u tr?
IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'KHO01')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'KHO01', N'Kho Chính', N'Kho l?u tr? chính - T?ng h?m, ?i?u hòa 20°C', N'Ho?t ??ng')

IF NOT EXISTS (SELECT 1 FROM ViTriLuuTru WHERE MaViTri = 'KHO02')
    INSERT INTO ViTriLuuTru (MaViTri, TenViTri, MoTa, TrangThai) VALUES
    (N'KHO02', N'Kho Ph?', N'Kho l?u tr? ph? - T?ng 2', N'Ho?t ??ng')

GO

-- =============================================
-- 3. C?P NH?T V? TRÍ CHO KÝ G?I HI?N CÓ
-- =============================================
-- C?p nh?t ký g?i ch?a có v? trí sang v? trí m?c ??nh
UPDATE KyGuiRuou 
SET ViTriLuuTru = 'VIP01' 
WHERE ViTriLuuTru IS NULL OR ViTriLuuTru = '' OR ViTriLuuTru NOT IN (SELECT MaViTri FROM ViTriLuuTru)
GO

-- =============================================
-- 4. KI?M TRA K?T QU?
-- =============================================
PRINT N''
PRINT N'=== DANH SÁCH V? TRÍ L?U TR? ==='
SELECT MaViTri, TenViTri, MoTa, TrangThai FROM ViTriLuuTru ORDER BY MaViTri

PRINT N''
PRINT N'=== KÝ G?I VÀ V? TRÍ ==='
SELECT k.MaKyGui, k.TenRuou, kh.TenKH, k.ViTriLuuTru, v.TenViTri, k.TrangThai
FROM KyGuiRuou k
LEFT JOIN KhachHang kh ON k.MaKH = kh.MaKH
LEFT JOIN ViTriLuuTru v ON k.ViTriLuuTru = v.MaViTri
ORDER BY k.MaKyGui

GO
