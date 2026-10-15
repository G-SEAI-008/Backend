using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Users;

public record CreateUserDto(
    [Required, StringLength(100, MinimumLength = 1)] string Name,
    [Required, EmailAddress, StringLength(256)] string Email);