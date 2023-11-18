public class SecondTimer : Timer
{
    private const string _seconds = "s";

    protected override string GetTimeText(int time)
    {
        return time.ToString() + _seconds;
    }
}
