
class Program
{

    static void Main(string[] args)
    {

        // 1) 
        // Create a class called Book with public fields: string Title, string Author, int PageCount
        // Create an instance of Book in Main, set its fields, and print them
        var firstBook = new Book
        {
            Title = "Lord of the Rings",
            Author = "Tolkien",
            PageCount = 5400
        }
        ;

        Console.WriteLine($"{firstBook.Title}");
        Console.WriteLine($"{firstBook.Author}");
        Console.WriteLine($"{firstBook.PageCount}");

        // 2)
        // Add a constructor to the Book class that takes title, author, and pageCount as parameters
        // and assigns them to the fields
        // Create two Book objects using the constructor and print their details

        var firstBook = new Book("Lord of the Rings", "Tolkien", 5400);
        var secondBook = new Book("Amerika", "Kafka", 250);

        Console.WriteLine($"{firstBook.Title}");
        Console.WriteLine($"{secondBook.Title}");

        // 3) 
        // Add a method called Summary() to the Book class that returns a string like
        // "Dune by Frank Herbert (412 pages)"
        // Call the method on a Book instance and print the result

        Book dune = new Book("Dune", "Frank Herbert", 412);
        Console.WriteLine($"{dune.Summary()}");


        // 4) Create a class called Inventory with a private int field called stockCount
        // Add a public property called StockCount with a get accessor(no set from outside)
        // Add a method AddStock(int amount) that increases stockCount if amount > 0

        Inventory inventory = new Inventory();
        inventory.AddStock(50);
        inventory.AddStock(50);
        inventory.AddStock(50);

        // 5) 
        // Add a RemoveStock(int amount) method to Inventory
        // It should only remove stock if amount > 0 and amount <= stockCount
        // Otherwise print "Not enough stock" or "Invalid amount"

        inventory.RemoveStock(32);
        inventory.RemoveStock(4232);
        Console.WriteLine($"{inventory.StockCount}");


        // 6) 
        // Create a class called Product with auto - implemented properties:
        // string Name(get/set) and double Price(get, private set)
        // Add a constructor that sets both, and try changing Price from outside the class
        // to confirm you get a compiler error
        Product product = new Product("Wireless Mouse", 24.99);
        Console.WriteLine($"{product.Name}");
        Console.WriteLine($"{product.Price}");

        product.Price = 19.99;

        // 7)
        // Create a class called Playlist with a List<string> called Songs
        // Add a method AddSong(string songName) that adds a song to the list
        // Add a method SongCount() that returns how many songs are in the playlist
        // Create a Playlist instance, add a few songs, and print the count


        Playlist playlist = new Playlist();
        playlist.AddSong("Bohemian Rhapsody");
        playlist.AddSong("Stairway to Heaven");
        playlist.AddSong("Hotel California");

        Console.WriteLine(playlist.SongCount());

        // 8)
        // Create an abstract class called Instrument with an abstract method string PlaySound()
        // Create a class Guitar that inherits from Instrument
        // and implements PlaySound() to return "Strum!"
        // Create a Guitar instance and print the result of PlaySound()

        Guitar guitar = new Guitar();
        Console.WriteLine(guitar.PlaySound());

        // 9)
        // Create an interface called IFlyable with a method void Fly()
        // Create a class called Drone that implements IFlyable
        // In Fly(), print "Drone is flying"
        // Create a Drone instance and call Fly()

        Drone drone = new Drone();
        drone.Fly();


        // 10)
        // Create a base class called Beverage with a property string Name
        // and a method Describe() that prints "This is a beverage"
        // Create a class Coffee that inherits from Beverage
        // Create a Coffee instance, set its Name, and call Describe()
        Coffee coffee = new Coffee();
        coffee.Name = "House Blend";
        coffee.Describe();


        // 11)
        // Make the Describe() method in Beverage virtual
        // Override Describe() in Coffee to print "This is a cup of coffee"
        // Create both a Beverage and a Coffee instance, call Describe() on each,
        // and observe the difference
        Beverage genericDrink = new Beverage();
        genericDrink.Describe();

        Coffee coffee = new Coffee();
        coffee.Describe();

        // 12)
        // Give Beverage a constructor that takes and sets Name
        // Give Coffee a constructor that takes name and roastLevel, calls base(name),
        // and sets a new RoastLevel property
        // Create a Coffee instance and print its Name and RoastLevel

        Coffee coffee = new Coffee("House Blend", "Dark");
        Console.WriteLine(coffee.Name);
        Console.WriteLine(coffee.RoastLevel);

        //         13)
        // Create classes Tea and Juice that also inherit from Beverage and override Describe()
        // (Tea prints "This is a cup of tea", Juice prints "This is a glass of juice")
        // Create a List < Beverage > containing a Coffee, a Tea, and a Juice
        // Loop through the list and call Describe() on each — notice each prints
        // its own version even though the list type is Beverage
        List<Beverage> drinks = new List<Beverage>
        {
            new Coffee("House Blend", "dark roast"),
            new Tea("Green Tea"),
            new Juice("Orange Juice")
        };

        foreach (Beverage drink in drinks)
        {
            drink.Describe();
        }

        // 14)
        // Add classes Piano and Drum that inherit from the abstract Instrument class
        // (from Exercise 8), each implementing PlaySound() appropriately
        // (Piano returns "Plink!", Drum returns "Boom!")
        // Create a List < Instrument > with a Guitar, Piano, and Drum
        // Loop through and print each instrument's sound using polymorphism
        List<Instrument> instruments = new List<Instrument>
        {
            new Guitar(),
            new Piano(),
            new Drum()
        };

        foreach (Instrument instrument in instruments)
        {
            Console.WriteLine(instrument.PlaySound());
        }


        //         15)
        //         Create an abstract class Task with:
        // - private field title, public property Title(get only)
        //         - private field priority, public property Priority(get only, an int 1-5)
        //         -constructor that sets both
        //         - abstract method string GetStatus()
        //         - virtual method PrintDetails() that prints Title, Priority, and the result of GetStatus()


        // Create two subclasses:
        // -UrgentTask: GetStatus() returns "Needs immediate attention"
        // - RoutineTask: GetStatus() returns "Can be scheduled normally"


        // Create a List < Task > with one UrgentTask and one RoutineTask
        // Loop through and call PrintDetails() on each
        List<Task> tasks = new List<Task>
        {
            new UrgentTask("Fix production bug", 1),
            new RoutineTask("Update documentation", 3)
        };

        foreach (Task task in tasks)
        {
            task.PrintDetails();
        }
    }
}

