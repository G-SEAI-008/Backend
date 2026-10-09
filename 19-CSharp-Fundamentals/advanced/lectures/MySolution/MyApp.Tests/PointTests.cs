using MyApp;

public class PointTests
{
    [Fact]
    public void Records_CompareByValue_ButReferencesDiffer()
    {
        var a = new Point(1, 2);
        var b = new Point(1, 2);

        Assert.Equal(a, b);
        Assert.NotSame(a, b);

        var c = a;
        Assert.Same(a, c);

    }
}