using BlogApi.Dtos.Users;

namespace BlogApi.Services;

public interface IUserService
{
    Task<IReadOnlyList<UserResponseDto>> GetAllAsync();

    Task<UserResponseDto?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task<UserResponseDto> CreateAsync(CreateUserDto dto);

    Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto);

    Task<bool> DeleteAsync(Guid id);
}