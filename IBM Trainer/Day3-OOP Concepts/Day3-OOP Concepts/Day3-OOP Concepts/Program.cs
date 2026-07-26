Console.WriteLine("Hello, World!");
//OOP concepts
//Helps us to think in terms of real-world objects and their interactions

//Classes and Objects- class is a blueprint for creating objects. An object is an instance of a class. It encapsulates data and behavior related to that data.

Patient patient = new Patient();
patient.Name = "John Doe";

//Encapsulation
BankAccount account = new BankAccount();
Console.WriteLine(account.GetBalance());


//Inheritance
Developer dev = new Developer();
dev.Work(); // Inherited from Employee
dev.Code(); // Specific to Developer

//runtime polymorphism
Payment payment1 = new CreditCardPayment();
Payment payment2 = new UpiPayment();
payment1.Pay(); // Calls CreditCardPayment's Pay method
payment2.Pay(); // Calls UpiPayment's Pay method

//compile-time polymorphism
Calculator calc = new Calculator();
Console.WriteLine(calc.Add(2, 3)); // Calls Add(int, int)
//Console.WriteLine(calc.Add(2, 3, 4)); // Calls Add(int, int, int)

//abstract class
Report pdfReport = new PdfReport();
pdfReport.PrintHeader(); // Calls the defined method in the abstract class
pdfReport.GenerateReport(); // Calls the overridden method in PdfReport

//interface


class Patient
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string MedicalHistory { get; set; }
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Medical History: {MedicalHistory}");
    }
}



//Pillars of OOP
//Encapsulation reduce complexity and increase reusability
//Encapsulation implements Abstraction
class BankAccount
{
    private double balance = 1000;   // Hidden data

    public double GetBalance()       // Only one public function
    {
        return balance;
    }
}
//balance is private → cannot access directly outside the class ❌
//GetBalance() is public → allows controlled access ✅
//Data is hidden and accessed only through a method



//abstaction Isolate complexity+isolate impact of changes. its a thought process during design phase




//Inheritance elliminates redundant code and promotes code reusability.
class Employee
{
    public void Work()
    {
        Console.WriteLine("Employee is working");
    }
}

// Derived class
class Developer : Employee
{
    public void Code()
    {
        Console.WriteLine("Developer is coding");
    }
}


//polimorphism  Polymorphism allows objects of different classes to be treated as objects of a common base class
//runtime polymorphism
class Payment
{
    public virtual void Pay()
    {
        Console.WriteLine("Processing payment");
    }
}

// Derived class 1
class CreditCardPayment : Payment
{
    public override void Pay()
    {
        Console.WriteLine("Processing Credit Card payment");
    }
}

// Derived class 2
class UpiPayment : Payment
{
    public override void Pay()
    {
        Console.WriteLine("Processing UPI payment");
    }
}

//Compile-time polymorphism
class Calculator
{
    // Method 1
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method 2 (Overloaded)
    public string Add(string a, int b, int c)
    {
        return a;
    }
}


//Virtual/Overriding-Helps us to achieve runtime polymorphism. It allows a derived class to provide a specific implementation of a method that is already defined in its base class.
//The method in the base class is marked as virtual, and the method in the derived class is marked as override.


//overloading-Method overloading allows a class to have multiple methods with the same name but different parameters. It is a compile-time polymorphism feature

//Abstractclass- An abstract class is a class that cannot be instantiated and is meant to be inherited by other classes.
//It can contain abstract methods (without implementation) that must be implemented by derived classes,
//as well as concrete methods (with implementation).
//Abstract classes are used to define common behavior for a group of related classes while allowing for specific implementations in the derived classes.

// Parent Abstract Class-partialy defined parent class
abstract class Report
{
    // Common defined method
    public void PrintHeader()
    {
        Console.WriteLine("Company Confidential Report");
    }

    // Abstract method (must be implemented)
    public abstract void GenerateReport();
}

// Child class 1
class PdfReport : Report
{
    public override void GenerateReport()
    {
        Console.WriteLine("Generating PDF Report Content");
    }
}

// Child class 2
class ExcelReport : Report
{
    public override void GenerateReport()
    {
        Console.WriteLine("Generating Excel Report Content");
    }
}


//interface
interface INotification
{
    void Send(string message);
}

// Email implementation
class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sending Email: " + message);
    }
}

// SMS implementation
class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sending SMS: " + message);
    }
}

