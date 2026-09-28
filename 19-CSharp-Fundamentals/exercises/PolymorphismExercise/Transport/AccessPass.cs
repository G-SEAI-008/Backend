namespace Transport;

public class AccessPass
{
    public string Holder { get; }

    public AccessPass(string holder)
    {
        Holder = holder;
    }

    public virtual bool Validate()
    {
        Console.WriteLine($"Validating generic access for {Holder}...");
        return true;
    }
}