using WarConflict.Soldiers;

namespace WarConflict.WEAPONS.Interfaces;

public interface IWeapon
{
    public string Name { get; set; }
    
    public int Damage { get; set; }

    public event Action<int> InflictDamage;
 
    public void Shoot(Soldier target, Team team);

}