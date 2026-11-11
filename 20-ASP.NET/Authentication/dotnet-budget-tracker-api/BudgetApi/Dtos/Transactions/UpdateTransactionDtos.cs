using System.ComponentModel.DataAnnotations;
using BudgetApi.Models;

namespace BudgetApi.Dtos.Transactions;

// PUT replaces the whole transaction, so every editable field is required.
public record UpdateTransactionDto(
    [Required] TransactionType? Type,
    [Required, StringLength(200, MinimumLength = 1)] string Description,
    [Range(0.01, 1_000_000)] decimal Amount,
    [Required] DateTimeOffset? Timestamp);