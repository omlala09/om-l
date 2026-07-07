////////// Online C# Editor for free
////////// Write, Edit and Run your C# code using C# Online Compiler

//////////using System;

//////////public class Program
//////////using System.IO.Pipes;

////////{
////////  //  public static void Main(string[] args)
////////    {

////////        //heading 1

////////        //Console.WriteLine("Start small. Ship something.");

////////        //heading 2



////////        //Console.WriteLine("2222.");


////////        //heading 3
////////        //int a = 1;

////////        //var message = string.Empty;
////////        //if (a > 0)
////////        {
////////            //  message = $"A's value is greater than 0 : {a};";
////////            //Console.WriteLine($"A's value is greater than 0 : {a};");

////////        }
////////        //else
////////        { 
////////          //  message = $"A's value is smaller than 0 : {a};";
////////            //Console.WriteLine($"A's value is smaller than 0 : {a};");
////////        }
////////        //Console.WriteLine(message);
////////        //Console.ReadLine();
////////    }
////////}
//////////heading 4
//////////int a = 1;
//////////var message = (a > 0) ? $"A's value is greater than 0 : {a};"
//////////  : $"A's value is smaller than 0 : {a};";
//////////Console.WriteLine(message);
//////////Console.ReadLine()

//////////heading 5

//////////int a = 5; //0101--------0000 0101 1111 1010
//////////int b = 3; //0011

//////////Console.WriteLine(-a);
//////////Console.ReadLine();

//////////heading 6

//////////int a = 5; //0101
//////////int b = 3; //0011

//////////Console.WriteLine(a | b);
//////////Console.ReadLine();

//////////heading 7

//////////int a = 5; //0101
//////////int b = 3; //0011

//////////Console.WriteLine(a >> b);
//////////Console.ReadLine();

//////////SESSION  2 
//////////heading 8
//////////oops
////////////  
//////////TYPES OF CLASS

//////////  1. REGULAR CLASS
//////////public class Program
//////////{
//////////    public String Name { get; set; }
//////////    public void Greet() => Console.WriteLine($"Hello, {Name}!");

//////////}
////////////  2. STATIC CLASS


//////////public static class MathUtilities
//////////{
//////////    public static int Square(int number) => number * number;

//////////}

//////////}
//////////class Program : Person

//////////{
//////////    static void Main()
//////////    {
//////////        // regular class

//////////        //var person = new Program();
//////////        Person person = new();
//////////        {
//////////            Name = "OM"
//////////         }
//////////        ;       // object initialization
//////////        person.Greet();

//////////        // static class

//////////        MathUtilities.Square(5);

//////////        Console.Readline();
//////////    }
//////////}





//////////heading 9


////////public static class mAthUtilities}
////////{
////////        public const string Name = "test";

////////        public static int Square(int number) => number * number;
////////Console.WriteLine(mAthUtilities.Name);
////////Console.ReadLine();


////////class Program
////////{
////////    static void Main()
////////    {
////////        // regular class
////////        //var person = new Program();
////////        Person person = new();
////////        {
////////            Name = "OM"
////////         }
////////        ;       // object initialization
////////        person.Greet();
////////        // static class
////////        MathUtilities.Square(5);
////////        Console.Readline();



//////// abstractt class
//////public abstract class Animal
//////{
//////    public string void speak();
//////    public void eat() => Console.WriteLine("Eating...");

//////}

////{public class Dog : Animal
////{
////    public override void speak() => Console.WriteLine("Woof!");
////}
////Console.ReadLine();
////}



//////heading
//////class Program
//////{ 
//////    static void Main()
//////{ 
//////Animal dog = new Dog():
//////    dog.Speak();
//////    dog.Eat();

//////    Console.ReadLine();
//////    }
//////}

//////sealed class

////public sealed class Logger
////{
////    public void Log(string messaage) => Console.WriteLine(messaage);

////}
////var logger = new Logger();
////logger.Log("test log ");
////Console.ReadLine();



//// heading 10
//// lecture 3

////using Test.Program
////namespace Test.Program
////{
////    public partial class Student
////    {
////        public string Name { get; set; }
////    }
////}
////    public partial class Student
////    {
////       public void Displaay() => Console.WriteLine($"Student : {Name}");
////    }
////}

//// Generic class 
////  public class Box <Program>
//// {
////    public Program  value {  get; set; }

//// }

//// var intBox = new Box<int> { value = 20 };
//// var stringBox = new Box <student> {value = student };
//// Console.WriteLine(intBox.value);
//// Console.Readline();
//// }
////}


//// nested class

////    public class Outer
////{
////    public class Inner
////    {
////        public void Print() => Console.WriteLine("Inner class");

////    }
////}
////    var inner = new Outer.Inner();
////    inner.Print();
////    Console.Readline();



////      
//    //{ 
//    //    public class Person
//    //{
//    //    public int Age { get; set; }
//    //    public string Name { get; set; }
//    //}
//    //}
//    //    public record Person(string Name, int Age);
//    //    class Program
//    //{
//    //    static void Main()
//    //    { }
//    //}
//    //    var Person = new Person()
//    //{
//    //    Name = "Test",
//    //     Age = 5
//    //    var personl = new Person()

//    //        name = "Test",
//    //        arg = 5
//    ////}; 
//    ///
//    //var user = new Person("Test",5);
//    ////    Person.Name = "Test1"; //mutable
//    ////    Person.Name = "Test2"; //mutable
//    ////    Person.Name = "Test3"; //mutable
//    ////    //record
//    //    Console.WriteLine(user);    
//    //    Console.ReadLine();
//    }
//}
//var user = new Person("test", 5);
//var user1 = new Person("test1", 5);
//var user2 = new Person ("test12", 5);

//Console.WriteLine(user1);
//Console.Readline()




