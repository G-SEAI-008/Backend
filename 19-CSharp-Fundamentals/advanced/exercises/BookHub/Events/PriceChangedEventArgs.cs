using BookHub.Models;

namespace BookHub.Events;

public sealed class PriceChangedEventArgs : EventArgs
{

    public PriceChangedEventArgs(Book book, decimal oldPrice, decimal newPrice, DateTimeOffset occuredAt)
    {
        Book = book;
        OldPrice = oldPrice;
        NewPrice = newPrice;
        OccuredAt = occuredAt;
    }

    public Book Book { get; }

    public DateTimeOffset OccuredAt { get; }

    public decimal OldPrice { get; }

    public decimal NewPrice { get; }
}