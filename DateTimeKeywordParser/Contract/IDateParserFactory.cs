
namespace DateTimeKeywordParser.Contract;

public interface IDateParserFactory
{
    IDateParser? GetParser(string dateKeyword);
}
