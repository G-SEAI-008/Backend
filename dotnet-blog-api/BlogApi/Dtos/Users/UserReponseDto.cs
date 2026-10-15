namespace BlogApi.Dtos.Users;

public record UserResponseDto(Guid Id, string Name, string Email, DateTimeOffset CreatedAt);