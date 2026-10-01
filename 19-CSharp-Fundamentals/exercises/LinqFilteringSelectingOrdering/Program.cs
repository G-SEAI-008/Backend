
var customers = new List<Customer>
{
    new Customer { Name = "Aisha",   City = "Berlin",  Age = 29, Account = new BankAccount { Iban = "DE01", Balance = 1800m, Currency = "EUR", Active = true } },
    new Customer { Name = "Jonas",   City = "Munich",  Age = 34, Account = new BankAccount { Iban = "DE02", Balance = 250m,  Currency = "EUR", Active = true } },
    new Customer { Name = "Priya",   City = "Berlin",  Age = 41, Account = new BankAccount { Iban = "DE03", Balance = 5200m, Currency = "EUR", Active = true } },
    new Customer { Name = "Luca",    City = "Hamburg", Age = 23, Account = new BankAccount { Iban = "DE04", Balance = 0m,    Currency = "EUR", Active = false } },
    new Customer { Name = "Noor",    City = "Leipzig", Age = 37, Account = new BankAccount { Iban = "DE05", Balance = 950m,  Currency = "EUR", Active = true } },
    new Customer { Name = "Omar",    City = "Berlin",  Age = 31, Account = new BankAccount { Iban = "DE06", Balance = 1400m, Currency = "EUR", Active = true } },
};

// Filtering

var berlinAndActive = customers.Where(c => string.Equals(c.City, "Berlin", StringComparison.OrdinalIgnoreCase) && c.Account.Active);


foreach (var c in berlinAndActive)
{
    Console.WriteLine($"{c.Name}");
}

var between25and40 = customers.Where(c => c.Age >= 25 && c.Age <= 40);

var richCustomers = customers.Where(c => c.Account.Balance > 1000m);

var customersWithA = customers.Where(c => c.Name.Contains('a', StringComparison.OrdinalIgnoreCase));


// Selecting
Console.WriteLine($"\nSelecting");

var customerNames = customers.Select(c => c.Name);

foreach (var c in customerNames)
{
    Console.WriteLine($"{c}");
}

var views = customers.Select(c => new { c.Name, c.City, c.Account.Balance });


var summary = customers.Select(c => new CustomerSummary(c.Name, c.City, c.Account.Balance, c.Account.Balance > 1000m));


// Ordering
Console.WriteLine($"\nOrdering");


var orderByBalance = customers.OrderByDescending(c => c.Account.Balance);

foreach (var c in orderByBalance)
{
    Console.WriteLine($"{c.Name} - {c.City} - {c.Account.Balance}");
}

var orderByCityAndName = customers.OrderBy(c => c.City).ThenBy(c => c.Name);


foreach (var c in orderByCityAndName)
{
    Console.WriteLine($"{c.City} - {c.Name}");

}


var orderByAge = customers.OrderBy(c => c.Age);


// Aggregate

Console.WriteLine($"\nAggregate");

var numberOfCustomers = customers.Count(c => c.City == "Berlin");

Console.WriteLine($"{numberOfCustomers}");


var totalBalance = customers.Where(c => c.Account.Active).Sum(c => c.Account.Balance);

Console.WriteLine($"Total Balance: {totalBalance}");


var averageAge = customers.Average(c => c.Age);

Console.WriteLine($"Average: {averageAge:F1}");


var highest = customers.Max(c => c.Account.Balance);
var lowest = customers.Min(c => c.Account.Balance);

Console.WriteLine($"{highest}");
Console.WriteLine($"{lowest}");

var inactive = customers.Any(c => c.Account.Active == false);
var allInEurope = customers.All(c => c.Account.Currency == "EUR");
Console.WriteLine($"{inactive}");
Console.WriteLine($"{allInEurope}");


var firstHamburg = customers.First(c => c.City == "Hamburg");
var firstParis = customers.FirstOrDefault(c => c.City == "Paris");

if (firstParis is null)
{
    Console.WriteLine($"No customer in Paris");
}


// Optional

var specialCustomers = customers.Where(c => c.Account.Active && c.City == "Berlin").OrderByDescending(c => c.Account.Balance).Take(3).Select(c => new { c.Name, c.Account.Balance }).ToList();

foreach (var c in specialCustomers)
{
    Console.WriteLine($"{c.Name} - {c.Balance}");

}