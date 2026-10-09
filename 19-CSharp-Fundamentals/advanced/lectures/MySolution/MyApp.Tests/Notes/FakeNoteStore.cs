using MyApp;

public class FakeNoteStore : INoteStore
{
    public List<string> Saved { get; } = new();

    public Task<IReadOnlyList<string>> GetAllAsync()
    {
        return Task.FromResult<IReadOnlyList<string>>(Saved);
    }

    public Task SaveAsync(string note)
    {
        Saved.Add(note);
        return Task.CompletedTask;
    }
}