using ModellingTypes.Models;



// 1. Parsing transaction types
Console.WriteLine("== Parsing ==");
var inputs = new[] { "income", " EXPENSE ", "gift", "5" };
foreach (var input in inputs)
{
    if (TryParseType(input, out var type))
    {
        Console.WriteLine($"'{input}' -> {type} ({(int)type})");
    }
    else
    {
        Console.WriteLine($"'{input}' is not a valid transaction type");
    }
}


// 2. Money is a value type
Console.WriteLine();
Console.WriteLine("== Money ==");
var price = new Money(10m, "EUR");
var discounted = price with { Amount = 7.5m };
Console.WriteLine($"price: {price}, discounted: {discounted}");
Console.WriteLine($"price == new Money(10m, \"EUR\"): {price == new Money(10m, "EUR")}");
Console.WriteLine($"price + discounted: {price.Add(discounted)}");
try
{
    price.Add(new Money(5m, "USD"));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}


Console.WriteLine();
Console.WriteLine("== Transactions ==");
var march = new DateTimeOffset(2026, 3, 1, 9, 0, 0, TimeSpan.Zero);
var salary = new Transaction(Guid.NewGuid(), TransactionType.Income, "Salary", new Money(2500m, "EUR"), march);
var rent = new Transaction(Guid.NewGuid(), TransactionType.Expense, "Rent", new Money(950m, "EUR"), march.AddDays(2));
var coffee = new Transaction(Guid.NewGuid(), TransactionType.Expense, "Coffee", new Money(3.2m, "EUR"), march.AddDays(4));

var corrected = coffee with { Description = "Coffee and cake", Amount = new Money(6.8m, "EUR") };
Console.WriteLine($"original:  {coffee.Description}, {coffee.Amount}");
Console.WriteLine($"corrected: {corrected.Description}, {corrected.Amount}");
Console.WriteLine($"same Id: {coffee.Id == corrected.Id}");
Console.WriteLine($"coffee == corrected: {coffee == corrected}");
Console.WriteLine($"coffee == coffee with {{ }}: {coffee == (coffee with { })}");


// 4. Budget is a class (reference type)
Console.WriteLine();
Console.WriteLine("== Budget ==");
var budget = new Budget("March", "EUR");
budget.Add(salary);
budget.Add(rent);

var sameBudget = budget;
sameBudget.Add(corrected);
Console.WriteLine($"budget.Count: {budget.Count}, sameBudget.Count: {sameBudget.Count}");


// 5. One list, two kinds of IReportable
Console.WriteLine();
Console.WriteLine("== Report ==");
var report = new List<IReportable> { salary, rent, corrected, budget };
foreach (var item in report)
{
    Console.WriteLine(item.ToReportLine());
}

static bool TryParseType(string input, out TransactionType type)
{
    return Enum.TryParse(input.Trim(), ignoreCase: true, out type) && Enum.IsDefined(type);
}