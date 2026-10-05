
Newspaper daily = new();

Reader readerOne = new("Karl");
Reader readerTwo = new("Hannah");

readerOne.SubscribeToNews(daily);
readerTwo.SubscribeToNews(daily);
readerOne.SubscribeToSpecialNews(daily);
readerTwo.SubscribeToSpecialNews(daily);


// daily.News += (object? sender, EventArgs e) => Console.WriteLine($"hello");


readerOne.UnsubscribeFromSpecialNews(daily);



daily.PublishNews();

// daily.PublishSpecialNews("Orca attacks sailing boat.");

class Newspaper
{
    public event EventHandler? News;

    public event EventHandler<SpecialNewsEventArgs>? SpecialNews;

    protected virtual void OnNews(EventArgs e)
    {
        News?.Invoke(this, e);
    }
    protected virtual void OnSpecialNews(SpecialNewsEventArgs e)
    {
        SpecialNews?.Invoke(this, e);
    }

    public void PublishNews()
    {
        Console.WriteLine($"Publishing News");
        OnNews(EventArgs.Empty);
    }


    public void PublishSpecialNews(string content)
    {
        OnSpecialNews(new SpecialNewsEventArgs(content));
    }

}


class Reader
{
    public string Name { get; set; } = string.Empty;

    public Reader(string name)
    {
        Name = name;
    }

    public void SubscribeToNews(Newspaper n)
    {
        n.News += Read;
    }

    public void SubscribeToSpecialNews(Newspaper n)
    {
        n.SpecialNews += ReadSpecialNews;
    }

    public void Read(object? sender, EventArgs e)
    {
        Console.WriteLine($"{Name} is reading the news");
    }

    public void ReadSpecialNews(object? sender, SpecialNewsEventArgs e)
    {
        Console.WriteLine($"{Name} is reading about {e.Content}");

    }
    public void UnsubscribeFromSpecialNews(Newspaper n)
    {
        n.SpecialNews -= ReadSpecialNews;
    }

}



class SpecialNewsEventArgs : EventArgs
{
    public string Content { get; set; } = string.Empty;

    public SpecialNewsEventArgs(string content)
    {
        Content = content;
    }
}