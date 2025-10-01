# FinShark API 🦈

FinShark is a RESTful API built with **ASP.NET Core 9**, **Entity Framework Core**, and **SQL Server**.

This project focuses on backend development practices such as:
- Repository Pattern
- DTO mapping
- LINQ & async/await
- Model validation
- Swagger integration

---

## 🔧 Technologies

- ASP.NET Core 9
- EF Core
- SQL Server
- Swagger UI

---

## 🚀 Getting Started

1. Clone this repo
2. Update the connection string in `appsettings.json`
3. Run EF migrations: `dotnet ef database update`
4. Start the app: `dotnet watch run`
5. Visit `http://localhost:{PORT}/swagger` to test

---

## 📌 Notes

- Comments are linked to Stocks (1-to-many)
- Repository pattern is used with Dependency Injection
- Work in progress 🚧