
//LECTURE 15 
// 03/09

Unit Testing — Complete Training Notes

//1. What is Unit Testing?
//Definition: Testing the smallest testable part of an application (usually a method/function) to verify it works correctly — instead of testing the whole
//application at once.
//Application
//├── Login Module
//│     ├── Login()
//│     ├── Logout()
//├── Product Module
//│     ├── AddProduct()
//│     ├── DeleteProduct()
//Each method gets tested separately, in isolation.
//Why do we need it?
//Take a login API with scenarios like:

//Correct username +password → Login success
//Wrong password → Unauthorized
//Username not found → "User not found"
//Username is null → Bad request
//Password is null → Bad request

//As a developer, you already know these rules. Testing them manually every time you touch the code is:

//Time - consuming
//Error - prone
//Not repeatable
//Not provable — "I tested it on my end" is verbal, and verbal proof doesn't count. If something breaks in production and there's no documented test,
//the developer is the first one questioned.

//Unit tests solve this by turning that manual, verbal testing into automated, documented, repeatable code.
//Benefits:
//✔ Catches bugs early ✔ Saves time on repeated manual checks ✔ Makes code reliable ✔ Prevents production issues ✔ Doubles as documentation of expected
//behavior

//2. What is a "Unit"?
//A unit = the smallest independently testable piece of code — a method or function, not an entire class.
//csharp
    public int Add(int a, int b)
{
    return a + b;
}
//Add() here is one unit. A class might have 10 methods → that's potentially 10+ separate unit tests, not one big test for the whole class.

//3. The Goal: Test Logic Without Running the Whole App
//Without unit testing, to test one small piece of logic (say CalculateSalary()), you'd have to:
//Run project → Log in → Navigate pages → Click through UI → Finally reach the salary check
//With unit testing:
//Run Test → Directly call CalculateSalary() → Done
//Much faster — and it doesn't need a live database or a fully running app.

//4. Mocking — Skipping Real External Calls
//Real apps depend on external things: databases, email services, SMS gateways (Twilio), Outlook, payment APIs. Calling these for real during every
//test run would be slow and unreliable (network issues, rate limits, etc.).
//Mocking = creating a fake stand-in for that dependency that behaves like the real thing, without actually calling it. The library used in .NET for this
//is Moq.
//csharp
    var mockService = new Mock<IEmployeeService>();

mockService.Setup(x => x.GetEmployee())
           .Returns(employee);
//This tells the test: "whenever GetEmployee() is called, just return this fake employee object — don't touch the real database."
//Benefits: no real DB / API calls needed → tests run faster and stay isolated to just your logic.

//5. The Three Testing Frameworks
//csharp
    // MSTest
[TestClass]
public class LoginTests
{
    [TestMethod]
    public void Login_Test() { }
}

// NUnit
[TestFixture]
public class LoginTests
{
    [Test]
    public void Login_Test() { }
}

// xUnit
public class LoginTests
{
    [Fact]
    public void Login_Test() { }
}
//Why xUnit is generally recommended today: it's the lightest of the three, supports the newest .NET features, and is directly integrated with the
//.NET CLI — no adjustments needed as your app moves to newer .NET versions.

//6. xUnit: [Fact] vs[Theory]
//[Fact] — one single, fixed test case:
//csharp[Fact]
public void Add_Test()
{
    Assert.Equal(5, 2 + 3);
}
//[Theory] — same test logic, run repeatedly across multiple input sets, without duplicating the method:
//csharp
[Theory]
[InlineData(2, 3, 5)]
[InlineData(10, 20, 30)]
[InlineData(5, 5, 10)]
public void Add_Test(int a, int b, int expected)
{
    Assert.Equal(expected, a + b);
}
//Instead of writing three separate Add_Test1, Add_Test2, Add_Test3 methods, one[Theory] handles all input combinations.

//7. The Universal Pattern: Arrange → Act → Assert (AAA)
//No matter which framework or language you use, every test follows this same three-step shape:
//Arrange  →  set up inputs/objects the method needs
//Act      →  actually call the method
//Assert   →  check the result matches what's expected
//csharp
    [Fact]
public void Add_Returns5()
{
    // Arrange
    var calculator = new Calculator();

    // Act
    var result = calculator.Add(2, 3);

    // Assert
    Assert.Equal(5, result);
}

//8.Full Worked Example — Testing a File Upload API
//The controller being tested:
//csharp
    public class FileController : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null)
            return BadRequest("File cannot be null"); // 400

        return Ok(new { FileName = file.FileName }); // 200
    }
}
//Test Case 1 — successful upload:
csharp[Fact]
public async Task UploadFile_ReturnsOk_WhenFileIsProvided()
{
    // ---------- ARRANGE ----------
    var controller = new FileController();

    var fileContent = "Hello test file";
    var fileName = "test.txt";

    var stream = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));
    IFormFile mockFile = new FormFile(stream, 0, stream.Length, "file", fileName);

    // ---------- ACT ----------
    var result = await controller.UploadFile(mockFile);

    // ---------- ASSERT ----------
    var okResult = Assert.IsType<OkObjectResult>(result);
    Assert.NotNull(okResult.Value);
}
//Test Case 2 — null file:
//csharp[Fact]
public async Task UploadFile_ReturnsBadRequest_WhenFileIsNull()
{
    // ---------- ARRANGE ----------
    var controller = new FileController();

    // ---------- ACT ----------
    var result = await controller.UploadFile(null);

    // ---------- ASSERT ----------
    Assert.IsType<BadRequestObjectResult>(result);
    // Note: if your controller uses `return BadRequest();` with no message,
    // the result type would instead be BadRequestResult
//}
//Walking through what each part does:

//MemoryStream + Encoding.UTF8.GetBytes(...) — builds fake file content in memory, no real file needed on disk.
//FormFile — the built-in concrete class that implements IFormFile, used to simulate an uploaded file.
//Assert.IsType<T>() — checks the type of the result (was it OkObjectResult or BadRequestObjectResult?).
//Assert.NotNull(...) / Assert.Equal(...) — checks the actual value returned.


//9. Common Assertions
//csharp
Assert.Equal(5, result);
Assert.True(isValid);
Assert.False(isDeleted);
Assert.Null(obj);
Assert.NotNull(obj);
Assert.Contains("Admin", roles);
Assert.Throws<Exception>(() => someMethod());
//Assertion is just validation — you're comparing what the method actually returned against what you expected it to return,
//including edge cases like exceptions being thrown correctly.

//10. Test Naming Convention
//A good test name reads like a sentence: MethodName_ExpectedResult_Condition
//Upload_ReturnsOK_WhenFileExists
//Login_ReturnsUnauthorized_WhenPasswordIsWrong
//This way, anyone glancing at the test explorer understands what's being verified — no need to open the code.

//11. Running Tests in Visual Studio

//Right-click the test method → Run Test / Debug Test
//Or press Ctrl + R, T
//Open Test Explorer (View → Test Explorer) to see all tests and their pass/fail status at a glance.