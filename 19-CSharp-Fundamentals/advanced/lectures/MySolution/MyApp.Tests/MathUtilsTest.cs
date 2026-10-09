using MyApp;

public class MathUtilsTests
{
    [Fact]
    public void Average_Throws_OnNullOrEmpty()
    {
        Assert.Throws<ArgumentNullException>(() => MathUtils.Average(null!));
        Assert.Throws<ArgumentException>(() => MathUtils.Average(Array.Empty<int>()));
    }

    [Fact]
    public void Average_ReturnsExpected()
    {
        var result = MathUtils.Average(new[] { 2, 4, 6 });
        Assert.Equal(4.0, result, precision: 5);
    }
}