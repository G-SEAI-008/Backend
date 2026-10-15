using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Users;

// PUT replaces the whole resource, so every editable field is sent.
public record UpdateUserDto(
    [Required, StringLength(100, MinimumLength = 1)] string Name,
    [Required, EmailAddress, StringLength(256)] string Email);