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


        // 2)
        // Create a List<string> of words
        // Use Select() to transform each word into its length (an int)
        // Print the resulting lengths


        // 3)
        // Create a List<int> of numbers from 1 to 15
        // Use Where() to keep only even numbers, then Select() to square each one
        // Print the results (this can be chained in one statement)


        // 4)
        // Create a List<string> of movie titles
        // Use OrderBy() to sort them alphabetically
        // Use OrderByDescending() to sort them in reverse order
        // Print both results


        // 5)
        // Create a List<double> of prices
        // Use Sum(), Average(), Max(), and Min() to calculate and print each value


        // 6)
        // Create a List<int> of exam scores
        // Use Count() to get the total number of scores
        // Use Count() with a predicate to get how many scores are 60 or above (passing)
        // Print both counts


        // 7)
        // Create a List<int> of numbers
        // Use First() to get the first number greater than 50
        // Use FirstOrDefault() to try to get the first number greater than 500 (doesn't exist)
        // Use Last() and LastOrDefault() similarly
        // Print each result and explain what happens when nothing matches


        // 8)
        // Create a List<int> of ages
        // Use Any() to check if any age is under 18
        // Use All() to check if all ages are 18 or older
        // Print both boolean results


        // 9)
        // Create a List<string> with some duplicate city names
        // Use Distinct() to get only the unique cities
        // Print the resulting list


        // 10)
        // Create a List<string> of student names
        // Use GroupBy() to group them by their first letter
        // Loop through the groups and print each group's key and its members


        // 11 )
        // Create a List<(string Category, double Price)> of products
        // (or a small class if you prefer) representing items and their category
        // Use GroupBy() to group by Category, then for each group print
        // the category name and the total price of items in that group


        // 12)
        // Create a List of a simple record or tuple: (string Name, int Age)
        // Use OrderBy() on Age, then ThenBy() on Name, to sort by age first
        // and alphabetically for ties
        // Print the sorted results


        // 13)
        // Create a List<List<int>> representing groups of numbers
        // Use SelectMany() to flatten it into a single List<int>
        // Print the flattened result


        // 14)
        // Create a List<int> of numbers from 1 to 30
        // Write a LINQ expression using method syntax that gets all multiples of 3,
        // sorted descending
        // Write the same logic using query syntax (from...where...orderby...select)
        // Print both results and confirm they match


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


    }
}