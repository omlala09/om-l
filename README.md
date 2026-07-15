# DTOs, AutoMapper, Exception Middleware & Logging Demo (ASP.NET Core)

Companion code for the lecture on DTOs, AutoMapper, exception handling, custom middleware, and logging.

## Concepts covered

### 1. Why DTOs?
Returning the EF Core model directly exposes your entire table structure - including columns like `Id` you may not want a client to see (e.g. auto-increment PKs, GUIDs, or sensitive columns like `Salary`). A DTO is a plain class that only carries what should cross the API boundary.

| | Model | DTO |
|---|---|---|
| Registered in DbContext | Yes (`DbSet<T>`) | No |
| Represents | A table | Whatever shape the API needs |
| Properties | Match the table exactly | Can be fewer, renamed, or reshaped |

### 2. AutoMapper
```csharp
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
```
- `CreateMap<TSource, TDest>()` maps properties with matching names automatically.
- `.ReverseMap()` also allows the opposite direction (`ProductDTO -> Product`).
- Register once in `Program.cs`: `builder.Services.AddAutoMapper(typeof(Program));`
- Inject `IMapper` into any controller and call `_mapper.Map<ProductDTO>(product)`.

### 3. Exceptions vs compile-time errors
Compile-time errors are caught before the app runs. Exceptions happen at runtime - e.g. `NullReferenceException`. The `Exception` object carries:
- `Message` - what went wrong
- `InnerException` - the underlying cause, if any
- `StackTrace` - exactly where in the call chain it happened
- `Data` - a dictionary for extra context

### 4. Custom exception-handling middleware
Instead of wrapping every action in `try/catch`, one middleware class sits in the pipeline and catches everything downstream:

```csharp
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public async Task InvokeAsync(HttpContext context)
    {
        try { await _next(context); }
        catch (Exception ex) { /* log it, write a clean 500 response */ }
    }
}
```
Registered in `Program.cs` with `app.UseMiddleware<ExceptionMiddleware>();` - placed early in the pipeline so it wraps everything after it.

### 5. Logging with `ILogger<T>`
```csharp
_logger.LogInformation("...");
_logger.LogWarning("...");
_logger.LogError(ex, "...");
_logger.LogCritical("...");
_logger.LogDebug("...");
```
Each level shows up labelled accordingly in the console/output window, so you can filter by severity.

## Worked example: `Employee`

`EmployeeController` reapplies the same pattern independently:
- `EmployeeDTO` hides `Salary` the same way `ProductDTO` hides `Id`
- Combines `ILogger` calls with a local `try/catch` for one specific action, while the global `ExceptionMiddleware` still catches anything unexpected elsewhere
- `POST api/employee` demonstrates `ReverseMap()` going DTO → entity

Try extending this yourself:
- Add a `SalaryDTO` used only by an admin-only endpoint that *does* expose salary, to see how you'd have two different DTOs for the same entity depending on the caller's permissions.
- Trigger `GET api/product/broken` and watch the console log an `Error`-level message while the client still gets a clean JSON 500 instead of a raw stack trace.

## Project structure

```
DtoMapperMiddlewareDemo/
├── Models/          Product.cs, Employee.cs
├── DTOs/            ProductDTO.cs, EmployeeDTO.cs
├── Mapping/         MappingProfile.cs
├── Middleware/       ExceptionMiddleware.cs
├── Data/            AppDbContext.cs
├── Controllers/     ProductController.cs, EmployeeController.cs
├── Program.cs
└── appsettings.json
```

## Running it locally

```bash
cd DtoMapperMiddlewareDemo
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```
Open `/swagger`, try `GET /api/product`, `GET /api/employee`, and `GET /api/product/broken` to see the middleware catch the deliberate exception.

## Pushing to GitHub

```bash
git init && git add . && git commit -m "DTOs, AutoMapper, exception middleware, logging demo"
git branch -M main
git remote add origin <your-repo-url>
git push -u origin main
```

## Note

Written and reviewed carefully but not compiled in this environment (no .NET SDK available here). Run `dotnet build` locally and resolve any environment-specific issues before relying on it.
