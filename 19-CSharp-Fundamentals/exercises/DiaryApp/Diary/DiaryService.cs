using DiaryApp.Models;

namespace DiaryApp.Services;

public class DiaryService
{
    private const string RootFolder = "DiaryEntries";

    public void SaveEntry(DiaryEntry entry)
    {
        // wrap in try - catch to catch Exception (e.g. IOExeption)



        // create directory if it does not exist

        // optional: Clean up filename to avoid invalid chars

        // create file path with Path.Combine();


        // create a StreamWriter to add log to file
    }

    public string? ReadEntry(string date, string title)
    {
        // wrap in try catch block to catch Exception, e.g. IOException


        // create correct filepath to find file

        // read file content if file exists
        // 

        return "";
    }
}