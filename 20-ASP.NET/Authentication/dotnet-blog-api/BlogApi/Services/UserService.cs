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

        return await _db.Users.AsNoTracking().OrderBy(u => u.CreatedAt).Select(u => new UserResponseDto(u.Id, u.Name, u.Email!, u.CreatedAt)).ToListAsync();
    }

    public async Task<UserResponseDto?> GetByIdAsync(Guid id)
    {

        return await _db.Users.AsNoTracking().Where(u => u.Id == id).Select(u => new UserResponseDto(u.Id, u.Name, u.Email!, u.CreatedAt)).FirstOrDefaultAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _db.Users.AnyAsync(u => u.Id == id);

    }




    private static UserResponseDto ToDto(User user) =>
        new(user.Id, user.Name, user.Email!, user.CreatedAt);
}