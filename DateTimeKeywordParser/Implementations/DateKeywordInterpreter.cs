using DateTimeKeywordParser.Contract;

namespace DateTimeKeywordParser.Implementations;

public class DateKeywordInterpreter
{
    private readonly IDateParserFactory _parserFactory;

    public DateKeywordInterpreter()
    {
        _parserFactory = new DateParserFactory();
    }
    public string Interpret(string keyword)
    {
        var parser = _parserFactory.GetParser(keyword);
        return parser?.Parse(keyword) ?? "Unknown keyword. Please try again.";
    }
}
