using System.Globalization;

class Parser
{
    public static bool TryParsePrice(string text, out decimal price)
    {
        price = 0M;
        if (string.IsNullOrWhiteSpace(text)) return false;

        string cleaned = text.Trim();
        cleaned = cleaned.Replace("£", "").Replace("€", "").Replace("$", "").Replace(",", ".");

        return decimal.TryParse(cleaned, out price);
    }
}