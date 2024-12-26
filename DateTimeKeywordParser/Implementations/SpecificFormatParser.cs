
using DateTimeKeywordParser.Contract;
using System.Globalization;
using System.IO;

namespace DateTimeKeywordParser.Implementations;

public class SpecificFormatParser : IDateParser
{

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
        var contentParts = formatContent.Split(',', StringSplitOptions.TrimEntries);

        if (contentParts.Length != 2 || !contentParts[0].Equals("now", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Format must follow 'Format(NOW, \"pattern\")'.");
        }

        string pattern = contentParts[1].Trim('"');
        return DateTime.Now.ToString(pattern, CultureInfo.InvariantCulture);


    }
}
