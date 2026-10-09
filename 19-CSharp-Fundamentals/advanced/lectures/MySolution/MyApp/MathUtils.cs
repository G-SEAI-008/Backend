namespace MyApp;

public static class MathUtils
{
    public static double Average(IEnumerable<int> values)
    {
        var list = values.ToList() ?? throw new ArgumentNullException(nameof(values));
        if (list.Count == 0) throw new ArgumentException("Sequence is empty", nameof(values));
        return list.Average();
    }
}