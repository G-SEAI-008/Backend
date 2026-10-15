using BudgetApi.Dtos.Transactions;
using BudgetApi.Models;
namespace BudgetApi.Dtos.Reports;

public record SummaryReportResponseDto(DateOnly StartDate, DateOnly EndDate, TransactionType? Type, decimal TotalIncome, decimal TotalExpense, decimal Net, IReadOnlyCollection<TransactionResponseDto> Transactions);
