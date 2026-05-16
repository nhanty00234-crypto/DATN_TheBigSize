
-- ====================================================================================
-- TẠO CƠ SỞ DỮ LIỆU QUANLISPORT (TÍCH HỢP AI AGENT)
-- ====================================================================================
CREATE DATABASE QuanLiSport;
GO

USE QuanLiSport;
GO

-- 1. Bảng Phân Quyền (Role)
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL -- Admin, Staff, Customer
);

-- 2. Bảng Tài Khoản (Accounts) - Đã bổ sung tích hợp AI Social & ELO
CREATE TABLE Accounts (
    AccountID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    FullName NVARCHAR(100),
    PhoneNumber VARCHAR(15),
    Email VARCHAR(100),
    RoleID INT,
    -- Các trường phục vụ AI Agent (Chatbot & Matchmaking)
    ZaloID VARCHAR(100) NULL,      -- Định danh khách hàng trên Zalo OA
    MessengerID VARCHAR(100) NULL, -- Định danh khách hàng trên Facebook Messenger
    DiemUyTin INT DEFAULT 100,     -- Trừ điểm nếu bùng kèo/hủy sân muộn
    DiemTrinhDo INT DEFAULT 1000,  -- Hệ số ELO để AI ghép kèo cân sức
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Account_Role FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- 3. Bảng Loại Sân (LoaiSan)
CREATE TABLE LoaiSan (
    LoaiSanID INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(50) NOT NULL, 
    GiaGocTheoGio DECIMAL(18, 2) NOT NULL, -- Sửa thành viết liền không dấu cách
    MoTa NVARCHAR(255)
);

-- 4. Bảng Khung Giờ Giá (KhungGioGia) - NEW: Phục vụ Dynamic Pricing
CREATE TABLE KhungGioGia (
    KhungGioID INT PRIMARY KEY IDENTITY(1,1),
    LoaiSanID INT,
    GioBatDau TIME NOT NULL,
    GioKetThuc TIME NOT NULL,
    NgayTrongTuan NVARCHAR(20), -- Ví dụ: 'T2-T6', 'T7-CN', hoặc 'All'
    GiaApDung DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_KhungGio_LoaiSan FOREIGN KEY (LoaiSanID) REFERENCES LoaiSan(LoaiSanID)
);

-- 5. Bảng Sân (San)
CREATE TABLE San (
    SanID INT PRIMARY KEY IDENTITY(1,1),
    TenSan NVARCHAR(50) NOT NULL,
    LoaiSanID INT,
    TrangThai NVARCHAR(50) DEFAULT N'Sẵn sàng', -- Sẵn sàng, Đang sửa chữa
    CONSTRAINT FK_San_LoaiSan FOREIGN KEY (LoaiSanID) REFERENCES LoaiSan(LoaiSanID)
);

-- 6. Bảng Dịch Vụ (DichVu)
CREATE TABLE DichVu (
    DichVuID INT PRIMARY KEY IDENTITY(1,1),
    TenDichVu NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL,
    DonViTinh NVARCHAR(20), 
    SoLuongTon INT DEFAULT 0
);

-- 7. Bảng Lịch Đặt Sân (LichDatSan) - Đã bổ sung HeSoGia cho AI
CREATE TABLE LichDatSan (
    DatSanID INT PRIMARY KEY IDENTITY(1,1),
    AccountID INT,
    SanID INT,
    NgayDat DATE NOT NULL,
    GioBatDau TIME NOT NULL,
    GioKetThuc TIME NOT NULL,
    HeSoGia FLOAT DEFAULT 1.0, -- AI quyết định hệ số (ví dụ 1.2 giờ cao điểm)
    TongTienDuKien DECIMAL(18, 2),
    TrangThai NVARCHAR(50) DEFAULT N'Chờ xác nhận', -- Chờ xác nhận, Đã xác nhận, Đã hủy, Đã hoàn thành
    GhiChu NVARCHAR(255),
    CONSTRAINT FK_DatSan_Account FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID),
    CONSTRAINT FK_DatSan_San FOREIGN KEY (SanID) REFERENCES San(SanID)
);

-- 8. Bảng Ghép Kèo (GhepKeo) - Kèo chính do người tạo
CREATE TABLE GhepKeo (
    KeoID INT PRIMARY KEY IDENTITY(1,1),
    DatSanID INT,
    AccountID_NguoiTao INT,
    MoTa NVARCHAR(MAX),
    TrinhDo NVARCHAR(50), -- Nghiệp dư, Bán chuyên
    SoNguoiThieu INT,
    TrangThai NVARCHAR(50) DEFAULT N'Đang tìm', -- Đang tìm, Đã đủ, Đã hủy
    CONSTRAINT FK_GhepKeo_DatSan FOREIGN KEY (DatSanID) REFERENCES LichDatSan(DatSanID),
    CONSTRAINT FK_GhepKeo_Account FOREIGN KEY (AccountID_NguoiTao) REFERENCES Accounts(AccountID)
);

