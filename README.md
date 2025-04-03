# Task Management System (Clean Architecture)
![image](https://github.com/user-attachments/assets/ec9c9f85-5836-4af2-9179-8978a1ee6ce3)
*(Example Clean Architecture Diagram)*

A task management system built using **Clean Architecture** principles with **ASP.NET Core**, **Entity Framework Core**, and **Domain-Driven Design (DDD)**.

## Table of Contents
- [Project Structure](#project-structure)
  - [Key Principles](#key-principles)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Running the Application](#running-the-application)
- [Testing](#testing)
- [API Endpoints](#api-endpoints)

  ---

## Project Structure
The solution follows **Clean Architecture** with 4 main layers:

```plaintext
TaskManagementSystem/
├── TaskManagementSystem.Domain/         # Entities, Enums, Exceptions
├── TaskManagementSystem.Application/    # Interfaces, Services, DTOs
├── TaskManagementSystem.Infrastructure/ # EF Core, Repositories, External Services
├── TaskManagementSystem/                # Controllers, Middleware, Startup Config
├── TaskManagementSystem.Tests/          # Unit and Integration Tests
```



### Key Principles:
- **Separation of Concerns** (SoC)
- **Dependency Inversion Principle (DIP)**
- **Testability**
- **Loose Coupling**

---

## Technologies Used
- **Backend**: ASP.NET Core 8
- **Database**: SQL Server (with Entity Framework Core)
- **ORM**: Entity Framework Core
- **Logging**: Serilog / Microsoft.Extensions.Logging
- **Testing**: xUnit + Moq + FluentAssertions
- **API Documentation**: Swagger UI
- **Dependency Injection**: Built-in .NET Core DI

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or VS Code)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/) (or Docker for SQL Server)

### Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/DarakhshahFida/webapi.git
   cd webapi
   ```
2. **Set up the database**:
    i. Update the connection string in appsettings.json.
    ii. **Run migrations**:
        Open Package Manager Console:
            ```
            add-migration "<comment>"
            update-database
            ```
   
---

## Running the Application
```
cd TaskManagementSystem
dotnet run
```

---

## Testing
```
cd TaskManagementSystem.Tests
dotnet test
```

---

## API Endpoints

### Tasks Management

| Method   | Endpoint             | Description          | Request Body |
|----------|----------------------|----------------------|--------------|
| `GET`    | `/api/task`          | Get all tasks       | -            |
| `GET`    | `/api/task/{id}`     | Get task by ID      | -            |
| `POST`   | `/api/task`          | Create new task     |```{ "title": "string", "description": "string", "dueDate": "YYYY-MM-DD", "priority": "string", "status": "string", "userId": int }``` |
| `PUT`    | `/api/task/{id}`     | Update existing task | ```{ "id": int, "title": "string", "description": "string", "dueDate": "YYYY-MM-DD", "priority": "string", "status": "string", "userId": int }``` |
| `DELETE` | `/api/task/{id}`     | Delete task         | -            |

---

### Authentication

| Method   | Endpoint               | Description        | Request Body |
|----------|------------------------|--------------------|--------------|
| `POST`   | `/api/auth/register`   | Register new user | ```{ "userName": "string", "email": "string", "password": "string" }``` |
| `POST`   | `/api/auth/login`      | User login        | ```{ "email": "string", "password": "string" }``` |
