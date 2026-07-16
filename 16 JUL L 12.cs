//16 jul
//L 12

//1. The Architectural Breakdown (M-V-C)
//The Model

// Models/Product.cs
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string SecretDatabaseCode { get; set; } // Internal data
}

//The View
< !--Views / Product / Index.cshtml-- >
@model MVCApp.ViewModels.ProductViewModel

<h2> @Model.Name </ h2 >
< p > Price: @Model.Price.ToString("C") </ p >

< button onclick = "alert('Item selected!')" > Select Item </ button >

    //The Controller

    // Controllers/ProductController.cs
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    // Renders the UI view page directly
    public IActionResult Index()
    {
        return View();
    }
}

//2. The View Model Layer & Manual Mapping
//The View Model Structure

// ViewModels/ProductViewModel.cs
public class ProductViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    // The 'SecretDatabaseCode' is intentionally left out for UI security
}

//Manual Mapping inside the Controller Action

public class ProductController : Controller
{
    public IActionResult Details(int id)
    {
        // 1. Fetch raw entity data from the database model layer
        Product rawProduct = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 999.99m,
            SecretDatabaseCode = "DB_CONN_102"
        };

        // 2. Perform manual mapping as explained in the session
        ProductViewModel viewModel = new ProductViewModel();
        viewModel.Name = rawProduct.Name;
        viewModel.Price = rawProduct.Price;

        // 3. Securely hand over the tailored View Model to the View template
        return View(viewModel);
    }
}

//3. The End-to-End Request Lifecycle


[HTTP Request] 
      │
      ▼
[Routing Middleware] ──► Inspects URL patterns defined in Program.cs
      │
      ▼
[Controller Factory] ──► Allocates memory &creates Controller Object via Constructor
      │
      ▼
[Filters Validation] ──► Checks user authentication, authorization roles, and security policies
      │
      ▼
[Model Binding]      ──► Fetches data, executes manual or internal map settings
      │
      ▼
[Action Invocation]  ──► Code triggers; processes logic &calls return View()
      │
      ▼
[View Engine(DOM)]  ──► Compiles C# syntax into raw browser-readable HTML
      │
      ▼
[Garbage Collection] ──► Triggers Dispose() to clear RAM cache and memory leaks

    //The View Engine Processing Role
    View Engine acts as an ongoing server translator.

    //Garbage Collection & the Dispose() Safeguard
    When the controller factory generates instances dynamically during spike traffic windows,
    local server storage cache scales out aggressively. If left unmonitored, vacant memory frames 
    get flooded with system garbage values, introducing performance bottlenecks.


    //4. Project Anatomy
    //(Static File Directory)
    This physical workspace preserves assets that must bypass standard pipeline compile paths entirely 
    (such as icon configurations, direct script components, baseline fonts, or Bootstrap themes)[cite: 2].
    This physical workspace preserves assets that must bypass standard pipeline compile paths entirely 
    (such as icon configurations, direct script components, baseline fonts, or Bootstrap themes)[cite: 2].


    //(Layout Engine Container)(Layout Engine Container)
    Houses layout definitions (like _Layout.cshtml) which function as parent shells[cite: 2]. Universal 
    components like headers and footers are declared here once, acting as structural wrappers that load 
    distinct sub-views dynamically within independent pages[cite: 2].Houses layout definitions
    (like _Layout.cshtml) which function as parent shells[cite: 2]. Universal components like headers and 
    footers are declared here once, acting as structural wrappers that load distinct sub-views dynamically 
    within independent pages[cite: 2].

//(Route Configuration)(Route Configuration)

    // Program.cs snippet configuring baseline MVC pipelines
app.UseStaticFiles(); // Necessary to authorize access to wwwroot files[cite: 2]

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Default fallback route mapping as shown by the instructor
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Defaults to HomeController -> Index()[cite: 2]// Program.cs snippet configuring baseline MVC pipelines
app.UseStaticFiles(); // Necessary to authorize access to wwwroot files[cite: 2]

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Default fallback route mapping as shown by the instructor
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Defaults to HomeController -> Index()[cite: 2]

