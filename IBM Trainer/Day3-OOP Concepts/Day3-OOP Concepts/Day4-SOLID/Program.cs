//SOLID Principles-5 design principles for writing clean, maintainable OOP code.

//Payment payment = new CashOnDelivery();
//ProcessRefund(payment);   // ❌ Runtime exception
//void ProcessRefund(Payment payment)
//{
//    payment.Refund();
//}

//Correct Usage
void ProcessRefund(IRefundable payment)
{
    payment.Refund();
}


//S – Single Responsibility Principle (SRP)-A class should have only one reason to change.
//→ One class = One responsibility.

//Wrong
public class Invoice
{
    public void CalculateTotal() { }

    public void SaveToDatabase() { }   // Database logic
}

//Correct
public class Invoices
{
    public void CalculateTotal() { }
}

public class InvoiceRepository
{
    public void Save() { }
}



//O – Open/Closed Principle (OCP)-Open for extension, closed for modification.
//→ Add new behavior without changing existing code.

//Wrong
public class Discount
{
    public double GetDiscount(string type)
    {
        if (type == "Regular")
            return 10;
        else if (type == "Premium")
            return 20;

            return 0;
    }
}

//Correct
public interface IDiscount
{
    double GetDiscount();
}

public class RegularDiscount : IDiscount
{
    public double GetDiscount() => 10;
}

public class PremiumDiscount : IDiscount
{
    public double GetDiscount() => 20;
}



//L – Liskov Substitution Principle (LSP)-Derived classes should be replaceable with base classes.
//The child class should be able to implement all the method of the parent class seamlessly and smoothly


//Wrong
//public class Payment
//{
//    public virtual void ProcessPayment()
//    {
//        Console.WriteLine("Processing payment...");
//    }

//    public virtual void Refund()
//    {
//        Console.WriteLine("Refund processed");
//    }
//}

//public class CashOnDelivery : Payment
//{
//    public override void Refund()
//    {
//        throw new NotSupportedException("COD cannot be refunded online");
//    }
//}


//Correct
public abstract class Payment
{
    public abstract void ProcessPayment();
}

public interface IRefundable
{
    void Refund();
}

public class CreditCardPayment : Payment, IRefundable
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Credit card payment processed");
    }

    public void Refund()
    {
        Console.WriteLine("Credit card refund processed");
    }
}

public class CashOnDelivery : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Cash will be collected on delivery");
    }
}




//I – Interface Segregation Principle (ISP)-Clients should not be forced to implement methods they don’t use.

//Wrong
public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Eat()
    {
        throw new NotImplementedException();
    }

    public void Work() { }
}


//Correct
public interface IWork
{
    void Work();
}

public interface IEat
{
    void Eat();
}

public class Human : IWork, IEat
{
    public void Work() { }
    public void Eat() { }
}

public class Robots : IWork
{
    public void Work() { }
}


//D – Dependency Inversion Principle (DIP)-Depend on abstractions, not concrete classes.
//Wrong-Notification tightly depends on EmailService.
public class EmailService
{
    public void Send() { }
}

public class Notification
{
    private EmailService _email = new EmailService();

    public void Notify()
    {
        _email.Send();
    }
}

//Correct
public interface IMessageService
{
    void Send();
}

public class EmailServices : IMessageService
{
    public void Send() { }
}

public class Notifications
{
    private readonly IMessageService _messageService;

    public Notifications(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify()
    {
        _messageService.Send();
    }
}

//builder.Services.AddScoped<IMessageService, EmailService>();
//builder.Services.AddScoped<IMessageService, SmsService>();