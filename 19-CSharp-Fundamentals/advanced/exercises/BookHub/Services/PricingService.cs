using BookHub.Events;

namespace BookHub.Services;

public class PricingService
{
    private readonly CatalogService _catalog;

    public PricingService(CatalogService catalog)
    {
        _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
    }

    public event EventHandler<PriceChangedEventArgs>? PriceChanged;

    public bool SetPrice(string isbn, decimal newPrice)
    {
        if (!_catalog.TryGet(isbn, out var book)) return false;
        var old = book.Price;
        if (newPrice == old) return false;

        var updated = book with { Price = newPrice };
        _catalog.UpdateBook(updated);

        OnPriceChanged(new PriceChangedEventArgs(updated, old, newPrice, DateTimeOffset.UtcNow));

        return true;
    }


    protected virtual void OnPriceChanged(PriceChangedEventArgs e) => PriceChanged?.Invoke(this, e);
}