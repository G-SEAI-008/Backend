using BudgetApi.Models;

namespace BudgetApi.Dtos.Transactions;

public record CreateTransactionDto(TransactionType? Type, string Description, decimal Amount, DateOnly TransactionDate, DateTimeOffset? Timestamp);