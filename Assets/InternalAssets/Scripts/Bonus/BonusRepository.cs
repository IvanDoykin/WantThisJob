using UnityEngine;

[CreateAssetMenu(fileName = "newBonusRepository", menuName = "Bonus/BonusRepository", order = 1)]
public class BonusRepository : ScriptableObject
{
    [SerializeField] private Bonus[] _bonuses;

    public Bonus GetBonusById(string id)
    {
        foreach (var bonus in _bonuses)
        {
            if (bonus.Id == id)
            {
                return bonus;
            }
        }

        throw new System.Exception($"Can't find bonus with id:{id}.");
    }

    public Bonus GetRandomBonus()
    {
        return _bonuses[Random.Range(0, _bonuses.Length)];
    }
}
