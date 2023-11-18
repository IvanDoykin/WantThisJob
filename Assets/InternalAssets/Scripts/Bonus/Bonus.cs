using UnityEngine;

[CreateAssetMenu(fileName = "newBonus", menuName = "Bonus/Bonus", order = 2)]
public class Bonus : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private Sprite _avatar;
    [SerializeField] private float _time;

    public string Id => _id;
    public Sprite Avatar => _avatar;
    public float Time => _time;
}
