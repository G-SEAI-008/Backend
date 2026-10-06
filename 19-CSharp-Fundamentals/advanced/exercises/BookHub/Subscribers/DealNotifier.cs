using BookHub.Events;
using BookHub.Services;

namespace BookHub.Subscribers;

public class DealNotifier
{
    private readonly Func<PriceChangedEventArgs, bool> _filter;


    public DealNotifier(Func<PriceChangedEventArgs, bool> filter)
    {
        _filter = filter;
    }
    public void Subscribe(PricingService pricing)
    {
        pricing.PriceChanged += OnPriceChanged;
        // subscribe
    }

    public void OnPriceChanged(object? sender, PriceChangedEventArgs e)
    {
        if (!_filter(e)) return;

        Console.WriteLine($"[DEAL] Good news! {e.Book.Title} dropped from {e.OldPrice:C} to {e.NewPrice:C}");
    }
}