using Documentation.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // app.MapScalarApiReference();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

var books = new List<BookResponseDto>
{
    new(1, "Dune", "Frank Herbert"),
    new(2, "Emma", "Jane Austen")
};

var group = app.MapGroup("/books").WithTags("Books");

group.MapGet("/", () => TypedResults.Ok(books)).WithName("GetAllBooks").WithSummary("List all books");

group.MapGet("/{id:int}", Results<Ok<BookResponseDto>, NotFound> (int id) =>
    books.FirstOrDefault(b => b.Id == id) is { } book
        ? TypedResults.Ok(book)
        : TypedResults.NotFound()).WithName("GetBookId").WithSummary("Get one book by id").WithDescription("Returns 404 when no book has this id.");

group.MapPost("/", (CreateBookDto dto) =>
{
    var book = new BookResponseDto(books.Count + 1, dto.Title, dto.Author);
    books.Add(book);
    return TypedResults.Created($"/books/{book.Id}", book);
}).WithName("CreateBook").WithSummary("Add a book").ProducesValidationProblem();


app.Run();