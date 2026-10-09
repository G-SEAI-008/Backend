using MyApp;

public class StringToolTests
{
    [Fact]
    public void Reverse_ReturnsExpected()
    {
        Assert.Equal("cba", StringTools.Reverse("abc"));
        Assert.NotEqual("abc", StringTools.Reverse("abc"));
    }

    [Theory]
    [InlineData("racecar", true)]
    [InlineData("RaceCar", true)]
    [InlineData("hello", false)]

    public void IsPalindrome_Works(string input, bool expected)
    {
        Assert.Equal(expected, StringTools.IsPalindrome(input));
        Assert.IsType<bool>(StringTools.IsPalindrome(input));
    }
}