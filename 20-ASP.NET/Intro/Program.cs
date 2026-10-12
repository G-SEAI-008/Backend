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

app.Run();


// Dependency Injection

public class TimeService
{
    public string Now() => DateTime.Now.ToString("T");
}

