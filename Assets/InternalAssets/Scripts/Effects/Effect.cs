using UnityEditor;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract void Apply(Player player);
    public abstract void Revert(Player player);
}
