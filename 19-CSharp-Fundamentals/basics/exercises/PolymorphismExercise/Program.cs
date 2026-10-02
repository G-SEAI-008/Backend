using FilesExporter;
using Game;
using Transport;

// GameCharacter demo
var party = new List<GameCharacter>
{
    new Warrior("Kael", 12),
    new Mage("Iris", 10),
    new Healer("Sora", 9)
};

foreach (var c in party)
{
    c.Describe();
    c.UseSpecial();
}

Console.WriteLine();

// Exporter demo
var exporters = new List<Exporter>
{
    new PdfExporter("report.pdf"),
    new CsvExporter("data.csv"),
    new HtmlExporter("page.html")
};

foreach (var ex in exporters)
{
    ex.Export("Sample content");
}

Console.WriteLine();

// AccessPass demo
var passes = new List<AccessPass>
{
    new MetroPass("Amina", zones: 2),
    new BikeSharePass("Jonas", minutes: 15),
    new FerryPass("Luca", DateTime.UtcNow.AddDays(3))
};

foreach (var p in passes)
{
    bool valid = p.Validate();
    Console.WriteLine($"Valid -> {valid}");
}
