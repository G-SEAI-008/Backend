
Dictionary<string, int> inventory = [];

inventory.Add("SKU-1001", 50);
inventory.Add("SKU-1002", 12);
inventory.Add("SKU-1003", 0);

inventory["SKU-1004"] = 25;
inventory["SKU-1001"] = 45;

// Console.WriteLine($"{inventory["SKU-1005"]}");

string searchSKU = "SKU-1002";
if (inventory.ContainsKey(searchSKU))
{
    Console.WriteLine($"Stock for {searchSKU}: {inventory[searchSKU]}");
}

if (inventory.TryGetValue(searchSKU, out int quantity))
{
    Console.WriteLine($"Stock for {searchSKU}: {quantity}");
}

inventory.Remove("SKU-1003");
inventory.Remove("SKU-1005");


var added = inventory.TryAdd("SKU-1001", 217);


foreach (KeyValuePair<string, int> item in inventory)
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}


foreach (var (key, value) in inventory)
{
    Console.WriteLine($"{key}");
    Console.WriteLine($"{value}");
}



Dictionary<Person, Address> personToAddress = new()
{
    {new Person(){Name = "Karl", Id = 1}, new Address() {Street ="Lindenstrasse"}}
};



foreach (KeyValuePair<Person, Address> item in personToAddress)
{
    Console.WriteLine($"{item.Key.Name}- {item.Value.Street}");
}


class Person
{
    public string Name { get; set; }

    public int Id { get; set; }
}

class Address
{
    public string Street { get; set; }
}