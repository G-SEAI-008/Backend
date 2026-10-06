namespace ModellingTypes.Models;

public class Budget : IReportable
{
    private List<Transaction> _transactions = new();

    public string Name { get; }

    public string Currency { get; }

    public int Count => _transactions.Count;

    public Money Balance
    {
        get
        {
            var total = new Money(0m, Currency);
            foreach (var transaction in _transactions)
            {
                total = transaction.Type == TransactionType.Income ? total.Add(transaction.Amount) : total.Subtract(transaction.Amount);
            }
            return total;
        }
    }

    public Budget(string name, string currency)
    {
        Name = name;
        Currency = currency;
    }

    public void Add(Transaction transaction)
    {
        if (transaction.Amount.Currency != Currency)
        {
            throw new InvalidOperationException($"Cannot add transaction in {transaction.Amount.Currency} to budget in {Currency}");
        }

        _transactions.Add(transaction);
    }

    public string ToReportLine()
    {
        return $"Budget {Name} : {Count} transaction balance {Balance}";
    }

}