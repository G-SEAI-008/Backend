using BlogApi.Endpoints;
using BlogApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.MapUserEndpoints();

app.Run();
