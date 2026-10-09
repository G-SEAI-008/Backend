namespace MyApp;

public static class StringTools
{
    public static string Reverse(string s) => new string(s.Reverse().ToArray());

    public static bool IsPalindrome(string s) => string.Equals(s, Reverse(s), StringComparison.OrdinalIgnoreCase);
}