
using DateTimeKeywordParser.Contract;
using System.Globalization;

namespace DateTimeKeywordParser.Implementations;

public class BasicDateKeywordParser: IDateParser
{
    private readonly Dictionary<string, Func<DateTime>> _keywordMappings;

    public BasicDateKeywordParser()
    {
        _keywordMappings = new Dictionary<string, Func<DateTime>>(StringComparer.OrdinalIgnoreCase)
        {
            { "today", () => DateTime.Now },
            { "yesterday", () => DateTime.Now.AddDays(-1) },
            { "tomorrow", () => DateTime.Now.AddDays(1) }
        };
    }

    public string Parse(string dateKeyword)
    {

        if (_keywordMappings.TryGetValue(dateKeyword, out var dateFunc))
        {
            return dateFunc().ToString("f", CultureInfo.InvariantCulture);
        }

        throw new ArgumentException($"Unknown keyword: {dateKeyword}");
    }
}
