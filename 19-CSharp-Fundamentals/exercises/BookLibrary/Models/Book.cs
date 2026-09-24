namespace BookLibrary.Models;

public class Book
{
    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public int Year { get; set; }


    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Title} by {Author} - {Year}");
    }
}
