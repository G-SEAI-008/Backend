using BlogApi.Models;
namespace BlogApi.Dtos.Posts;

public record PostResponseDto(Guid Id, Guid UserId, string Title, string Content, string AuthorName, DateTimeOffset PublishedAt);