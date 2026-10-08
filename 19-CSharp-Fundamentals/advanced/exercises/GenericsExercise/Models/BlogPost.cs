namespace GenericsExercise.Models;

public class BlogPost : IIdentifiable
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int Likes { get; set; }

    public override string ToString()
    {
        return $"Employee - ID: {Id} - Title: {Title} - Likes: {Likes}";
    }
}