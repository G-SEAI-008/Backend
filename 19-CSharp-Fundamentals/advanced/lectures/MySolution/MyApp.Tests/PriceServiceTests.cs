using MyApp;

public class PriceServiceTests
{
    [Fact]
    public async Task GetPriceWithVatAsync_AddsVat()
    {
        var service = new PriceService();
        decimal result = await service.GetPriceWithVatAsync(100m);
        Assert.Equal(119m, result);
    }

    [Fact]
    public async Task GetPriceWithVatAsync_Throws_OnNegativePrice()
    {
        var service = new PriceService();

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.GetPriceWithVatAsync(-1m));
    }
}
