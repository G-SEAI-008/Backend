using System.Text.Json;
using BudgetTracker.Services;

namespace BudgetTracker.Models;


public class JSONStorage : IStorage
{
    private readonly string _path;

    public JSONStorage(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

        if (!File.Exists(_path)) File.WriteAllText(_path, "[]");
    }

    public void AddTransaction(Transaction newTransaction)
    {
        List<Transaction> transactions = LoadTransactions();
        transactions.Add(newTransaction);
        SaveTransactions(transactions);
    }

    public bool DeleteTransaction(Guid id)

    {
        Console.WriteLine($"{id}");

        List<Transaction> transactions = LoadTransactions();
        int countRemoved = transactions.RemoveAll(t => t.Id == id);
        Console.WriteLine($"{countRemoved}");

        SaveTransactions(transactions);

        if (countRemoved > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public IReadOnlyCollection<Transaction> GetTransactionsByDate(DateOnly date)
    {
        List<Transaction> transactions = LoadTransactions();
        return transactions.FindAll(t => DateOnly.FromDateTime(t.TransactionDate) == date);
    }

    public IReadOnlyCollection<Transaction> GetTransactionsInRange(DateOnly startDate, DateOnly endDate)
    {
        List<Transaction> transactions = LoadTransactions();
        return transactions.FindAll(t => DateOnly.FromDateTime(t.TransactionDate) >= startDate && DateOnly.FromDateTime(t.TransactionDate) <= endDate);
    }


    private List<Transaction> LoadTransactions()
    {

        try
        {
            if (!File.Exists(_path))
            {
                return new List<Transaction>();
            }

            string json = File.ReadAllText(_path);


            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Transaction>();
            }

            List<Transaction> transactions = JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
            return transactions;
        }
        catch (Exception ex) when (ex is IOException || ex is JsonException)
        {
            Console.WriteLine($"Error loading transactions {ex.Message}");
            return new List<Transaction>();

        }

    }

    private void SaveTransactions(List<Transaction> transactions)
    {
        try
        {
            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"Error saving transactions {ex.Message}");

        }
    }

}