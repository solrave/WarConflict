using WarConflict.Soldiers;

namespace WarConflict.Weapons;

public class Shotgun : IWeapon
{
    public string Name { get; } = "Shotgun";
    public int Damage { get; } = 2;
    public void Shoot(ISoldier soldier)
    {
        int hpLeft = soldier.CurrentHealth - Damage;
        if (hpLeft < 0) soldier.CurrentHealth = 0;
        else soldier.CurrentHealth -= Damage;
    }
}