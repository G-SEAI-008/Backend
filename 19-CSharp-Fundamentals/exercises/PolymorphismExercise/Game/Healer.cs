namespace Game;

public class Healer : GameCharacter
{
    public Healer(string name, int level) : base(name, level) { }

    public override void UseSpecial()
    {
        Console.WriteLine($"{Name} casts Group Heal!");
    }

    public override void Describe()
    {
        Console.WriteLine($"{Name} (Level {Level}) – Keeper of vitality");
    }
}