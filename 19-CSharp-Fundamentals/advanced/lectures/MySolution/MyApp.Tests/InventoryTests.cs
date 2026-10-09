using MyApp;

public class InventoryTests
{
    [Fact]
    public void AddAndGetAll_ContainsItems_InOrder()
    {
        // Arrange
        var inv = new Inventory();

        //Act
        inv.Add("apple");
        inv.Add("banana");
        var all = inv.GetAll();
        // Assert

        Assert.Equal(2, all.Count);
        Assert.Contains("apple", all);
        Assert.DoesNotContain("cherry", all);
        Assert.Collection(all, first => Assert.Equal("apple", first), second => Assert.Equal("banana", second));
    }
}