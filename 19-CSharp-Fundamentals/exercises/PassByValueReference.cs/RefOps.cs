public class RefOps
{
    public static void Swap(ref int a, ref int b)
    {
        (a, b) = (b, a);

    }
}