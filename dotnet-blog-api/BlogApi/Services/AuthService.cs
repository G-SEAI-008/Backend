using BlogApi.Dtos.Users;
using BlogApi.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogApi.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;

    public AuthService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<(IdentityResult Result, UserResponseDto? User)> RegisterAsync(RegisterDto dto)
    {

        var user = new User
        {
            Name = dto.Name,
            UserName = dto.Email,
            Email = dto.Email,
            CreatedAt = DateTimeOffset.UtcNow
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            return (result, null);
        }

        return (result, new UserResponseDto(user.Id, user.Name, user.Email, user.CreatedAt));
    }
}