using BookLibrary.Models;

class Program
{
    public static void Main(string[] args)
    {

        var books = new List<Book>();

        while (true)
        {
            Console.WriteLine($"\nLibrary Menu");
            Console.WriteLine("1) Add Book");
            Console.WriteLine("2) Get Book");
            Console.WriteLine("3) Edit Book");
            Console.WriteLine("4) Remove Book");
            Console.WriteLine("5) Exit");
            Console.Write("Choose an option (1-5): ");


            var choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    GetBook();
                    break;
                case "3":
                    EditBook();
                    break;
                case "4":
                    RemoveBook();
                    break;
                case "5":
                    Console.WriteLine($"Goodbye!");
                    return;
                default:
                    Console.WriteLine($"Invalid option. Please choose 1-5.");
                    break;
            }

        }


        void AddBook()
        {
            string title = ReadNonEmpty("Title: ");
            var existing = FindByTitle(title);
            if (existing != null)
            {
                Console.WriteLine($"A book with that title already exists. Use 'Edit Book'");
                return;
            }

            string author = ReadNonEmpty("Author: ");
            int year = ReadInt("Year: ", 0, 3000);

            books.Add(new Book(title, author, year));
            Console.WriteLine($"Book added");
        }

        void GetBook()
        {
            string title = ReadNonEmpty("Enter title to search: ");
            var book = FindByTitle(title);
            if (book is null)
            {
                Console.WriteLine($"No book found with that title");
                return;
            }
            book.DisplayInfo();
        }


        void RemoveBook()
        {
            string title = ReadNonEmpty("Enter a title to remove a book: ");
            var book = FindByTitle(title);
            if (book is null)
            {
                Console.WriteLine($"No book found with that title");
                return;
            }
            books.Remove(book);
            Console.WriteLine($"Book removed");
        }

        void EditBook()
        {
            string title = ReadNonEmpty("Enter title to edit: ");
            var book = FindByTitle(title);
            if (book is null)
            {
                Console.WriteLine($"No book found with that title.");
                return;
            }

            Console.WriteLine($"Press ENTER to keep current value");

            Console.Write($"New title [{book.Title}]: ");
            string? newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                var duplicate = FindByTitle(newTitle);
                if (duplicate != null && !ReferenceEquals(duplicate, book))
                {
                    Console.WriteLine($"Another book already has that title. Title unchanged");
                }
                else
                {
                    book.Title = newTitle.Trim();
                }
            }

            Console.Write($"New author [{book.Author}]: ");
            string? newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor))
            {
                book.Author = newAuthor.Trim();
            }


            Console.Write($"New Year [{book.Year}]:");
            string? yearInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(yearInput))
            {
                if (int.TryParse(yearInput, out int newYear) && newYear >= 0 && newYear <= 3000)
                {
                    book.Year = newYear;
                }
                else
                {
                    Console.WriteLine($"Invalid year. Year unchanged");
                }

            }
            Console.WriteLine($"Book updated.");
        }


        //helpers
        string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine($"Please enter a non-empty value.");
            }
        }


        Book? FindByTitle(string title)
        {
            return books.Find(b => b.Title.Contains(title.Trim(), StringComparison.OrdinalIgnoreCase));
        }


        int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write($"{prompt}");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int n) && n >= min && n <= max)
                {
                    return n;
                }
                Console.WriteLine($"Please enter a number between {min} and {max}");
            }
        }

    }
}
