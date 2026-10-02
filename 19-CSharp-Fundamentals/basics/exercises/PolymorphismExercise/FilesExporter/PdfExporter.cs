namespace FilesExporter;

public class PdfExporter : Exporter
{
    public PdfExporter(string fileName) : base(fileName) { }

    public override void Export(string content)
    {
        Log("PDF");
        Console.WriteLine($"Embedding text: {content}");
    }
}