using WarConflict.Soldiers;
using static System.Console;
using System.Threading;
using WarConflict.UNITS.Interfaces;

namespace WarConflict;

public class Battlefield
{
    private Team _blueTeam;
    private Team _redTeam;

    public Battlefield(Team blueTeam, Team redTeam)
    {
        _blueTeam = blueTeam;
        _redTeam = redTeam;
        SubscribeUnitsToEvents();
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
            WriteLine($"{_blueTeam.Name} team WINS!");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
        
        if ( !_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            WriteLine($"{_redTeam.Name} team WINS!");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
    }

    private void SubscribeUnitsToEvents()
    {
        foreach (var unit in _blueTeam.Squad)
        {
            unit.OnAction += ShowMessage;
            if (unit is IAttacker attacker)
            {
                attacker.Weapon.InflictDamage += unit.TakeDamage;
            }
        }
        
        foreach (var unit in _redTeam.Squad)
        {
            unit.OnAction += ShowMessage;
            if (unit is IAttacker attacker)
            {
                attacker.Weapon.InflictDamage += unit.TakeDamage;
            }
        }
    }

    private void ShowMessage(EventArgs args)
    {
        WriteLine();
        //Thread.Sleep(500);
    }

}