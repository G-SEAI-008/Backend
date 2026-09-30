Console.WriteLine($"LINQ");

List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200.00m, InStock = true },
                new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 25.50m, InStock = true },
                new Product { Id = 3, Name = "Desk Chair", Category = "Furniture", Price = 150.00m, InStock = false },
                new Product { Id = 4, Name = "Monitor", Category = "Electronics", Price = 300.00m, InStock = true },
                new Product { Id = 5, Name = "Coffee Mug", Category = "Kitchen", Price = 12.00m, InStock = true }
            };




var queryResults = products.Where(filterProduct);


bool filterProduct(Product p)
{

    return p.InStock;
}

Console.WriteLine($"\nIn Stock:");

foreach (Product p in queryResults)
{
    Console.WriteLine($"{p.Name}");
}

var queryResult2 = products.Where(p => p.InStock).OrderByDescending(p => p.Price);

Console.WriteLine($"\nOrdered and in Stock");

foreach (Product p in queryResult2)
{
    Console.WriteLine($"{p.Name}");
    Console.WriteLine($"{p.Price}");
}

Console.WriteLine($"\nProjection");
var queryResult3 = products.Where(p => p.InStock).OrderByDescending(p => p.Price).Select(p => p.Name);

foreach (string p in queryResult3)
{
    Console.WriteLine($"{p}");
}


// immediate execustion vs deferred execution

Console.WriteLine($"\nlazy query");
var lazyQuery = products.Where(p => p.Price < 50.00m);

products.Add(new Product { Id = 6, Name = "Sticky Notes", Category = "Office", Price = 3.50m, InStock = true });

foreach (var item in lazyQuery)
{
    Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");
}

Console.WriteLine($"\n eager query");


var eagerList = products.Where(p => p.Price < 50.00m).ToList();
products.Add(new Product { Id = 7, Name = "Pen", Category = "Office", Price = 1.50m, InStock = true });


foreach (var item in eagerList)
{
    Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");
}


Console.WriteLine($"\nAggregation");
bool hasExpensiveItem = products.Any(p => p.Price > 1000.00m);
decimal totalCatalogValue = products.Sum(p => p.Price);

Console.WriteLine($"{hasExpensiveItem}");
Console.WriteLine($"{totalCatalogValue}");


Console.WriteLine($"\n Grouping");

var groupedProducts = products.GroupBy(p => p.Category);

foreach (var group in groupedProducts)
{
    Console.WriteLine($"\nCategory: {group.Key} Count: {group.Count()}");

    foreach (var prod in group)
    {
        Console.WriteLine($"{prod.Name} - {prod.Price}");
    }

}



// example order

List<Order> rawOrders = new List<Order>
            {
                new Order { Id = 101, ItemName = "Wireless Headphones", CustomerType = "VIP", TotalAmount = 120.00m, IsCompleted = true , CustomerId = 1},
                new Order { Id = 102, ItemName = "USB Cable", CustomerType = "Standard", TotalAmount = 15.00m, IsCompleted = true , CustomerId = 2},
                new Order { Id = 103, ItemName = "Gaming Keypad", CustomerType = "Standard", TotalAmount = 85.00m, IsCompleted = true , CustomerId = 2},
                new Order { Id = 104, ItemName = "Mechanical Keyboard", CustomerType = "VIP", TotalAmount = 150.00m, IsCompleted = false , CustomerId = 3}, // Not completed
                new Order { Id = 105, ItemName = "4K Webcam", CustomerType = "Guest", TotalAmount = 95.00m, IsCompleted = true , CustomerId = 4}, // Guest tier
                new Order { Id = 106, ItemName = "Monitor Stand", CustomerType = "VIP", TotalAmount = 65.00m, IsCompleted = true, CustomerId = 3 }
            };


Console.WriteLine($"\n Orders");


var filterdOrders = rawOrders.Where(o => o.IsCompleted && (o.CustomerType == "Standard" || o.CustomerType == "VIP") && o.TotalAmount > 50.00m).ToList();

foreach (Order order in filterdOrders)
{
    Console.WriteLine($"{order.CustomerType} - {order.ItemName} - {order.TotalAmount}");
}


decimal totalRevenue = filterdOrders.Sum(o => o.TotalAmount);
Console.WriteLine($"\nTotal Revenue : {totalRevenue}");


Console.WriteLine($"\nGroup and sort orders");

var groupedOrders = filterdOrders.GroupBy(o => o.CustomerType);

foreach (var group in groupedOrders)
{
    Console.WriteLine($"{group.Key}");

    var sortedGroupItems = group.OrderByDescending(o => o.TotalAmount);

    foreach (var order in sortedGroupItems)
    {
        Console.WriteLine($"Order: {order.Id}: {order.ItemName} - {order.TotalAmount}");
    }

}


// join

List<Customer> customers = new()
{
    new Customer { Id = 1, Name = "Karl" },
    new Customer { Id = 2, Name = "Hannah" },
    new Customer { Id = 3, Name = "Anke" },
    new Customer { Id = 4, Name = "Kate" }
};

Console.WriteLine($"\n Join");


var customerOrders = rawOrders.Join(customers, o => o.CustomerId, c => c.Id, (o, c) => new { Item = o.ItemName, CustomerName = c.Name });

foreach (var customerOrder in customerOrders)
{
    Console.WriteLine($"{customerOrder.CustomerName} - {customerOrder.Item}");
}


Console.WriteLine($"\nGroupJoin");


var groupJoin = customers.GroupJoin(rawOrders, c => c.Id, o => o.CustomerId, (c, ol) => new { Name = c.Name, Orders = ol });


foreach (var customer in groupJoin)
{
    Console.WriteLine($"\n{customer.Name}");

    foreach (var order in customer.Orders)
    {
        Console.WriteLine($"{order.ItemName}");
        Console.WriteLine($"{order.TotalAmount}");
    }
}


var groupedOrdersByCustomerType = rawOrders.Join(customers, o => o.CustomerId, c => c.Id, (o, c) => new { Order = o.ItemName, Customer = c.Name, Type = o.CustomerType }).GroupBy(x => x.Type);


Console.WriteLine($"\n Customer Type");

foreach (var group in groupedOrdersByCustomerType)
{
    Console.WriteLine($"\n{group.Key}");
    foreach (var item in group)
    {
        Console.WriteLine($"{item.Customer} - {item.Order}");
    }

}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool InStock { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string CustomerType { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public bool IsCompleted { get; set; }

    public int CustomerId { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}



