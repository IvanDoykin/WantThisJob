using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int _defaultHealth = 100;
    private const int _defaultEnergy = 5;

    public delegate void OnHealthChange(int health);
    public event OnHealthChange HealthHasChanged;

    public delegate void OnEnergyChange(int energy);
    public event OnEnergyChange EnergyHasChanged;

    private int _health = _defaultHealth;
    private int _energy = _defaultEnergy;

    private void Start()
    {
        HealthHasChanged?.Invoke(_health);
        EnergyHasChanged?.Invoke(_energy);
    }

    public void AddHealth(int health)
    {
        _health += health;
        HealthHasChanged?.Invoke(_health);
    }

    public void AddEnergy(int energy)
    {
        _energy += energy;
        EnergyHasChanged?.Invoke(_energy);
    }
}
