using BlogApi.Dtos.Posts;
using BlogApi.Dtos.Users;
using BlogApi.Filters;
using BlogApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlogApi.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users")
            .WithTags("Users")
            .AddEndpointFilter<RejectEmptyIdFilter>();

        // TypedResults in the handler signatures tell OpenAPI about the success and 404 responses.
        // Responses produced outside the handler (validation, filters, exceptions) are listed by hand.
        group.MapGet("/", GetAllUsers)
            .WithName("GetAllUsers")
            .WithSummary("List all users");

        group.MapGet("/{id:guid}", GetUserById)
            .WithName("GetUserById")
            .WithSummary("Get one user by id")
            .ProducesValidationProblem();

        group.MapGet("/{id:guid}/posts", GetPostsByUser)
            .WithName("GetPostsByUser")
            .WithSummary("List the posts written by one user")
            .ProducesValidationProblem();

        return group;
    }

    // The services are injected as handler parameters.
    private static async Task<Ok<IReadOnlyList<UserResponseDto>>> GetAllUsers(IUserService userService)
    {
        return TypedResults.Ok(await userService.GetAllAsync());
    }

    private static async Task<Results<Ok<UserResponseDto>, NotFound>> GetUserById(Guid id, IUserService userService)
    {
        var user = await userService.GetByIdAsync(id);
        return user is null ? TypedResults.NotFound() : TypedResults.Ok(user);
    }

    private static async Task<Results<Ok<IReadOnlyList<PostResponseDto>>, NotFound>> GetPostsByUser(
        Guid id, IUserService userService, IPostService postService)
    {
        if (!await userService.ExistsAsync(id))
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(await postService.GetByUserAsync(id));
    }



}