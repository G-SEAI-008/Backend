using System.Collections.Concurrent;
using BlogApi.Dtos.Users;
using BlogApi.Errors;
using BlogApi.Models;

namespace BlogApi.Services;

// Keeps users in memory. The data is lost when the app stops.
public class UserService : IUserService
{
    // ConcurrentDictionary is safe to use from several requests at the same time,
    // which matters because this service is registered as a singleton.
    private readonly ConcurrentDictionary<Guid, User> _users = new();

    public Task<IReadOnlyList<UserResponseDto>> GetAllAsync()
    {
        IReadOnlyList<UserResponseDto> users = _users.Values
            .OrderBy(u => u.CreatedAt)
            .Select(ToDto)
            .ToList();
        return Task.FromResult(users);
    }

    public Task<UserResponseDto?> GetByIdAsync(Guid id)
    {
        var user = _users.TryGetValue(id, out var found) ? ToDto(found) : null;
        return Task.FromResult(user);
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return Task.FromResult(_users.ContainsKey(id));
    }

    public Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        EnsureEmailIsFree(dto.Email, null);

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

    public Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto)
    {
        if (!_users.TryGetValue(id, out var user))
        {
            return Task.FromResult<UserResponseDto?>(null);
        }

        EnsureEmailIsFree(dto.Email!, id);

        user.Name = dto.Name!;
        user.Email = dto.Email!;
        return Task.FromResult<UserResponseDto?>(ToDto(user));
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(_users.TryRemove(id, out _));
    }

    // Throws when another user already has this email. The exception handler turns it into a 409.
    private void EnsureEmailIsFree(string email, Guid? currentUserId)
    {
        var taken = _users.Values.Any(u =>
            u.Id != currentUserId && string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));

        if (taken)
        {
            throw new ConflictException($"A user with the email '{email}' already exists.");
        }
    }

    private static UserResponseDto ToDto(User user) =>
        new(user.Id, user.Name, user.Email, user.CreatedAt);
}