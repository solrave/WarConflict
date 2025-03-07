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
            if (!_redTeam.IsAlive) break;
            TriggerAction(_redTeam, _blueTeam);
            _blueTeam.RemoveDeadUnits();
            if (!_blueTeam.IsAlive) break;
        }
        FinishFight();
    }

    private void TriggerAction(Team friendlyTeam, Team enemyTeam)
    {
        var actionUnit = Helper.GetRandomSoldierForAction(friendlyTeam);
        actionUnit.MakeAction(friendlyTeam, enemyTeam);
    }
    
    private void FinishFight()
    {
        switch (_blueTeam.IsAlive)
        {
            case false when !_redTeam.IsAlive:
                _logger.Log("DRAW!Everybody is dead.");
                Helper.DelayAndExit();
                break;
            case true when !_redTeam.IsAlive:
                _logger.Log($"{_blueTeam.TeamName} team WINS!");
                Helper.DelayAndExit();
                break;
            case false when _redTeam.IsAlive:
                _logger.Log($"{_redTeam.TeamName} team WINS!");
                Helper.DelayAndExit();
                break;
        }
    }
}