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

    private void SubscribeUnitsToEvents()
    {
        foreach (var unit in _blueTeam.Squad)
        {
            unit.Weapon.AttackInfo += AttackMessage;
            unit.Weapon.DamageMessage += DamageMessage;
            unit.Weapon.RemoveDead += _blueTeam.RemoveDead;
        }
        
        foreach (var unit in _redTeam.Squad)
        {
            unit.Weapon.AttackInfo += AttackMessage;
            unit.Weapon.DamageMessage += DamageMessage;
            unit.Weapon.RemoveDead += _redTeam.RemoveDead;
        }
    }

    private void AttackMessage(ISoldier attacker,ISoldier target)
    {
        WriteLine($"{attacker.FractionName}'s {attacker.Rank} ATTACKS" +
                  $" {target.FractionName}'s {target.Rank} with {attacker.Weapon.Name}.");
        if (attacker.Weapon.Damage > attacker.Weapon.WeaponDamage)
        {
            WriteLine($"{attacker.FractionName}'s {attacker.Rank} inflicts additional {attacker.Weapon.CritDamage} !");
        }
       // Thread.Sleep(1000);
    }

    private void DamageMessage(ISoldier target, int damage)
    {
        WriteLine(!target.IsAlive
            ? $"{target.FractionName}'s {target.Rank} is DEAD!"
            : $"{target.FractionName}'s {target.Rank} gets {damage} damage.");
    }

}