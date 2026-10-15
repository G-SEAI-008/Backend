namespace BudgetTracker.ConsoleUI;

using BudgetTracker.Models;


public class ConsoleReader()
{

    public static string ReadNonEmpty(string prompt)
    {
        Console.WriteLine($"{prompt}");

        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine($"Input cannot be empty");
            input = Console.ReadLine();
        }

        return input.Trim();
    }


    public static T ReadInput<T>(string prompt) where T : ISpanParsable<T>
    {
        Console.WriteLine($"{prompt}");
        string? input = Console.ReadLine();
        bool isValid = T.TryParse(input, null, out T? result);

        while (!isValid || result is null)
        {
            Console.WriteLine($"Please enter a valid {typeof(T).Name}: ");
            input = Console.ReadLine();
            isValid = T.TryParse(input, null, out result);
        }
        return result;

    }

    public static TransactionType ReadTransactionType()
    {
        Console.WriteLine($"Type: Income or Expense");
        string? input = Console.ReadLine();
        var validType = Enum.TryParse<TransactionType>(input, true, out TransactionType result);
        while (!validType)
        {
            Console.WriteLine($"Not a valid transaction type. Please try again.");
            input = Console.ReadLine();
            validType = Enum.TryParse<TransactionType>(input, true, out result);
        }
        return result;
    }

    public static DateOnly ReadDate()
    {
        while (true)
        {
            try
            {
                int year = ReadInput<int>("Enter a year(yyyy): ");
                int month = ReadInput<int>("Enter a month (mm): ");
                int day = ReadInput<int>("Enter a day (dd): ");

                return new DateOnly(year, month, day);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"The calendar dat entered is invalid. Please try again.");

            }
        }
    }

}