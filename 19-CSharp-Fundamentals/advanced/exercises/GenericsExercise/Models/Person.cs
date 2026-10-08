namespace GenericsExercise.Models;

public class Person : IComparable<Person>
{
    public string Name { get; init; } = "";
    public int Age { get; init; }

    public int CompareTo(Person? other)
    {
        if (other is null)
        {
            return 1;
        }
        return Age.CompareTo(other.Age);
    }

    public override string ToString() => $"{Name} ({Age})";
}