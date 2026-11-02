using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Auth;

public record LoginDto(
    [Required, EmailAddress] string Email,
    [Required] string Password);