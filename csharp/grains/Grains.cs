using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n is < 1 or > 64)
            throw new ArgumentOutOfRangeException();

        return (ulong)Math.Pow(2, n - 1);
    }

    public static ulong Total(int squares = 64) => (ulong)Math.Pow(2, squares + 1) - 1;
}