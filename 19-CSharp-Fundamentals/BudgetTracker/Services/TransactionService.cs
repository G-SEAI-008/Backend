using BudgetTracker.Models;

namespace BudgetTracker.Services;

public class TransactionService
{
    private readonly IStorage _storageService;


    public TransactionService(IStorage storageService)
    {
        _storageService = storageService;
    }

    public event EventHandler<TransactionAddedEventArgs>? TransactionAdded;

    public void AddTransaction(TransactionType transactionType, string description, decimal amount)

    {
        Transaction newTransaction = new Transaction(transactionType, description, amount, DateTime.UtcNow);
        _storageService.AddTransaction(newTransaction);
        OnTransactionAdded(new TransactionAddedEventArgs(newTransaction, DateTime.UtcNow));
    }

    public bool RemoveTransaction(Guid id)
    {
        return _storageService.DeleteTransaction(id);
    }


    public IEnumerable<Transaction> GenerateReport(DateOnly startDate, DateOnly endDate, TransactionType? type)
    {
        var rawList = _storageService.GetTransactionsInRange(startDate, endDate);

        if (type != null)
        {
            return rawList.Where(entry => entry.Type == type);
        }

        return rawList;
    }


    protected virtual void OnTransactionAdded(TransactionAddedEventArgs e)
    {
        TransactionAdded?.Invoke(this, e);
    }
}

