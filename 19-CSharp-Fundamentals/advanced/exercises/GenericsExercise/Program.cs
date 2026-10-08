using GenericsExercise.Models;
using GenericsExercise.Services;
using GenericsExercise.Utils;

// 1
GenericRepository<Employee> employeeRepo = new();
GenericRepository<BlogPost> blogPostRepo = new();

employeeRepo.Add(new Employee() { Name = "Karl", Department = "IT", Id = 1 });
var employees = employeeRepo.GetAll();
var employeeOne = employeeRepo.GetById(1);
var updated = employeeRepo.Update(new Employee { Name = "Karla", Department = "IT", Id = 1 });
var deleted = employeeRepo.Delete(1);

blogPostRepo.Add(new BlogPost() { Title = "First", Id = 1, Likes = 20000 });



// 2
var pairOne = new Pair<int, string>(1, "one");
var pairTwo = new Pair<int, string>(1, "one");
Console.WriteLine($"{pairOne == pairTwo}");
pairOne.Deconstruct(out int numberA, out string wordA);
Console.WriteLine($"{numberA} - {wordA}");


var recordPairOne = new PairRecord<int, string>(1, "one");
var recordPairTwo = new PairRecord<int, string>(1, "one");
Console.WriteLine($"{recordPairOne == recordPairTwo}");
var (numberB, wordB) = recordPairOne;
Console.WriteLine($"{numberB} - {wordB}");


// 3
string partOne = "hello";
string partTwo = "world";
Swap(ref partOne, ref partTwo);
Console.WriteLine($"{partOne} {partTwo}");


// 4
Console.WriteLine($"int: {FindMax(new[] { 5, 2, 9, 1, 3 })}");
Console.WriteLine($"string: {FindMax(new[] { "apple", "pear", "banana" })}");
var people = new List<Person>
{
    new() { Name = "Lin", Age = 29 },
    new() { Name = "Mina", Age = 41 },
    new() { Name = "Zed", Age = 35 }
};
Console.WriteLine($"Person: {FindMax(people)}");


// methods
static void Swap<T>(ref T first, ref T second)
{
    (first, second) = (second, first);
}


static T FindMax<T>(IEnumerable<T> items) where T : IComparable<T>
{
    T max = items.First(); // throws InvalidOperationException for an empty sequence
    foreach (var item in items)
    {
        if (item.CompareTo(max) > 0)
        {
            max = item;
        }
    }
    return max;
}




