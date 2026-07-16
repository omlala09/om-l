//LECTURE 13 
// 16/07

//1. MVC Architecture, Lifecycle, and Controller Differences

//The Lifecycle Workflow:
//A client Request is intercepted by the Route Engine, which routes it to a specific Controller.

//MVC Controller vs. Web API Controller:
//While both utilize controllers, an MVC controller typically handles UI rendering by returning Razor views
//via ActionResult (e.g., return View();).
//A Web API controller is decoupled from presentation layers, instead returning data structures along with
//standard HTTP status codes.

//Controller Return Type Differences

// 1. MVC Controller returning a Razor presentation view
using MvcSession.Models;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View(); // Searches for Index.cshtml view file
    }
}

// 2. Web API Controller returning raw data / status codes
[ApiController]
[Route("api/[controller]")]
public class ProductsApiController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = new List<string> { "Laptop", "Mouse" };
        return Ok(products); // Returns HTTP 200 OK status with JSON data
    }
}


//2. Strong Model Binding and HTML Helpers

//Syntax Case Sensitivity:
//In the view page (.cshtml), a lowercase @model Namespace.Class specifies the template type, while an
//uppercase @Model.Property evaluates and writes out that model's data

//Loosely Coupled vs. Tightly Coupled Helpers:
//HTML helpers like @Html.TextBox are loosely coupled (relying on magic strings).
//Tightly coupled / strongly typed helpers like @Html.TextBoxFor utilize lambda expressions (m => m.Property),\
//catching structural errors at compile-time rather than runtime

//Model & Strongly Typed View binding

namespace MvcSession.Models
{
    public class Product
    {
        public int Id { get; set; }
        [cite: 3]
        public string Name { get; set; }
        [cite: 3]
    }
}

//The Strongly Typed View

@model MvcSession.Models.Product

< !--Displaying model data using uppercase @Model -->
< h2 > Product Details: @Model.Name </ h2 >

< div >
    < !--Tightly coupled HTML Helpers using Lambda Expressions -->
    @Html.LabelFor(m => m.Name)
    @Html.TextBoxFor(m => m.Name)
</ div >


//3. Passing Data: ViewData, ViewBag, and TempData

//Utilizing State Management Containers

public class ProductsController : Controller
{
    public IActionResult Details()
    {
        // ViewData uses dictionary syntax
        ViewData["Message"] = "Loading data via dictionary format..."; [cite: 3]
        
        // ViewBag uses cleaner dynamic object properties
        ViewBag.Vikas = "Dynamic data wrapper value."; [cite: 3]
        
        return View();
    }

    public IActionResult ProcessOrder()
    {
        // TempData survives redirect boundaries
        TempData["Alert"] = "Order processed successfully!";

        // Redirecting from one method to another action
        return RedirectToAction("Index"); [cite: 3]
    }
}

//Razor UI View:

< h3 > @ViewData["Message"] </ h3 > < !--Reading from ViewData dictionary -->
< p > @ViewBag.Vikas </ p >         < !--Accessing dynamic property natively -->

//4.Master Layout Layouts and Reusable Components (Partial Views)

//Centralized Layout (_Layout.cshtml): Contains the universal application header, scripts, styles, and
//structural placeholders. The @RenderBody() method acts as a dynamic content canvas where context-specific
//pages inject themselves[cite: 3].  

//Partial Views: Small, encapsulated component templates named with an
//underscore prefix (e.g., _ProductCard.cshtml)[cite: 3]. They exist to avoid duplicating UI components and
//can accept sub-model objects to render themselves multiple times seamlessly[cite: 3].Centralized Layout
//(_Layout.cshtml): Contains the universal application header, scripts, styles, and structural placeholders.
//The @RenderBody() method acts as a dynamic content canvas where context-specific pages inject themselves
//[cite: 3].  Partial Views: Small, encapsulated component templates named with an underscore prefix (e.g.,
//_ProductCard.cshtml)[cite: 3]. They exist to avoid duplicating UI components and can accept sub-model 
//objects to render themselves multiple times seamlessly[cite: 3].

//Calling a Component Element (Partial View)


    <!-- Inside index.cshtml page, rendering a reusable product component layout -->
<div class= "product-grid" >
    @foreach(var prod in Model.ProductList)
    {
    // Renders the partial view component and passes sub-model context
    @Html.Partial("_ProductCard", prod)
    }
</ div >

//5.JavaScript AJAX Implementation and External API Consumption

AJAX View Processing: Using client scripts inside layout template markers (@section Scripts) allows custom 
    asynchronous processing without hard refreshing the main document framework[cite: 3].

//Backend HTTP API Consumption: When connecting to downstream APIs inside an MVC action, a separate HttpClient
//    is initialized[cite: 3]. The speaker stresses applying appropriate asynchronous pattern practices 
//    (await client.GetAsync(...)) to safeguard thread processes from blocking states and system application 
//    deadlocks[cite: 3].AJAX View Processing: Using client scripts inside layout template markers
//    (@section Scripts) allows custom asynchronous processing without hard refreshing the main document
//    framework[cite: 3].

//Backend HTTP API Consumption: When connecting to downstream APIs inside an MVC action, a separate HttpClient
//    is initialized[cite: 3]. The speaker stresses applying appropriate asynchronous pattern practices 
//    (await client.GetAsync(...)) to safeguard thread processes from blocking states and system application 
//    deadlocks[cite: 3].


//Combined API Calling and Front-End AJAX Retrieval
//Controller Code calling an External Endpoint:

    public async Task<IActionResult> FetchExternalProducts()
{
    using (var client = new HttpClient())
    {
        // Non-blocking asynchronous query invocation to retrieve external data[cite: 3]
        var response = await client.GetAsync("https://api.hostedservices.com/v1/products");[cite: 3]
        
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            return Json(data);
        }
    }
    return BadRequest();
}public async Task<IActionResult> FetchExternalProducts()
{
    using (var client = new HttpClient())
    {
        // Non-blocking asynchronous query invocation to retrieve external data[cite: 3]
        var response = await client.GetAsync("https://api.hostedservices.com/v1/products");[cite: 3]
        
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            return Json(data);
        }
    }
    return BadRequest();
}

//Razor Page UI Component executing AJAX Processing (Index.cshtml)

@section Scripts
{
    <script>
        $(document).ready(function () {
            // Asynchronously queries the target MVC action route safely[cite: 3]
            $.get("/Products/FetchExternalProducts", function(data) {
            console.log("Asynchronous payload retrieved successfully!"); [cite: 3]
                // Dynamic front-end rendering or data binding logic runs here[cite: 3]
            });
    });
    </script>
}






