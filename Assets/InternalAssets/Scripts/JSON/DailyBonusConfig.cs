using System;

[Serializable]
public enum DailyBonusType
{
    Release,
    Test
}

[Serializable]
public class DailyBonusConfig : Savable
{
    public static readonly DailyBonusConfig Default = new DailyBonusConfig(DailyBonusType.Release);

    public string Type { get; set; }

    public DailyBonusConfig(DailyBonusType type)
    {
        Type = type.ToString();
    }
}

