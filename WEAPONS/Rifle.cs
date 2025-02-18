using WarConflict.Soldiers;
using WarConflict.WEAPONS.Interfaces;

namespace WarConflict.Weapons;

public class Rifle : IWeapon
{
    public string Name { get; set; } = "Rifle";

    public int Damage { get; set; } = 5;
    public event Action<int>? InflictDamage;

    public void Shoot(Soldier target, Team team)
    {
       InflictDamage?.Invoke(Damage);
    }
   
}