-- 9. Bảng Chi Tiết Ghép Kèo (ChiTietGhepKeo) - NEW: Phục vụ AI Matchmaking
CREATE TABLE ChiTietGhepKeo (
    ChiTietKeoID INT PRIMARY KEY IDENTITY(1,1),
    KeoID INT,
    AccountID_NguoiThamGia INT,
    TrangThaiThamGia NVARCHAR(50) DEFAULT N'Chờ duyệt', -- Chờ duyệt, Đã tham gia
    CONSTRAINT FK_CTGK_Keo FOREIGN KEY (KeoID) REFERENCES GhepKeo(KeoID),
    CONSTRAINT FK_CTGK_Account FOREIGN KEY (AccountID_NguoiThamGia) REFERENCES Accounts(AccountID)
);

-- 10. Bảng Đánh Giá (DanhGia) - NEW: Data cho AI học hỏi & Xếp hạng ELO
CREATE TABLE DanhGia (
    DanhGiaID INT PRIMARY KEY IDENTITY(1,1),
    DatSanID INT,
    AccountID_NguoiDanhGia INT,
    AccountID_NguoiBiDanhGia INT NULL, -- Có thể NULL nếu đánh giá chung dịch vụ sân
    SoSao INT CHECK (SoSao BETWEEN 1 AND 5),
    BinhLuan NVARCHAR(MAX),
    NgayDanhGia DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_DanhGia_DatSan FOREIGN KEY (DatSanID) REFERENCES LichDatSan(DatSanID),
    CONSTRAINT FK_DanhGia_NguoiDanhGia FOREIGN KEY (AccountID_NguoiDanhGia) REFERENCES Accounts(AccountID),
    CONSTRAINT FK_DanhGia_NguoiBiDanhGia FOREIGN KEY (AccountID_NguoiBiDanhGia) REFERENCES Accounts(AccountID)
);

-- 11. Bảng Thẻ Giữ Xe (TheGiuXe)
CREATE TABLE TheGiuXe (
    TheID INT PRIMARY KEY IDENTITY(1,1),
    MaSoThe VARCHAR(20) UNIQUE NOT NULL,
    LoaiXe NVARCHAR(20),
    TrangThai NVARCHAR(20) DEFAULT N'Trống' 
);

-- 12. Bảng Lịch Xe Ra Vào (LichXeRaVao)
CREATE TABLE LichXeRaVao (
    LichXeID INT PRIMARY KEY IDENTITY(1,1),
    TheID INT,
    BienSoXe VARCHAR(20),
    GioVao DATETIME DEFAULT GETDATE(),
    GioRa DATETIME,
    PhiGuiXe DECIMAL(18, 2) DEFAULT 0,
    AccountID_NhanVien INT,
    CONSTRAINT FK_Xe_The FOREIGN KEY (TheID) REFERENCES TheGiuXe(TheID),
    CONSTRAINT FK_Xe_NhanVien FOREIGN KEY (AccountID_NhanVien) REFERENCES Accounts(AccountID)
);

-- 13. Bảng Hóa Đơn (HoaDon)
CREATE TABLE HoaDon (
    HoaDonID INT PRIMARY KEY IDENTITY(1,1),
    DatSanID INT NULL, 
    AccountID_KhachHang INT,
    AccountID_NhanVien INT,
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTienSan DECIMAL(18, 2) DEFAULT 0,
    TongTienDichVu DECIMAL(18, 2) DEFAULT 0,
    GiamGia DECIMAL(18, 2) DEFAULT 0,
    TongThanhToan DECIMAL(18, 2),
    PhuongThucThanhToan NVARCHAR(50), 
    TrangThaiThanhToan NVARCHAR(50), 
    CONSTRAINT FK_HD_DatSan FOREIGN KEY (DatSanID) REFERENCES LichDatSan(DatSanID),
    CONSTRAINT FK_HD_Khach FOREIGN KEY (AccountID_KhachHang) REFERENCES Accounts(AccountID),
    CONSTRAINT FK_HD_NhanVien FOREIGN KEY (AccountID_NhanVien) REFERENCES Accounts(AccountID)
);

-- 14. Bảng Chi Tiết Hóa Đơn (ChiTietHoaDon)
CREATE TABLE ChiTietHoaDon (
    ChiTietID INT PRIMARY KEY IDENTITY(1,1),
    HoaDonID INT,
    DichVuID INT,
    SoLuong INT NOT NULL,
    DonGiaTaiThoiDiemBan DECIMAL(18, 2),
    ThanhTien DECIMAL(18, 2),
    CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (HoaDonID) REFERENCES HoaDon(HoaDonID),
    CONSTRAINT FK_CTHD_DichVu FOREIGN KEY (DichVuID) REFERENCES DichVu(DichVuID)
);
