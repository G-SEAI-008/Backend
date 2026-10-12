using Intro.Endpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TimeService>();


var app = builder.Build();

// string appName = builder.Configuration["AppName"] ?? "Default App";
// string greeting = builder.Configuration["Greeting"] ?? "Hi";


// app.Use(async (context, next) =>
// {
//     Console.WriteLine($"Handling request: {context.Request.Path}");
//     await next.Invoke();
//     Console.WriteLine($"Finished handling request");
// });

// // authorization, authentication
// // 
// app.UseStaticFiles();

// app.MapGet("/config", () =>
// {
//     Console.WriteLine($"in config");

//     return $"{appName} says: {greeting}";
// });


// app.MapGet("/user", () => "Salut Guest!");

// app.MapGet("/time", (TimeService ts) => ts.Now());




// HTTP VERB * Pfad : GET /users
// endpoints


// List<User> users = new()
// {
//     new User(Id: 1, Name : "Alice"),
//     new User(Id: 2, Name: "Karl"),
//     new User(Id: 3, Name: "Jane")
// };

// List<Post> posts =
// [
//     new Post(1, "First"),
//     new Post(2, "Second"),
//     new Post (3, "Third")
// ];


// app.MapGet("/users", ([FromServices] TimeService ts) =>
// {
//     Console.WriteLine($"{ts.Now()}");
//     ts.BeCool();
//     ts.AddStuff();

//     return users;
// });


// app.MapGet("/users/{id:int}", ([FromRoute] int id) =>

// {
//     return users.FirstOrDefault(u => u.Id == id);
// });


// app.MapPost("/users", ([FromBody] UserRequestDto dto, [FromHeader] string custom) =>
// {
//     Console.WriteLine($"{custom}");
//     users.Add(new User(users.Count + 1, dto.Name));
//     return users;
// });


// app.MapGet("/users/search", ([FromQuery] string? name) =>
// {
//     return users.Where(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
// });


// app.MapGet("/posts", () => TypedResults.Ok(posts));


// app.MapGet("/posts/{id:int}", Results<Ok<PostResponseDto>, NotFound> (int id) =>
// {
//     Post? post = posts.FirstOrDefault(p => p.Id == id);

//     if (post is null)
//     {
//         return TypedResults.NotFound();
//     }
//     else
//     {
//         return TypedResults.Ok(new PostResponseDto(post.Id, post.Title));
//     }

// });


// app.MapPost("/posts", (PostRequestDto postDto) =>
// {
//     Post newPost = new(posts.Count + 1, postDto.Title);
//     posts.Add(newPost);
//     return TypedResults.Created($"/posts/{newPost.Id}", newPost);
// });


// app.MapGet("/slow", async Task<Ok<string>> () =>
// {
//     await Task.Delay(100);
//     return TypedResults.Ok("Done");
// });

// app.MapPut("/posts/{id:int}", (int id, PostUpdateDto dto) =>
// {
//     //.....

// });

// app.MapDelete("/posts/{id:int}", (int id) =>
// {
//     // delete a post with id
// });



// var api = app.MapGroup("/api");

// api.MapGet("/users", () => TypedResults.Ok(users));



app.MapUserEndpoints();

app.Run();


// Dependency Injection

public class TimeService : ICool
{
    public string Now() => DateTime.Now.ToString("T");

    public void BeCool()
    {
        Console.WriteLine($"I am cool");
    }
}


interface ICool
{
    void BeCool();
}


static class Extension
{
    public static void AddStuff(this ICool x)
    {
        x.BeCool();
        Console.WriteLine($"yaaaays");
    }
}



record User(int Id, string Name);

record UserRequestDto(string Name);
record Post(int Id, string Title);

record PostRequestDto(string Title);

record PostResponseDto(int Id, string Title);

record PostUpdateDto(string? Title);