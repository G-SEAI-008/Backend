using System.Collections.Concurrent;
using BlogApi.Dtos.Posts;
using BlogApi.Models;

namespace BlogApi.Services;

// Keeps posts in memory. The data is lost when the app stops.
public class PostService : IPostService
{
    private readonly ConcurrentDictionary<Guid, Post> _posts = new();
    private readonly IUserService _userService;

    // The container passes in the registered IUserService.
    public PostService(IUserService userService)
    {
        _userService = userService;
    }

    public Task<IReadOnlyList<PostResponseDto>> GetAllAsync()
    {
        IReadOnlyList<PostResponseDto> posts = _posts.Values
            .OrderByDescending(p => p.PublishedAt)
            .Select(ToDto)
            .ToList();
        return Task.FromResult(posts);
    }

    public Task<IReadOnlyList<PostResponseDto>> GetByUserAsync(Guid userId)
    {
        IReadOnlyList<PostResponseDto> posts = _posts.Values
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.PublishedAt)
            .Select(ToDto)
            .ToList();
        return Task.FromResult(posts);
    }

    public Task<PostResponseDto?> GetByIdAsync(Guid id)
    {
        var post = _posts.TryGetValue(id, out var found) ? ToDto(found) : null;
        return Task.FromResult(post);
    }

    // Returns null when the author does not exist.
    public async Task<PostResponseDto?> CreateAsync(CreatePostDto dto)
    {
        // Validation has already checked that UserId is present.
        var userId = dto.UserId!.Value;

        if (!await _userService.ExistsAsync(userId))
        {
            return null;
        }

        var post = new Post
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = dto.Title,
            Content = dto.Content,
            PublishedAt = DateTimeOffset.UtcNow
        };

        _posts[post.Id] = post;
        return ToDto(post);
    }

    public Task<PostResponseDto?> UpdateAsync(Guid id, UpdatePostDto dto)
    {
        if (!_posts.TryGetValue(id, out var post))
        {
            return Task.FromResult<PostResponseDto?>(null);
        }

        post.Title = dto.Title;
        post.Content = dto.Content;
        return Task.FromResult<PostResponseDto?>(ToDto(post));
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(_posts.TryRemove(id, out _));
    }

    public Task DeleteByUserAsync(Guid userId)
    {
        foreach (var post in _posts.Values.Where(p => p.UserId == userId))
        {
            _posts.TryRemove(post.Id, out _);
        }
        return Task.CompletedTask;
    }

    private static PostResponseDto ToDto(Post post) =>
        new(post.Id, post.UserId, post.Title, post.Content, post.PublishedAt);
}