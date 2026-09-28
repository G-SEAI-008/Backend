namespace FilesExporter;

public class HtmlExporter : Exporter
{
    public HtmlExporter(string fileName) : base(fileName) { }

    public override void Export(string content)
    {
        Log("HTML");
        Console.WriteLine($"<p>{content}</p>");
    }
}
