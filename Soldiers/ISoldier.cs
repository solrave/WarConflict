using WarConflict.Weapons;

namespace WarConflict.Soldiers;
using static System.Console;
public interface ISoldier
{
    public event Action<MessageHandler> AttackInfo;

    public int Number { get; set; }
    
    public string FractionName { get; set; }
    
    public string Rank { get; }
   
    public bool IsAlive { get; }

    public void FightAction(Team team, Team enemyTeam);

    public void TakeDamage(Func<int> damage);

}