
using DateTimeKeywordParser.Contract;
using System.Globalization;

namespace DateTimeKeywordParser.Implementations;

public class SpecificFormatParser : IDateParser
{
    private readonly IDateParserFactory _parserFactory;
    public SpecificFormatParser()
    {
        _parserFactory = new DateParserFactory();
    }
    public string Parse(string dateKeyword)
    {
        const string formatPrefix = "format(";
        const string formatSuffix = ")";

        if (!dateKeyword.StartsWith(formatPrefix, StringComparison.OrdinalIgnoreCase) 
            || !dateKeyword.EndsWith(formatSuffix))
        {
            throw new ArgumentException("Invalid format syntax. Use Format(NOW, \"pattern\").");
        }


        string formatContent = dateKeyword[formatPrefix.Length..^formatSuffix.Length];
        
        int commaIndex = formatContent.IndexOf(',');
        if (commaIndex == -1)
        {
            throw new ArgumentException("Format string must contain a keyword and a pattern separated by a comma.");
        }
        string keyword = formatContent[..commaIndex].Trim();
        string pattern = formatContent[(commaIndex + 1)..].Trim().Trim('"');

        var parser = _parserFactory.GetParser(keyword)
            ?? throw new ArgumentException($"Unknown keyword: {keyword}");

        string result = parser.Parse(keyword);

        if (!DateTime.TryParse(result, out DateTime parsedDate))
        {
            throw new InvalidOperationException($"Unable to interpret the keyword '{keyword}' as a valid date.");
        }
        return parsedDate.ToString(pattern, CultureInfo.InvariantCulture);


    }
}
