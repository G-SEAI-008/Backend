using Models;
using Services;
using static Helpers.InputUtils;

namespace Controllers;


class ProductController
{
    private readonly IProductInventoryService _service;

    public ProductController(IProductInventoryService service)
    {
        _service = service;
    }


    public void AddProduct()
    {
        Console.WriteLine($"Add your product: ");

        string name = ReadNonEmpty("Name: ");
        decimal price = ReadDecimal("Price: ", 0, 10000000000);
        int stock = ReadInt("Stock: ", 0, 10000000);

        var existing = _service.FindByName(name);
        if (existing != null)
        {
            Console.WriteLine($"A Product with that name alread exists.");
        }

        Product newProduct = new()
        {
            Name = name,
            Price = price,
            Stock = stock
        };

        _service.Add(newProduct);
        Console.WriteLine($"Added with id: {newProduct.Id}");

        Console.Beep();

    }

    public void AddMultipleProducts()
    {
        bool ongoing = true;
        int count = 0;

        List<Product> batch = new();

        while (ongoing)
        {
            Console.Clear();
            Console.WriteLine($"Add your product:");

            string name = ReadNonEmpty("Name: ");
            decimal price = ReadDecimal("Price: ", 0, 1000000000);
            int stock = ReadInt("Stock: ", 0, 1000000);


            Product newProduct = new()
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            batch.Add(newProduct);
            count++;
            Console.WriteLine($"Have you finished: Press 'y' or 'n'");
            var userChoice = Console.ReadKey();
            if (userChoice.Key == ConsoleKey.Y)
            {
                _service.Add(batch);
                ongoing = false;
            }

        }

    }

    public void ListProduct()
    {
        var products = _service.Products;
        foreach (Product product in products)
        {
            Console.WriteLine($"""

            Id: {product.Id}
            Name: {product.Name}
            Price: {product.Price}
            Stock: {product.Stock}

        """);

        }


    }
    public void GetById()
    {
        var id = ReadId("Enter a product id: ");
        Product? product = _service.GetById(id);

        if (product is null)
        {
            Console.WriteLine($"No product found");
        }
        else
        {
            Console.WriteLine($"""

            Id: {product.Id}
            Name: {product.Name}
            Price: {product.Price}
            Stock: {product.Stock}

        """);
        }



    }
    public void RemoveById()
    {
        var id = ReadId("Enter a product id: ");

        bool removed = _service.Remove(id);
        if (removed)
        {
            Console.WriteLine($"Product removed.");
        }
        else
        {
            Console.WriteLine($"Product not found.");

        }
    }

    public void FindByName()
    {
        string? productName = ReadNonEmpty("Enter a product name: ");

        Product? product = _service.FindByName(productName);

        if (product is null)
        {
            Console.WriteLine($"Product not found.");
        }
        else
        {
            Console.WriteLine($"""

            Id: {product.Id}
            Name: {product.Name}
            Price: {product.Price}
            Stock: {product.Stock}

        """);

        }
    }

}