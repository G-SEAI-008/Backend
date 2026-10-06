namespace ModellingTypes.Models;

public record Transaction(
    Guid Id,
    TransactionType Type,
    string Description,
    Money Amount,
    DateTimeOffset Timestamp) : IReportable
{
    public string ToReportLine()
    {
        return $"{Timestamp:yyyy-MM-dd} {Type} {Amount} {Description}";
    }
}