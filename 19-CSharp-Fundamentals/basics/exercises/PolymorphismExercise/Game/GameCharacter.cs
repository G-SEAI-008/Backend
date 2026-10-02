namespace Game;

public class GameCharacter
{
    public string Name { get; }
    public int Level { get; }

    public GameCharacter(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public virtual void UseSpecial()
    {
        Console.WriteLine($"{Name} channels a basic surge of power.");
    }

    public virtual void Describe()
    {
        Console.WriteLine($"{Name} (Level {Level})");
    }
}
