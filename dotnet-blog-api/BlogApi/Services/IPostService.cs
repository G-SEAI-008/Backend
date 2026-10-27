using BlogApi.Dtos.Posts;

namespace BlogApi.Services;

public interface IPostService
{
    Task<IReadOnlyList<PostResponseDto>> GetAllAsync(string? search);
    Task<IReadOnlyList<PostResponseDto>> GetByUserAsync(Guid userId);
    Task<PostResponseDto?> GetByIdAsync(Guid id);
    Task<PostResponseDto?> CreateAsync(CreatePostDto dto);
    Task<PostResponseDto?> UpdateAsync(Guid id, UpdatePostDto dto);
    Task<bool> DeleteAsync(Guid id);
}