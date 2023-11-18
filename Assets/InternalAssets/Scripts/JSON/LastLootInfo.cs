using System;

[Serializable]
public class LastLootInfo : Savable
{
    public static readonly LastLootInfo Default = new LastLootInfo(DateTime.MinValue);

    public DateTime LastLootTime { get; set; }

    public LastLootInfo(DateTime lastLootTime)
    {
        LastLootTime = lastLootTime;
    }
}
