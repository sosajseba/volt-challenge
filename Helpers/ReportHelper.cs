namespace VoltChallenge.Services.Support;

public static class ReportHelper
{
    public static double GetCost(DateTime timestamp, double solarOutputValue)
    {
        double rate = 0.0;
        bool isWinter = IsWinter(timestamp);

        if (timestamp.DayOfWeek == DayOfWeek.Saturday || timestamp.DayOfWeek == DayOfWeek.Sunday)
        {
            if (timestamp.Hour >= 0 && timestamp.Hour < 9)
                rate = 0.12;
            else if (timestamp.Hour >= 9 && timestamp.Hour < 17)
                rate = 0.10;
            else if (timestamp.Hour >= 17 && timestamp.Hour < 24)
                rate = 0.11;
        }
        else
        {
            if (timestamp.Hour >= 0 && timestamp.Hour < 6)
                rate = 0.08;
            else if (timestamp.Hour >= 6 && timestamp.Hour < 9)
                rate = 0.15;
            else if (timestamp.Hour >= 9 && timestamp.Hour < 14)
                rate = 0.10;
            else if (timestamp.Hour >= 14 && timestamp.Hour < 17)
                rate = 0.11;
            else if (timestamp.Hour >= 17 && timestamp.Hour < 22)
                rate = 0.13;
            else if (timestamp.Hour >= 22 && timestamp.Hour < 24)
                rate = 0.09;
        }

        if (isWinter)
        {
            rate *= 1.15;
        }

        return solarOutputValue * rate / 60;
    }

    private static bool IsWinter(DateTime timestamp) => timestamp.Month == 12 || timestamp.Month == 1 || timestamp.Month == 2;
}