using WarConflict.Weapons;
using WarConflict.WEAPONS.Interfaces;

namespace WarConflict.UNITS.Interfaces;

public interface IAttacker
{
    public IWeapon Weapon { get; }
    
    public event Action<EventArgs>? OnAttack;
    
    public void Attack(Team team);
    
}