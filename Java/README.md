# Badminton Match Management System

Hệ thống quản lý lịch thi đấu, đặt sân cầu lông với thuật toán xếp hạng ELO và định giá động.

## 📋 Cấu trúc Dự án

```
.
├── frontend-app/          # React application
│   └── src/
│       ├── components/    # Reusable UI components
│       ├── pages/        # Page components
│       ├── services/     # API service layer
│       └── assets/       # Images, icons, logos
├── backend-api/          # .NET 10 API
│   ├── Controllers/      # API endpoints
│   ├── Models/          # Database models
│   └── Services/        # Business logic
├── docker-compose.yml   # Services configuration
└── README.md           # This file
```

## 🚀 Cài đặt và Chạy

### Yêu cầu
- Node.js 18+
- .NET 10 SDK
- Docker & Docker Compose
- Git

### 1️⃣ Chạy Database và Services

```bash
# Khởi động tất cả services (SQL Server, n8n, PostgreSQL, Redis)
docker-compose up -d

# Kiểm tra trạng thái
docker-compose ps
```

**Thông tin kết nối:**
- **SQL Server**: localhost:1433
  - User: sa
  - Password: YourPassword123!
- **n8n**: http://localhost:5678
- **PostgreSQL**: localhost:5432
- **Redis**: localhost:6379

### 2️⃣ Chạy Backend

```bash
cd backend-api

# Khôi phục dependencies
dotnet restore

# Chạy migrations (nếu có)
dotnet ef database update

# Chạy development server
dotnet watch run
```

Server sẽ chạy tại `http://localhost:5000`

### 3️⃣ Chạy Frontend

```bash
cd frontend-app

# Cài đặt dependencies
npm install

# Tạo file .env
echo "REACT_APP_API_URL=http://localhost:5000/api" > .env

# Chạy development server
npm start
```

App sẽ mở tại `http://localhost:3000`

## 📁 Chi tiết cấu trúc thư mục

### Frontend (React)
- **components/**: Các component tái sử dụng (Button, MatchCard, etc.)
- **pages/**: Các trang hoàn chỉnh (Dashboard, Booking, Profile, etc.)
- **services/**: API calls (apiService.js)
- **assets/**: Hình ảnh, icons, fonts

### Backend (.NET)
- **Controllers/**: 
  - `BookingController.cs` - API endpoints cho đặt lịch
  - `MatchmakingController.cs` - API endpoints cho tìm đối thủ
- **Models/**: 
  - `Account.cs` - Người dùng (với ELO rating)
  - `San.cs` - Sân cầu lông
- **Services/**: 
  - `PricingService.cs` - Tính giá động (theo giờ, ngày)

## 🔧 Công nghệ

| Component | Technology |
|-----------|-----------|
| Frontend | React, JavaScript/JSX |
| Backend | .NET 10, C# |
| Database | SQL Server 2022 |
| Automation | n8n |
| Cache | Redis |
| Container | Docker |

## 📊 Tính năng Chính

- ✅ Quản lý tài khoản người dùng
- ✅ Tìm kiếm đối thủ (dựa trên ELO rating)
- ✅ Đặt lịch thi đấu
- ✅ Quản lý sân cầu lông
- ✅ Định giá động theo giờ và ngày
- ✅ Hệ thống xếp hạng ELO

## 🎯 ELO Rating System

Hệ thống xếp hạng dựa trên:
- Điểm rating hiện tại
- Kết quả trận đấu
- Mức chênh lệch rating với đối thủ

## 💰 Dynamic Pricing

Giá được tính dựa trên:
- **Ngày trong tuần**: Thứ 7, Chủ nhật x1.2
- **Giờ**: 18:00-22:00 x1.3, sau 22:00 x1.5
- **Lễ/Tết**: x1.5

## 📝 Git Workflow

```bash
# Tạo branch mới
git checkout -b feature/tên-feature

# Commit
git commit -m "feat: mô tả chức năng"

# Push
git push origin feature/tên-feature

# Tạo Pull Request
```

## 🐛 Troubleshooting

### SQL Server không kết nối được
```bash
docker-compose logs mssql
docker restart badminton-db
```

### Port bị chiếm dụng
```bash
# Thay đổi port trong docker-compose.yml hoặc:
docker-compose down
```

### Dependencies lỗi
```bash
# Frontend
rm -rf node_modules package-lock.json && npm install

# Backend
dotnet clean && dotnet restore
```

## 📞 Support

Liên hệ team lead nếu gặp vấn đề.

---

**Last Updated**: 2026-04-29
