using DependencyInjection.Dtos.Users;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<PostService>();

builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddTransient<TransientService>();

// builder.Services.AddSingleton<GreetingCache>();
builder.Services.AddSingleton<IGreetingService, GreetingService>();


// AddSingleton - eine Instanz solange die App läuft

// AddScoped - eine Instanz pro http Anfrage -> DB verbinden


// AddTransient - eine Instanz pro Aufruf


var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/users", GetAllUsers);


app.MapGet("/lifetimes", (SingletonService singletonA, SingletonService singletonB, ScopedService scopedA, ScopedService scopedB, TransientService transientA, TransientService transientB) => new
{
    Singleton = new[] { singletonA.Id, singletonB.Id },
    Scoped = new[] { scopedA.Id, scopedB.Id },
    Transient = new[] { transientA.Id, transientB.Id }
});


app.MapGet("/greet/{name}", (string name, IGreetingService greetings) => greetings.Greet(name));


app.MapGet("/environment", (IWebHostEnvironment env) => new
{
    env.EnvironmentName,
    env.ApplicationName
});


app.Run();



static async Task<Ok<IReadOnlyList<UserResponseDto>>> GetAllUsers(IUserService userService)
{
    return TypedResults.Ok(await userService.GetAllAsync());
}




// app.MapGet("/captive", (GreetingCache cache) => cache.ScopedId);





// var storage = new StorageState();

// var transactionService = new TransactionService(storage);



// class TransactionService
// {
//     private readonly _storage


//        public TransactionService(Storage st)
//     {
//         _storage = st;
//     }
// }


// class Storage
// {

// }