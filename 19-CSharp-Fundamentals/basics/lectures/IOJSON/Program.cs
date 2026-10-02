using System.Text.Json;
using System.Text.Json.Serialization;

DateOnly.TryParse("2026-10-01", out var parsedData);

Console.WriteLine($"{parsedData.Year}");

// File Class

// File.Exists()
// Console.WriteLine($"{File.Exists("test.txt")}");

// File.WriteAllText("example.txt", "Hello, World");
// File.AppendAllText("example.txt", "Salut!");


// File.WriteAllLines("example.txt", ["a", "b", "c", "d"]);


// Console.WriteLine($"{File.ReadAllText("example.txt")}");
// string[] content = File.ReadAllLines("example.txt");

// foreach (var line in content)
// {
//     Console.WriteLine($"{line}");
// }

// byte[] bytes = File.ReadAllBytes("example.txt");
// foreach (var b in bytes)
// {
//     Console.WriteLine($"{b}");
// }


// File.Copy(source, destination)
// File.Move(source, destination)
// File.Delete("example.txt");

// FileInfo

// var fileInfo = new FileInfo("example.txt");
// Console.WriteLine($"{fileInfo.Length}");
// Console.WriteLine($"{fileInfo.DirectoryName}");
// fileInfo.Delete();


// Directory

// Console.WriteLine($"{Directory.Exists("data")}");


// if (!Directory.Exists("data"))
// {
//     Directory.CreateDirectory("data")
// }

// Directory.CreateDirectory("data");

// Path

// var path = Path.Combine("data", "example.json");

// Console.WriteLine($"{Path.GetDirectoryName(path)}");
// Console.WriteLine($"{Path.GetExtension(path)}");
// Console.WriteLine($"{Path.GetRandomFileName()}");
// Console.WriteLine($"{Path.GetTempFileName()}");




// using var writer = new StreamWriter("log.txt", append: true);

// writer.WriteLine($"Log entry at {DateTime.Now} ");


// using var reader = new StreamReader("log.txt");

// string? line;
// while ((line = reader.ReadLine()) != null)
// {
//     Console.WriteLine($"{line}");
// }



// JSON


var person = new Person
{
    Name = "Aisha",
    Age = 30
};

var options = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(person, options);

// Console.WriteLine($"{json}");

File.WriteAllText("person.json", json);


string jsonIn = File.ReadAllText("person.json");
Console.WriteLine($"in: {jsonIn}");

var aisha = JsonSerializer.Deserialize<Person>(jsonIn);
Console.WriteLine($"check date: {aisha?.Name} - {aisha?.Age} - {aisha?.Date.Month}");



var listOfPerson = new List<Person>
{
    new() {Name ="Karl", Age = 20},
    new() {Name ="Hannah", Age = 20},
    new() {Name ="John", Age = 20},
};

var jsonPersons = JsonSerializer.Serialize(listOfPerson);

List<Person> loaded = JsonSerializer.Deserialize<List<Person>>(jsonPersons) ?? new List<Person>();


class Person
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int Age { get; set; }


    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
}


