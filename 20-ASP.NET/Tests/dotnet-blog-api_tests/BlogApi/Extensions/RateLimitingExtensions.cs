using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;
using System.Threading.RateLimiting;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BlogApi.Extensions;

public static class RateLimitingExtensions
{
    public static IServiceCollection AddBlogRateLimiting(
        this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode =
                StatusCodes.Status429TooManyRequests;

            options.AddFixedWindowLimiter("fixed", limiter =>
            {
                limiter.PermitLimit = 5;
                limiter.Window = TimeSpan.FromSeconds(20);
                limiter.QueueLimit = 0;
            });

            // PER-USER
            options.AddPolicy("per-user", context =>
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey:
                    context.User.FindFirstValue(JwtRegisteredClaimNames.Sub)
                        ?? context.Connection.RemoteIpAddress?.ToString()
                        ?? "anonymous",
                factory: _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 5,
                    Window = TimeSpan.FromSeconds(20),
                    QueueLimit = 0
                }));
        });

        return services;
    }
}