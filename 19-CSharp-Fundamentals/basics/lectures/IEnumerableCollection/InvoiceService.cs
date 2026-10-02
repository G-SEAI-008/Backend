
public class InvoiceLine
{
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}

public class InvoiceService
{
    public decimal CalculateTotal(IEnumerable<InvoiceLine> lines)
    {

        decimal total = 0m;
        foreach (var line in lines)
        {
            total += line.UnitPrice * line.Quantity;
        }
        return total;
    }
}