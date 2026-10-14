namespace BlogApi.Models;

public class User
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.Now;
}