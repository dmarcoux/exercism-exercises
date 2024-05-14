using System;

class WeighingMachine(int precision)
{
    public readonly int Precision = precision;

    private double _weight;
    public double Weight
    {
        get => _weight;

        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);

            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight => $"{(_weight - TareAdjustment).ToString($"N{Precision}")} kg";
}