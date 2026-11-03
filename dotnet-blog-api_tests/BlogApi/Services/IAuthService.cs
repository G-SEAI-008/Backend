using BlogApi.Dtos.Auth;
using BlogApi.Dtos.Users;
using Microsoft.AspNetCore.Identity;

namespace BlogApi.Services;

public interface IAuthService
{
    Task<(IdentityResult Result, UserResponseDto? User)> RegisterAsync(RegisterDto dto);

    Task<LoginResponseDto?> LoginAsync(LoginDto dto);
}