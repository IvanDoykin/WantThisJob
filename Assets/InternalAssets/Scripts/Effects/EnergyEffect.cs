public class EnergyEffect : Effect
{
    private const int _bonusEnergy = 2;

    public override void Apply(Player player)
    {
        player.AddEnergy(_bonusEnergy);
    }

    public override void Revert(Player player)
    {
        player.AddEnergy(-_bonusEnergy);
    }
}