// Create your classes here:

public class Book
{
    public string Title;
    public string Author;
    public int PageCount;

    public Book(string title, string author, int pageCount)
    {
        Title = title;
        Author = author;
        PageCount = pageCount;
    }

    public string Summary()
    {
        return $"{Title} by {Author} ({PageCount} pages)";

    }
}

public class Inventory
{
    private int stockCount;

    public int StockCount
    {
        get { return stockCount; }
    }

    public void AddStock(int amount)
    {
        if (amount > 0)
        {
            stockCount += amount;
        }
    }

    public void RemoveStock(int amount)
    {
        if (amount > 0 && amount <= stockCount)
        {
            stockCount -= amount;

        }
        else
        {
            Console.WriteLine($"Invalid amount");
        }
    }
}


public class Product
{
    public string Name { get; set; }
    public double Price { get; private set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

}

public class Playlist
{
    public List<string> Songs = new List<string>();

    public void AddSong(string songName)
    {
        Songs.Add(songName);
    }

    public int SongCount()
    {
        return Songs.Count;
    }
}

public abstract class Instrument
{
    public abstract string PlaySound();
}

public class Guitar : Instrument
{
    public override string PlaySound()
    {
        return "Strum!";
    }
}
public class Piano : Instrument
{
    public override string PlaySound()
    {
        return "Plink!";
    }
}

public class Drum : Instrument
{
    public override string PlaySound()
    {
        return "Boom!";
    }
}


public interface IFlyable
{
    void Fly();
}

public class Drone : IFlyable
{
    public void Fly()
    {
        Console.WriteLine($"Drone is flying");
    }
}

public class Beverage
{
    public string Name { get; set; }

    public Beverage(string name)
    {
        Name = name;
    }

    public virtual void Describe()
    {
        Console.WriteLine("This is a beverage");
    }
}

public class Coffee : Beverage
{
    public string RoastLevel { get; set; }

    public Coffee(string name, string roastLevel) : base(name)
    {
        RoastLevel = roastLevel;
    }


    public override void Describe()
    {
        Console.WriteLine("This is a cup of coffee");

    }
}

public class Tea : Beverage
{
    public Tea(string name) : base(name) { }

    public override void Describe()
    {
        Console.WriteLine("This is a cup of tea");
    }
}

public class Juice : Beverage
{
    public Juice(string name) : base(name) { }

    public override void Describe()
    {
        Console.WriteLine("This is a glass of juice");
    }
}

public abstract class Task
{
    public string Title { get; }
    public int Priority { get; }

    public Task(string title, int priority)
    {
        Title = title;
        Priority = priority;
    }

    public abstract string GetStatus();

    public virtual void PrintDetails()
    {
        Console.WriteLine($"{Title} (Priority {Priority}): {GetStatus()}");
    }
}

public class UrgentTask : Task
{
    public UrgentTask(string title, int priority) : base(title, priority)
    {
    }

    public override string GetStatus()
    {
        return "Needs immediate attention";
    }
}

public class RoutineTask : Task
{
    public RoutineTask(string title, int priority) : base(title, priority)
    {
    }

    public override string GetStatus()
    {
        return "Can be scheduled normally";
    }
}
