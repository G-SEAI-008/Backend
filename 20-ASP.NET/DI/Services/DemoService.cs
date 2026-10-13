namespace DependencyInjection.Services;


public class SingletonService
{
    public Guid Id { get; } = Guid.NewGuid();
}
public class ScopedService
{
    public Guid Id { get; } = Guid.NewGuid();
}
public class TransientService
{
    public Guid Id { get; } = Guid.NewGuid();
}


public class GreetingCache
{
    private readonly ScopedService _scoped;

    public GreetingCache(ScopedService scoped)
    {
        _scoped = scoped;
    }

    public Guid ScopedId => _scoped.Id;
}


public interface IGreetingService
{
    string Greet(string name);
}

public class GreetingService : IGreetingService
{
    private readonly IConfiguration _configuration;

    private readonly ILogger<GreetingService> _logger;

    public GreetingService(IConfiguration configuration, ILogger<GreetingService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public string Greet(string name)
    {
        var greeting = _configuration["Greeting"] ?? "Hello";
        _logger.LogInformation($"Greeting {name}");
        _logger.LogError("AHHHHHHH");
        return $"{greeting}, {name}!";
    }
}