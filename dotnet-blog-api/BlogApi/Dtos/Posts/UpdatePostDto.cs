using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Posts;

// PUT replaces the whole resource, so every editable field is sent.
public record UpdatePostDto(
    [Required, StringLength(200, MinimumLength = 1)] string Title,
    [Required, StringLength(10_000, MinimumLength = 1)] string Content);