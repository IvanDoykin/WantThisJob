using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "newEffectReference", menuName = "Effects/EffectReference", order = 2)]
public class EffectReference : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private MonoScript _effect;
    private Effect _cachedEffect;

    public string Id => _id;
    public Effect Effect
    {
        get
        {
            if (_cachedEffect == null)
            {
                _cachedEffect = (Effect)CreateInstance(_effect.GetClass().ToString());
            }
            return _cachedEffect;
        }
    }
}