using System;
using UnityEngine;

public class DailyBonus : MonoBehaviour
{
    [SerializeField] private BonusRepository _bonusRepository;
    private Timer _timer;

    private JSONInputOutput<DailyBonusConfig> _dailyBonusConfig = new JSONInputOutput<DailyBonusConfig>();
    private JSONInputOutput<LastLootInfo> _lastLootInfo = new JSONInputOutput<LastLootInfo>();

    private void Awake()
    {
        _timer = GetComponentInChildren<Timer>();
    }

    public bool TryGetDailyBonus(out Bonus bonus)
    {
        DailyBonusConfig dailyBonusConfig;

        if (_dailyBonusConfig.HasData())
        {
            dailyBonusConfig = _dailyBonusConfig.Read();    
        }
        else
        {
            dailyBonusConfig = DailyBonusConfig.Default;
            _dailyBonusConfig.Write(dailyBonusConfig);
        }

        LastLootInfo lastLootInfo;

        if (_lastLootInfo.HasData())
        {
            lastLootInfo = _lastLootInfo.Read();
        }
        else
        {
            lastLootInfo = LastLootInfo.Default;
            _lastLootInfo.Write(lastLootInfo);
        }

        TimeSpan timeAfterLastLoot = TimeUtility.TimeBetween(lastLootInfo.LastLootTime, DateTime.Now);
        if (timeAfterLastLoot >= TimeUtility.GetDayFromConfig(TimeSpan.FromDays(1), dailyBonusConfig))
        {
            _lastLootInfo.Write(new LastLootInfo(DateTime.Now));
            _timer.StartAt((float)TimeUtility.GetDayFromConfig(TimeSpan.FromDays(1), dailyBonusConfig).TotalSeconds);
            bonus = _bonusRepository.GetRandomBonus();
            return true;
        }
        else
        {
            _timer.StartAt((float)TimeUtility.GetDayFromConfig(TimeSpan.FromDays(1), dailyBonusConfig).TotalSeconds - (float)timeAfterLastLoot.TotalSeconds);
        }

        bonus = null;
        return false;
    }
}
