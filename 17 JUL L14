// LECTURE 14  
//2 SEP

//ASP.NET MVC / Core — Revision Session Notes
//Topics covered: View Engines, Layouts, Partial Views, Validation, Forms, Authorization
//, Bundling/Minification, File I/O, and Unit Testing (next session).

//1. View Engine — How C# Becomes HTML
//A browser only understands HTML/CSS/JS — it has no idea what @Model.Name means.
//The View Engine is the translator that converts your Razor/C# code into pure HTML
//before it's sent to the browser.
//ASPX (old engine) → used <% %> blocks, strongly coupled to controls,
//no auto-protection against XSS.
//Razor (current engine) → uses @, cleaner syntax, faster (integrated pipeline),
//and auto-encodes output to prevent Cross-Site Scripting by default.
//html
<!-- Old ASPX way -->
<%= Model.Name %>

<!-- Modern Razor way -->
@Model.Name

@foreach (var item in Model.Products)
{
    <div>@item.Name</div>
}


//2. Layout Page (_Layout.cshtml) — The Master Template
//Instead of repeating the navbar/header/footer on every single page, one shared layout wraps all of them.
html<!DOCTYPE html>
<html>
<head>
    <title>@ViewData["Title"]</title>
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    <nav>Home | Products | Contact</nav>

    <div class="container">
        @RenderBody()   <!-- individual page content plugs in here -->
    </div>

    <script src="~/js/site.js"></script>
</body>
</html>

//Every page just does:

csharp@{ Layout = "~/Views/Shared/_Layout.cshtml"; }
<h2>Product Details</h2>

//3. Partial Views — Reusable UI Chunks
//If a piece of UI (like a "Product Header") appears on multiple pages, don't
//copy-paste it — make it a partial view and call it wherever needed.
//csharp
// Call synchronously
@Html.Partial("_ProductHeader")

// Call asynchronously (preferred — runs on its own thread)
@await Html.PartialAsync("_ProductHeader", Model)

//Example use case: Product page has a shared header, but different tabs (History,
//    Reviews, Cart) below it — each tab is its own partial view, so only the changing 
//    part re-renders.


//4. Model Validation (Data Annotations)
//Instead of writing manual if checks, decorate your model properties directly:
//csharpusing System.ComponentModel.DataAnnotations;

public class Employee
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
    public int Age { get; set; }
}

//Check it server-side in the controller:
//csharp[HttpPost]

public IActionResult Save(Employee model)
{
    if (!ModelState.IsValid)
        return View(model);   // sends errors back to the view

    // save to database
    return RedirectToAction("Index");
}

//This gives you both layers of protection: HTML5 required on the front end,
//and ModelState.IsValid as the real gatekeeper on the server.

//5. Strongly-Typed Forms (HTML Helpers)
//Html.BeginForm() binds your form directly to a controller action — no JavaScript 
//    wiring needed.
//csharp
    @using (Html.BeginForm("Save", "Employee", FormMethod.Post))
{
    @Html.LabelFor(m => m.Name)
    @Html.TextBoxFor(m => m.Name)
    @Html.ValidationMessageFor(m => m.Name)

    <button type="submit">Submit</button>
}

//This is equivalent to a plain <form method="post">, but the helper wires up the
//route (action/controller) automatically and keeps everything strongly typed to your
//model.

//6. Role-Based Access Control (RBAC)
//Restrict a page or entire controller to specific roles:

csharp[Authorize(Roles = "Admin")]
public IActionResult Index()
{
    return View();
}

// Multiple roles allowed
[Authorize(Roles = "Admin,HR")]
public class ProductController : Controller { }

//Anyone not in the listed role(s) gets an "unauthorized" response instead of the page.

//7. Bundling & Minification (Performance)

//Bundling — combines multiple CSS/JS files into one file → fewer HTTP requests.
//Minification — strips whitespace/comments from that file → smaller download size.

csharppublic class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            "~/Scripts/jquery.js",
            "~/Scripts/app.js"));

        bundles.Add(new StyleBundle("~/bundles/css").Include(
            "~/Content/site.css"));
    }
}
//Result: faster page loads, less network overhead.

//8. File Upload & Download (System.IO)
//Upload:
//csharp
    public class FileController : Controller
{
    private readonly string _uploadPath =
        Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty.");

        if (!Directory.Exists(_uploadPath))
            Directory.CreateDirectory(_uploadPath);

        var fullPath = Path.Combine(_uploadPath, file.FileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok("Upload successful.");
    }
}
//Download:
//csharp[HttpGet]
public IActionResult Download(string fileName)
{
    var fullPath = Path.Combine(_uploadPath, fileName);

    if (!System.IO.File.Exists(fullPath))
        return NotFound("File not found.");

    byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
    return File(fileBytes, "application/octet-stream", fileName);
}
//Flow: IFormFile (incoming file) → Path.Combine (build the save path) →
//FileStream (write it) → File.ReadAllBytes (read it back for download).

//9. Unit Testing (next session's topic)
//Instead of manually re-testing every feature after each change, you write automated
//test cases once and re-run them anytime.
//csharp[TestMethod]
public void TestEmployeeName()
{
    var e = new Employee();
    e.Name = "Om";

    Assert.AreEqual("Om", e.Name);
}
  
