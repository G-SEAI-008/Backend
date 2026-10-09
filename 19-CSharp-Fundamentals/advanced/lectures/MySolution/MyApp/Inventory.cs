namespace MyApp;

public class Inventory
{
    private readonly List<string> _items = new();
    public void Add(string item) => _items.Add(item);
    public bool Remove(string item) => _items.Remove(item);

    public IReadOnlyList<string> GetAll() => _items;
}