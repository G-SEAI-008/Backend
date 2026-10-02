using DiaryApp.Models;
using DiaryApp.Services;



bool running = true;

var diary = new DiaryService();

while (running)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Log entry");
    Console.WriteLine("2. Retrieve entry");
    Console.WriteLine("3. Exit");
    Console.Write("Selection: ");

    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.Write("Enter title: ");
            string? title = Console.ReadLine();
            Console.Write("Enter text: ");
            string? text = Console.ReadLine();
            var entry = new DiaryEntry { Title = title ?? string.Empty, Text = text ?? string.Empty, Date = DateTime.Today };
            diary.SaveEntry(entry);
            break;

        case "2":
            Console.Write("Enter date (yyyy-mm-dd): ");
            string? date = Console.ReadLine();
            Console.Write("Enter title: ");
            string? readTitle = Console.ReadLine();
            string? retrieved = diary.ReadEntry(date ?? string.Empty, readTitle ?? string.Empty);
            Console.WriteLine(retrieved ?? "Entry not found.");
            break;

        case "3":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid selection");
            break;
    }

    Console.WriteLine();
}