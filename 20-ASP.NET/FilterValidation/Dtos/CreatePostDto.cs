using System.ComponentModel.DataAnnotations;

public record CreatePostDto(
[Required] Guid? UserId,
[Required, StringLength(200, MinimumLength = 1)] string Title,
[Required, StringLength(10_000, MinimumLength = 1)] string Content);