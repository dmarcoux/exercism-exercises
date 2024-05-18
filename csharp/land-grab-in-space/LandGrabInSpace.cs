using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot(Coord firstCoord, Coord secondCoord, Coord thirdCoord, Coord fourthCoord)
{
    private Coord _firstCoord = firstCoord;
    private Coord _secondCoord = secondCoord;
    private Coord _thirdCoord = thirdCoord;
    private Coord _fourthCoord = fourthCoord;

    public readonly double LongestSide()
    {
        var coords = new Coord[5] { _firstCoord, _secondCoord, _thirdCoord, _fourthCoord, _firstCoord };
        var sides = new double[4];

        for (int i = 0; i < 4; i++)
        {
            Coord firstCoord = coords[i];
            Coord secondCoord = coords[i + 1];
            int dX = secondCoord.X - firstCoord.X;
            int dY = secondCoord.Y - firstCoord.Y;
            sides.Append(Math.Sqrt(dX * dX + dY * dY));
        }

        return sides.Max();
    }
}

public class ClaimsHandler
{
    private List<Plot> _claims = new List<Plot>();
    public void StakeClaim(Plot plot) => _claims.Add(plot);

    public bool IsClaimStaked(Plot plot) => _claims.Contains(plot);

    public bool IsLastClaim(Plot plot) => _claims.LastOrDefault().Equals(plot);

    public Plot GetClaimWithLongestSide() => _claims.MaxBy(x => x.LongestSide());
}