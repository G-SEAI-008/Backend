public class RangeChecker
{
    public bool Contains(in TemperatureRange range, double value)
    {
        // range.Max = 200;
        // range.Min = 400;
        return value >= range.Min && value <= range.Max;
    }
}