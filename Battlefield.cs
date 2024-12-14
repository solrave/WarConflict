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
        SubscribeUnitsToEvents();
    }

    public void StartFight()
    {
        while (_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            _blueTeam.PickRandomSoldier().Attack(_redTeam);
            CheckResult();
            _redTeam.PickRandomSoldier().Attack(_blueTeam);
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
            unit.Weapon.AttackInfo += ShowMessage;
            unit.Weapon.DamageMessage += DamageMessage;
            unit.Weapon.RemoveDead += _redTeam.RemoveDead;
        }
        
        foreach (var unit in _redTeam.Squad)
        {
            unit.Weapon.AttackInfo += ShowMessage;
            unit.Weapon.DamageMessage += DamageMessage;
            unit.Weapon.RemoveDead += _blueTeam.RemoveDead;
        }
    }

    private void ShowMessage(MessageHandler eventMessage)
    {
        WriteLine(eventMessage.Message);
        //Thread.Sleep(500);
    }

    private void DamageMessage(ISoldier target, int damage)
    {
        WriteLine(!target.IsAlive
            ? $"{target.FractionName}'s {target.Rank} is DEAD!"
            : $"{target.FractionName}'s {target.Rank} gets {damage} damage.");
        //Thread.Sleep(500);
    }

}