using Models;
using Services;

namespace Service;

class ProductDB : IProductInventoryService
{
    public IReadOnlyCollection<Product> Products => throw new NotImplementedException();

    public void Add(Product product)
    {
        throw new NotImplementedException();
    }

    public void Add(IEnumerable<Product> products)
    {
        throw new NotImplementedException();
    }

    public Product? FindByName(string name)
    {
        throw new NotImplementedException();
    }

    public Product? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Guid id)
    {
        throw new NotImplementedException();
    }
}