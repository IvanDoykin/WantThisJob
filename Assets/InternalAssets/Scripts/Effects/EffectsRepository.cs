using UnityEngine;

[CreateAssetMenu(fileName = "newEffectsRepository", menuName = "Effects/EffectsRepository", order = 1)]
public class EffectsRepository : ScriptableObject
{
    [SerializeField] private EffectReference[] _effects;

    public EffectReference GetEffectById(string id)
    {
        foreach (var effect in _effects)
        {
            if (effect.Id == id)
            {
                return effect;
            }
        }

        throw new System.Exception($"Can't find effect with id:{id}.");
    }
}
