using System;

[Serializable]
public class ActiveBonuses : Savable
{
    public static readonly ActiveBonuses Default = new ActiveBonuses(new ActiveBonus[0]);

    public ActiveBonus[] Bonuses { get; set; }

    public ActiveBonuses(ActiveBonus[] bonuses)
    {
        Bonuses = new ActiveBonus[bonuses.Length];
        bonuses.CopyTo(Bonuses, 0);
    }
}

[Serializable]
public struct ActiveBonus
{
    public string Id { get; set; }
    public DateTime ActivateTime { get; set; }

    public ActiveBonus(string id, DateTime activateTime)
    {
        Id = id;
        ActivateTime = activateTime;
    }
}
