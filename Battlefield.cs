using WarConflict.Soldiers;
using static System.Console;
using System.Threading;

namespace WarConflict;

public class Battlefield
{
    private Team _blueTeam;
    private Team _redTeam;

    public Battlefield(Team blueTeam, Team redTeam)
    {
        _blueTeam = blueTeam;
        _redTeam = redTeam;
    }

    public void StartFight()
    {
        while (_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            int blueIndex = Helper.PickRandomSoldier(_blueTeam);
            int redIndex = Helper.PickRandomSoldier(_redTeam);
            ISoldier blueSoldier = _blueTeam.Squad[blueIndex];
            ISoldier redSoldier = _redTeam.Squad[redIndex];
            blueSoldier.Attack(redSoldier);
            ShowMessage(redSoldier,blueSoldier);
            CheckIfAlive(redSoldier);
            _redTeam.CheckIfSoldierDead(redSoldier);
            redSoldier.Attack(blueSoldier);
            ShowMessage(blueSoldier,redSoldier);
            CheckIfAlive(blueSoldier);
            _blueTeam.CheckIfSoldierDead(blueSoldier);
        }

        if (!_blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            WriteLine("DRAW!Everybody is dead.");
            Thread.Sleep(500);
        }

        if ( _blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            WriteLine($"{_blueTeam.Name} team WINS!");
            Thread.Sleep(500);
        }
        
        if ( !_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            WriteLine($"{_redTeam.Name} team WINS!");
            Thread.Sleep(500);
        }
    }

    private void ShowMessage(ISoldier target, ISoldier attacker)
    {
        WriteLine($"{attacker.FractionName}'s {attacker.Rank} ATTACKS {target.FractionName}'s {target.Rank} with {attacker.Weapon.Name}.");
        WriteLine($"{target.FractionName}'s {target.Rank} GETS {attacker.Weapon.Damage} damage. HP = {target.CurrentHealth}");
        Thread.Sleep(1000);
    }
    
    private void CheckIfAlive(ISoldier soldier)
    {
        if (soldier.CurrentHealth == 0)
        {
            soldier.IsAlive = false;
            WriteLine($"{soldier.FractionName}'s {soldier.Rank} is DEAD!");
        }
       
    }
}