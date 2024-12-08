using System.Reflection.Metadata;

namespace WarConflict.Soldiers;
using static Console;
using System.Threading;
public class Marine : ISoldier
{
    public string FractionName { get; set; }
    public string Rank { get; }
    public  int MaxHealth { get; }
    public int CurrentHealth { get;  set; }
    public int Damage { get; } 
    public bool IsAlive { get; set; } 

    public Marine(MarineStats stats)
    {
        Rank = stats.Rank;
        MaxHealth = stats.MaxHealth;
        CurrentHealth = MaxHealth;
        Damage = stats.Damage;
        IsAlive = true;
    }

    public void Attack(ISoldier soldier)
    {
        int hpLeft = soldier.CurrentHealth -= Damage;
        if (hpLeft < 0) soldier.CurrentHealth = 0;
        else soldier.CurrentHealth -= Damage;
    }
    
}