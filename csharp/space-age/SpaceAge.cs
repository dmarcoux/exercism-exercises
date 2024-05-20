using System;

public class SpaceAge(int seconds)
{
    private struct SecondsInOneYearOn
    {
        public const double Mercury = 7_600_543.81992;
        public const double Venus = 19_414_149.0522;
        public const double Earth = 31_557_600.0;
        public const double Mars = 59_354_032.69;
        public const double Jupiter = 374_355_659.124;
        public const double Saturn = 929_292_362.885;
        public const double Uranus = 2_651_370_019.33;
        public const double Neptune = 5_200_418_560.0;
    }

    public double OnVenus() => seconds / SecondsInOneYearOn.Venus;
    public double OnEarth() => seconds / SecondsInOneYearOn.Earth;
    public double OnMercury() => seconds / SecondsInOneYearOn.Mercury;
    public double OnMars() => seconds / SecondsInOneYearOn.Mars;
    public double OnJupiter() => seconds / SecondsInOneYearOn.Jupiter;
    public double OnSaturn() => seconds / SecondsInOneYearOn.Saturn;
    public double OnUranus() => seconds / SecondsInOneYearOn.Uranus;
    public double OnNeptune() => seconds / SecondsInOneYearOn.Neptune;
}