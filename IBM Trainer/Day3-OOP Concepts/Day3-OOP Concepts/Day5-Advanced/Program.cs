//IEnumerable:Defined in: System.Collections
//                        Works with in-memory collections
//                        Query execution happens in memory
//                        Best for: Lists, Arrays, etc.
//Filtering happens after data is loaded into memory.

MyResource resource = new MyResource();
resource.DoWork();
resource.Dispose();   // Manual cleanup

//Real time eample IDispose
using (StreamWriter writer = new StreamWriter("test.txt"))
{
    writer.WriteLine("Hello World");
} // Dispose() is called automatically here


List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

IEnumerable<int> result = numbers.Where(x => x > 2);

foreach (var num in result)
{
    Console.WriteLine(num);
}

//IQueryable:            Defined in: System.Linq
//                       Works with remote data sources (like databases)
//                       Query execution happens at the data source
//                       Best for: Entity Framework, LINQ to SQL

//Filtering happens at the database level before data is loaded.
//using (var context = new AppDbContext())
//{
//    IQueryable<Employee> employees = context.Employees;

//    var result = employees.Where(e => e.Salary > 50000);

//    foreach (var emp in result)
//    {
//        Console.WriteLine(emp.Name);
//    }
//}

// IQueryable
//var employees = context.Employees.ToList().Where(e => e.Salary > 50000);
//SQL-SELECT* FROM Employees WHERE Salary > 50000

//IEnumerable
//var employees = context.Employees.ToList().Where(e => e.Salary > 50000);
//SQL-SELECT * FROM Employees

//Then filtering happens in memory ❌
//This is inefficient for large tables.





//Deferred Execution
//The query is not executed immediately when it is defined.
//It runs only when you iterate over the result (like foreach, ToList(), Count(), etc.).

//👉 Also called lazy loading of query results.

//website
//    teachers name : "John", subject: "Math"
//students name: "Alice", grade: "A": n+1 problem 
//List<int> numbersss = new List<int> { 1, 2, 3, 4 };

//var results = numbersss.Where(x =>
//{
//    Console.WriteLine($"Filtering {x}");
//    return x > 2;
//});

//Console.WriteLine("Query defined");

//foreach (var item in results)
//{
//    Console.WriteLine($"Result: {item}");
//}

//Where() did NOT execute immediately.Filtering happened only during foreach iteration.


//Immediate Execution
//The query is executed immediately when it is defined.
//This happens when you use methods like:
//ToList(),ToArray(),Count(),First(),Single(),Max(), Min(), etc.
//These are called terminal operators.

List<int> numbers1 = new List<int> { 1, 2, 3, 4 };

var result1 = numbers1.Where(x =>
{
    Console.WriteLine($"Filtering {x}");
    return x > 2;
}).ToList();   // Immediate execution happens here

Console.WriteLine("Query executed");

foreach (var item in result1)
{
    Console.WriteLine($"Result: {item}");
}

//Filtering happens immediately when ToList() is called.
//The result is stored in memory.
//foreach does NOT re-run the filter.
//That’s Immediate Execution.

//Filtering & Projection methods → Deferred
//Materializing methods (ToList, Count, First) → Immediate

//undetetermistic behavior,clean unused managed resources

//IDisposable is an interface in .NET used to release unmanaged resources manually.
//void Dispose();
class MyResource : IDisposable
{
    public void DoWork()
    {
        Console.WriteLine("Working with resource...");
    }

    public void Dispose()
    {
        Console.WriteLine("Releasing unmanaged resources...");
    }
}

