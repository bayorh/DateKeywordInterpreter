

using DateTimeKeywordParser.Contract;
using System.Globalization;

namespace DateTimeKeywordParser.Implementations;

public class TodayParser : IDateParser
{
    public string Parse(string dateKeyword) => DateTime.Now.ToString("f", CultureInfo.InvariantCulture);
}
