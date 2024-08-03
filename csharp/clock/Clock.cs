using System;

public class Clock : IEquatable<Clock>
{
    private int Hours { get; }
    private int Minutes { get; }

    public Clock(int hours, int minutes)
    {
        if (minutes >= 0 || minutes % 60 == 0)
        {
            Hours = (hours + minutes / 60) % 24;
            Minutes = minutes % 60;
        }
        else
        {
            Hours = (hours + minutes / 60 - 1) % 24;
            Minutes = 60 - (int.Abs(minutes) % 60);
        }

        // Negative hours aren't possible, roll over
        if (Hours < 0)
        {
            Hours = 24 - int.Abs(Hours);
        }
    }

    public Clock Add(int minutesToAdd) => new(Hours, Minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new(Hours, Minutes - minutesToSubtract);

    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";

    #region IEquatable
    public override bool Equals(object obj) => Equals(obj as Clock);

    public override int GetHashCode() => (Hours, Minutes).GetHashCode();

    public static bool operator ==(Clock lhs, Clock rhs)
    {
        if (lhs is null)
        {
            return (rhs is null);
        }

        return lhs.Equals(rhs);
    }

    public static bool operator !=(Clock lhs, Clock rhs) => !(lhs == rhs);

    public bool Equals(Clock other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (GetType() != other.GetType())
        {
            return false;
        }

        return Hours == other.Hours && Minutes == other.Minutes;
    }
    #endregion
}
