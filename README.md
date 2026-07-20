# om-l — C# / ASP.NET Core Training Repository

Hands-on code, examples, and lecture notes from a C# and ASP.NET Core training programme (JUNE -20 JULY). This repository is a personal learning log covering everything from core C# fundamentals through to a secured, tested ASP.NET Core Web API.

## Contents

| File | Covers |
|---|---|
| `Program.cs` | Minimal hosting model entry point (`WebApplication.CreateBuilder`, middleware pipeline, controller mapping) |
| `sessioncontroller.cs` | Working `SessionController` — GET/POST CRUD-style API over an in-memory list |
| `07 j ex.cs` | Partial classes; Generics (`Holder<T>`, `Repository<T>`, constraints, generic methods) |
| `08 july.cs` | OOP fundamentals — Encapsulation, Inheritance, Polymorphism, Abstraction |
| `14 july re.cs` | Collections (`List`, `Dictionary`, `HashSet`, `Stack`), Async/Await, LINQ |
| `L 5  09 JULY.cs` | Abstraction via `abstract class` vs `interface` |
| `L6 09 july` | Minimal working Web API (`ProductController`) |
| `16 JUL L11.cs` | API design with XML docs; JWT authentication & role-based authorization |
| `16 JUL L 12.cs` | MVC architecture, View Models, request lifecycle |
| `L 13` | MVC vs Web API controllers, `ViewData`/`ViewBag`/`TempData`, HTML helpers |
| `17 JUL L14` | Razor view engine, layouts, partial views, validation, RBAC, file I/O |
| `L 16 20 JUL.cs` | Consolidated Web API reference (DI, full CRUD controller, `appsettings.json`) |
| `L 10` | DTOs, AutoMapper, custom exception middleware, structured logging |
| `L15.cs` | Unit testing — xUnit, Moq, Arrange-Act-Assert, worked examples |
| `API Session` / `API SESSION.CSPROJ` / `17 j.csproj` | Project files (.NET 10, ASP.NET Core Web API) |
| `08 j 2.slnx` | Visual Studio solution file |
| `L9.zip` | Archived supplementary material |

## Topics Covered

- **C# Fundamentals** — classes, partial classes, OOP (encapsulation, inheritance, polymorphism, abstraction), generics, collections, async/await, LINQ
- **ASP.NET Core Web APIs** — minimal hosting model, dependency injection, middleware, routing, CRUD controllers, Swagger
- **MVC Architecture** — Razor views, layouts, partial views, model validation, ViewModels
- **Security** — JWT authentication, Role-Based Access Control (RBAC)
- **Clean Architecture** — DTOs, AutoMapper, custom exception middleware, logging
- **Unit Testing** — xUnit, Moq, test naming conventions, Arrange-Act-Assert

## Tech Stack

- C# / .NET 10
- ASP.NET Core Web API & MVC
- Entity Framework Core
- JWT Bearer Authentication
- AutoMapper
- xUnit + Moq

## Running the API project

```bash
dotnet restore
dotnet build
dotnet run
```
Then open `/swagger` to explore the available endpoints.

## Notes

This is a running personal notes/practice repository built alongside a training programme, not a single production application — files are organised by lecture/date rather than by folder structure.
