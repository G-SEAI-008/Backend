using BookShelf.Models;

namespace BookShelf.Services;


public class Shelf
{
    private readonly List<Book> _books;

    private readonly Action<string> _log;

    public Shelf(List<Book> Books, Action<string> log)
    {
        _books = Books;
        _log = log;
    }

    public List<Book> Find(Func<Book, bool> filter)
    {
        // var matches = new List<Book>();

        // foreach (var book in _books)
        // {
        //     if (filter(book))
        //     {
        //         matches.Add(book);
        //     }
        // }

        var matches = _books.Where(filter).ToList();

        _log($"Find: {matches.Count} of {_books.Count} books matched");
        return matches;
    }


    public decimal PriceFor(Book book, Func<decimal, decimal> pricing)
    {
        decimal price = pricing(book.Price);
        return Math.Round(price, 2);
    }

    public decimal Total(Func<decimal, decimal> pricing)
    {
        decimal total = 0m;

        foreach (var book in _books)
        {
            total += PriceFor(book, pricing);
        }

        _log($"Total: {total} for {_books.Count} books");
        return total;
    }
}
