using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.Posts;

// UserId is Guid? so that a missing value arrives as null and [Required] can reject it.
// With a plain Guid a missing value becomes Guid.Empty and passes [Required].
public record CreatePostDto(
    [Required, StringLength(200, MinimumLength = 1)] string Title,
    [Required, StringLength(10_000, MinimumLength = 1)] string Content);