using WarConflict.UNITS;
using static System.Console;

namespace WarConflict;

public class Team
{
    private readonly List<Soldier> _squad;

    public IReadOnlyList<Soldier> Squad => _squad;
    
    public string? TeamName { get; private set; }
    
    public bool IsAlive { get; private set; }
    
    public Team(string teamName, List<Soldier> squad)
    {
        TeamName = teamName;
        _squad = squad;
        IsAlive = true;
    }

    public void RemoveDeadUnits()
    {
        foreach (var unit in Squad)
        {
            if (unit.IsAlive != true)
            {
                _squad.Remove(unit);
            }
        }
    }
    
    public void CheckIfTeamAlive()
    {
        if (_squad.Count == 0)
        {
            IsAlive = false;
        }
    }
    
}