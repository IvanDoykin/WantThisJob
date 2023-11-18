using UnityEngine;

public class BonusesView : MonoBehaviour
{
    [SerializeField] private BonusView _bonusViewPrefab;

    public BonusView CreateView(Bonus bonus, float time)
    {
        var bonusView = Instantiate(_bonusViewPrefab, transform);
        bonusView.Initialize(bonus, time);
        return bonusView;
    }
}
