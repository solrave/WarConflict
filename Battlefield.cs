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
            ISoldier blueSoldier = _blueTeam.Squad[Helper.PickRandomSoldier(_blueTeam)];
            ISoldier redSoldier = _redTeam.Squad[Helper.PickRandomSoldier(_redTeam)];
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
            //Helper.ClearConsole();
            WriteLine("Ничья.");
            Thread.Sleep(1000);
        }

        if ( _blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            //Helper.ClearConsole();
            WriteLine("Синяя команда победила!");
            Thread.Sleep(1000);
        }
        
        if ( !_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            //Helper.ClearConsole();
            WriteLine("Красная команда победила!");
            Thread.Sleep(1000);
        }
    }

    private void ShowMessage(ISoldier target, ISoldier attacker)
    {
        WriteLine($"{attacker.FractionName}'s {attacker.Rank} ATTACKS {target.FractionName}'s {target.Rank}.");
        WriteLine($"{target.FractionName}'s {target.Rank} GETS {attacker.Damage} damage. HP = {target.CurrentHealth}");
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