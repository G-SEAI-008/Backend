using MyApp;

public class CalculatorTests
{
    [Fact]
    public void Add_ReturnSum()
    {
        var calc = new Calculator();
        int result = calc.Add(2, 3);
        Assert.Equal(5, result);
    }


    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(0, 5, 0)]
    [InlineData(-1, 5, -5)]

    public void Multiply_WorksForManyCases(int a, int b, int expected)
    {
        var calc = new Calculator();
        int result = calc.Multiply(a, b);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    [InlineData(3, 2, 5)]
    public void Add_WorksForManyCases(int a, int b, int expected)
    {
        var calc = new Calculator();
        int result = calc.Add(a, b);
        Assert.Equal(expected, result);
    }
}