using Microsoft.AspNetCore.Identity;

namespace BlogApi.Models;

public class User : IdentityUser<Guid>
{

    public required string Name { get; set; } = string.Empty;

    public required DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.Now;


    // navigation property
    public List<Post> Posts { get; set; } = [];
}

