using DateTimeKeywordParser.Contract;


namespace DateTimeKeywordParser.Implementations;

public class DateParserFactory: IDateParserFactory
{
    public IDateParser? GetParser(string input)
    {
        return input switch
        {
            "today" => new TodayParser(),
            "tomorrow" => new TomorrowParser(),
            "yesterday" => new YesterdayParser(),
            "now" or { } when input.StartsWith("now") => new NowParser(),
            _ when input.StartsWith("in ") => new RelativeDateParser(true),
            _ when input.EndsWith(" ago") => new RelativeDateParser(false),
            _ => null
        };
    }

}
