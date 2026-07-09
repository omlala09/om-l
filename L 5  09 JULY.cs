//Abstraction
//using System;

//public abstract class PaymentProcessor
//{
//    // Constructors are not abstract; they are called when a derived class is instantiated.
//    // If you need specific logic, define a constructor or leave it default.
//    public PaymentProcessor() { }

//    // Abstract methods should not have a body and must be overridden.
//    public abstract void ProcessPayment(decimal amount);

//    public void SendReceipt(string email)
//    {
//        Console.WriteLine($"Receipt sent to {email}.");
//    }
//}

//public class CreditCardProcessor : PaymentProcessor
//{
//    // Use 'override' to implement the abstract method.
//    public override void ProcessPayment(decimal amount)
//    {
//        Console.WriteLine($"Processing payment of {amount:C}.");
//    }
//}

//// Main execution logic (must be inside a method like Main)
//class Program
//{
//    static void Main()
//    {
//        PaymentProcessor processor = new CreditCardProcessor();
//        processor.ProcessPayment(1200);
//        processor.SendReceipt("user@example.com");
//        Console.ReadLine();
//    }
//}


using System;
public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}

public class CreditCardProcessor : IPaymentGateway
{

    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C}.");
    }
}

public class UPIProcessor: IPaymentGateway
{
    public override void ProcessPayment(decimal amount)
   {
        Console.WriteLine($"Processing payment of {amount:C}.");
   }
}

class program
{

    static void Main()
    {
        IPaymentGateway gateway = new UPIProcessor();
        gateway.ProcessPayment(100);

        IPaymentGateway gateway1 = new CreditCardProcessor();
        gateway1.ProcessPayment(200);




        Console.ReadLine();
    }
}

