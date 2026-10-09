namespace MyApp;

public class PriceService
{
    public async Task<decimal> GetPriceWithVatAsync(decimal netPrice)
    {
        if (netPrice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(netPrice), "Price cannot be negative");
        }

        await Task.Delay(10);
        return Math.Round(netPrice * 1.19m, 2);
    }
}