using BookHub.Events;
using BookHub.Models;

namespace BookHub.Services;

public class CatalogService
{
    private readonly Dictionary<string, Book> _books = new();

    // add EventHandler for BookAddded
    public event EventHandler<BookAddedEventArgs>? BookAdded;
    // add EventHandler for BookRemoved
    public event EventHandler<BookRemovedEventArgs>? BookRemoved;

    public bool AddBook(Book book)
    {
        if (book is null) throw new ArgumentNullException(nameof(book));

        if (_books.ContainsKey(book.Isbn)) return false;
        _books[book.Isbn] = book;

        // trigger book added event
        OnBookAdded(new BookAddedEventArgs(book, DateTimeOffset.UtcNow));
        return true;
    }

    public bool RemoveBook(string isbn)
    {
        if (!TryGet(isbn, out Book bookToRemove)) return false;
        _books.Remove(isbn);

        // trigger book removed event
        OnBookRemoved(new BookRemovedEventArgs(isbn, DateTimeOffset.UtcNow));
        return true;
    }

    public bool UpdateBook(Book updated)
    {
        if (!_books.ContainsKey(updated.Isbn)) return false;
        _books[updated.Isbn] = updated;
        return true;
    }

    public bool TryGet(string isbn, out Book book) => _books.TryGetValue(isbn, out book!);



    protected virtual void OnBookAdded(BookAddedEventArgs e) => BookAdded?.Invoke(this, e);
    protected virtual void OnBookRemoved(BookRemovedEventArgs e) => BookRemoved?.Invoke(this, e);
}
