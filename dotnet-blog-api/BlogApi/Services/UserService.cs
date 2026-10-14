using System.Collections.Concurrent;
using BlogApi.Dtos.User;
using BlogApi.Models;

namespace BlogApi.Services;

public class UserService : IUserService
{

    private readonly ConcurrentDictionary<Guid, User> _users = new();


    public Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            CreatedAt = DateTimeOffset.UtcNow
        };

        _users[user.Id] = user;

        return Task.FromResult(ToDto(user));
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(_users.TryRemove(id, out _));
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return Task.FromResult(_users.ContainsKey(id));
    }

    public Task<IReadOnlyList<UserResponseDto>> GetAllAsync()
    {
        IReadOnlyList<UserResponseDto> users = _users.Values.OrderBy(u => u.CreatedAt).Select(ToDto).ToList();
        return Task.FromResult(users);

    }

    public Task<UserResponseDto?> GetByIdAsync(Guid id)
    {
        var user = _users.TryGetValue(id, out var found) ? ToDto(found) : null;
        return Task.FromResult(user);
    }

    public Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto)
    {

        if (!_users.TryGetValue(id, out var user))
        {
            return Task.FromResult<UserResponseDto?>(null);
        }

        user.Name = dto.Name ?? user.Name;
        user.Email = dto.Email ?? user.Email;
        return Task.FromResult<UserResponseDto?>(ToDto(user));
    }

    private static UserResponseDto ToDto(User user) => new(user.Id, user.Name, user.Email, user.CreatedAt);
}