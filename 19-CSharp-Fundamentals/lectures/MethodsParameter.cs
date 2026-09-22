using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata;

class Program
{
    public static void Main(string[] args)
    {

        double estimatedLightYears = 14.5;
        double fuelNeeded = CalculateJumpFuel(estimatedLightYears, 5000);
        Console.WriteLine($"Fuel required: {fuelNeeded}");


        FireLaser(80);
        FireLaser(100, false);


        PlotCourse("Nebula-9");
        PlotCourse(124.5, -45.2, 89.1);


        bool isHabitable = ScanPlanet("Kepler-186f", out string atmosphereInfo);
        Console.WriteLine(isHabitable);
        Console.WriteLine(atmosphereInfo);


        int lifeSupportpower = 100;
        Console.WriteLine($"initial: {lifeSupportpower}");
        SustainDamage(ref lifeSupportpower);
        Console.WriteLine($"after Damage: {lifeSupportpower}");


    }


    static double CalculateJumpFuel(double lightyears, int shipMass)
    {
        double baseFuel = lightyears * 1.5;
        double massPenalty = shipMass * 0.02;
        return baseFuel + massPenalty;
    }


    static void FireLaser(int powerLevel, bool isStunMode = true)
    {
        if (isStunMode)
        {
            Console.WriteLine($"Firing EMP bursts at {powerLevel}");
        }
        else
        {
            Console.WriteLine($"Warning! Firing laser at {powerLevel}");
        }
    }


    // method overloading


    static void PlotCourse(string destinationName)
    {
        Console.WriteLine($"Course plotted to known location: {destinationName}");
    }

    static void PlotCourse(double x, double y, double z)
    {
        Console.WriteLine($"Calculating coordinates: X: {x}, Y: {y}, Z: {z}");
    }


    // out parameter


    static bool ScanPlanet(string planetName, out string atmosphereInfo)
    {
        if (planetName == "Kepler-186f")
        {
            atmosphereInfo = "Nitrogen-Oxygen mix. Breathable";
            return true;
        }

        atmosphereInfo = "Toxic";
        return false;
    }


    static void SustainDamage(ref int systemPower)
    {
        Console.WriteLine($"Draining power...");
        systemPower -= 40;
    }

}



class Person
{
    public static void DoSomething()
    {
        Console.WriteLine($"I do something");
    }
}