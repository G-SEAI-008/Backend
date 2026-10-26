using System.ComponentModel.DataAnnotations;
using BudgetApi.Models;

namespace BudgetApi.Dtos.Transactions;

// Type is nullable so that a missing value arrives as null and [Required] can reject it.
// Timestamp is optional: when it is missing, the service uses the current time.
public record CreateTransactionDto(
    [Required] TransactionType? Type,
    [Required, StringLength(200, MinimumLength = 1)] string Description,
    [Range(0.01, 1_000_000)] decimal Amount,
    DateTimeOffset? Timestamp);