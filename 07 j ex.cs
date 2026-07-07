//Partial Classes:

//1.Handling Large Entities

//public partial class User {
//    public int Id { get; set; }
//    public string Username { get; set; }
//    public string PasswordHash { get; set; }
//}


//public partial class User
//{
//    public string Username;
//}


//using System;

// This is the first part of your partial class
//public partial class User
//{
//    public string Username = ""; // Added "" to stop the warning
//}

//// This is the second part (you could put this in another file later)
//public partial class User
//{
//    public void SayHello()
//    {
//        Console.WriteLine("Hello, my name is " + Username);
//    }
//}

//// This is the REQUIRED entry point for any C# program
//class Program
//{
//    static void Main()
//    {
//        User myUser = new User();
//        myUser.Username = "Om";
//        myUser.SayHello();
//    }
//}



// example
// A Calculator Class

//public partial class Calculator
//{
//    public int Add(int a, int b)
//    {
//        return a + b;
//    }
//}


//using System;

//// This is your existing partial class
//public partial class Calculator
//{
//    public int Add(int a, int b)
//    {
//        return a + b;
//    }
//}

//// THIS IS WHAT YOU ARE MISSING:
//class Program
//{
//    static void Main()
//    {
//        // Now the computer has a place to start!
//        Calculator calc = new Calculator();
//        int result = calc.Add(10, 20);
//        Console.WriteLine("The result is: " + result);
//    }
//}


//example 3

//// 1. IMPORTING LIBRARIES
//// This tells C# to include the 'System' library, which allows us to use 'Console.WriteLine'.
//// It MUST be at the very top of your file.
//using System;

//// 2. PARTIAL CLASS DEFINITION
//// 'partial' tells the compiler that the definition of the class 'Service' is spread 
//// across multiple locations. The compiler will "stitch" them together.
//public partial class Service
//{
//    // A 'public' method can be called from outside this class.
//    public void DoWork()
//    {
//        Console.WriteLine("Working...");
//        // Calling a method that is defined in the OTHER partial part of this class.
//        Log("Work Complete.");
//    }
//}

//// 3. THE SECOND PART
//// Because this uses the same name ('Service') and the same 'partial' keyword, 
//// the compiler merges this 'Log' method into the 'Service' class above.
//public partial class Service
//{
//    // A 'private' method can only be called from inside the same class.
//    private void Log(string message)
//    {
//        Console.WriteLine($"[LOG]: {message}");
//    }
//}

//// 4. THE ENTRY POINT
//// This is the starting engine of your application.
//class Program
//{
//    static void Main()
//    {
//        // We create an instance of the class. Even though it's partial, 
//        // to the rest of the program, it acts like a single, normal class.
//        Service myService = new Service();

//        // This triggers the process.
//        myService.DoWork();
//    }
//}

// Example 4
//using System;

//class Program
//{
//    static void Main()
//    {
//        UserAccount user = new UserAccount("om@example.com");

//        // Custom initialization
//        user.Initialize();

//        Console.WriteLine($"User {user.Email} is active: {user.IsActive}");
//    }
//}
//public partial class UserAccount
//{
//    // We declare the hook here
//    partial void OnCreated();

//    // We can "expand" the constructor logic here
//    public void Initialize()
//    {
//        IsActive = true;
//        OnCreated(); // If someone implements this, it runs
//    }
//}
//public partial class UserAccount
//{
//    public string Email { get; set; }
//    public bool IsActive { get; set; }

//    // This constructor sets the basic data
//    public UserAccount(string email)
//    {
//        Email = email;
//        IsActive = false; // Default state
//    }
//}

//Example 5
//A Product Class
//using System;

//class Program
//{
//    static void Main()
//    {
//        // We create one 'Product' object
//        Product item = new Product();

//        // We access properties from Info.cs
//        item.ProductName = "Gaming Laptop";
//        item.Price = 1200.00m;

//        // We access properties and methods from Stock.cs
//        item.StockCount = 5;

//        if (item.IsAvailable())
//        {
//            Console.WriteLine($"{item.ProductName} is available for ${item.Price}");
//        }
//    }
//}
//public partial class Product
//{
//    public int StockCount { get; set; }

//    public bool IsAvailable()
//    {
//        return StockCount > 0;
//    }
//}
//public partial class Product
//{
//    public string ProductName { get; set; }
//    public decimal Price { get; set; }
//}

//Generic Classes

//Example 1

//1.The Generic Container

//using System;

//namespace JulyExamples
//{
//    // The Generic Container Class
//    public class Holder<T>
//    {
//        // Using '?' makes it nullable, fixing the CS8618 warning
//        public T? Value { get; set; }
//    }

