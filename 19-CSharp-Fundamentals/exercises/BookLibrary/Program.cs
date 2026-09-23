// while (true)
// {
//     Console.WriteLine($"Tell me something");
//     string? userInput = Console.ReadLine();

//     if (userInput != null && userInput.Equals("no", StringComparison.OrdinalIgnoreCase))
//     {
//         return;
//     }
//     Console.WriteLine($"{userInput}");

// }


// List<T>
using System.Runtime.InteropServices;

List<int> numbers = new();
numbers.Add(5);
numbers.Add(10);
List<string> names = new();

numbers.Remove(5);
numbers.Remove(3);

foreach (int num in numbers)
{
    Console.WriteLine($"{num}");

}


var persons = new List<Person>();
// List<Person> personsB = new();

persons.Add(new Person("Karl"));
persons.Add(new Person("Hannah"));


var found = persons.Find(p => p.Name.Equals("Karl", StringComparison.OrdinalIgnoreCase));
Console.WriteLine($"Found: {found?.Name} - {found?.Id}");


foreach (var person in persons)
{
    Console.WriteLine($"{person.Name} - {person.Id}");

}


class Person
{
    public string Name { get; set; } = string.Empty;
    public Guid Id { get; } = Guid.NewGuid();

    public Person(string name)
    {
        Name = name;
    }
}