using System.Collections.Generic;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.IsMatch(text, @"^\[(.+)\].+");

    public string[] SplitLogLine(string text) => Regex.Split(text, @"<[\^|\*|=|-]+>");

    public int CountQuotedPasswords(string lines) => Regex.Count(lines, @""".*password.*""", RegexOptions.IgnoreCase);

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end\-of\-line\d+", "");

    public string[] ListLinesWithPasswords(string[] lines)
    {
        List<string> processedLines = [];

        foreach (string line in lines)
        {
            Match match = Regex.Match(line, @"(password\S+)", RegexOptions.IgnoreCase);
            if (match.Length > 0)
            {
                processedLines.Add($"{match.Groups[0].Value}: {line}");
            }
            else
            {
                processedLines.Add($"--------: {line}");
            }
        }

        return processedLines.ToArray();
    }
}