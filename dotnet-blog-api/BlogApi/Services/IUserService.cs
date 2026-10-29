using BlogApi.Dtos.Users;

namespace BlogApi.Services;

public interface IUserService
{
    Task<IReadOnlyList<UserResponseDto>> GetAllAsync();

    Task<UserResponseDto?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

}