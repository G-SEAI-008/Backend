using BudgetApi.Dtos.Transactions;

namespace BudgetApi.Services;

public interface ITransactionService
{
    Task<IReadOnlyList<TransactionResponseDto>> GetAllAsync();
    Task<IReadOnlyList<TransactionResponseDto>> GetInRangeAsync(DateOnly start, DateOnly end);
    Task<TransactionResponseDto?> GetByIdAsync(Guid id);
    Task<TransactionResponseDto> CreateAsync(CreateTransactionDto dto);
    Task<TransactionResponseDto?> UpdateAsync(Guid id, UpdateTransactionDto dto);
    Task<bool> DeleteAsync(Guid id);
}