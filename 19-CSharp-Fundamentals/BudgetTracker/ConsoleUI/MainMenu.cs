namespace BudgetTracker.ConsoleUI;

using BudgetTracker.Models;
using BudgetTracker.Services;


public class MainMenu
{


    public static void Run()
    {
        IStorage storage = new JSONStorage("data/transactions.json");

        TransactionService transactionService = new TransactionService(storage);
        LoggerService loggerService = new LoggerService("logs/transactions.log");

        transactionService.TransactionAdded += loggerService.OnTransactionAdded;


        while (true)
        {
            Console.WriteLine("""

        Transaction Services
        Please choose an option

        1) Add an transaction
        2) Remove an transaction
        3) Generate a report
        4) Exit the program

        """);


            var userChoice = Console.ReadLine()?.Trim();


            switch (userChoice)
            {
                case "1":
                    AddTransaction();
                    break;
                case "2":
                    RemoveTransaction();
                    break;
                case "3":
                    GenerateReport();
                    break;
                case "4":
                    return;

            }

        }

        void AddTransaction()
        {
            var type = ConsoleReader.ReadTransactionType();
            var description = ConsoleReader.ReadNonEmpty("Describe your transaction");
            var amount = ConsoleReader.ReadInput<Decimal>("Enter amount: ");
            transactionService.AddTransaction(type, description, amount);
        }

        void RemoveTransaction()
        {
            var id = ConsoleReader.ReadInput<Guid>("Enter a valid transaction id.");
            var removed = transactionService.RemoveTransaction(id);
            if (removed)
            {
                Console.WriteLine($"Transaction with {id} removed");
            }
            else
            {
                Console.WriteLine($"No transaction found with id {id}.");

            }
        }

        void GenerateReport()
        {

            Console.WriteLine($"Enter a StartDate");
            DateOnly startDate = ConsoleReader.ReadDate();

            Console.WriteLine($"Enter an ende Date");
            DateOnly endDate = ConsoleReader.ReadDate();


            TransactionType type = ConsoleReader.ReadTransactionType();

            var results = transactionService.GenerateReport(startDate, endDate, type);

            Console.WriteLine($"Report Results");

            foreach (Transaction r in results)
            {
                Console.WriteLine($"{r.Type.ToString()} - {r.Description} - {r.Amount}");
            }
        }

    }
}