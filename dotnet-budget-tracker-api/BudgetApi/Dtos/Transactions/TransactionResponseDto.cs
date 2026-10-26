using BudgetApi.Models;

namespace BudgetApi.Dtos.Transactions;

public record TransactionResponseDto(
    Guid Id,
    DateTimeOffset Timestamp,
    TransactionType Type,
    string Description,
    decimal Amount);