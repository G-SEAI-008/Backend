using MyApp;

public class NoteServiceTests
{
    [Fact]
    public async Task AddAsync_TrimsAndSaves()
    {
        var store = new FakeNoteStore();
        var service = new NoteService(store);

        await service.AddAsync("  buy milk  ");
        string saved = Assert.Single(store.Saved);
        Assert.Equal("buy milk", saved);
    }

    [Fact]
    public async Task AddAsync_RejectsEmptyText_AndSavesNothing()
    {
        var store = new FakeNoteStore();
        var service = new NoteService(store);

        await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync(" "));
        Assert.Empty(store.Saved);
    }


    [Fact]
    public async Task CountAsync_ReturnsNumberOfStoredNotes()
    {
        var store = new FakeNoteStore();
        store.Saved.Add("first");
        store.Saved.Add("second");
        var service = new NoteService(store);

        Assert.Equal(2, await service.CountAsync());
    }
}