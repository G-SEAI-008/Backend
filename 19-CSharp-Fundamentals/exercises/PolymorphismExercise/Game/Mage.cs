namespace Game;

public class Mage : GameCharacter
{
    public Mage(string name, int level) : base(name, level) { }

    public override void UseSpecial()
    {
        Console.WriteLine($"{Name} unleashes Arcane Burst!");
    }

    public override void Describe()
    {
        Console.WriteLine($"{Name} (Level {Level}) – Master of elements");
    }
}
