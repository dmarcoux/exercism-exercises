using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder(identifier.Length);

        bool afterHyphen = false;
        foreach (char ch in identifier)
        {
            sb.Append(ch switch
            {
                _ when ch is (>= 'α' and <= 'ω') => default,
                _ when Char.IsWhiteSpace(ch) => '_',
                _ when Char.IsControl(ch) => "CTRL",
                _ when Char.IsLetter(ch) => afterHyphen ? Char.ToUpper(ch) : ch,
                _ => default
            });
            afterHyphen = (ch == '-');
        }

        return sb.ToString();
    }
}
