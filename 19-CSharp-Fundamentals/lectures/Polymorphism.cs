


// foreach (var hero in group)
// {

//     if (hero.Type == "Warrior")
//     {
//         hero.SwingSword();
//     }
//     else if (hero.Type = "Mage")
//     {
//         hero.CastFirBall();

//     }
//     else if (hero.Type == "Archer")
//     {
//         hero.ShotArrow();
//     }
// }


List<Character> group = new()
{
    new Warrior("T"),
    new Mage("G"),
    new Archer("L")
};

foreach (var hero in group)
{
    hero.Attack();
}



public abstract class Character
{
    public string Name { get; set; }

    public int Health { get; set; }

    protected Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public abstract void Attack();

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage.");
    }
}


class Warrior : Character
{
    public Warrior(string name) : base(name, 120) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} swings a sword");
    }
}

class Mage : Character
{
    public Mage(string name) : base(name, 70) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} shoots fireball");
    }
}

class Archer : Character
{
    public Archer(string name) : base(name, 85) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} shoots an arrow");
    }


    public override void TakeDamage(int damage)
    {
        Console.WriteLine($"{Name} mitigates damage");
        base.TakeDamage(damage - 5);
    }
}