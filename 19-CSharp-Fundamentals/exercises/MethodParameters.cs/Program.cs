using Utils;

int result1 = Calculator.Add(2, 2);
int result2 = Calculator.Multiply(2, 3);
double result3 = Calculator.Add(2.23D, 234.23D);
double result4 = Calculator.Divide(2, 0);
double result5 = Calculator.Divide(4, 0);


Console.WriteLine($"1: {result1}");
Console.WriteLine($"2: {result2}");
Console.WriteLine($"3: {result3}");
Console.WriteLine($"4: {result4}");
Console.WriteLine($"5: {result5}");


Console.WriteLine($"{Statistics.Average(100, 23, 55)}");
Console.WriteLine($"{Statistics.Average(100, 23)}");
Console.WriteLine($"{Statistics.Average(100, 23, 0)}");


Console.WriteLine($"{Formatter.FormatNumber(2)}");
Console.WriteLine($"{Formatter.FormatNumber(5.2342)}");
Console.WriteLine($"{Formatter.FormatMessage("hello", 5)}");


