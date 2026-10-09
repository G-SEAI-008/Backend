namespace MyApp;

public interface INoteStore
{
    Task SaveAsync(string note);
    Task<IReadOnlyList<string>> GetAllAsync();
}