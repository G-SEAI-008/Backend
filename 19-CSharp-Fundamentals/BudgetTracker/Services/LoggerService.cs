namespace BudgetTracker.Services;

public class LoggerService
{
    private readonly string _path;



    public LoggerService(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        Directory.CreateDirectory(Path.GetDirectoryName(_path)!);

        if (!File.Exists(_path)) File.WriteAllText(_path, "");

    }

    public void OnTransactionAdded(object? sender, TransactionAddedEventArgs e)
    {
        Console.WriteLine($"Transaction added - {e.Transaction.Type} - {e.Transaction.Description} - {e.Transaction.Amount} {e.Transaction.Timestamp} ");

        LogToFile($"{e.TimeStamp} - {e.Transaction.Type} - {e.Transaction.Description} - {e.Transaction.Amount}\n");
    }

    private void LogToFile(string message)
    {
        File.AppendAllText(_path, message);
    }
}