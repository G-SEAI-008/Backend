// DaySchedule.cs
public class DaySchedule
{
    public DateOnly Date { get; set; }
    public List<Session> Sessions { get; set; } = new();
}