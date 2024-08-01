using System;
using System.Collections.Generic;
using System.Text;

public static class RotationalCipher
{
    private const int a = 'a';
    private const int z = 'z';
    private const int A = 'A';
    private const int Z = 'Z';
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

            char shiftedCharacter = (char)(character + shiftKey);

            if (character >= a && character <= z)
            {
                if (shiftedCharacter > z)
                {
                    shiftedCharacter = (char)(a + shiftedCharacter - z - 1);
                }
                rotatedCharacters.Append(shiftedCharacter);
                continue;
            }

            if (shiftedCharacter > Z)
            {
                shiftedCharacter = (char)(A + shiftedCharacter - Z - 1);
            }
            rotatedCharacters.Append(shiftedCharacter);
        }

        return rotatedCharacters.ToString();
    }

    private static bool IsLatinLetter(char c) =>
        char.IsBetween(c, 'a', 'z') || char.IsBetween(c, 'A', 'Z');
}
