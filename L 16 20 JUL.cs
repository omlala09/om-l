ASP.NET CORE WEB API - TOPICS COVERED & CODE REFERENCE
=========================================================

1. TOPICS COVERED
------------------
1. ASP.NET vs ASP.NET Core
2. .NET versions (LTS/STS) & Target Frameworks
3. Visual Studio project templates
4. What a Web API is
5. React + ASP.NET Core combo
6. Native AOT (Ahead-of-Time compilation)
7. Authentication options (None / Microsoft Identity / Windows Auth)
8. Docker & containers (introduction)
9. ASP.NET Core project structure (Connected Services, Dependencies, Analyzers, Frameworks, Packages)
10. launchSettings.json
11. appsettings.json & configuration/secrets handling
12. Program.cs (old Startup.cs vs modern minimal hosting model)
13. WebApplication Builder pattern
14. Dependency Injection (Singleton / Scoped / Transient)
15. Middleware pipeline
16. Controllers & Action Methods
17. Routing & URL structure
18. Method Overloading (signature conflicts)
19. HTTP verbs - GET / POST / PUT / DELETE (CRUD)
20. HTTP Status Codes (2xx-5xx)
21. Models
22. Swagger / Swashbuckle vs Postman
23. .http files (in-IDE API testing)
24. Logging (ILogger)


2. CODE REFERENCE
------------------

2.1 Program.cs -- Modern Minimal Hosting Model
-----------------------------------------------
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register services (Dependency Injection)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton<IMyService, MyService>();
// builder.Services.AddScoped<IMyService, MyService>();
// builder.Services.AddTransient<IMyService, MyService>();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


2.2 Model -- Student.cs
-------------------------
namespace StudentApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Branch { get; set; } = "";
    }
}


2.3 Controller -- StudentsController.cs (Full CRUD)
------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> Students = new()
        {
            new Student { Id = 1, Name = "Om",   Branch = "CSE AI & ML" },
            new Student { Id = 2, Name = "Aman", Branch = "CSE" }
        };

        // GET api/students
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Students);
        }

        // GET api/students/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Add(Student student)
        {
            Students.Add(student);
            return Ok(student);
        }

        // PUT api/students/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student updatedStudent)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            student.Name = updatedStudent.Name;
            student.Branch = updatedStudent.Branch;
            return Ok(student);
        }

        // DELETE api/students/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            Students.Remove(student);
            return NoContent();
        }
    }
}


2.4 Original In-Class Example -- WeatherForecast
---------------------------------------------------

WeatherForecast.cs
-------------------
namespace APISession
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
}

WeatherForecastController.cs
------------------------------
using Microsoft.AspNetCore.Mvc;

namespace APISession.Controllers
{
    [ApiController]
    [Route("[controller]")]      // -> /weatherforecast
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // GET /weatherforecast
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET /weatherforecast/{id}
        [HttpGet("{id}")]
        public WeatherForecast Get(int id)
        {
            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 25,
                Summary = "Mild"
            };
        }
    }
}


2.5 Dependency Injection Example
-----------------------------------
public interface IMessageService
{
    string GetMessage();
}

public class MessageService : IMessageService
{
    public string GetMessage() => "Hello from Service";
}

// Registration in Program.cs
builder.Services.AddScoped<IMessageService, MessageService>();

// Constructor injection in a controller
[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public string Get() => _messageService.GetMessage();
}


2.6 appsettings.json
-----------------------
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=StudentDB;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*"
}