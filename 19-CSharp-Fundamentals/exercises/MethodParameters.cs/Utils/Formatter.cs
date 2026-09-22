namespace Utils;

public class Formatter
{
    public static string FormatNumber(int n)
    {
        return $"Number: {n}";
    }

    public static string FormatNumber(double d)
    {
        return $"Number: {Math.Round(d, 2)}";
    }


    public static string FormatMessage(string text, int repeat = 1)
    {
        var result = string.Empty;
        for (int i = 0; i < repeat; i++)
        {
            result += text;
            if (i < repeat - 1) result += " ";
        }

        return result;


        // check https://learn.microsoft.com/de-de/dotnet/fundamentals/runtime-libraries/system-text-stringbuilder
        // not always a better option to use StringBuilder

        // StringBuilder sb = new StringBuilder("");

        // for (int i = 0; i < repeat; i++)
        // {
        //     sb.Append(text);
        //     if (i < repeat - 1) sb.Append(" ");
        // }
        // return sb.ToString();


    }

}