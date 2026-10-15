using BudgetApi.Models;

namespace BudgetApi.Dtos.Transactions;

public record UpdateTransactionDto(TransactionType? Type, string? Description, decimal? Amount, DateTimeOffset? Timestamp);