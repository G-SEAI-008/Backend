using GenericsExercise.Models;

namespace GenericsExercise.Services;

class GenericRepository<T> where T : class, IIdentifiable
{
    private readonly Dictionary<int, T> _store = new();


    public void Add(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (_store.ContainsKey(item.Id))
        {
            throw new InvalidOperationException($"Item with Id={item.Id} already exists.");
        }
        _store[item.Id] = item;
    }

    public T? GetById(int id) => _store.TryGetValue(id, out var value) ? value : null;

    public bool Update(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (!_store.ContainsKey(item.Id)) return false;
        _store[item.Id] = item;
        return true;
    }

    public bool Delete(int id) => _store.Remove(id);

    public IEnumerable<T> GetAll() => _store.Values;
}
