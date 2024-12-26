using DateTimeKeywordParser.Contract;
using System.Globalization;

namespace DateTimeKeywordParser.Implementations;

public class YesterdayParser : IDateParser
{
    public string Parse(string input) => DateTime.Now.AddDays(-1).ToString("f", CultureInfo.InvariantCulture);
}