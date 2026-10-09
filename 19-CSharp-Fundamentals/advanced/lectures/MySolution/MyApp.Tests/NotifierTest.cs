using MyApp;

public class NotifierTests
{
    [Fact]
    public void Publish_RaisesMessagePublishedEvents()
    {
        //arrange
        var notifier = new Notifier();
        string? received = null;
        notifier.MessagePublished += (s, msg) => received = msg;
        //act
        notifier.Publish("Hello");
        //assert
        Assert.Equal("Hello", received);
    }


    [Fact]
    public void Unsubscribe_Handler_DoesNotReceiveEvent()
    {
        var notifier = new Notifier();
        string? received = null;
        EventHandler<string> handler = (s, msg) => received = msg;
        notifier.MessagePublished += handler;
        notifier.MessagePublished -= handler;

        notifier.Publish("Hellos");

        Assert.Null(received);
    }
}