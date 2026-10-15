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

        group.MapPost("/", CreateUser)
            .WithName("CreateUser")
            .WithSummary("Create a user")
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status409Conflict);

        group.MapPut("/{id:guid}", UpdateUser)
            .WithName("UpdateUser")
            .WithSummary("Replace a user's name and email")
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status409Conflict);

        group.MapDelete("/{id:guid}", DeleteUser)
            .WithName("DeleteUser")
            .WithSummary("Delete a user and their posts")
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

    private static async Task<Created<UserResponseDto>> CreateUser(CreateUserDto dto, IUserService userService)
    {
        var user = await userService.CreateAsync(dto);
        return TypedResults.Created($"/users/{user.Id}", user);
    }

    private static async Task<Results<Ok<UserResponseDto>, NotFound>> UpdateUser(
        Guid id, UpdateUserDto dto, IUserService userService)
    {
        var user = await userService.UpdateAsync(id, dto);
        return user is null ? TypedResults.NotFound() : TypedResults.Ok(user);
    }

    private static async Task<Results<NoContent, NotFound>> DeleteUser(
        Guid id, IUserService userService, IPostService postService)
    {
        if (!await userService.ExistsAsync(id))
        {
            return TypedResults.NotFound();
        }

        // Remove the user's posts first so no post points to a missing user.
        // Once the data lives in a database, cascade delete does this for us.
        await postService.DeleteByUserAsync(id);
        await userService.DeleteAsync(id);
        return TypedResults.NoContent();
    }
}