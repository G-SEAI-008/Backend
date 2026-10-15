using BudgetTracker.Models;

namespace BudgetTracker.Services;

public interface IStorage
{
    public void AddTransaction(Transaction transaction);

    public bool DeleteTransaction(Guid id);

    public IReadOnlyCollection<Transaction> GetTransactionsByDate(DateOnly date);

    public IReadOnlyCollection<Transaction> GetTransactionsInRange(DateOnly startDate, DateOnly endDate);




}