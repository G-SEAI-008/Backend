// Program.cs
using BookHub.Models;
using BookHub.Services;
using BookHub.Subscribers;

var catalog = new CatalogService();
var pricing = new PricingService(catalog);

var logger = new ConsoleLogger();
logger.Subscribe(catalog, pricing);

var notifier = new DealNotifier(e => e.NewPrice < e.OldPrice);
notifier.Subscribe(pricing);

var dune = new Book("9780441172719", "Dune", 20m);
var neuromancer = new Book("9780441569595", "Neuromancer", 18m);

Console.WriteLine("== Adding books ==");
catalog.AddBook(dune);
catalog.AddBook(neuromancer);
Console.WriteLine($"Add Dune again: {catalog.AddBook(dune)}"); // guard: no event

Console.WriteLine();
Console.WriteLine("== Changing prices ==");
pricing.SetPrice(dune.Isbn, 17m);        // drop: logger and notifier react
pricing.SetPrice(neuromancer.Isbn, 21m); // increase: only the logger reacts
Console.WriteLine($"Set Dune to 17 again: {pricing.SetPrice(dune.Isbn, 17m)}"); // guard: no event

Console.WriteLine();
Console.WriteLine("== Unsubscribing the logger from price changes ==");
pricing.PriceChanged -= logger.OnPriceChanged;
pricing.SetPrice(dune.Isbn, 16m);        // only the notifier reacts

Console.WriteLine();
Console.WriteLine("== Removing books ==");
catalog.RemoveBook(neuromancer.Isbn);
Console.WriteLine($"Remove Neuromancer again: {catalog.RemoveBook(neuromancer.Isbn)}"); // guard: no event

catalog.TryGet(dune.Isbn, out var current);
Console.WriteLine();
Console.WriteLine($"Dune now costs {current?.Price:0.00}");