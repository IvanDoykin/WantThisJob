using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BonusController : MonoBehaviour
{
    [SerializeField] private BonusRepository _bonusRepository;
    [SerializeField] private EffectsRepository _effectsRepository;

    private Player _player;
    private DailyBonus _dailyBonus;
    private BonusesView _bonusesView;

    private JSONInputOutput<ActiveBonuses> _activeBonuses = new JSONInputOutput<ActiveBonuses>();

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        _dailyBonus = GetComponentInChildren<DailyBonus>();
        _bonusesView = GetComponentInChildren<BonusesView>();

        ActivateBonuses();
    }

    private void ActivateBonuses()
    {
        ActiveBonuses activeBonuses;

        if (_activeBonuses.HasData())
        {
            activeBonuses = _activeBonuses.Read();
        }
        else
        {
            activeBonuses = ActiveBonuses.Default;
            _activeBonuses.Write(activeBonuses);
        }

        List<ActiveBonus> validBonuses = new List<ActiveBonus>();
        foreach (var bonus in activeBonuses.Bonuses)
        {
            if (TimeUtility.TimeBetween(bonus.ActivateTime, DateTime.Now).TotalSeconds < _bonusRepository.GetBonusById(bonus.Id).Time)
            {
                validBonuses.Add(bonus);
            }
        }

        activeBonuses = new ActiveBonuses(validBonuses.ToArray());

        if (_dailyBonus.TryGetDailyBonus(out Bonus dailyBonus))
        {
            ActiveBonus[] bonuses = new ActiveBonus[activeBonuses.Bonuses.Length + 1];
            activeBonuses.Bonuses.CopyTo(bonuses, 0);
            bonuses[bonuses.Length - 1] = new ActiveBonus(dailyBonus.Id, DateTime.Now);
            activeBonuses = new ActiveBonuses(bonuses);
        }

         _activeBonuses.Write(activeBonuses);

        foreach (var bonus in activeBonuses.Bonuses)
        {
            _effectsRepository.GetEffectById(bonus.Id).Effect.Apply(_player);
            var bonusView = _bonusesView.CreateView(_bonusRepository.GetBonusById(bonus.Id), 
                _bonusRepository.GetBonusById(bonus.Id).Time - (float)TimeUtility.TimeBetween(bonus.ActivateTime, DateTime.Now).TotalSeconds);
            bonusView.Timer.HasEnd += () =>
            {
                _effectsRepository.GetEffectById(bonus.Id).Effect.Revert(_player);
                Destroy(bonusView.gameObject);
            };
        }
    }
}
