using System;

public class Player
{
    public int RollDie() => System.Random.Shared.Next(1, 19);

    public double GenerateSpellStrength() => System.Random.Shared.NextDouble() * 100.0;
}
