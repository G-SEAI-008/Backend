namespace Game;

public class Warrior : GameCharacter
{
    public Warrior(string name, int level) : base(name, level) { }

    public override void UseSpecial()
    {
        Console.WriteLine($"{Name} performs Shield Bash!");
    }

    public override void Describe()
    {
        Console.WriteLine($"{Name} (Level {Level}) – Front‑line defender");
    }
}