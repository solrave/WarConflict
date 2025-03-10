using WarConflict.UNITS.Interfaces;

namespace WarConflict.WEAPONS;

public abstract class Weapon
{
    protected int Damage;
    public string? Name; //не используется но можно применять при выводе сообщений, для информации.

    public abstract void Shoot(IHittable target, Team team);
}