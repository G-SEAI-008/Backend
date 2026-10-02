using Models;

namespace Services;

interface IProductInventoryService
{
    public IReadOnlyCollection<Product> Products { get; }

    public void Add(Product product);

    public void Add(IEnumerable<Product> products);

    public bool Remove(Guid id);

    public Product? GetById(Guid id);

    public Product? FindByName(string name);
}

