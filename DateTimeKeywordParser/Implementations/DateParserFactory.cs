using DateTimeKeywordParser.Contract;


namespace DateTimeKeywordParser.Implementations;

public class DateParserFactory: IDateParserFactory
{
    public IDateParser? GetParser(string input)
    {
        return input switch
        {
            "today" or "tomorrow" or "yesterday" => new BasicDateKeywordParser(),
            "now" or { } when input.StartsWith("now") => new NowParser(),
            _ when input.StartsWith("in ") => new RelativeDateParser(true),
            _ when input.EndsWith(" ago") => new RelativeDateParser(false),
            _ when input.StartsWith("format(", StringComparison.OrdinalIgnoreCase) => new SpecificFormatParser(),
            _ => null
        };
    }

}
