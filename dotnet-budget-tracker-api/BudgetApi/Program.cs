using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// let enums use their name instead of numbers
builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
