using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return $"{checked(@base * multiplier)}";
        }
        catch (OverflowException e)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier) => (@base * multiplier) switch
    {
        float.PositiveInfinity or float.NegativeInfinity => "*** Too Big ***",
        float gdp => gdp.ToString(),
    };

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return $"{checked(@salaryBase * multiplier)}";
        }
        catch (OverflowException e)
        {
            return "*** Much Too Big ***";
        }
    }
}