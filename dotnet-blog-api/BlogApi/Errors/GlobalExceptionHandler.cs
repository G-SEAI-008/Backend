using Microsoft.AspNetCore.Diagnostics;

namespace BlogApi.Errors;

// Turns exceptions that reach the exception handler middleware into ProblemDetails responses.
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(IProblemDetailsService problemDetailsService, ILogger<GlobalExceptionHandler> logger)
    {
        _problemDetailsService = problemDetailsService;
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, title) = exception switch
        {
            ConflictException => (StatusCodes.Status409Conflict, "Conflict"),
            // Thrown by the framework, for example when the JSON body cannot be read.
            BadHttpRequestException badRequest => (badRequest.StatusCode, "Bad request"),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            _logger.LogError(exception, "Unhandled exception for {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);
        }

        httpContext.Response.StatusCode = statusCode;

        return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails =
            {
                Status = statusCode,
                Title = title,
                // Only show the message for errors we expect. A 500 message can leak internal details.
                Detail = statusCode == StatusCodes.Status500InternalServerError ? null : exception.Message
            }
        });
    }
}