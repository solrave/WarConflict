using WarConflict.UNITS.Interfaces;


namespace WarConflict;

public class BattleController
{
    private readonly BattleLogger _logger;
    private readonly Team _blueTeam;
    private readonly Team _redTeam;

    public BattleController(Team blueTeam, Team redTeam, BattleLogger logger)
    {
        _blueTeam = blueTeam;
        _redTeam = redTeam;
        _logger = logger;
    }

    public void StartFight()
    {
        while (_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            TriggerAction(_blueTeam, _redTeam);
            _redTeam.RemoveDeadUnits();
            _redTeam.CheckIfTeamAlive();
            TriggerAction(_redTeam, _blueTeam);
            _blueTeam.RemoveDeadUnits();
            _blueTeam.CheckIfTeamAlive();
        }
        FinishFight();
    }

    private void TriggerAction(Team actionTeam, Team targetTeam)
    {
        var actionUnit = Helper.GetRandomSoldierForAction(actionTeam);
        if (actionUnit is IHealer healer)
        {
            healer.Heal(actionTeam);
        }
        else
        {
            actionUnit.MakeAction(targetTeam);
        }
    }
    
    private void FinishFight()
    {
        if (!_blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            _logger.Log("DRAW!Everybody is dead.");
            Thread.Sleep(500);
            Environment.Exit(0);
        }

        if ( _blueTeam.IsAlive && !_redTeam.IsAlive)
        {
            _logger.Log($"{_blueTeam.TeamName} team WINS!");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
        
        if ( !_blueTeam.IsAlive && _redTeam.IsAlive)
        {
            _logger.Log($"{_redTeam.TeamName} team WINS!");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
    }

}