//    // This is the required Entry Point
//    class Program
//    {
//        static void Main()
//        {
//            // Usage of our Generic Class
//            // 1. Integer Holder
//            Holder<int> intHolder = new Holder<int>();
//            intHolder.Value = 10;
//            Console.WriteLine("Int Value: " + intHolder.Value);

//            // 2. String Holder
//            Holder<string> strHolder = new Holder<string>();
//            strHolder.Value = "Hello Generics";
//            Console.WriteLine("String Value: " + strHolder.Value);
//        }
//    }
//}


//Example 2
//Generic Repository Pattern

//using System;
//using System.Collections.Generic;

//namespace RepositoryExample
//{
//    // The Generic Repository manages data for any type 'T'
//    public class Repository<T>
//    {
//        // A simple list to act as our "database"
//        private List<T> _data = new List<T>();

//        public void Add(T item)
//        {
//            _data.Add(item);
//            Console.WriteLine($"Item of type {typeof(T).Name} added successfully.");
//        }

//        public void DisplayAll()
//        {
//            Console.WriteLine($"Displaying all {typeof(T).Name}s:");
//            foreach (var item in _data)
//            {
//                Console.WriteLine($"- {item}");
//            }
//        }
//    }

//    // This class is the Entry Point
//    class Program
//    {
//        static void Main()
//        {
//            // Example 1: Repository for Products (using string)
//            Repository<string> productRepo = new Repository<string>();
//            productRepo.Add("Gaming Laptop");
//            productRepo.Add("Wireless Mouse");
//            productRepo.DisplayAll();

//            // Example 2: Repository for User IDs (using int)
//            Repository<int> userRepo = new Repository<int>();
//            userRepo.Add(101);
//            userRepo.Add(102);
//            userRepo.DisplayAll();
//        }
//    }
//}

//Example 3
//Generic Constraints 

//using System;
//using System.Collections.Generic;

//namespace ConstraintExample
//{
//    // 1. First, we define a "contract" that items must follow
//    public interface IPriceable
//    {
//        decimal GetPrice();
//    }

//    // 2. We use a constraint: 'where T : IPriceable'
//    // This ensures that the Calculator can ONLY be used with types that have GetPrice()
//    public class PriceCalculator<T> where T : IPriceable
//    {
//        public decimal CalculateTotal(List<T> items)
//        {
//            decimal total = 0;
//            foreach (var item in items)
//            {
//                total += item.GetPrice();
//            }
//            return total;
//        }
//    }

//    // 3. A concrete class that follows the contract
//    public class Product : IPriceable
//    {
//        public decimal Price { get; set; }
//        public decimal GetPrice() => Price;
//    }

//    class Program
//    {
//        static void Main()
//        {
//            var products = new List<Product>
//            {
//                new Product { Price = 10.50m },
//                new Product { Price = 20.00m }
//            };

//            // This works because Product implements IPriceable
//            var calc = new PriceCalculator<Product>();
//            Console.WriteLine($"Total Price: {calc.CalculateTotal(products)}");
//        }
//    }
//}

//Example 4
//Generic Methods

//using System;

//namespace MethodExample
//{
//    public class Utility
//    {
//        // This is a Generic Method. The <T> goes before the parameters.
//        public void Swap<T>(ref T a, ref T b)
//        {
//            T temp = a;
//            a = b;
//            b = temp;
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Utility utils = new Utility();

//            // 1. Swapping integers
//            int x = 5, y = 10;
//            utils.Swap(ref x, ref y);
//            Console.WriteLine($"Swapped Ints: x={x}, y={y}");

//            // 2. Swapping strings
//            string s1 = "Hello", s2 = "World";
//            utils.Swap(ref s1, ref s2);
//            Console.WriteLine($"Swapped Strings: s1={s1}, s2={s2}");
//        }
//    }
//}

//Example 5
//This is the 5th example. You've covered:

//Generic Container (Storage)

//Generic Repository (Architecture)

//Generic Pair (Data Structures)

//Generic Constraints (Safety)

//Generic Methods (Utility)

//using System;

//namespace MethodExample
//{
//    public class Utility
//    {
//        // This is a Generic Method. The <T> goes before the parameters.
//        public void Swap<T>(ref T a, ref T b)
//        {
//            T temp = a;
//            a = b;
//            b = temp;
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Utility utils = new Utility();

//            // 1. Swapping integers
//            int x = 5, y = 10;
//            utils.Swap(ref x, ref y);
//            Console.WriteLine($"Swapped Ints: x={x}, y={y}");

//            // 2. Swapping strings
//            string s1 = "Hello", s2 = "World";
//            utils.Swap(ref s1, ref s2);
//            Console.WriteLine($"Swapped Strings: s1={s1}, s2={s2}");
//        }
//    }
//}

