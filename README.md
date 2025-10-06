
# BorsaPort API 📈

BorsaPort is a secure, scalable RESTful API built with ASP.NET Core 9 and Entity Framework Core.  
It allows users to register, authenticate, view and manage their stock portfolios.

---

## 🎯 Features

- 🔐 **JWT Authentication** (Login, Register, Token-based access)
- 👥 **User Identity & Role Management** via ASP.NET Identity
- 💼 **Stock Management** (CRUD operations)
- 📊 **User Portfolio Management** (Many-to-Many: User ↔ Stocks)
- 📚 **DTO Mapping** with clean separation of concerns
- 🧼 **Model Validation** using Data Annotations
- 🚀 **Repository Pattern** with Dependency Injection
- 🧪 **Swagger UI** for testing and documentation

---

## 🔧 Tech Stack

- **ASP.NET Core 9**
- **Entity Framework Core**
- **SQL Server**
- **ASP.NET Identity**
- **Swagger UI**

---

## 🔐 Authentication

This project uses **JWT (JSON Web Token)** for secure authentication.

- On successful login/register, a token is issued
- Token must be passed in the `Authorization` header
- All protected routes require valid JWT

```
Authorization: Bearer <your_token_here>
```

---

## 🗂️ Project Structure

```
📦 BorsaPort.API
 ┣ 📁 Controllers
 ┣ 📁 Models
 ┣ 📁 DTOs
 ┣ 📁 Interfaces
 ┣ 📁 Repositories
 ┣ 📁 Extensions
 ┣ 📁 Data (DbContext & Migrations)
 ┗ 📄 Program.cs / Startup.cs
```

---

## 🚀 Getting Started

1. **Clone the Repository**
```bash
git clone https://github.com/yourusername/BorsaPortApi.git
cd BorsaPortApi
```

2. **Update Database Connection**  
Update your SQL Server connection string in `appsettings.json`.

3. **Run EF Migrations**
```bash
dotnet ef database update
```

4. **Start the App**
```bash
dotnet watch run
```

5. **Access Swagger**
```bash
http://localhost:{PORT}/swagger
```

---

## 📌 Key Endpoints

| Endpoint               | Method | Auth Required | Description                   |
|------------------------|--------|----------------|-------------------------------|
| `/api/account/register`| POST   | ❌             | Register a new user           |
| `/api/account/login`   | POST   | ❌             | Login and get JWT token       |
| `/api/stocks`          | GET    | ✅             | Get all available stocks      |
| `/api/stocks/{id}`     | GET    | ✅             | Get details of a single stock |
| `/api/stocks`          | POST   | ✅ (Admin)     | Add a new stock               |
| `/api/portfolio`       | GET    | ✅             | Get current user's portfolio  |

---

## 🛠 Example Portfolio Logic

- Each AppUser can have multiple stocks in their Portfolio
- Each Stock can belong to multiple users
- Portfolio is a join table: (AppUserId + StockId)
- User's portfolio can only be accessed when logged in

---

## 🧠 Concepts Covered

- Many-to-Many Relationship (EF Core)
- JWT Bearer Authentication
- Claims-based Identity Extensions
- DTOs for decoupling models from responses
- Role-based access (User / Admin)
- Repository Pattern with async methods

---

## 📌 Notes

- All database changes are tracked via EF Core Migrations
- You can manually seed users or portfolios in SQL Server
- This is a backend-only project. Frontend will be developed separately using React & TypeScript.

---

## 🚧 Work In Progress

- ✅ Backend API: Complete  
- 🛠️ Frontend: In development (React/TSX)  
- 📡 Data Source: Will be updated to integrate Borsa Istanbul (BIST) data or static fallback  
