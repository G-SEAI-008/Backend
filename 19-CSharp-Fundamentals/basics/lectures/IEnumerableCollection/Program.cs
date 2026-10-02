InvoiceService service = new();

var lines = new List<InvoiceLine>
{
    new() {UnitPrice = 10.0m, Quantity = 2},
    new() {UnitPrice = 5.0m, Quantity = 5}
};

decimal total = service.CalculateTotal(lines);
Console.WriteLine($"Total: {total}");


ShoppingBasket basket = new();

basket.AddItem(new BasketItem { ProductId = Guid.NewGuid(), ProductName = "Apple", Price = 0.5m, Quantity = 3 });
basket.AddItem(new BasketItem { ProductId = Guid.NewGuid(), ProductName = "Banana", Price = 0.9m, Quantity = 10 });


foreach (var el in basket.Items)
{
    Console.WriteLine($"{el.ProductName} - {el.Quantity}");
}



// IEnumerable - IList

static IEnumerable<int> GenerateNumbersLazy(int count)
{
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine($"Generating lazy numbers {i}");
        yield return 1;
    }
}


var lazy = GenerateNumbersLazy(10);
foreach (var x in lazy.Take(3))
{
    Console.WriteLine($"Using {x}");
}


static List<int> GenerateNumbersEager(int count)
{
    var list = new List<int>();

    for (int i = 0; i < count; i++)
    {
        Console.WriteLine($"Eager generating {i}");
        list.Add(i);

    }
    return list;
}

var eager = GenerateNumbersEager(10);

foreach (var x in eager.Take(3))
{
    Console.WriteLine($"Using {x}");

}