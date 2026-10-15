namespace BudgetTracker.Models;

public class Transaction
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTime Timestamp { get; } = DateTime.UtcNow;

    public TransactionType Type { get; set; }

    public string Description { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }


    public Transaction(TransactionType type, string description, decimal amount, DateTime transactionDate)
    {
        // todo: add validation
        Type = type;
        Description = description;
        Amount = amount;
        TransactionDate = transactionDate;
    }
}