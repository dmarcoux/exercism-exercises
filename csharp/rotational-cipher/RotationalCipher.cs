using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        int remainder = shiftKey % 26;
        if (remainder == 0)
        {
            return text;
        }

        StringBuilder rotatedCharacters = new StringBuilder();

        foreach (char character in text)
        {
            if (!IsLatinLetter(character))
            {
                rotatedCharacters.Append(character);
                continue;
            }

            char a = char.IsLower(character) ? 'a' : 'A';
            char shiftedCharacter = (char)(a + (character - a + shiftKey) % 26);

            rotatedCharacters.Append(shiftedCharacter);
        }

        return rotatedCharacters.ToString();
    }

    private static bool IsLatinLetter(char c) =>
        char.IsBetween(c, 'a', 'z') || char.IsBetween(c, 'A', 'Z');
}
