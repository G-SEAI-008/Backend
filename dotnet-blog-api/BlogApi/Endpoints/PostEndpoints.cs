using BlogApi.Dtos.Posts;
using BlogApi.Filters;
using BlogApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlogApi.Endpoints;

public static class PostEndpoints
{
    public static RouteGroupBuilder MapPostEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/posts")
            .WithTags("Posts")
            .AddEndpointFilter<RejectEmptyIdFilter>();

        group.MapGet("/", GetAllPosts)
            .WithName("GetAllPosts")
            .WithSummary("List all posts, newest first");

        group.MapGet("/{id:guid}", GetPostById)
            .WithName("GetPostById")
            .WithSummary("Get one post by id")
            .ProducesValidationProblem();

        // CreatePost already returns ValidationProblem, so the 400 response is inferred.
        group.MapPost("/", CreatePost)
            .WithName("CreatePost")
            .WithSummary("Create a post");

        group.MapPut("/{id:guid}", UpdatePost)
            .WithName("UpdatePost")
            .WithSummary("Replace a post's title and content")
            .ProducesValidationProblem();

        group.MapDelete("/{id:guid}", DeletePost)
            .WithName("DeletePost")
            .WithSummary("Delete a post")
            .ProducesValidationProblem();

        return group;
    }

    private static async Task<Ok<IReadOnlyList<PostResponseDto>>> GetAllPosts(string? search, IPostService postService)
    {
        return TypedResults.Ok(await postService.GetAllAsync(search));
    }

    private static async Task<Results<Ok<PostResponseDto>, NotFound>> GetPostById(Guid id, IPostService postService)
    {
        var post = await postService.GetByIdAsync(id);
        return post is null ? TypedResults.NotFound() : TypedResults.Ok(post);
    }

    // The DTO is validated before this handler runs. An invalid body gets a 400 response
    // and the handler is never called.
    private static async Task<Results<Created<PostResponseDto>, ValidationProblem>> CreatePost(
        CreatePostDto dto, IPostService postService)
    {
        var post = await postService.CreateAsync(dto);
        if (post is null)
        {
            return TypedResults.ValidationProblem(new Dictionary<string, string[]>
            {
                ["UserId"] = [$"No user exists with the id '{dto.UserId}'."]
            });
        }

        return TypedResults.Created($"/posts/{post.Id}", post);
    }

    private static async Task<Results<Ok<PostResponseDto>, NotFound>> UpdatePost(
        Guid id, UpdatePostDto dto, IPostService postService)
    {
        var post = await postService.UpdateAsync(id, dto);
        return post is null ? TypedResults.NotFound() : TypedResults.Ok(post);
    }

    private static async Task<Results<NoContent, NotFound>> DeletePost(Guid id, IPostService postService)
    {
        return await postService.DeleteAsync(id) ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}