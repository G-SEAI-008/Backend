using System.ComponentModel.DataAnnotations;

public record CreateEntryDto(

   [Required, StringLength(100, MinimumLength = 1)] string Title,
    [Required, StringLength(10_000, MinimumLength = 1)] string Content);