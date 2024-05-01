using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) => DateTime.Parse(appointmentDateDescription);

    public static bool HasPassed(DateTime appointmentDate) => DateTime.Now > appointmentDate;

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        TimeSpan appointmentTime = appointmentDate.TimeOfDay;

        return ((appointmentTime >= new TimeSpan(12, 0, 0)) && (appointmentTime < new TimeSpan(18, 0, 0)));
    }

    public static string Description(DateTime appointmentDate) =>
        $"You have an appointment on {appointmentDate.ToString()}.";

    public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year, 9, 15);
}
