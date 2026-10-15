using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddValidation();
builder.Services.AddProblemDetails();

builder.Services.AddSingleton<UserService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapPost("/posts", (CreatePostDto dto) =>
{
    Post newPost = new Post()
    {
        Title = dto.Title,
        Content = dto.Content
    };

    return TypedResults.Ok(newPost);
});


app.MapGet("/users/exists/{id:guid}", async Task<Results<Ok<string>, NotFound>> (Guid id, UserService us) =>
{
    var userExists = await us.ExistsAsync(id);
    if (userExists is false)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok("user exists");

});


app.MapGet("/custom-exception", () =>
{


// if email exists
    throw new ConflictException("Conflict");

});


app.MapGet("/server-error", () =>
{
    throw new ArgumentNullException();
});

app.Run();
