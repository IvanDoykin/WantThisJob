using System;

public static class TimeUtility
{
    public static TimeSpan GetDayFromConfig(TimeSpan time, DailyBonusConfig day)
    {
        if (day.Type == DailyBonusType.Release.ToString())
        {
            return time;
        }
        
        if (day.Type == DailyBonusType.Test.ToString())
        {
            return new TimeSpan(time.Days, time.Hours, time.Minutes);
        }

        throw new Exception($"Can't find config type {day.Type}.");
    }

    public static TimeSpan TimeBetween(DateTime from, DateTime to)
    {
        var time = to.Subtract(from);
        if (time <= TimeSpan.Zero)
        {
            time = TimeSpan.Zero;
        }

        return time;
    }
}
