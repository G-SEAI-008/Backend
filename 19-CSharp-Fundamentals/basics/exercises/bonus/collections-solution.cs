class Program
{
    public static void Main(string[] args)
    {

        // 1)
        // Declare an int array of size 5 and assign values individually by index
        // Declare a string array using an array initializer with 4 city names
        // Print both arrays using a loop

        int[] numbers = new int[5];
        numbers[0] = 10;
        numbers[1] = 20;
        numbers[2] = 30;
        numbers[3] = 40;
        numbers[4] = 50;

        string[] cities = { "Berlin", "Paris", "Rome", "Madrid" };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        foreach (string city in cities)
        {
            Console.WriteLine(city);
        }


        // 2)
        // Declare an int array with 6 values
        // Use a for loop to double every value in the array
        // Use a foreach loop to print the resulting array
        int[] values = { 1, 2, 3, 4, 5, 6 };

        for (int i = 0; i < values.Length; i++)
        {
            values[i] *= 2;
        }

        foreach (int value in values)
        {
            Console.WriteLine(value);
        }


        // 3)
        // Declare an int array of unsorted numbers
        // Print its Length
        // Sort it using Array.Sort()
        // Reverse it using Array.Reverse()
        // Print the array after each step

        int[] scores = { 42, 17, 89, 3, 56 };
        Console.WriteLine(scores.Length); // 5

        Array.Sort(scores);
        Console.WriteLine(string.Join(", ", scores));

        Array.Reverse(scores);
        Console.WriteLine(string.Join(", ", scores));

        // 4)
        // Create a List<string> of fruits
        // Add 4 fruits using .Add()
        // Remove one fruit using .Remove()
        // Print the final list using a foreach loop

        List<string> fruits = new List<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Cherry");
        fruits.Add("Melon");

        fruits.Remove("Banana");

        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // 5)
        // Create a List<string> of programming languages
        // Check if it Contains("Python")
        // Find the IndexOf("C#")
        // Insert("Rust") at index 1
        // Print the list after each operation
        List<string> languages = new List<string> { "C#", "Java", "Python" };

        Console.WriteLine(languages.Contains("Python"));
        Console.WriteLine(languages.IndexOf("C#"));

        languages.Insert(1, "Rust");
        Console.WriteLine(string.Join(", ", languages));


        // 6)
        // Create a Dictionary<string, int> mapping product names to prices
        // Add 3 entries using .Add()
        // Print all keys and values using a foreach loop over the dictionary
        Dictionary<string, int> prices = new Dictionary<string, int>();
        prices.Add("Laptop", 1200);
        prices.Add("Mouse", 25);
        prices.Add("Keyboard", 45);

        foreach (KeyValuePair<string, int> entry in prices)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }

        // 7)
        // Using the prices dictionary from Exercise 6:
        // Try to access a key that might not exist using TryGetValue()
        // Check if a key exists using ContainsKey()
        // Update the value for an existing key
        // Print the results of each operation

        if (prices.TryGetValue("Monitor", out int monitorPrice))
        {
            Console.WriteLine($"Monitor price: {monitorPrice}");
        }
        else
        {
            Console.WriteLine("Monitor not found");
        }

        Console.WriteLine(prices.ContainsKey("Mouse"));

        prices["Mouse"] = 30;
        Console.WriteLine(prices["Mouse"]);


        // 8)
        // Create a Dictionary<string, List<string>> that maps a course name
        // to a list of enrolled student names
        // Add 2 courses, each with a few students
        // Loop through the dictionary and print each course with its students

        Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

        courses.Add("Math 101", new List<string> { "Alice", "Bob" });
        courses.Add("History 201", new List<string> { "Charlie", "Dana", "Eve" });

        foreach (KeyValuePair<string, List<string>> course in courses)
        {
            Console.WriteLine($"{course.Key}:");
            foreach (string student in course.Value)
            {
                Console.WriteLine($"  - {student}");
            }
        }


        // 9)
        // Write a method PrintAll(IEnumerable<string> items) (below the Main method) that loops through
        // and prints each item
        // Call it once with a string array and once with a List<string>
        // to show that both work because both implement IEnumerable<string>
        // 
        string[] fruitArray = { "Apple", "Banana", "Cherry" };
        List<string> fruitList = new List<string> { "Melon", "Kiwi" };

        PrintAll(fruitArray);
        PrintAll(fruitList);

        // 10)
        // Write a method GetEvenNumbers(IEnumerable<int> numbers) (below the Main methods) that returns
        // only the even numbers using yield return
        // Call it with an int array and print the results with foreach
        int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };
        foreach (int even in GetEvenNumbers(nums))
        {
            Console.WriteLine(even);
        }


        // 11)
        // Write a method AddDefaultItem(ICollection<string> items) (below the Main method) that adds
        // the string "N/A" to the collection and prints the new Count
        // Call it with a List<string> (works, since List implements ICollection)
        // Try calling it with a string[] and observe the compiler error
        // (arrays do NOT implement ICollection<T>'s Add method properly - it's fixed size)
        List<string> myList = new List<string> { "Apple", "Banana" };
        AddDefaultItem(myList);

        // string[] myArray = { "Apple", "Banana" };
        // AddDefaultItem(myArray);


        // 12)
        // Write two methods:
        // CountItemsEnumerable(IEnumerable<int> items) - counts items by iterating manually
        // CountItemsCollection(ICollection<int> items) - uses the .Count property directly
        // Call both with the same List<int> and compare how each works internally

        List<int> numberS = new List<int> { 1, 2, 3, 4, 5 };

        Console.WriteLine(CountItemsEnumerable(numberS)); // 5 (iterates manually)
        Console.WriteLine(CountItemsCollection(numberS));  // 5 (direct property access, faster)


        // 13)
        // Create a class called ShoppingCart (below the Program class) with a private List<string> called items
        // Expose a public property Items of type IReadOnlyCollection<string>
        // that returns the list (read-only view)
        // Add a method AddItem(string item) that adds to the internal list
        // Try modifying Items from outside the class and observe the compiler error


        ShoppingCart cart = new ShoppingCart();
        cart.AddItem("Milk");
        cart.AddItem("Bread");

        foreach (string item in cart.Items)
        {
            Console.WriteLine(item);
        }

        // cart.Items.Add("Eggs");
        // Compiler error: 'IReadOnlyCollection<string>' does not contain a definition for 'Add'


        // 14)
        // Write a method Summarize(IReadOnlyCollection<int> numbers) that prints
        // the Count and the sum of all numbers (using a foreach loop to sum, since
        // IReadOnlyCollection doesn't have LINQ built in without "using System.Linq")
        // Call it with both a List<int> and an int array

        List<int> listNumbers = new List<int> { 10, 20, 30 };
        int[] arrayNumbers = { 5, 15, 25 };

        Summarize(listNumbers);
        Summarize(arrayNumbers);


        // 15)
        // Create a class called Library with:
        // - a private List<string> called books
        // - a method AddBook(string title) that adds a book
        // - a method RemoveBook(string title) that removes a book if it exists
        // - a property AvailableBooks of type IReadOnlyCollection<string>
        // - a method Search(IEnumerable<string> keywords) that returns an
        //   IEnumerable<string> of books whose title contains any of the keywords
        //
        // Create a Library, add 5 books, remove 1, search for a keyword,
        // and print the AvailableBooks and search results

        Library library = new Library();
        library.AddBook("The Hobbit");
        library.AddBook("Dune");
        library.AddBook("1984");
        library.AddBook("Brave New World");
        library.AddBook("The Great Gatsby");

        library.RemoveBook("1984");

        Console.WriteLine("Available books:");
        foreach (string book in library.AvailableBooks)
        {
            Console.WriteLine($"- {book}");
        }

        Console.WriteLine("\nSearch results for 'The':");
        foreach (string result in library.Search(new List<string> { "The" }))
        {
            Console.WriteLine($"- {result}");
        }

    }
    static void PrintAll(IEnumerable<string> items)
    {
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }
    }

    static IEnumerable<int> GetEvenNumbers(IEnumerable<int> numbers)
    {
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                yield return number;
            }
        }
    }

    static void AddDefaultItem(ICollection<string> items)
    {
        items.Add("N/A");
        Console.WriteLine($"Count: {items.Count}");
    }

    static int CountItemsEnumerable(IEnumerable<int> items)
    {
        int count = 0;
        foreach (int item in items)
        {
            count++;
        }
        return count;
    }

    static int CountItemsCollection(ICollection<int> items)
    {
        return items.Count;
    }

    static void Summarize(IReadOnlyCollection<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"Count: {numbers.Count}, Sum: {sum}");
    }
}

public class ShoppingCart
{
    private List<string> items = new List<string>();

    public IReadOnlyCollection<string> Items => items;

    public void AddItem(string item)
    {
        items.Add(item);
    }
}

public class Library
{
    private List<string> books = new List<string>();

    public void AddBook(string title)
    {
        books.Add(title);
    }

    public void RemoveBook(string title)
    {
        if (books.Contains(title))
        {
            books.Remove(title);
        }
    }

    public IReadOnlyCollection<string> AvailableBooks => books;

    public IEnumerable<string> Search(IEnumerable<string> keywords)
    {
        foreach (string book in books)
        {
            foreach (string keyword in keywords)
            {
                if (book.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    yield return book;
                    break;
                }
            }
        }
    }
}