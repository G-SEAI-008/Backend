using BookHub.Events;

namespace BookHub.Services;

public class PricingService
{
    private readonly CatalogService _catalog;

    public PricingService(CatalogService catalog)
    {
        _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
    }

    // add EventHandler for PriceChanged

    public bool SetPrice(string isbn, decimal newPrice)
    {
        if (!_catalog.TryGet(isbn, out var book)) return false;
        var old = book.Price;
        if (newPrice == old) return false;

        var updated = book with { Price = newPrice };
        _catalog.UpdateBook(updated);

        // trigger event for price changed

        return true;
    }


    // add method to trigger event
}