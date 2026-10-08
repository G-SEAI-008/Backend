namespace GenericsExercise.Models;

class Employee : IIdentifiable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public override string ToString()
    {
        return $"Post - Id: {Id} - Name: {Name} - Department: {Department}";
    }
}