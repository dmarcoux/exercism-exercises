using System;
using System.Text.RegularExpressions;

static class LogLine
{
    public static string Message(string logLine) => Regex.Replace(logLine, "\\s*\\[.*\\]:\\s*", "").Trim();

    public static string LogLevel(string logLine) => Regex.Replace(logLine, "\\s*\\[(.*)\\]:.*", "$1").Trim().ToLower();

    public static string Reformat(string logLine) => $"{Message(logLine)} ({LogLevel(logLine)})";
}
