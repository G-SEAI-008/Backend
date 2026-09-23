public static class Statistics
{
    public static double Average(double a, double b, double c)
    {
        return (a + b + c) / 3;
    }

    public static double Average(double a, double b)
    {
        return (a + b) / 2;
    }


    //alternative
    public static double Average(double[] doubles)
    {
        int length = doubles.Length;
        var sum = doubles.Sum();
        return sum / length;
    }

}