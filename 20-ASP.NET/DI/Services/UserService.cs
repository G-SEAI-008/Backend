using DependencyInjection.Dtos.Users;

namespace DependencyInjection.Services;

public class UserService : IUserService
{
    public Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<UserResponseDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }
}