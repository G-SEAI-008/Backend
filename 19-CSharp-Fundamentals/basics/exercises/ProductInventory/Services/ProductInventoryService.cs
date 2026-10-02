using Models;

namespace Services;


class ProductInventoryService : IProductInventoryService
{


    private readonly IList<Product> _products = new List<Product>();


    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Add(IEnumerable<Product> products)
    {
        foreach (var p in products)
        {
            _products.Add(p);
        }
    }

    public Product? FindByName(string name)
    {
        return _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Product? GetById(Guid id)
    {
        return _products.FirstOrDefault(p => p.Id == id);

    }

    public bool Remove(Guid id)
    {
        var product = GetById(id);
        if (product is null)
        {
            return false;
        }
        return _products.Remove(product);
    }
}