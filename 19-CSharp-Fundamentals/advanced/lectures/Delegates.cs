
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

var calc = new Calculator();

Console.WriteLine($"{calc.Compute(4, 3, MathService.Add)}");
Console.WriteLine($"{calc.Compute(4, 3, MathService.Multiply)}");
Console.WriteLine($"{calc.Compute(3, 3, (a, b) => a - b)}");


Func<decimal, decimal> halfOff = p => p / 2;
Func<decimal, decimal> addTax = p => p * 1.2m;
Func<decimal, decimal> noDiscount = p => p;
Func<decimal, decimal> iDontLikeYourPrice = p => p * 2.5m;


PriceEngine engine = new();
Console.WriteLine($"{engine.CalculatePrice(100, halfOff)}");
Console.WriteLine($"{engine.CalculatePrice(100, addTax)}");
Console.WriteLine($"{engine.CalculatePrice(100, noDiscount)}");
Console.WriteLine($"{engine.CalculatePrice(100, iDontLikeYourPrice)}");

var products = new List<Product>
{
    new("Keyboard", 49.99m),
    new("Mouse", 19.99m),
    new("Monitor", 189.00m)
};

Func<Product, bool> isCheap = p => p.Price < 50m;

foreach (var product in Filter(products, isCheap))
{
    Console.WriteLine($"{product.Name}");
}

Console.WriteLine($"\n Starts with M");

foreach (var product in Filter(products, p => p.Name.StartsWith("M")))
{
    Console.WriteLine($"{product.Name}");
}


static List<Product> Filter(List<Product> items, Func<Product, bool> predicate)
{
    var result = new List<Product>();

    foreach (var item in items)
    {
        if (predicate(item))
        {
            result.Add(item);
        }
    }
    return result;

}

Processor processor = new();

processor.Process(msg => Console.WriteLine($"Console: {msg}"));
processor.Process(msg => File.AppendAllText("log.txt", msg + "\n"));


// method groups


var messages = new List<string>();
Action<string> print = Console.WriteLine;
Action<string> collect = message.Add;


print("Hello");
collect("first");
collect("second");

// public delegate int Operation(int x, int y);


// Func
// Action
// class Calculator
// {
//     public int Compute(int a, int b, Operation operation)
//     {
//         return operation(a, b);
//     }
// }
class Calculator
{
    public int Compute(int a, int b, Func<int, int, int> operation)
    {
        return operation(a, b);
    }
}

class MathService
{
    public static int Add(int a, int b) => a + b;
    public static int Multiply(int a, int b) => a * b;

}


class PriceEngine
{
    public decimal CalculatePrice(decimal basePrice, Func<decimal, decimal> strategy)
    {
        return strategy(basePrice);
    }
}

record Product(string Name, decimal Price);


class Processor
{
    public void Process(Action<string> logAction)
    {
        logAction("Processing started");
        logAction("Processing finished");
    }
}