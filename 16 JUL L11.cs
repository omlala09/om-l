///
//LECTURE 11
// August 28,
//Defining the Interface with XML Comments:

public interface IProductService
{
    /// <summary>
    /// Fetches a product by its unique ID for sample records.
    /// </summary>
    /// <param name="id">The integer ID of the product.</param>
    /// <returns>Returns the matching product object.</returns>
    Product GetProductById(int id);
}

//Implementing the Class utilizing <inheritdoc />:

public class ProductService : IProductService
{
    // <inheritdoc />
    public Product GetProductById(int id)
    {
        // Implementation logic
        return new Product { Id = id, Name = "Sample Product" };
    }
}

//Securing Web APIs with JWT & Role-Based Authorization
//Step A: Configure appsettings.json
{
    "JWT": {
        "Key": "YourSuperSecretUnbreakableKeyOfAppropriateLength32Bytes!",
    "Issuer": "myApp",
    "Audience": "myAppUsers"
    }
}
//Step B: Install the NuGet Package
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.x

    //Step C: Configure Program.cs

    using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// 1. Get JWT Configurations
var jwtKey = builder.Configuration["JWT:Key"];
var jwtIssuer = builder.Configuration["JWT:Issuer"];
var jwtAudience = builder.Configuration["JWT:Audience"];

// 2. Register Authentication Services with JWT Bearer configurations
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddControllers();
// Optional: Configure SwaggerGen options to accept Bearer tokens (using AddSwaggerGen)

var app = builder.Build();

app.UseAuthentication(); // Must run before Authorization
app.UseAuthorization();

app.MapControllers();
app.Run();

//Step D: Create AuthController.cs

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Simple hardcoded check
        if (model.Username == "admin" && model.Password == "123")
        {
            var jwtKey = _config["JWT:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // User claims representing user identity and role
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, "Admin") // Role-based claim
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { Token = tokenString });
        }

        return Unauthorized("Invalid login credentials.");
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

//Step E: Apply Authorization to Controllers

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize] // Requires a valid JWT token for all methods in this controller
public class ProductController : ControllerBase
{
    // 1. Fully Authorized endpoint restricted to 'Admin' roles only
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetSecuredProducts()
    {
        return Ok(new[] { "Secured Laptop", "Secured Phone" });
    }

    // 2. An endpoint open to everyone regardless of JWT authorization
    [HttpGet("public-sample")]
    [AllowAnonymous]
    public IActionResult GetPublicSample()
    {
        return Ok(new[] { "Anonymous Product 1", "Anonymous Product 2" });
    }
}