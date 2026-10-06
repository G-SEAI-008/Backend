using BookHub.Models;

namespace BookHub.Events;

public sealed class BookAddedEventArgs : EventArgs
{

    public BookAddedEventArgs(Book book, DateTimeOffset occuredAt)
    {
        Book = book;
        OccuredAt = occuredAt;
    }

    public Book Book { get; }

    public DateTimeOffset OccuredAt { get; }
}