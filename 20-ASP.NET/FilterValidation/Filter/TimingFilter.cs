using System.Diagnostics;

public class TimingFilter : IEndpointFilter

{


    private readonly ILogger<TimingFilter> _logger;

    public TimingFilter(ILogger<TimingFilter> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {

        var stopwatch = Stopwatch.StartNew();

        var result = await next(context);

        _logger.LogInformation($"{context.HttpContext.Request.Path}, {stopwatch.ElapsedMilliseconds}");
        return result;
    }
}