namespace Transport;

public class MetroPass : AccessPass
{
    public int Zones { get; }

    public MetroPass(string holder, int zones) : base(holder)
    {
        Zones = zones;
    }

    public override bool Validate()
    {
        Console.WriteLine($"{Holder}: Metro zones = {Zones}");
        return Zones >= 1;
    }
}