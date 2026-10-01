// Session.cs
public class Session
{
    public string Title { get; set; } = string.Empty;
    public string Track { get; set; } = string.Empty; // e.g., Backend, Frontend, Data
    public int DurationMinutes { get; set; }
    public List<string> Tags { get; set; } = new();   // e.g., ["C#", "LINQ", "Performance"]
}

