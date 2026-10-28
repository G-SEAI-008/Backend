using BlogApi.Data;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        if (await db.Users.AnyAsync())
        {
            return;
        }

        var now = DateTimeOffset.UtcNow;

        var ada = new User
        {
            Id = Guid.NewGuid(),
            Name = "Ada Lovelace",
            Email = "ada@example.com",
            CreatedAt = now.AddDays(-10)
        };

        var alan = new User
        {
            Id = Guid.NewGuid(),
            Name = "Alan Turing",
            Email = "alan@example.com",
            CreatedAt = now.AddDays(-5)
        };

        var posts = new List<Post>
        {
            new()
            {
                Id = Guid.NewGuid(),
                User = ada,
                Title = "Notes on the Analytical Engine",
                Content = "The engine weaves algebraic patterns just as the loom weaves flowers and leaves.",
                PublishedAt = now.AddDays(-9)
            },
            new()
            {
                Id = Guid.NewGuid(),
                User = ada,
                Title = "Why programs need testing",
                Content = "A machine does exactly what it is told, so the instructions must be right.",
                PublishedAt = now.AddDays(-3)
            },
            new()
            {
                Id = Guid.NewGuid(),
                User = alan,
                Title = "Can machines think?",
                Content = "A better question is whether a machine can do well in the imitation game.",
                PublishedAt = now.AddDays(-1)
            }

        };


        db.Users.AddRange(ada, alan);
        db.Posts.AddRange(posts);

        await db.SaveChangesAsync();
    }
}