using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTimeOffset PublishedAt { get; set; }

    // foreign key
    public Guid UserId { get; set; }

    // navigation property

    public User User { get; set; } = null!;
}

