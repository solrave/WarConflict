using WarConflict.Weapons;
using WarConflict.WEAPONS;

namespace WarConflict.UNITS.Interfaces;

public interface IAttacker
{
    public Weapon Weapon { get; }
    
    public event Action<IHittable, IHittable>? OnAttack;
    
    public void Attack(Team team);
    
}