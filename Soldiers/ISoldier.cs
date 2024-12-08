namespace WarConflict.Soldiers;
using static System.Console;
public interface ISoldier
{
    public string FractionName { get; set; }
    public string Rank { get; }
   
    public bool IsAlive { get; set; }
    
    public int CurrentHealth { get; set; }
    
    public int Damage { get; }

    public void Attack(ISoldier soldier);
    
}