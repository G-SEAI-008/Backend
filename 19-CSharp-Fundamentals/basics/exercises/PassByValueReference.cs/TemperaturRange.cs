public readonly struct TemperatureRange
{
    public double Min { get; }
    public double Max { get; }

    public TemperatureRange(double min, double max)
    {
        Min = min;
        Max = max;
    }
}