using static System.Console;
using System.Threading;
using WarConflict.UNITS.Interfaces;

namespace WarConflict;

public class BattleField
{
    private readonly Team _blueTeam;
    private readonly Team _redTeam;

    public BattleField(Team blueTeam, Team redTeam)
    {
        _blueTeam = blueTeam;
        _redTeam = redTeam;
        //SubscribeUnitsToEvents();
    }

    public void StartFight()
    {
        while (_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            //_blueTeam.PickRandomSoldier().FightAction(_blueTeam, _redTeam);
            CheckResult();
           //_redTeam.PickRandomSoldier().FightAction(_redTeam, _blueTeam);
            CheckResult();
        }

    }

    private void CheckResult()
    {
        if (!_blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            WriteLine("DRAW!Everybody is dead.");
            Thread.Sleep(500);
            Environment.Exit(0);
        }

        if ( _blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            WriteLine($"{_blueTeam.TeamName} team WINS!");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
        
        if ( !_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            WriteLine($"{_redTeam.TeamName} team WINS!");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
    }

    private void SubscribeUnitsToEvents(Team team, Team enemyTeam)
    {
        foreach (var unit in team.Squad)
        {
            unit.OnAction += ShowMessage;
            foreach (var redUnit in _redTeam.Squad)
            {
                if (redUnit is IAttacker attacker)
                {
                    attacker.Weapon.InflictDamage += unit.TakeHit;
                }
            }
        }
        
        foreach (var unit in _redTeam.Squad)
        {
            unit.OnAction += ShowMessage;
            if (unit is IAttacker attacker)
            {
                attacker.Weapon.InflictDamage += unit.TakeHit;
            }
        }
    }

    private void ShowMessage(EventArgs args)
    {
        WriteLine();
        //Thread.Sleep(500);
    }

}