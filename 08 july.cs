// LECTURE 4
//OOPS
//OOPS is a way to structure program into objects.
//types
//Encapsulation
//Inheritance
//Polymorphism
//Abstraction


//Encapsulation
//using System;

//namespace OOPDemo
//{
//    public class Employee
//    {
//        // Fields must match the variables used in properties
//        private string _name = "Default";
//        private double _salary;

//        public string Name
//        {
//            get { return _name; }
//            set
//            {
//                if (!string.IsNullOrWhiteSpace(value))
//                    _name = value;
//                else
//                    Console.WriteLine("Name can't be null or empty.");
//            }
//        }

//        public double Salary
//        {
//            get { return _salary; }
//            set
//            {
//                if (value > 0)
//                    _salary = value;
//                else
//                    Console.WriteLine("Salary can't be 0 or negative.");
//            }
//        }

//        public void DisplayData()
//        {
//            Console.WriteLine($"Name: {_name}, Salary: {_salary}");
//        }
//    }

//    // Entry point class
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Employee emp = new Employee();
//            emp.Name = "Jane Doe";
//            emp.Salary = 60000;
//            emp.DisplayData();
//        }
//    }
//}



// encapsulation example
//using OOPDemo;
//using System;

//namespace OOPDemo
//{
//    public class Employee
//    {
//        // 1. Fields must match the variables used in properties (Case-sensitive!)
//        private string _name = "Unknown";
//        private double _salary;

//        public string Name
//        {
//            get { return _name; }
//            set
//            {
//                // Corrected logic: assign only if NOT empty
//                if (!string.IsNullOrWhiteSpace(value))
//                    _name = value;
//                else
//                    Console.WriteLine("Name can't be null or empty.");
//            }
//        }

//        public double Salary
//        {
//            get { return _salary; }
//            set
//            {
//                if (value > 0)
//                    _salary = value;
//                else
//                    Console.WriteLine("Salary can't be 0 or negative.");
//            }
//        }

//        public void DisplayData()
//        {
//            // Use the private fields (_name, _salary) here
//            Console.WriteLine($"Name: {_name}, Salary: {_salary}");
//        }
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        Employee emp = new Employee();
//        emp.Name = "John";
//        emp.Salary = 5000;
//        emp.DisplayData();
//    }
//}


//Inheritance

//using System;

//namespace OOPDemo
//{
//    // Base Class (Parent)
//    public class Employee
//    {
//        // Using 'protected' allows members to be accessed by derived classes
//        protected string Name;
//        protected double Salary;

//        public void DisplayData()
//        {
//            Console.WriteLine($"Name: {Name}, Salary: {Salary}");
//        }
//    }

//    // Derived Class (Child)
//    // The ':' operator indicates that 'Person' inherits from 'Employee'
//    public class Person : Employee
//    {
//        public void SetData(string name, double salary)
//        {
//            // Accessing protected members from the base class
//            this.Name = name;
//            this.Salary = salary;
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Person p = new Person();
//            p.SetData("Alice", 75000); // Inherited functionality
//            p.DisplayData();           // Inherited method from Employee
//        }
//    }
//}

//Polymorphism
//using System;

//public class Animal
//{
//    // The 'virtual' keyword allows this method to be overridden
//    public virtual void Speak()
//    {
//        Console.WriteLine("The animal makes a sound.");
//    }
//}

//public class Dog : Animal
//{
//    // The 'override' keyword provides specific behavior for Dog
//    public override void Speak()
//    {
//        Console.WriteLine("The dog barks.");
//    }
//}

//public class Cat : Animal
//{
//    public override void Speak()
//    {
//        Console.WriteLine("The cat meows.");
//    }
//}

//// Usage
//class Program
//{
//    static void Main()
//    {
//        Animal myDog = new Dog();
//        Animal myCat = new Cat();

//        myDog.Speak(); // Outputs: The dog barks.
//        myCat.Speak(); // Outputs: The cat meows.
//    }
//}
//public class Calculator
//{
//    public int Add(int a, int b)
//    {
//        return a + b;
//    }

//    // Overloading: Same name, different parameters
//    public double Add(double a, double b)
//    {
//        return a + b;
//    }
//}

//abstraction

//using System;

//// 'abstract' class cannot be instantiated directly
//public abstract class PaymentProcessor
//{
//    // A regular method: shared logic for all processors
//    public void ShowStatus()
//    {
//        Console.WriteLine("Processor is active and ready.");
//    }

//    // Abstract method: MUST be implemented by child classes
//    public abstract void ProcessPayment(double amount);
//}

//public class CreditCardProcessor : PaymentProcessor
//{
//    public override void ProcessPayment(double amount)
//    {
//        Console.WriteLine($"Processing credit card payment of ${amount}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        PaymentProcessor myProcessor = new CreditCardProcessor();
//        myProcessor.ShowStatus();             // Inherited logic
//        myProcessor.ProcessPayment(100.50);   // Specific logic
//    }
//}


//public interface IReportGenerator
//{
//    void Generate(); // Only declaration, no body
//}

//public class PdfReport : IReportGenerator
//{
//    public void Generate()
//    {
//        Console.WriteLine("Generating PDF Report...");
//    }
//}

