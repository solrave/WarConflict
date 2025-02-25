using WarConflict.UNITS.Interfaces;

namespace WarConflict.WEAPONS;

public abstract class Weapon
{
    public string Name { get; init; }
    
    public int Damage { get; init; }

    public abstract event Action<int>? InflictDamage;
 
    public abstract void Shoot(IHittable target, Team team);

}