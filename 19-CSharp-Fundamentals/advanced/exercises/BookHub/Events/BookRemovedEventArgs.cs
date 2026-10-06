using BookHub.Models;

namespace BookHub.Events;

public sealed class BookRemovedEventArgs : EventArgs
{

    public BookRemovedEventArgs(string isbn, DateTimeOffset occuredAt)
    {
        Isbn = isbn;
        OccuredAt = occuredAt;
    }
    public string Isbn { get; }
    public DateTimeOffset OccuredAt { get; }
}