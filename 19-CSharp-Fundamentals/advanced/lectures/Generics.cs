// Generics



List<int> numbers = new() { 1, 2, 3, 4 };
List<string> words = new() { "hello", "salut", "ciao" };


List<Dictionary<int, List<string>>>;


List<Customer> customers = new()
{
    new Customer() {Name="Karl"},
    new Customer() {Name="Hannah"}
};

List<Product> products = new()
{
    new Product(){ProductName = "Laptop"},
    new Product(){ProductName = "Apple"}
};


Repository<Customer> customerRepo = new();
Repository<Product> productRepo = new();
Repository<Monster> monsterRepo = new();
// Repository<int> intRepo = new();
// Repository<string> stringRepo = new();
// stringRepo.Add("hello");

customerRepo.Add(new Customer() { Name = "John" });

// customerRepo.Add(new Product() { ProductName = "Laptop" });

interface ICustomerRepository<Customer>
{
    IEnumerable<Customer> GetAll();
    Customer? GetById(int id);

    void Add(Customer entity);
    void Update(Customer entity);

    void Delete(Customer entity);
}
interface IProductRepository<Product>
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);

    void Add(Product entity);
    void Update(Product entity);

    void Delete(Product entity);
}


interface IRepositoy<T>
{
    IEnumerable<T> GetAll();
    T? GetById(int id);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}

class Repository<T> : IRepositoy<T> where T : class
{

    private readonly List<T> _entities = new List<T>();
    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _entities;
    }

    public T? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}


interface IEntity
{
    int Id { get; set; }
}

class Customer : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

class Product : IEntity
{
    public string? ProductName { get; set; }
    public int Id { get; set; }
}

class Monster : IEntity
{
    public int Id { get; set; }
    public string MonsterName { get; set; }
}