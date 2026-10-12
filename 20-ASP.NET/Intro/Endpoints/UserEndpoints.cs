namespace Intro.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users");

        group.MapGet("/", GetAllUsers);
        group.MapGet("/{id:int}", GetUserById);

        return group;
    }
    private static string[] GetAllUsers() => ["Alice", "Bob"];

    private static string GetUserById(int id) => $"User {id}";
}