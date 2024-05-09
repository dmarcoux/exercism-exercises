using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        // Calculate with Pythagorean theorem
        double x2 = Math.Pow(x, 2);
        double y2 = Math.Pow(y, 2);

        return (x2 + y2) switch
        {
            // Inner circle with a radius of 1, so 1^2
            <= 1.0 => 10,
            // Middle circle with a radius of 5, so 5^2
            <= 25.0 => 5,
            // Outer circle with a radius of 10, so 10^2
            <= 100.0 => 1,
            _ => 0
        };
    }
}
