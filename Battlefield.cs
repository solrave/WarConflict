using WarConflict.Soldiers;
using static System.Console;

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
            Soldier blueSoldier = _blueTeam.Squad[Helper.PickRandomSoldier(_blueTeam)];
            Soldier redSoldier = _redTeam.Squad[Helper.PickRandomSoldier(_redTeam)];
            blueSoldier.Attack(redSoldier);
            redSoldier.TakeDamage(blueSoldier.Damage);
            redSoldier.Attack(blueSoldier);
            blueSoldier.TakeDamage(redSoldier.Damage);
            _blueTeam.CheckForDeadSoldiers();
            _redTeam.CheckForDeadSoldiers();
        }

        if (!_blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            Helper.ClearConsole();
            Write("Ничья.");
        }

        if ( _blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            Helper.ClearConsole();
            WriteLine("Синяя команда победила!");
        }
        
        if ( !_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            Helper.ClearConsole();
            WriteLine("Красная команда победила!");
        }
    }

}