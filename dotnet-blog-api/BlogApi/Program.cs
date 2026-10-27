using BlogApi.Data;
using BlogApi.Endpoints;
using BlogApi.Errors;
using BlogApi.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Validates DataAnnotations on endpoint parameters (the DTOs) before the handler runs.
// An invalid request gets a 400 response with the errors in ProblemDetails format.
builder.Services.AddValidation();

// Error responses use the ProblemDetails format (RFC 9457).
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();

// Generates an OpenAPI document that describes every endpoint.
builder.Services.AddOpenApi();

var app = builder.Build();

// Only expose the API documentation while developing.
if (app.Environment.IsDevelopment())
{
    // The OpenAPI document: /openapi/v1.json
    app.MapOpenApi();

    // Interactive API reference built from that document: /scalar
    app.MapScalarApiReference();
}

// Catches exceptions thrown later in the pipeline and passes them to GlobalExceptionHandler.
app.UseExceptionHandler();

// Adds a ProblemDetails body to error responses that have none, such as a plain 404.
app.UseStatusCodePages();

app.MapUserEndpoints();
app.MapPostEndpoints();

app.Run(); ;