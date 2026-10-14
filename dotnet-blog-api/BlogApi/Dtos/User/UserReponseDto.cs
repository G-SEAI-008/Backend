namespace BlogApi.Dtos.User;

public record UserResponseDto(Guid Id, string Name, string Email, DateTimeOffset CreatedAt);