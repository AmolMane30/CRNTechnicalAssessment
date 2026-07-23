# CRN Technical Assessment

A RESTful Web API built with **ASP.NET Core 8** following **Clean Architecture** principles. The application provides secure JWT-based authentication and CRUD operations for Products and Items using Entity Framework Core and SQL Server.

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![C#](https://img.shields.io/badge/C%23-12-blue)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![JWT](https://img.shields.io/badge/Auth-JWT-green)

---

## 📌 Features

- ✅ User Registration
- ✅ User Login
- ✅ JWT Authentication & Authorization
- ✅ Product CRUD Operations
- ✅ Item CRUD Operations
- ✅ Repository Pattern
- ✅ Clean Architecture
- ✅ Entity Framework Core
- ✅ SQL Server Integration
- ✅ FluentValidation
- ✅ Global Exception Handling Middleware
- ✅ Serilog Logging
- ✅ Swagger API Documentation
- ✅ Docker Support

---

## 🏗️ Project Architecture

```
CRNTechnicalAssessment
│
├── CRNTechnicalAssessment.API
│   ├── Controllers
│   ├── Middleware
│   ├── Program.cs
│   └── appsettings.json
│
├── CRNTechnicalAssessment.Application
│   ├── DTOs
│   ├── Interfaces
│   ├── Services
│   └── Validators
│
├── CRNTechnicalAssessment.Domain
│   └── Entities
│
└── CRNTechnicalAssessment.Infrastructure
    ├── Data
    ├── Repositories
    ├── Security
    └── Configurations
```

---

## 🛠️ Technology Stack

| Technology | Used |
|------------|------|
| ASP.NET Core | .NET 8 |
| C# | ✔ |
| Entity Framework Core | ✔ |
| SQL Server | ✔ |
| JWT Authentication | ✔ |
| BCrypt Password Hashing | ✔ |
| FluentValidation | ✔ |
| Serilog | ✔ |
| Swagger/OpenAPI | ✔ |
| Docker | ✔ |

---

## 📂 Project Structure

### API Layer

- Controllers
- Middleware
- Dependency Injection
- Authentication Configuration
- Swagger Configuration

### Application Layer

- Business Logic
- DTOs
- Interfaces
- Services
- Validators

### Domain Layer

- Entity Models

### Infrastructure Layer

- Entity Framework Core
- Database Context
- Repository Implementations
- JWT Token Generation

---

## 🗄️ Database

Database: **SQL Server**

ORM: **Entity Framework Core**

Entities:

- User
- Product
- Item

---

## 🔐 Authentication

The application uses **JWT (JSON Web Token)** authentication.

### Register

```
POST /api/auth/register
```

### Login

```
POST /api/auth/login
```

After logging in, copy the generated JWT token and authorize using Swagger.

---

## 📡 API Endpoints

### Authentication

| Method | Endpoint |
|--------|----------|
| POST | `/api/auth/register` |
| POST | `/api/auth/login` |

---

### Products

| Method | Endpoint | Authorization |
|--------|----------|---------------|
| GET | `/api/products` | Public |
| GET | `/api/products/{id}` | Public |
| POST | `/api/products` | JWT Required |
| PUT | `/api/products/{id}` | JWT Required |
| DELETE | `/api/products/{id}` | JWT Required |

---

### Items

| Method | Endpoint | Authorization |
|--------|----------|---------------|
| GET | `/api/items` | Public |
| GET | `/api/items/{id}` | Public |
| POST | `/api/items` | JWT Required |
| PUT | `/api/items/{id}` | JWT Required |
| DELETE | `/api/items/{id}` | JWT Required |

---

## ✔ Validation

Validation is implemented using **FluentValidation**.

Examples:

- Product name cannot be empty
- Username is required
- Email must be valid
- Password minimum length validation

---

## ⚠ Exception Handling

Global Exception Middleware provides consistent JSON error responses.

Example response:

```json
{
  "statusCode": 500,
  "message": "User already exists."
}
```

---

## 📝 Logging

Logging is implemented using **Serilog**.

Log files are generated in:

```
Logs/
```

---

## 📖 Swagger

Swagger is enabled for interactive API testing.

Features:

- API Documentation
- JWT Authentication Support
- Interactive Request & Response Testing

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/AmolMane30/CRNTechnicalAssessment.git
```

### 2. Navigate to the Project

```bash
cd CRNTechnicalAssessment
```

### 3. Update Configuration

Open:

```
CRNTechnicalAssessment.API/appsettings.json
```

Update the following values:

```json
"ConnectionStrings": {
  "DefaultConnection": "Your SQL Server Connection String"
},

"Jwt": {
  "Key": "Your Secret Key",
  "Issuer": "CRNTechnicalAssessment",
  "Audience": "CRNTechnicalAssessment",
  "ExpiryMinutes": 60
}
```

### 4. Apply Database Migrations

Using Package Manager Console:

```powershell
Update-Database
```

Or using .NET CLI:

```bash
dotnet ef database update
```

### 5. Run the Project

```bash
dotnet run
```

---

## 🐳 Docker

### Build Docker Image

```bash
docker build -t crntechnicalassessment .
```

### Run Docker Container

```bash
docker run -d -p 8080:80 crntechnicalassessment
```

---

## 🔒 Security

- BCrypt Password Hashing
- JWT Authentication
- Authorization using `[Authorize]`
- Protected CRUD Operations

---

## 📈 Future Improvements

- Role-Based Authorization
- Refresh Tokens
- Unit Testing
- AutoMapper
- Pagination
- API Versioning

---

## 👨‍💻 Author

**Amol Mane**

- GitHub: https://github.com/amolmane30
- LinkedIn: https://www.linkedin.com/in/amolmane30/

---

## ⭐ If you found this project useful, consider giving it a star!
