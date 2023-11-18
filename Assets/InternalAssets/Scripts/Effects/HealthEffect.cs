public class HealthEffect : Effect
{
    private const int _bonusHealth = 30;

    public override void Apply(Player player)
    {
        player.AddHealth(_bonusHealth);
    }

    public override void Revert(Player player)
    {
        player.AddHealth(-_bonusHealth);
    }
}