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
        // subscribe
    }

    public void OnPriceChanged(object? sender, PriceChangedEventArgs e)
    {
        // add reaction to price changed event 
        // filter when this fill be triggerd
    }
}