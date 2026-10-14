using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddValidation();
builder.Services.AddProblemDetails();

var app = builder.Build();


app.MapPost("/entries", (CreateEntryDto dto) =>
{
    var entry = new JournalEntry
    {
        Id = Guid.NewGuid(),
        Title = dto.Title,
        Content = dto.Content,
        CreatedAt = DateTimeOffset.UtcNow
    };

    return TypedResults.Created($"/entries/{entry.Id}", entry);
});

app.MapGet("/entries/{take:int}", ([Range(1, 50)] int take = 10) => TypedResults.Ok(new { Take = take }));


app.MapPost("/posts", (CreatePostDto dto) =>
{
    var post = new Post()
    {
        Title = dto.Title,
        Content = dto.Content
    };

    return TypedResults.Created($"/posts/{post.Id}", post);
});

app.MapPost("/posts2", CreatePost);



var group = app.MapGroup("/users").AddEndpointFilter<RejectEmptyIdFilter>();

group.MapGet("/{id:guid}", (Guid id) =>
{
    return TypedResults.Ok(new { Id = id });
});

group.MapGet("/test", () =>
{
    TypedResults.Ok("testing");
});


var comments = app.MapGroup("/comments").AddEndpointFilter<TimingFilter>();

comments.MapGet("/", async () =>
{
    await Task.Delay(200);
    return TypedResults.Ok("Hello world");
});



app.Run();



static async Task<Results<Created<Post>, ValidationProblem>> CreatePost(CreatePostDto dto)
{
    //....
    Post? post = null;

    if (post is null)
    {
        return TypedResults.ValidationProblem(new Dictionary<string, string[]>
        {
            ["UserId"] = [$"No user exists with the id {dto.UserId}"]
        });
    }

    return TypedResults.Created($"/posts/{post.Id}", post);
}