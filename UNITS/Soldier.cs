using WarConflict.Weapons;

namespace WarConflict.Soldiers;
using static System.Console;
public abstract class Soldier
{
    public string FractionName { get; set; }
    
    public string Rank { get; }
    
    public int Number { get; set; }
    
    public bool IsAlive { get; }
    
    public event Action<EventArgs> OnAction;

    public abstract void Action();

    public abstract void TakeDamage(Func<int> damage);

}