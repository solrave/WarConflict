using WarConflict.Weapons;

namespace WarConflict.Soldiers;
using static System.Console;
public interface ISoldier
{
   
    public IWeapon Weapon { get; }
    
    public string FractionName { get; set; }
    
    public string Rank { get; }
   
    public bool IsAlive { get; set; }

    public void Attack(Team team);

    public void TakeDamage(int damage);

}