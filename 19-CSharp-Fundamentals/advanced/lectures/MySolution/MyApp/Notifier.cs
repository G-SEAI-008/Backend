namespace MyApp;

public class Notifier
{
    public event EventHandler<string>? MessagePublished;

    public void Publish(string message)
    {
        MessagePublished?.Invoke(this, message);
    }
}