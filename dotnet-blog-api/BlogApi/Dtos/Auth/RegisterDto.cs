using System.ComponentModel.DataAnnotations;

public record RegisterDto(
    [Required, StringLength(100, MinimumLength = 1)] string Name,
    [Required, EmailAddress, StringLength(256)] string Email,
    [Required, MinLength(8)] string Password);
