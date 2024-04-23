using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimiter) {
        int delimiterIndex = str.IndexOf(delimiter);
        return str.Substring(delimiterIndex + delimiter.Length);
    }

    public static string SubstringBetween(this string str, string firstDelimiter, string secondDelimiter) {
        int firstDelimiterIndex = str.IndexOf(firstDelimiter);
        int secondDelimiterIndex = str.IndexOf(secondDelimiter);
        return str.Substring(firstDelimiterIndex + firstDelimiter.Length, secondDelimiterIndex - firstDelimiterIndex - firstDelimiter.Length);
    }

    public static string Message(this string str) => str.SubstringAfter("]: ");

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}
