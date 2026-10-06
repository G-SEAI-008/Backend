
namespace ModellingTypes.Models;

public readonly record struct Money(decimal Amount, string Currency)
{
    public Money Add(Money other)
    {
        EnsureSameCurreny(other);
        return this with { Amount = Amount + other.Amount };
    }


    public Money Subtract(Money other)
    {
        EnsureSameCurreny(other);
        return this with { Amount = Amount - other.Amount };
    }

    public override string ToString()
    {
        return $"{Amount:F2} {Currency}";
    }


    private void EnsureSameCurreny(Money other)
    {
        if (Currency != other.Currency)
        {
            throw new InvalidOperationException($"Cannot combine {Currency} with {other.Currency}");
        }
    }
}