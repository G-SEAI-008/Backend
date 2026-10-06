using BookShelf.Models;
using BookShelf.Services;

var books = new List<Book>
{
    new("9780441172719", "Dune", "Frank Herbert", 20.00m, 1965),
    new("9780441569595", "Neuromancer", "William Gibson", 18.00m, 1984),
    new("9780547928227", "The Hobbit", "J.R.R. Tolkien", 12.50m, 1937),
    new("9780553293357", "Foundation", "Isaac Asimov", 9.99m, 1951),
    new("9780062315007", "The Alchemist", "Paulo Coelho", 14.00m, 1988)
};

Action<string> print = message => Console.WriteLine($"[LOG] {message}");
Action<string> appendToFile = message => File.AppendAllText("log.txt", $"[LOG] {message + Environment.NewLine}");

var shelf = new Shelf(books, print);

// 1. Filters
Console.WriteLine("== Filters ==");
Func<Book, bool> isCheap = book => book.Price < 15.00m;
Func<Book, bool> isOld = book => book.Year < 1970;

Func<Book, bool> And(Func<Book, bool> first, Func<Book, bool> second)
{
    return book => first(book) && second(book);
}

PrintTitles("Cheap", shelf.Find(isCheap));
PrintTitles("isOld", shelf.Find(isOld));

PrintTitles("Cheap and before 1970", shelf.Find(book => isCheap(book) && isOld(book)));
PrintTitles("Cheap and before 1970", shelf.Find(And(isCheap, isOld)));
PrintTitles("By Tolkien", shelf.Find(IsByTolkien));


// 2. Pricing strategies
Console.WriteLine();
Console.WriteLine("== Pricing ==");

var strategies = new Dictionary<string, Func<decimal, decimal>>
{
    {"Full price", price => price},
    {"10% off", price => price * 0.90m},
    {"Half price, min 5.00", price => Math.Max(price/ 2.0m, 5.00m)}
};

foreach (var (name, strategy) in strategies)
{
    Console.WriteLine($"{name}: {shelf.Total(strategy)}");

}


Console.WriteLine($"Dune at 10% off: {shelf.PriceFor(books[0], strategies["10% off"])}");


// 3. Swapping the logger
Console.WriteLine();
Console.WriteLine("== Logging ==");

var history = new List<string>();
var silentShelf = new Shelf(books, history.Add);

silentShelf.Find(isOld);
silentShelf.Total(strategies["Full price"]);

Console.WriteLine($"Collected: {history.Count} log messages");

foreach (var message in history)
{
    Console.WriteLine($"{message}");
}




static bool IsByTolkien(Book book) => book.Author.Contains("Tolkien");


static void PrintTitles(string label, List<Book> found)
{
    Console.WriteLine($"{label}: {string.Join(", ", found.Select(book => book.Title))}");
}