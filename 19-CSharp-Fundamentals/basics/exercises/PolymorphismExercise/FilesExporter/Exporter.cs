namespace FilesExporter;

public abstract class Exporter
{
    public string FileName { get; }

    protected Exporter(string fileName)
    {
        FileName = fileName;
    }

    public abstract void Export(string content);

    protected void Log(string kind)
    {
        Console.WriteLine($"[{kind}] -> {FileName}");
    }
}