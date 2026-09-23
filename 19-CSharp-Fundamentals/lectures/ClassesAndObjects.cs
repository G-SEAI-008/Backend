
PlayerCharacter playerOne = new("abc", "karl", 100, "wizard");
var playerTwo = new PlayerCharacter("cde", "hannah", 1200, "wizard");


Console.WriteLine($"{playerOne.Health}");

playerOne.TakeDamage(50);
playerOne.Heal(100);

Console.WriteLine($"{playerOne.Health}");
// Monster monsterOne = new("lll");
// Console.WriteLine($"{monsterOne.Id}");
// Console.WriteLine($"{monsterOne.Name}");
playerOne.LevelUp();
Console.WriteLine($"{playerOne.Health}");



class PlayerCharacter
{

    public static int charactersCreated = 0;
    // fields
    private int _health = 100;

    //property
    public int Health
    {
        get => _health;
        set
        {
            if (value < 0)
            {
                _health = 0;
            }
            else if (value > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health = value;
            }
        }
    }


    public string Name { get; set; }

    public string CharacterId { get; init; }

    public int Level { get; private set; }

    public string Archetype { get; init; }

    private int _maxHealth;

    public int MaxHealth
    {
        get => _maxHealth;

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Mex Health must be greater than zero.");
            }

            _maxHealth = value;
        }
    }

    public bool IsAlive => Health > 0;

    public double HealthPercentage => ((double)Health / MaxHealth) * 100.0;




    // constructor
    public PlayerCharacter(string characterId, string name, int maxHealth, string archetype)
    {
        CharacterId = characterId;
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Level = 1;

        charactersCreated++;
    }


    public void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0) return;
        Health -= damageAmount;
        Console.WriteLine($"{Name} took {damageAmount} damage");

        if (!IsAlive)
        {
            Console.WriteLine($"{Name} has been defeated in combat");
        }

    }


    public void Heal(int healAmount)
    {
        if (!IsAlive)
        {
            Console.WriteLine($"Cannot heal {Name} because they are defeated");
            return;
        }

        if (healAmount <= 0) return;

        Health += healAmount;
        Console.WriteLine($"{Name} recovered {healAmount} HP");

    }


    public void LevelUp()
    {
        Level++;
        MaxHealth += 20;
        Health = MaxHealth;
        Console.WriteLine($"{Name} reached Level {Level}");
    }
}



class Monster
{
    public string Id { get; init; }
    public string Name { get; set; }
    public int Level { get; set; }


    public Monster(string id)
    {
        Id = id;
        Name = "Default Monster";
    }

    public Monster(string id, string name)
    {
        Id = id;
        Name = name;
    }
}