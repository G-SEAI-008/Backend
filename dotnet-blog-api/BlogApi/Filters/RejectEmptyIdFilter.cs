namespace BlogApi.Filters;

// An endpoint filter runs before the handler and can stop the request early.
// This one rejects routes such as /users/00000000-0000-0000-0000-000000000000,
// because an empty GUID is never a valid id in this API.
public class RejectEmptyIdFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var routeValues = context.HttpContext.Request.RouteValues;

        if (routeValues.TryGetValue("id", out var value)
            && Guid.TryParse(value?.ToString(), out var id)
            && id == Guid.Empty)
        {
            return TypedResults.ValidationProblem(new Dictionary<string, string[]>
            {
                ["id"] = ["The id must not be an empty GUID."]
            });
        }

        // Nothing wrong, so pass the request on to the next filter or the handler.
        return await next(context);
    }
}