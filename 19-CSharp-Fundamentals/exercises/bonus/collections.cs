class Program
{
    public static void Main(string[] args)
    {

        // 1)
        // Declare an int array of size 5 and assign values individually by index
        // Declare a string array using an array initializer with 4 city names
        // Print both arrays using a loop


        // 2)
        // Declare an int array with 6 values
        // Use a for loop to double every value in the array
        // Use a foreach loop to print the resulting array


        // 3)
        // Declare an int array of unsorted numbers
        // Print its Length
        // Sort it using Array.Sort()
        // Reverse it using Array.Reverse()
        // Print the array after each step


        // 4)
        // Create a List<string> of fruits
        // Add 4 fruits using .Add()
        // Remove one fruit using .Remove()
        // Print the final list using a foreach loop


        // 5)
        // Create a List<string> of programming languages
        // Check if it Contains("Python")
        // Find the IndexOf("C#")
        // Insert("Rust") at index 1
        // Print the list after each operation


        // 6)
        // Create a Dictionary<string, int> mapping product names to prices
        // Add 3 entries using .Add()
        // Print all keys and values using a foreach loop over the dictionary


        // 7)
        // Using the prices dictionary from Exercise 6:
        // Try to access a key that might not exist using TryGetValue()
        // Check if a key exists using ContainsKey()
        // Update the value for an existing key
        // Print the results of each operation


        // 8)
        // Create a Dictionary<string, List<string>> that maps a course name
        // to a list of enrolled student names
        // Add 2 courses, each with a few students
        // Loop through the dictionary and print each course with its students


        // Write methods below the Main method

        // 9)
        // Write a method PrintAll(IEnumerable<string> items) that loops through
        // and prints each item
        // Call it once with a string array and once with a List<string>
        // to show that both work because both implement IEnumerable<string>


        // 10)
        // Write a method GetEvenNumbers(IEnumerable<int> numbers) that returns
        // only the even numbers using yield return
        // Call it with an int array and print the results with foreach


        // 11)
        // Write a method AddDefaultItem(ICollection<string> items) that adds
        // the string "N/A" to the collection and prints the new Count
        // Call it with a List<string> (works, since List implements ICollection)
        // Try calling it with a string[] and observe the compiler error
        // (arrays do NOT implement ICollection<T>'s Add method properly - it's fixed size)


        // 12)
        // Write two methods:
        // CountItemsEnumerable(IEnumerable<int> items) - counts items by iterating manually
        // CountItemsCollection(ICollection<int> items) - uses the .Count property directly
        // Call both with the same List<int> and compare how each works internally


        // 13)
        // Create a class called ShoppingCart (below the Program class) with a private List<string> called items
        // Expose a public property Items of type IReadOnlyCollection<string>
        // that returns the list (read-only view)
        // Add a method AddItem(string item) that adds to the internal list
        // Try modifying Items from outside the class and observe the compiler error


        // 14)
        // Write a method Summarize(IReadOnlyCollection<int> numbers) that prints
        // the Count and the sum of all numbers (using a foreach loop to sum, since
        // IReadOnlyCollection doesn't have LINQ built in without "using System.Linq")
        // Call it with both a List<int> and an int array


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

    }
}