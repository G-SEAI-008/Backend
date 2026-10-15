using BudgetApi.Dtos.Reports;
using BudgetApi.Models;

namespace BudgetApi.Services;

public class ReportService : IReportService
{
    private readonly ITransactionService _transactionService;

    public ReportService(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<SummaryReportResponseDto> GetSummaryAsync(DateOnly start, DateOnly end, TransactionType? type)
    {
        var transactions = await _transactionService.GetInRangeAsync(start, end);

        if (type is not null)
        {
            transactions = transactions.Where(t => t.Type == type).ToList();
        }

        var totalIncome = transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
        var totalExpense = transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);

        return new SummaryReportResponseDto(
            start, end, type, totalIncome, totalExpense, totalIncome - totalExpense, transactions);
    }
}