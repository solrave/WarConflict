using WarConflict.Weapons;

namespace WarConflict.Soldiers;
using static System.Console;
public interface ISoldier
{
    public event Action<MessageHandler> AttackInfo;
   
    public IWeapon Weapon { get; }

    public int Number { get; set; }
    
    public string FractionName { get; set; }
    
    public string Rank { get; }
   
    public bool IsAlive { get; set; }

    public void Attack(Team team);

    public void TakeDamage(int damage);

}