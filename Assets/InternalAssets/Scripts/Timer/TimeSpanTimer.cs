using System;

public class TimeSpanTimer : Timer
{
    protected override string GetTimeText(int time)
    {
        if (time == 0)
        {
            return string.Empty;
        }

        return TimeSpan.FromSeconds(time).ToString();
    }
}