using System.ComponentModel.DataAnnotations;

namespace Documentation.Dtos;

public record BookResponseDto(int Id, string Title, string Author);

public record CreateBookDto(
    [Required, StringLength(200, MinimumLength = 1)] string Title,
    [Required, StringLength(100, MinimumLength = 1)] string Author);