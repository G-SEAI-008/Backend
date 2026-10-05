using BookHub.Events;
using BookHub.Models;

namespace BookHub.Services;

public class CatalogService
{
    private readonly Dictionary<string, Book> _books = new();

    // add EventHandler for BookAddded
    // add EventHandler for BookRemoved

    public bool AddBook(Book book)
    {
        if (book is null) throw new ArgumentNullException(nameof(book));

        if (_books.ContainsKey(book.Isbn)) return false;
        _books[book.Isbn] = book;

        // trigger book added event
        return true;
    }

    public bool RemoveBook(string isbn)
    {
        if (!TryGet(isbn, out Book bookToRemove)) return false;
        _books.Remove(isbn);

        // trigger book removed event
        return true;
    }

    public bool UpdateBook(Book updated)
    {
        if (!_books.ContainsKey(updated.Isbn)) return false;
        _books[updated.Isbn] = updated;
        return true;
    }

    public bool TryGet(string isbn, out Book book) => _books.TryGetValue(isbn, out book!);


    // add method to raise event for book added
    // add method to raise event for book removed
}
