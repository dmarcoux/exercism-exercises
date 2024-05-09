using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word) => !word.Where(char.IsLetter).GroupBy(char.ToUpper).Any(g => g.Count() != 1);
}
