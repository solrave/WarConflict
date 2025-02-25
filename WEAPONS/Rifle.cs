using WarConflict.UNITS;
using WarConflict.UNITS.Interfaces;
using WarConflict.WEAPONS;

namespace WarConflict.Weapons;

public class Rifle : Weapon
{
    public override event Action<int>? InflictDamage;
    
    public Rifle()
    {
        Name = "Rifle";
        Damage = 5;
    }

    public override void Shoot(IHittable target, Team team)
    {
       InflictDamage?.Invoke(Damage);
       target.TakeHit(Damage);
    }
   
}