public class BasketItem
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}

public class ShoppingBasket
{
    private readonly List<BasketItem> _items = new();


    public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

    public void AddItem(BasketItem item)
    {
        _items.Add(item);
    }


}