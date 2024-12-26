
using DateTimeKeywordParser.Implementations;

namespace DatekeywordParserConsole;

internal class Program
{
    static void Main(string[] args)
    {
        var interpreter = new DateKeywordInterpreter();
        Console.WriteLine("Date Keyword Interpreter");
        Console.WriteLine(@"Type a date-related keyword 
                            Keyword supported are:
                                1. Basic: 'today', 'tomorrow', 'yesterday', 'next week', and 'last week'.
                                2. Relatives: phrases like 'in 3 days', '5 weeks ago', 'in 2 months', and '1 year ago'.
                                3. Now type: phrases like 'NOW-1d', 'NOW+2h'.
                                4. Specific date pattern: pattern like  'Format(today, yyyy-MM-dd)', 
                                                                        'Format(NOW+2h, HH:mm:ss)',
                                                                        'Format(in 5 weeks, dddd, MMMM dd)'.
                                
                           Type 'exit' to quit:");


        while (true)
        {
            Console.Write("Input: ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "exit")
            {
                Console.WriteLine("Exiting......!");
                break;
            }

            try
            {
                string result = interpreter.Interpret(input);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

     }
}
