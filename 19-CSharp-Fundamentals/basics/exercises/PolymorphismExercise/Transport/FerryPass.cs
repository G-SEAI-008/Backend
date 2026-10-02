namespace Transport;

public sealed class FerryPass : AccessPass
{
    public DateTime Expiry { get; }

    public FerryPass(string holder, DateTime expiry) : base(holder)
    {
        Expiry = expiry;
    }

    public sealed override bool Validate()
    {
        bool ok = DateTime.UtcNow <= Expiry.ToUniversalTime();
        Console.WriteLine($"{Holder}: Ferry pass valid? {ok} (expires {Expiry:yyyy-MM-dd})");
        return ok;
    }
}