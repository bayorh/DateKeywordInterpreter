
using DateTimeKeywordParser.Contract;
using System.Globalization;

namespace DateTimeKeywordParser.Implementations;
public class NowParser : IDateParser 
{
    public string Parse(string dateKeyword)
    {
        if (dateKeyword == "now")
            return DateTime.Now.ToString("f", CultureInfo.InvariantCulture);

        if (dateKeyword.StartsWith("now") || dateKeyword.StartsWith("now-") || dateKeyword.StartsWith("now+"))
        {
            // Parse offsets
            string offset = dateKeyword.Substring(3).Trim();
            return GetNowOffset(offset).ToString("f", CultureInfo.InvariantCulture);
        }

        throw new ArgumentException("Invalid format for 'now' keyword.");
    }
    private DateTime GetNowOffset(string nowKeywordoffset) 
    {
        char operation = nowKeywordoffset[0];
        string value = nowKeywordoffset[1..^1];
        string unit = nowKeywordoffset[^1..];

        if (!int.TryParse(value, out int amount))
            throw new ArgumentException("Invalid numeric value in now offset.");
        return unit switch
        {
            "d" => operation == '+' ? DateTime.Now.AddDays(amount) : DateTime.Now.AddDays(-amount),
            "h" => operation == '+' ? DateTime.Now.AddHours(amount) : DateTime.Now.AddHours(-amount),
            "m" => operation == '+' ? DateTime.Now.AddMinutes(amount) : DateTime.Now.AddMinutes(-amount),
            _ => throw new ArgumentException("Unsupported unit in now offset. Use 'd' (days), 'h' (hours), or 'm' (minutes).")
        };
    }
}
