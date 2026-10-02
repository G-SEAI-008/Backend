
class Program
{
    public static void Main(string[] args)
    {
        // IfElse();
        // int number = 20;
        // string result = number % 2 == 0 ? "Even" : "Odd";

        Console.Write($"What is your name? ");

        string userInput = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine($"Hello Guest");
        }
        else
        {
            Console.WriteLine($"Hello ${userInput}");
        }
        // Loop();
    }



    public static void IfElse()
    {
        decimal accountBalance = 250.00m;
        decimal withdrawalAmount = 100.00m;
        bool isAccountActive = true;


        if (isAccountActive && accountBalance >= withdrawalAmount)
        {
            accountBalance -= withdrawalAmount;
            Console.WriteLine($"Withdrawal approved. Remaining balance: {accountBalance:C}");

        }
        else if (!isAccountActive)
        {
            Console.WriteLine($"Transaction declined: Account is suspended");
        }
        else
        {
            Console.WriteLine($"Transaction declined: Insufficient balance");
        }


        int userTierCode = 2;

        string tierDescription = userTierCode switch
        {
            1 => "Standard Tier: Basic account access.",
            2 => "Gold Tier: Fee waivers and 1% cash back",
            3 => "Platinum Tier: Premium support and 3% cash back",
            _ => "Invalid Tier: Contact system administrator"
        };

        Console.WriteLine($"User Status: {tierDescription}");

    }


    public static void Loop()
    {
        decimal balance = 1000.00m;
        decimal interestRate = 0.05m;

        Console.WriteLine($"5 Year Savings Projection");

        for (int year = 1; year <= 5; year++)
        {
            balance += balance * interestRate;
            Console.WriteLine($"End of Year {year}: {balance:C}");
        }


        string[] transactionTypes = { "Deposit", "Withdrawal", "Wire Transfer", "Fee Payment" };

        Console.WriteLine($"Processing Transactions");

        foreach (string transaction in transactionTypes)
        {
            Console.WriteLine($"Processing log: Transaction Type -> {transaction}");
        }

        int attempts = 0;
        int maxAttempts = 3;
        bool isConnected = false;

        Console.WriteLine($"Network Connection Attempt");

        while (!isConnected && attempts < maxAttempts)
        {
            attempts++;
            Console.WriteLine($"Attempt {attempts} of {maxAttempts} to reach server");

            if (attempts == 2)
            {
                isConnected = true;
                Console.WriteLine($"Connection successfully established");
            }
        }
    }


    public static void GuardClause()
    {
        void ProcessOrder(decimal amount, bool isVerified)
        {
            if (isVerified)
            {
                if (amount > 0)
                {
                    Console.WriteLine($"Order Processed");

                }
            }
        }

        void ProcessOrderRefactored(decimal amount, bool isVerified)
        {
            if (!isVerified) return;
            if (amount <= 0) return;

            Console.WriteLine($"Order Processed");
        }
    }
}