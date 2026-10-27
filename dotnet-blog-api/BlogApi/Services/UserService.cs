using System.Collections.Concurrent;
using BlogApi.Data;
using BlogApi.Dtos.Users;
using BlogApi.Errors;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Services;

// Keeps users in memory. The data is lost when the app stops.
public class UserService : IUserService
{


    private readonly ApplicationDbContext _db;

    public UserService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<UserResponseDto>> GetAllAsync()
    {

        return await _db.Users.AsNoTracking().OrderBy(u => u.CreatedAt).Select(u => new UserResponseDto(u.Id, u.Name, u.Email, u.CreatedAt)).ToListAsync();
    }

    public async Task<UserResponseDto?> GetByIdAsync(Guid id)
    {

        return await _db.Users.AsNoTracking().Where(u => u.Id == id).Select(u => new UserResponseDto(u.Id, u.Name, u.Email, u.CreatedAt)).FirstOrDefaultAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _db.Users.AnyAsync(u => u.Id == id);

    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        await EnsureEmailIsFree(dto.Email, null);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Email = dto.Email,
            CreatedAt = DateTimeOffset.UtcNow
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return ToDto(user);
    }

    public async Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto)
    {

        var user = await _db.Users.FindAsync(id);
        if (user is null)
        {
            return null;
        }

        await EnsureEmailIsFree(dto.Email!, id);

        user.Name = dto.Name!;
        user.Email = dto.Email!;

        await _db.SaveChangesAsync();
        return ToDto(user);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null)
        {
            return false;
        }

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return true;
    }

    private async Task EnsureEmailIsFree(string email, Guid? currentUserId)
    {

        var normalisedEmail = email.ToLower();
        var taken = await _db.Users.AnyAsync(u => u.Id != currentUserId && u.Email.ToLower() == normalisedEmail);

        if (taken)
        {
            throw new ConflictException($"A user with the email '{email}' already exists.");
        }
    }

    private static UserResponseDto ToDto(User user) =>
        new(user.Id, user.Name, user.Email, user.CreatedAt);
}