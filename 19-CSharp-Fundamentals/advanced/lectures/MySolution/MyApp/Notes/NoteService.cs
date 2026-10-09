namespace MyApp;

public class NoteService
{
    private readonly INoteStore _store;

    public NoteService(INoteStore store)
    {
        _store = store;
    }

    public async Task AddAsync(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Note cannot be empty.", nameof(text));
        }

        await _store.SaveAsync(text.Trim());
    }

    public async Task<int> CountAsync()
    {
        var notes = await _store.GetAllAsync();
        return notes.Count;
    }
}
