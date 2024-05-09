using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        char[] alphabet = Enumerable.Range('A', 26).Select(asciiCode => (char)asciiCode).ToArray();
        return !alphabet.Except(input.ToUpper().ToCharArray()).Any();
    }
}
