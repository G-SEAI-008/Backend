namespace BlogApi.Dtos.Posts;

public record PostResponseDto(Guid Id, Guid UserId, string Title, string Content, DateTimeOffset PublishedAt);