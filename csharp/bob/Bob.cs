using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (IsSilent(statement))
        {
            return "Fine. Be that way!";
        }

        return (IsQuestion(statement), IsYelling(statement)) switch
        {
            (true, false) => "Sure.",
            (false, true) => "Whoa, chill out!",
            (true, true) => "Calm down, I know what I'm doing!",
            _ => "Whatever."
        };
    }

    private static bool IsSilent(string statement) => string.IsNullOrWhiteSpace(statement);

    private static bool IsQuestion(string statement) => statement.TrimEnd().EndsWith("?");

    private static bool IsYelling(string statement) => statement.Any(char.IsLetter) && !statement.Any(char.IsLower);
}
