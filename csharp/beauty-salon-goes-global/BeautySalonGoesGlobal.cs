using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime dateTime = DateTime.Parse(appointmentDateDescription);
        return TimeZoneInfo.ConvertTimeToUtc(dateTime, GetTimeZone(location));
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        TimeSpan timeSpan = alertLevel switch
        {
            AlertLevel.Early => new TimeSpan(1, 0, 0, 0),
            AlertLevel.Standard => new TimeSpan(1, 45, 0),
            AlertLevel.Late => new TimeSpan(0, 30, 0),
            _ => throw new ArgumentOutOfRangeException()
        };

        return appointment.Subtract(timeSpan);
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo timeZoneInfo = GetTimeZone(location);

        return timeZoneInfo.IsDaylightSavingTime(dt) != timeZoneInfo.IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        if (DateTime.TryParse(dtStr, GetCultureInfo(location), DateTimeStyles.None, out DateTime dateTime))
        {
            return dateTime;
        }
        else
        {
            return new DateTime(1, 1, 1);
        }
    }

    private static TimeZoneInfo GetTimeZone(Location location) => location switch
    {
        // We don't have to check for the operating system since .NET 6: https://stackoverflow.com/a/68120062
        Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
        Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"),
        Location.London => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
        _ => throw new ArgumentOutOfRangeException()
    };

    private static CultureInfo GetCultureInfo(Location location) => location switch
    {
        Location.NewYork => CultureInfo.GetCultureInfo("en-US"),
        Location.Paris => CultureInfo.GetCultureInfo("fr-FR"),
        Location.London => CultureInfo.GetCultureInfo("en-GB"),
        _ => throw new ArgumentOutOfRangeException()
    };
}