namespace BlogApi.Dtos.Auth;

public record LoginResponseDto(string Token, DateTimeOffset ExpiresAt);