using System.Collections.Concurrent;
using BudgetApi.Dtos.Transactions;
using BudgetApi.Models;

namespace BudgetApi.Services;

// Keeps transactions in memory. The data is lost when the app stops.
public class TransactionService : ITransactionService
{
    // Safe to use from several requests at the same time, which matters for a singleton.
    private readonly ConcurrentDictionary<Guid, Transaction> _transactions = new();

    public Task<IReadOnlyList<TransactionResponseDto>> GetAllAsync()
    {
        IReadOnlyList<TransactionResponseDto> transactions = _transactions.Values
            .OrderByDescending(t => t.Timestamp)
            .Select(ToDto)
            .ToList();
        return Task.FromResult(transactions);
    }

    // Both dates are inclusive. A transaction's day is the calendar date of its own Timestamp.
    public Task<IReadOnlyList<TransactionResponseDto>> GetInRangeAsync(DateOnly start, DateOnly end)
    {
        IReadOnlyList<TransactionResponseDto> transactions = _transactions.Values
            .Where(t =>
            {
                var day = DateOnly.FromDateTime(t.Timestamp.DateTime);
                return day >= start && day <= end;
            })
            .OrderBy(t => t.Timestamp)
            .Select(ToDto)
            .ToList();
        return Task.FromResult(transactions);
    }

    public Task<TransactionResponseDto?> GetByIdAsync(Guid id)
    {
        var transaction = _transactions.TryGetValue(id, out var found) ? ToDto(found) : null;
        return Task.FromResult(transaction);
    }

    public Task<TransactionResponseDto> CreateAsync(CreateTransactionDto dto)
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Timestamp = dto.Timestamp ?? DateTimeOffset.UtcNow,
            // Validation has already checked that Type is present.
            Type = dto.Type!.Value,
            Description = dto.Description,
            Amount = dto.Amount
        };

        _transactions[transaction.Id] = transaction;
        return Task.FromResult(ToDto(transaction));
    }

    public Task<TransactionResponseDto?> UpdateAsync(Guid id, UpdateTransactionDto dto)
    {
        if (!_transactions.TryGetValue(id, out var transaction))
        {
            return Task.FromResult<TransactionResponseDto?>(null);
        }

        transaction.Type = dto.Type!.Value;
        transaction.Description = dto.Description;
        transaction.Amount = dto.Amount;
        transaction.Timestamp = dto.Timestamp!.Value;
        return Task.FromResult<TransactionResponseDto?>(ToDto(transaction));
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(_transactions.TryRemove(id, out _));
    }

    private static TransactionResponseDto ToDto(Transaction t) =>
        new(t.Id, t.Timestamp, t.Type, t.Description, t.Amount);
}