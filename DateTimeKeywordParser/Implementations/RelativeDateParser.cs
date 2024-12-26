
using DateTimeKeywordParser.Contract;
using System.Globalization;

namespace DateTimeKeywordParser.Implementations;

public class RelativeDateParser : IDateParser
{
    private readonly bool _isFuture;

    public RelativeDateParser(bool isFuture)
    {
        _isFuture = isFuture;
    }

    public string Parse(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length >= 2 && int.TryParse(parts[1], out int value))
        {
            string unit = parts[^1];
            var multiplier = _isFuture ? 1 : -1;

            return unit switch
            {
                "day" or "days" => DateTime.Now.AddDays(multiplier * value).ToString("f", CultureInfo.InvariantCulture),
                "week" or "weeks" => DateTime.Now.AddDays(multiplier * value * 7).ToString("f", CultureInfo.InvariantCulture),
                "month" or "months" => DateTime.Now.AddMonths(multiplier * value).ToString("f", CultureInfo.InvariantCulture),
                "year" or "years" => DateTime.Now.AddYears(multiplier * value).ToString("f", CultureInfo.InvariantCulture),
                _ => throw new ArgumentException("Invalid time unit. Use day(s), week(s), month(s), or year(s).")
            };
        }

        throw new ArgumentException("Invalid format for relative date. Use 'in X unit(s)' or 'X unit(s) ago'.");
    }
}