namespace Helpers;

class InputUtils
{
    public static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();
            Console.WriteLine("Please enter a non-empty value.");

        }
    }


    public static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int n) && n >= min && n <= max)
                    return n;
                Console.WriteLine($"Please enter a number between {min} and {max}.");

            }
        }
    }
    public static decimal ReadDecimal(string prompt, decimal min, decimal max)
    {
        while (true)
        {
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal n) && n >= min && n <= max)
                    return n;
                Console.WriteLine($"Please enter a number between {min} and {max}.");

            }
        }
    }
    public static Guid ReadId(string prompt)
    {
        while (true)
        {
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (Guid.TryParse(input, out Guid n))
                    return n;

                Console.WriteLine($"Please enter a valid guid. ");

            }
        }
    }

}