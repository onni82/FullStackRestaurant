# 🍽️ FullStackRestaurant API

## 📌 Overview
**FullStackRestaurant** is a REST API built with **ASP.NET Core 8** and **Entity Framework Core**.  
It provides functionality for managing a restaurant, including:

- ✅ Manage **Tables** (CRUD)  
- ✅ Manage **Customers** (CRUD)  
- ✅ Manage **Bookings** (with availability checks)  
- ✅ Manage **Menu items** (CRUD)  
- ✅ **Admin authentication** with JWT  
- ✅ List **available tables** for a given date, time, and number of guests  

A booking automatically blocks a table for **2 hours** from the start time.  
Example: A booking at `18:00` blocks the table from `16:01` until `19:59`.  

---

## 🚀 Tech Stack
- ASP.NET Core 8 (Minimal API / Controllers)  
- Entity Framework Core (Code-First, SQLite/SQL Server)  
- JWT Authentication  
- Swagger / OpenAPI for API documentation  

---

## ⚙️ Setup & Installation

### 1️⃣ Clone the repo
```bash
git clone https://github.com/yourusername/FullStackRestaurant.git
cd FullStackRestaurant
```

### 2️⃣ Configure environment variables
You must provide a **JWT secret key** via environment variables.  
ASP.NET Core uses `__` (double underscore) for nested keys.

For example:

**Windows (PowerShell):**
```powershell
$env:Jwt__Key="your_super_secret_key_here"
```

**Linux / macOS:**
```bash
export Jwt__Key="your_super_secret_key_here"
```

Or add to your `.env` file:
```env
Jwt__Key=your_super_secret_key_here
ASPNETCORE_ENVIRONMENT=Development
```

### 3️⃣ Run database migrations
```bash
dotnet ef database update
```

### 4️⃣ Start the API
```bash
dotnet run
```

The API will run at:
```
https://localhost:5001
http://localhost:5000
```

---

## 🔑 Authentication
Admins can log in using:
```http
POST /api/admins/login
```
with JSON body:
```json
{
  "username": "admin",
  "password": "password123"
}
```

If successful, you’ll receive a **JWT token**:
```json
{
  "token": "eyJhbGciOiJIUzI1..."
}
```

Use this token in **Authorization headers**:
```
Authorization: Bearer <your_token>
```

Protected endpoints (Tables, Bookings, Customers, Menu) require a valid token.  

---

## 📖 API Endpoints

### 🔐 Authentication
- `POST /api/admins/login` → Login and receive JWT  

### 👤 Customers
- `GET /api/customers` → List all customers  
- `GET /api/customers/{id}` → Get customer by ID  
- `POST /api/customers` → Create a customer  
- `PUT /api/customers/{id}` → Update a customer  
- `DELETE /api/customers/{id}` → Delete a customer  

### 🍽️ Tables
- `GET /api/tables` → List all tables  
- `GET /api/tables/{id}` → Get table by ID  
- `POST /api/tables` → Create a table  
- `PUT /api/tables/{id}` → Update a table  
- `DELETE /api/tables/{id}` → Delete a table  

### 📅 Bookings
- `GET /api/bookings` → List all bookings  
- `GET /api/bookings/{id}` → Get booking by ID  
- `POST /api/bookings` → Create a booking (checks availability)  
- `DELETE /api/bookings/{id}` → Cancel a booking  
- `GET /api/bookings/available?date=2025-08-01&time=18:00&guests=4` → Find available tables  

### 🍕 Menu
- `GET /api/menu` → List all dishes  
- `GET /api/menu/{id}` → Get dish by ID  
- `POST /api/menu` → Add a new dish  
- `PUT /api/menu/{id}` → Update a dish  
- `DELETE /api/menu/{id}` → Delete a dish  

---

## 🛠️ Development Notes
- Default JWT secret is:  
  `"dev_only_change_me_please_1234567890"`  
  ⚠️ **Change this in production via env var `Jwt__Key`**
- Swagger UI available at:  
  ```
  https://localhost:5001/swagger
  ```
- DB provider is **SQLite** by default, but you can switch to **SQL Server** in `appsettings.json`.

---

## 📌 Roadmap
- [ ] Add unit & integration tests  
- [ ] Add role-based authorization (e.g., Manager vs Admin)  
- [ ] Add support for reservations longer than 2 hours  

---

## 📝 License
MIT License. Free to use and modify.  
