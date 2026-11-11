using BudgetApi.Dtos.Reports;
using BudgetApi.Models;
using BudgetApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BudgetApi.Endpoints;

public static class ReportEndpoints
{
    public static RouteGroupBuilder MapReportEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/reports")
            .WithTags("Reports");

        group.MapGet("/summary", GetSummary)
            .WithName("GetSummary")
            .WithSummary("Totals for a date range, optionally for one type");

        return group;
    }

    private static async Task<Results<Ok<SummaryReportResponseDto>, ValidationProblem>> GetSummary(
        DateOnly start, DateOnly end, TransactionType? type, IReportService reportService)
    {
        if (start > end)
        {
            return TypedResults.ValidationProblem(new Dictionary<string, string[]>
            {
                ["end"] = ["The end date must be on or after the start date."]
            });
        }

        return TypedResults.Ok(await reportService.GetSummaryAsync(start, end, type));
    }
}