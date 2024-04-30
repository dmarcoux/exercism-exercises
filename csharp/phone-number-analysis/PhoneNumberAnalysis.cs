using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] phoneNumberParts = phoneNumber.Split("-");

        return (IsNewYork: phoneNumberParts[0] == "212", IsFake: phoneNumberParts[1] == "555", LocalNumber: phoneNumberParts[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
