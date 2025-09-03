# FullStackRestaurant API

## Overview
**FullStackRestaurant** is a REST API built with **ASP.NET Core 8** and **Entity Framework Core**.  
It provides functionality for managing a restaurant, including:

- Manage **Tables** (CRUD)
- Manage **Customers** (CRUD)
- Manage **Bookings** (with availability checks)
- Manage **Menu items** (CRUD)
- **Admin authentication** with JWT
- List **available tables** for a given date, time, and number of guests

A booking automatically blocks a table for **2 hours** from the start time.

---

## Tech Stack
- ASP.NET Core 8 (Minimal API / Controllers)
- Entity Framework Core (Code-First, SQLite/SQL Server)
- JWT Authentication
- Swagger / OpenAPI for API documentation

---

## Setup & Installation

### 1. Clone the repo
```bash
git clone https://github.com/onni82/FullStackRestaurant.git
cd FullStackRestaurant
```

### 2. Configure environment variables
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

### 3. Run database migrations
```bash
dotnet ef database update
```

### 4. Start the API
```bash
dotnet run
```

The API will run at:
```
https://localhost:7232
http://localhost:5024
```

---

## Authentication
Admins can log in using:
```http
POST /api/Auth/login
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

Protected endpoints (Bookings, Customers, MenuItems, Tables) require a valid token.

---

## API Endpoints

### Authentication
- `POST /api/Auth/login` → Login and receive JWT

### Bookings
- `GET /api/Bookings` → List all bookings
- `POST /api/Bookings` → Create a booking (checks availability)
- `GET /api/Bookings/{id}` → Get booking by ID
- `DELETE /api/Bookings/{id}` → Cancel a booking
- `GET /api/Bookings/available-tables` → Find available tables // commented out

### Customers
- `GET /api/Customers` → List all customers
- `POST /api/Customers` → Create a customer
- `GET /api/Customers/{id}` → Get customer by ID
- `PUT /api/Customers/{id}` → Update a customer
- `DELETE /api/Customers/{id}` → Delete a customer

### MenuItems
- `GET /api/MenuItems` → List all dishes
- `POST /api/MenuItems` → Add a new dish
- `GET /api/MenuItems/{id}` → Get dish by ID
- `PUT /api/MenuItems/{id}` → Update a dish
- `DELETE /api/MenuItems/{id}` → Delete a dish

### Tables
- `GET /api/Tables` → List all tables
- `POST /api/Tables` → Create a table
- `GET /api/Tables/{id}` → Get table by ID
- `PUT /api/Tables/{id}` → Update a table
- `DELETE /api/Tables/{id}` → Delete a table
- `GET /api/Tables/available` → Find available tables

---

## Development Notes
- Default JWT secret is:
  `"dev_only_change_me_please_1234567890"`
  **Change this in production via env var `Jwt__Key`**
