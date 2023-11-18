using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private const string _healthTitle = "Health: ";
    private const string _energyTitle = "Energy: ";

    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _energy;

    private Player _player;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
        _player.HealthHasChanged += (health) => _health.text = _healthTitle + health.ToString();
        _player.EnergyHasChanged += (enerhy) => _energy.text = _energyTitle + enerhy.ToString();
    }
}