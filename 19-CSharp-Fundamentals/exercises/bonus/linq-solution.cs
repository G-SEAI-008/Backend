class Program
{
    public static void Main(string[] args)
    {

        // 1)
        // Create a List<int> of numbers from 1 to 20
        // Use LINQ's Where() to get only the numbers greater than 10
        // Print the results with a foreach loop

        // Create a List<int> of numbers from 1 to 20
        // Use LINQ's Where() to get only the numbers greater than 10
        // Print the results with a foreach loop
        List<int> numbersOne = Enumerable.Range(1, 20).ToList();

        var greaterThanTen = numbersOne.Where(n => n > 10);

        foreach (int n in greaterThanTen)
        {
            Console.WriteLine(n);
        }


        // 2)
        // Create a List<string> of words
        // Use Select() to transform each word into its length (an int)
        // Print the resulting lengths

        List<string> words = new List<string> { "cat", "elephant", "dog", "hippopotamus" };

        var lengths = words.Select(w => w.Length);

        foreach (int length in lengths)
        {
            Console.WriteLine(length);
        }

        // 3)
        // Create a List<int> of numbers from 1 to 15
        // Use Where() to keep only even numbers, then Select() to square each one
        // Print the results (this can be chained in one statement)

        List<int> numbersThree = Enumerable.Range(1, 15).ToList();

        var evenSquares = numbersThree.Where(n => n % 2 == 0).Select(n => n * n);

        foreach (int result in evenSquares)
        {
            Console.WriteLine(result);
        }

        // 4)
        // Create a List<string> of movie titles
        // Use OrderBy() to sort them alphabetically
        // Use OrderByDescending() to sort them in reverse order
        // Print both results

        List<string> movies = new List<string> { "Inception", "Alien", "Zootopia", "Matrix" };

        var ascending = movies.OrderBy(m => m);
        var descending = movies.OrderByDescending(m => m);

        Console.WriteLine("Ascending:");
        foreach (string movie in ascending)
        {
            Console.WriteLine(movie);
        }

        Console.WriteLine("Descending:");
        foreach (string movie in descending)
        {
            Console.WriteLine(movie);
        }

        // 5)
        // Create a List<double> of prices
        // Use Sum(), Average(), Max(), and Min() to calculate and print each value

        List<double> prices = new List<double> { 19.99, 5.50, 42.00, 8.75, 100.00 };

        Console.WriteLine(prices.Sum());
        Console.WriteLine(prices.Average());
        Console.WriteLine(prices.Max());
        Console.WriteLine(prices.Min());

        // 6)
        // Create a List<int> of exam scores
        // Use Count() to get the total number of scores
        // Use Count() with a predicate to get how many scores are 60 or above (passing)
        // Print both counts
        List<int> scores = new List<int> { 45, 78, 92, 55, 88, 60, 33, 71 };

        int totalCount = scores.Count();
        int passingCount = scores.Count(s => s >= 60);

        Console.WriteLine($"Total scores: {totalCount}");
        Console.WriteLine($"Passing scores: {passingCount}");

        // 7)

        // Create a List<int> of numbers
        // Use First() to get the first number greater than 50
        // Use FirstOrDefault() to try to get the first number greater than 500 (doesn't exist)
        // Use Last() and LastOrDefault() similarly
        // Print each result and explain what happens when nothing matches
        List<int> numbers = new List<int> { 12, 45, 67, 89, 23, 56 };

        int firstOver50 = numbers.First(n => n > 50);
        Console.WriteLine(firstOver50); // 67

        // int firstOver100 = numbers.First(n => n > 100);

        int firstOver500 = numbers.FirstOrDefault(n => n > 500);
        Console.WriteLine(firstOver500);

        int lastOver50 = numbers.Last(n => n > 50);
        Console.WriteLine(lastOver50);

        int lastOver500 = numbers.LastOrDefault(n => n > 500);
        Console.WriteLine(lastOver500);

        // Note: First() and Last() throw an InvalidOperationException if nothing matches.
        // FirstOrDefault() and LastOrDefault() return default(T) instead (0 for int, null for reference types).}


        // 8)
        // Create a List<int> of ages
        // Use Any() to check if any age is under 18
        // Use All() to check if all ages are 18 or older
        // Print both boolean results

        List<int> ages = new List<int> { 22, 34, 19, 45, 17, 30 };

        bool anyUnder18 = ages.Any(a => a < 18);
        bool allAdults = ages.All(a => a >= 18);

        Console.WriteLine(anyUnder18);
        Console.WriteLine(allAdults);

        // 9)
        // Create a List<string> with some duplicate city names
        // Use Distinct() to get only the unique cities
        // Print the resulting list

        List<string> cities = new List<string> { "Berlin", "Paris", "Berlin", "Madrid", "Paris", "Rome" };

        var uniqueCities = cities.Distinct();

        foreach (string city in uniqueCities)
        {
            Console.WriteLine(city);
        }

        // 10)
        // Create a List<string> of student names
        // Use GroupBy() to group them by their first letter
        // Loop through the groups and print each group's key and its members

        List<string> students = new List<string>
        {
            "Anna", "Ben", "Alice", "Brian", "Catherine", "Charlie", "Amy"
        };

        var groups = students.GroupBy(s => s[0]);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Key}:");
            foreach (string name in group)
            {
                Console.WriteLine($"  - {name}");
            }
        }


        // 11 )
        // Create a List<(string Category, double Price)> of products
        // (or a small class if you prefer) representing items and their category
        // Use GroupBy() to group by Category, then for each group print
        // the category name and the total price of items in that group
        var products = new List<(string Category, double Price)>
        {
            ("Fruit", 2.50),
            ("Vegetable", 1.20),
            ("Fruit", 3.00),
            ("Dairy", 4.50),
            ("Vegetable", 0.80)
        };

        var groupedTotals = products.GroupBy(p => p.Category);

        foreach (var group in groupedTotals)
        {
            double total = group.Sum(p => p.Price);
            Console.WriteLine($"{group.Key}: {total}");
        }

        // 12)
        // Create a List of a simple record or tuple: (string Name, int Age)
        // Use OrderBy() on Age, then ThenBy() on Name, to sort by age first
        // and alphabetically for ties
        // Print the sorted results

        var people = new List<(string Name, int Age)>
        {
            ("Charlie", 30),
            ("Alice", 25),
            ("Bob", 30),
            ("Dana", 25)
        };

        var sorted = people.OrderBy(p => p.Age).ThenBy(p => p.Name);

        foreach (var person in sorted)
        {
            Console.WriteLine($"{person.Name} ({person.Age})");
        }


        // 13)
        // Create a List<List<int>> representing groups of numbers
        // Use SelectMany() to flatten it into a single List<int>
        // Print the flattened result

        List<List<int>> groups13 = new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 4, 5 },
            new List<int> { 6, 7, 8, 9 }
        };

        var flattened = groups13.SelectMany(g => g);

        foreach (int number in flattened)
        {
            Console.WriteLine(number);
        }


        // 14)
        // Create a List<int> of numbers from 1 to 30
        // Write a LINQ expression using method syntax that gets all multiples of 3,
        // sorted descending
        // Write the same logic using query syntax (from...where...orderby...select)
        // Print both results and confirm they match

        List<int> numbers14 = Enumerable.Range(1, 30).ToList();

        // Method syntax:
        var result1 = numbers14
            .Where(n => n % 3 == 0)
            .OrderByDescending(n => n);

        // Query syntax:
        var result2 =
            from n in numbers14
            where n % 3 == 0
            orderby n descending
            select n;

        Console.WriteLine("Method syntax:");
        foreach (int n in result1)
        {
            Console.WriteLine(n);
        }

        Console.WriteLine("Query syntax:");
        foreach (int n in result2)
        {
            Console.WriteLine(n);
        }


        // 15)
        // Create a List of a small class or tuple representing orders:
        // (string Customer, string Product, double Amount)
        // Write a single LINQ chain that:
        // 1. Filters orders with Amount > 20
        // 2. Groups them by Customer
        // 3. For each customer, calculates their total spend
        // 4. Orders the results by total spend descending
        // 5. Takes the top 3 customers
        // Print the customer name and total spend for each of the top 3

        var orders = new List<(string Customer, string Product, double Amount)>
        {
            ("Alice", "Book", 15.00),
            ("Bob", "Headphones", 45.00),
            ("Alice", "Lamp", 30.00),
            ("Charlie", "Chair", 60.00),
            ("Bob", "Mouse", 10.00),
            ("Alice", "Desk", 120.00),
            ("Charlie", "Monitor", 90.00),
            ("Dana", "Keyboard", 25.00)
        };

        var topCustomers = orders
            .Where(o => o.Amount > 20)
            .GroupBy(o => o.Customer)
            .Select(g => new { Customer = g.Key, TotalSpend = g.Sum(o => o.Amount) })
            .OrderByDescending(c => c.TotalSpend)
            .Take(3);

        foreach (var customer in topCustomers)
        {
            Console.WriteLine($"{customer.Customer}: {customer.TotalSpend}");
        }

    }


}