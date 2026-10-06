
using BookHub.Events;
using BookHub.Services;

namespace BookHub.Subscribers;

public class ConsoleLogger
{

    public void Subscribe(CatalogService catalog, PricingService pricing)
    {
        catalog.BookAdded += OnBookAdded;
        catalog.BookRemoved += OnBookRemoved;
        pricing.PriceChanged += OnPriceChanged;
    }

    // add reaction for book added event

    public void OnBookAdded(object? sender, BookAddedEventArgs e) => Console.WriteLine($"[LOG] {e.OccuredAt:T}]: {e.Book.Title} at {e.Book.Price:C}");


    // add reaction for book removed event
    public void OnBookRemoved(object? sender, BookRemovedEventArgs e) => Console.WriteLine($"[LOG] {e.OccuredAt:T}]: Removed ISBN: {e.Isbn}");


    // add reaction for price changed event

    public void OnPriceChanged(object? sender, PriceChangedEventArgs e) => Console.WriteLine($"[LOG] Price change: {e.Book.Title} {e.OldPrice} -> {e.NewPrice}");



    public void Unsubscribe(CatalogService catalog, PricingService pricing)
    {
        catalog.BookAdded -= OnBookAdded;
        catalog.BookRemoved -= OnBookRemoved;
        pricing.PriceChanged -= OnPriceChanged;
    }
}