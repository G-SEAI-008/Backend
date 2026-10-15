using BudgetTracker.Models;

public sealed class TransactionAddedEventArgs(Transaction transaction, DateTimeOffset timestamp) : EventArgs
{
    public Transaction Transaction { get; } = transaction;

    public DateTimeOffset TimeStamp { get; } = timestamp;
}