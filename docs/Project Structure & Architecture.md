# Manzili – Project Structure & Architecture

## Overview
The Manzili project is built with **ASP.NET Core 8 MVC** and follows a layered structure to ensure clean separation of concerns, scalability, and maintainability.  
The architecture enforces **strict rules**: Controllers may only communicate with Services, and Services may only communicate with Repositories via defined Interfaces.  

## Folder Structure


- **Controllers/** → Handle HTTP requests, delegate to Services  
- **Models/** → Domain entities (mapped with EF Core)  
- **ViewModels/** → Data transfer objects for Views  
- **Views/** → Razor Views (UI) + custom CSS in `wwwroot/css`  
- **Services/** → Business logic layer (`IService` + implementation)  
- **Repositories/** → Data access layer (`IRepository` + implementation)  
- **Helpers/** → Utility classes (optional)  
- **Middlewares/** → Custom middlewares (optional)  
- **Migrations/** → EF Core migrations  
- **wwwroot/** → Static files (CSS, JS, images)  
- **Program.cs** → App entry point  
- **appsettings.json** → App configuration

---

## Responsibilities by Layer

### Controllers
- Entry point for requests (HTTP GET/POST).
- No business logic.
- Call corresponding Service methods.
- Return Razor Views or JSON responses.

### Models
- Represent database entities.
- Used by EF Core for persistence.
- Contain only properties (no business logic).

### ViewModels
- Shape data for the Views.
- Prevent exposing database entities directly.
- Example: `ProductViewModel`, `ServiceDetailsViewModel`.

### Services
- Contain business rules and workflows.
- Depend on Repository interfaces.
- Example:  
  - `IOrderService` / `OrderService`  
  - `IUserService` / `UserService`  

### Repositories
- Encapsulate EF Core queries and CRUD operations.
- Expose interfaces for Services.  
- Example:  
  - `IRepository<T>` (generic)  
  - `IUserRepository`, `IOrderRepository` (specific)  

### Helpers <span style="color:blue">(Optional)
- Utility classes like `DateHelper`, `StringFormatter`.  
- Cross-cutting logic not tied to business rules.

### Middlewares <span style="color:blue">(Optional)
- Centralized request/response processing.  
- Examples: global error handler, request logging.

---

## Dependency Rules
- **Controllers → Services → Repositories**  
- **Services cannot talk to Controllers or Views.**  
- **Repositories cannot be called directly from Controllers.**  
- **Models are shared across Repositories & Services.**  
- **ViewModels are used only for Controller ↔ View communication.**

---

## Technologies & Standards
- **Framework**: ASP.NET Core 8 MVC  
- **Database ORM**: Entity Framework Core  
- **Database**: SQL Server 
- **Styling**: Custom CSS in `wwwroot/css`  
- **Logging**: (future decision, e.g., Serilog or built-in logger)  
- **Unit Testing**: (future decision, e.g., xUnit + Moq)  

---

## Future-Proofing
- Analytics features coded, external marketing integrations delayed until future phase.  
- Small Business Owners’ collaboration/visibility → planned for future modules.  
- Middleware and Helpers will evolve as project scales.  

> **Note:**  
> This architecture choice (**folder-based management**) was selected because the project is currently an **MVP version**.