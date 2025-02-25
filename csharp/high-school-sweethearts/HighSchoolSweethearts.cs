using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    private const string Banner =
    @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0}  +  {1}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
    ";
    
    public static string DisplaySingleLine(string studentA, string studentB) =>
        $"                  {studentA} ♡ {studentB}                    ";

    public static string DisplayBanner(string studentA, string studentB) => string.Format(Banner, studentA.Trim(), studentB.Trim());

    public static string DisplayGermanExchangeStudents(string studentA , string studentB, DateTime start, float hours) =>
        string.Format(CultureInfo.GetCultureInfo("de-DE"), "{0} and {1} have been dating since {2:d} - that's {3:n2} hours", studentA, studentB, start, hours);
}
