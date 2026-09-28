namespace Transport;

public class BikeSharePass : AccessPass
{
    public int MinutesRemaining { get; private set; }

    public BikeSharePass(string holder, int minutes) : base(holder)
    {
        MinutesRemaining = minutes;
    }

    public override bool Validate()
    {
        Console.WriteLine($"{Holder}: Bike‑share minutes = {MinutesRemaining}");
        return MinutesRemaining > 0;
    }
}