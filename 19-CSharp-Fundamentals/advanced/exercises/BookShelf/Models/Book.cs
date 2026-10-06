// Models/Book.cs
namespace BookShelf.Models;

public record Book(string Isbn, string Title, string Author, decimal Price, int Year);