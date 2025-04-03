# Task Management System (Clean Architecture)
A task management system built using **Clean Architecture** principles with **ASP.NET Core**, **Entity Framework Core**, and **Domain-Driven Design (DDD)**.

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
    1. Update the connection string in appsettings.json.
    2. **Run migrations**:
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

| Method   | Endpoint             | Description          |
|----------|----------------------|----------------------|
| `GET`    | `/api/task`          | Get all tasks       |
| `GET`    | `/api/task/{id}`     | Get task by ID      |
| `POST`   | `/api/task`          | Create new task     |
| `PUT`    | `/api/task/{id}`     | Update existing task |
| `DELETE` | `/api/task/{id}`     | Delete task         |

### Authentication

| Method   | Endpoint               | Description        |
|----------|------------------------|--------------------|
| `POST`   | `/api/auth/register`   | Register new user |
| `POST`   | `/api/auth/login`      | User login        |
