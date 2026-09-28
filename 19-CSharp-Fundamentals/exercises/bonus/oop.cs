class Program
{

    static void Main(string[] args)
    {

        // 1) 
        // Create a class called Book with public fields: string Title, string Author, int PageCount
        // Create an instance of Book in Main, set its fields, and print them


        // 2)
        // Add a constructor to the Book class that takes title, author, and pageCount as parameters
        // and assigns them to the fields
        // Create two Book objects using the constructor and print their details

        // 3) 
        // Add a method called Summary() to the Book class that returns a string like
        // "Dune by Frank Herbert (412 pages)"
        // Call the method on a Book instance and print the result


        // 4) Create a class called Inventory with a private int field called stockCount
        // Add a public property called StockCount with a get accessor (no set from outside)
        // Add a method AddStock(int amount) that increases stockCount if amount > 0


        // 5) 
        // Add a RemoveStock(int amount) method to Inventory
        // It should only remove stock if amount > 0 and amount <= stockCount
        // Otherwise print "Not enough stock" or "Invalid amount"


        // 6) 
        // Create a class called Product with auto-implemented properties:
        // string Name (get/set) and double Price (get, private set)
        // Add a constructor that sets both, and try changing Price from outside the class
        // to confirm you get a compiler error


        //7)
        // Create a class called Playlist with a List<string> called Songs
        // Add a method AddSong(string songName) that adds a song to the list
        // Add a method SongCount() that returns how many songs are in the playlist
        // Create a Playlist instance, add a few songs, and print the count


        // 8)
        // Create an abstract class called Instrument with an abstract method string PlaySound()
        // Create a class Guitar that inherits from Instrument
        // and implements PlaySound() to return "Strum!"
        // Create a Guitar instance and print the result of PlaySound()


        // 9)
        // Create an interface called IFlyable with a method void Fly()
        // Create a class called Drone that implements IFlyable
        // In Fly(), print "Drone is flying"
        // Create a Drone instance and call Fly()


        // 10)
        // Create a base class called Beverage with a property string Name
        // and a method Describe() that prints "This is a beverage"
        // Create a class Coffee that inherits from Beverage
        // Create a Coffee instance, set its Name, and call Describe()


        // 11)
        // Make the Describe() method in Beverage virtual
        // Override Describe() in Coffee to print "This is a cup of coffee"
        // Create both a Beverage and a Coffee instance, call Describe() on each,
        // and observe the difference


        // 12)
        // Give Beverage a constructor that takes and sets Name
        // Give Coffee a constructor that takes name and roastLevel, calls base(name),
        // and sets a new RoastLevel property
        // Create a Coffee instance and print its Name and RoastLevel


        // 13)
        // Create classes Tea and Juice that also inherit from Beverage and override Describe()
        // (Tea prints "This is a cup of tea", Juice prints "This is a glass of juice")
        // Create a List<Beverage> containing a Coffee, a Tea, and a Juice
        // Loop through the list and call Describe() on each — notice each prints
        // its own version even though the list type is Beverage


        // 14)
        // Add classes Piano and Drum that inherit from the abstract Instrument class
        // (from Exercise 8), each implementing PlaySound() appropriately
        // (Piano returns "Plink!", Drum returns "Boom!")
        // Create a List<Instrument> with a Guitar, Piano, and Drum
        // Loop through and print each instrument's sound using polymorphism


        // 15)
        // Create an abstract class Task with:
        // - private field title, public property Title (get only)
        // - private field priority, public property Priority (get only, an int 1-5)
        // - constructor that sets both
        // - abstract method string GetStatus()
        // - virtual method PrintDetails() that prints Title, Priority, and the result of GetStatus()
        //
        // Create two subclasses:
        // - UrgentTask: GetStatus() returns "Needs immediate attention"
        // - RoutineTask: GetStatus() returns "Can be scheduled normally"
        //
        // Create a List<Task> with one UrgentTask and one RoutineTask
        // Loop through and call PrintDetails() on each
    }
}

// Create your classes here:
