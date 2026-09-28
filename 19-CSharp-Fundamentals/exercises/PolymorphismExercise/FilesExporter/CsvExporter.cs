namespace FilesExporter;

public class CsvExporter : Exporter
{
    public CsvExporter(string fileName) : base(fileName) { }

    public override void Export(string content)
    {
        Log("CSV");
        Console.WriteLine($"Writing comma‑separated values: {content}");
    }
}
