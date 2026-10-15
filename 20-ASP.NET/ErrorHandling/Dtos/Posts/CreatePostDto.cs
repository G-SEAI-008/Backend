using System.ComponentModel.DataAnnotations;
public record CreatePostDto([Required, StringLength(100, MinimumLength = 1)] string Title, [Required, StringLength(100000, MinimumLength = 1)] string Content);
