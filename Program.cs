//Abstraction is about security and hiding complexity. Use abstract classes when you need a base "identity" for your objects.

//Polymorphism is about flexibility. It allows your code to execute the correct method version at runtime based on the specific object being used (e.g., calling Speak() on any animal).

//1.Abstraction Example
//using System;

//// Abstract Class: Provides the blueprint
//public abstract class PaymentProcessor
//{
//    // Implementation shared by all child classes
//    public void DisplayProcessorInfo()
//    {
//        Console.WriteLine("Processor is ready for secure transactions.");
//    }

//    // Abstract method: MUST be implemented by child classes
//    public abstract void ProcessPayment(double amount);
//}

//// Child Class: Specific implementation for Credit Cards
//public class CreditCardProcessor : PaymentProcessor
//{
//    public override void ProcessPayment(double amount)
//    {
//        Console.WriteLine($"Processing credit card payment of ${amount} through secure gateway.");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        PaymentProcessor processor = new CreditCardProcessor();
//        processor.DisplayProcessorInfo(); // Shared logic
//        processor.ProcessPayment(250.00);  // Specific child logic
//    }
//}

//2. Polymorphism Example
using System;

public class Animal
{
    // 'virtual' allows this method to be overridden
    public virtual void Speak()
    {
        Console.WriteLine("The animal makes a generic sound.");
    }
}

public class Dog : Animal
{
    // 'override' provides the specific behavior for Dog
    public override void Speak()
    {
        Console.WriteLine("The dog barks: Woof! Woof!");
    }
}

public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("The cat meows: Meow! Meow!");
    }
}

class Program
{
    static void Main()
    {
        // Polymorphism: Using a base class reference for derived objects
        Animal myDog = new Dog();
        Animal myCat = new Cat();

        myDog.Speak(); // Outputs specific Dog behavior
        myCat.Speak(); // Outputs specific Cat behavior
    }
}