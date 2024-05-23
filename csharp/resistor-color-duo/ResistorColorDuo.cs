using System;

public static class ResistorColorDuo
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

    public static int Value(string[] colorNames)
    {
        // We only consider the first two bands, so everything after doesn't have to be processed
        int numberOfBands = Math.Min(colorNames.Length, 2);
        string[] colors = new string[numberOfBands];

        for (int i = 0; i < numberOfBands; i++)
        {
            if (!Color.TryParse(colorNames[i], ignoreCase: true, out Color color))
                throw new ArgumentOutOfRangeException();

            colors[i] = ((int)color).ToString();
        }

        return int.Parse(string.Join("", colors));
    }
}