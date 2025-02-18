using WarConflict.Weapons;

namespace WarConflict.Soldiers;

public interface IAttacker
{
    public IWeapon Weapon { get; }
    public void Attack(Team team);
}