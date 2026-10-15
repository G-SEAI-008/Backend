namespace BudgetApi.Models;

public class Transaction
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTimeOffset Timestamp { get; set; }

    public TransactionType Type { get; set; }

    public string Description { get; set; } = string.Empty;

    public decimal Amount { get; set; }

}