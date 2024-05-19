using System;

public static class ResistorColor
{
    private enum Color {
        Black,
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Grey,
        White,
    };

    public static int ColorCode(string colorName)
    {
        if (Color.TryParse(colorName, ignoreCase: true, out Color color))
            return (int)color;

        throw new ArgumentOutOfRangeException();
    }

    public static string[] Colors()
        => Array.ConvertAll(Enum.GetNames(typeof(Color)), x => x.ToLower());
}