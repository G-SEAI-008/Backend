using DiaryApp.Models;

namespace DiaryApp.Services;

public class DiaryService
{
    private const string RootFolder = "DiaryEntries";

    public void SaveEntry(DiaryEntry entry)
    {
        try
        {

            string dateFolder = Path.Combine(RootFolder, entry.Date.ToString("yyyy-MM-dd"));

            if (!Directory.Exists(dateFolder))
            {
                Directory.CreateDirectory(dateFolder);
            }

            string safeTitle = string.Join("_", entry.Title.Split(Path.GetInvalidFileNameChars()));

            string filePath = Path.Combine(dateFolder, safeTitle + ".txt");


            using var writer = new StreamWriter(filePath, append: true);

            writer.WriteLine($"[{DateTime.Now:HH:mm}] {entry.Text}");
            Console.WriteLine($"Entry saved successfully.");
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"Error saving entry: {ex.Message}");
        }
    }

    public string? ReadEntry(string date, string title)
    {

        try
        {
            string dateFolder = Path.Combine(RootFolder, date);
            string safeTitle = string.Join("_", title.Split(Path.GetInvalidFileNameChars()));
            string filePath = Path.Combine(dateFolder, safeTitle + ".txt");


            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            return null;
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"Error reading entry: {ex.Message}");
            return null;
        }
    }
}