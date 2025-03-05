using WarConflict.UNITS;
using WarConflict.UNITS.Interfaces;
using WarConflict.WEAPONS;

namespace WarConflict.Weapons;

public class Rifle : Weapon
{
    public Rifle()
    {
        Name = "Rifle";
        Damage = 6;
    }

    public override void Shoot(IHittable target, Team team)
    {
       target.TakeHit(Damage);
    }
   
}