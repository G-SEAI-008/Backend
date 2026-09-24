
var bookRepo = new BookRepository();
var bookDB = new BookDatabaseService();

ActingCool(new Person());
ActingCool(new Animal());

HealSomething(new Character());
HealSomething(new Drink());


void ActingCool(ICool character)
{
    character.BeingCool();
}

void HealSomething(IHeal thing)
{
    thing.Heal();
}


interface IHeal
{
    public void Heal();
}


class Character : IHeal
{
    public void Heal()
    {
        throw new NotImplementedException();
    }
}


class Drink : IHeal
{
    public void Heal()
    {
        throw new NotImplementedException();
    }
}

class Menu
{
    void Run()
    {


    }

    void AddBook(IRepository repo)
    {
        // userinput
        repo.Add();
    }
}

interface ICool
{
    void BeingCool();
}


class Person : ICool
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public void BeingCool()
    {
        Console.WriteLine($"I am cool!");
    }
}

class Animal : ICool
{
    public void BeingCool()
    {
        Console.WriteLine($"I am cool in an animal style.");
    }
}


interface IRepository
{
    void Add();
    void Get();
    void Remove();
    void Edit();
}


class BookRepository : IRepository
{
    public void Add()
    {
        throw new NotImplementedException();
    }

    public void Edit()
    {
        throw new NotImplementedException();
    }

    public void Get()
    {
        throw new NotImplementedException();
    }

    public void Remove()
    {
        throw new NotImplementedException();
    }
}


class BookDatabaseService : IRepository
{
    public void Add()
    {
        throw new NotImplementedException();
    }

    public void Edit()
    {
        throw new NotImplementedException();
    }

    public void Get()
    {
        throw new NotImplementedException();
    }

    public void Remove()
    {
        throw new NotImplementedException();
    }
}