using WarConflict.UNITS.Interfaces;

namespace WarConflict.WEAPONS;

public abstract class Weapon
{
    public string? Name; //не используется но можно применять при выводе сообщений, для информации.

    protected int Damage;
 
    public abstract void Shoot(IHittable target, Team team);

}