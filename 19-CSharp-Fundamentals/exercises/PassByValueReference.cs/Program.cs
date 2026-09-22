using System.Net.WebSockets;

int myNumber = 2;
Console.WriteLine($"Initial: My Number: {myNumber}");
ValueDemo.Bump(myNumber);
Console.WriteLine($"My Number: {myNumber}");


int a = 5;
int b = 10;
Console.WriteLine($"Swap");
Console.WriteLine($"{a} - {b}");
RefOps.Swap(ref a, ref b);
Console.WriteLine($"{a} - {b}");


Console.WriteLine($"Account");
Account myAccount = new();
AccountOps accountOps = new();
Console.WriteLine($"{myAccount.Balance}");
accountOps.Deposit(myAccount, 100);
Console.WriteLine($"{myAccount.Balance}");
accountOps.Reset(myAccount);
Console.WriteLine($"{myAccount.Balance}");



Console.WriteLine($"Format Price");
decimal price;
Console.WriteLine($"Parse \"£12.50\": {Parser.TryParsePrice("£12.50", out price)}, price = {price:0.00}");
Console.WriteLine($"Parse \"€12.50\": {Parser.TryParsePrice("€12.50", out price)}, price = {price:0.00}");
Console.WriteLine($"Parse \"12,50\": {Parser.TryParsePrice("12,50", out price)}, price = {price:0.00}");
Console.WriteLine($"Parse \"oops\": {Parser.TryParsePrice("oops", out price)}, price = {price:0.00}");



Console.WriteLine($"TemperatureRange");

TemperatureRange range = new(1, 20);
RangeChecker checker = new();
Console.WriteLine($"{checker.Contains(range, 4)}");
Console.WriteLine($"{checker.Contains(range, 30)}");



