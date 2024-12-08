namespace WarConflict.Weapons;
using Soldiers;

public class Rifle : IWeapon
{
    private Random _randomizer = new();
    public string Name { get; } = "Rifle";
    public int Damage { get; private set; } = 1;

    private int critDamage = 0;

    public void Shoot(ISoldier soldier)
    {
        Damage = ApplyCriticalDamage();
        int hpLeft = soldier.CurrentHealth - Damage;
        if (hpLeft < 0) soldier.CurrentHealth = 0;
        else soldier.CurrentHealth -= Damage;
    }

    private int ApplyCriticalDamage()
    {
        int critChance = _randomizer.Next(0, Damage);
        if (critChance % 2 == 0)
        {
            return Damage + 2;
        }
        return Damage;
    }
}