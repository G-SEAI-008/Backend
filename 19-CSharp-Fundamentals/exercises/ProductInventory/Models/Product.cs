namespace Models;

public class Product
{
    public Guid Id { get; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required decimal Price { get; set; }

    public required int Stock { get; set; }
}