
using BookHub.Events;
using BookHub.Services;

namespace BookHub.Subscribers;

public class ConsoleLogger
{

    public void Subscribe(CatalogService catalog, PricingService pricing)
    {
        // subscribe to event handlers
    }


    // add reaction for book added event


    // add reaction for book removed event


    // add reaction for price changed event


    public void Unsubscribe(CatalogService catalog, PricingService pricing)
    {
        // unsubscribe from event handlers
    }
}