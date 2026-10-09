using System.ComponentModel.DataAnnotations;
using MyApp;

public class TemperatureConverterTests
{
    [Theory]
    [InlineData(0, 32)]
    [InlineData(100, 212)]
    public void CelsiusToFahrenheit_KnownPoints(double c, double f) => Assert.Equal(f, TemperaturConverter.CelsiusToFahrenheit(c), precision: 5);


    [Fact]
    public void CelsiusToFahrenheit_InRange()
    {
        var f = TemperaturConverter.CelsiusToFahrenheit(20);
        Assert.InRange(f, 67.9, 68.1);
    }
}